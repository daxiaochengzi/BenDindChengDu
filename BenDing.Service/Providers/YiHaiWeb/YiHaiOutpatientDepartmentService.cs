using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.JsonEntity;
using BenDing.Domain.Models.Dto.Resident;
using BenDing.Domain.Models.Dto.Web;
using BenDing.Domain.Models.Dto.YiHai.Base;
using BenDing.Domain.Models.Dto.YiHai.Web;
using BenDing.Domain.Models.Dto.YiHai.XmlDto;
using BenDing.Domain.Models.Params.Base;
using BenDing.Domain.Models.Params.Resident;
using BenDing.Domain.Models.Params.UI;
using BenDing.Domain.Models.Params.Web;
using BenDing.Domain.Models.Params.YinHai.Ui;
using BenDing.Domain.Models.Params.YinHai.Web;
using BenDing.Domain.Xml;
using BenDing.Repository.Interfaces.Web;
using BenDing.Repository.Interfaces.YiHaiWeb;
using BenDing.Repository.Providers.YiHaiWeb;
using BenDing.Service.Interfaces;
using BenDing.Service.Interfaces.YiHaiWeb;
using Newtonsoft.Json;
using NFine.Application.BenDingManage;
using NFine.Domain._03_Entity.BenDingManage;

namespace BenDing.Service.Providers.YiHaiWeb
{
   public class YiHaiOutpatientDepartmentService: IYiHaiOutpatientDepartmentService
    {
        private MedicalInsuranceSignInBase medicalInsuranceSignInService = new MedicalInsuranceSignInBase();
        private readonly IYiHaiSqlRepository _yiHaiSqlRepository;
        private readonly IWebServiceBasicService _webServiceBasicService;
        private readonly ISystemManageRepository _systemManageRepository;
        private readonly IWebBasicRepository _webServiceBasic;
        private readonly IMedicalInsuranceSqlRepository _medicalInsuranceSqlRepository;
        public YiHaiOutpatientDepartmentService(
            IWebServiceBasicService iWebServiceBasicService,
            IYiHaiSqlRepository iHaiSqlRepository,
            ISystemManageRepository iSystemManageRepository,
            IWebBasicRepository iWebBasicRepository,
            IMedicalInsuranceSqlRepository insuranceSqlRepository
            )
        {
            _webServiceBasicService = iWebServiceBasicService;
            _yiHaiSqlRepository = iHaiSqlRepository;
            _systemManageRepository = iSystemManageRepository;
            _webServiceBasic = iWebBasicRepository;
            _medicalInsuranceSqlRepository = insuranceSqlRepository;
        }

        public void MedicalInsuranceSignIn(MedicalInsuranceSignInUiParam param)
        {
            var userBase = _webServiceBasicService.GetUserBaseInfo(param.UserId);
            var resultDto = JsonConvert.DeserializeObject<DealModelDto>(param.ResultJson);
            var outputData= XmlHelp.DeSerializer<MedicalInsuranceSignInXmlDto>(resultDto.TransactionOutputXml);
            if (outputData != null && outputData.Row.Any())
            {
                    var outputDefault = outputData.Row.FirstOrDefault();
                    if (outputDefault != null)
                    {
                        var insertEntity = new MedicalInsuranceSignInEntity()
                        {
                            BatchNo = outputDefault.BatchNo,
                            MedicalInsuranceOrganization = outputDefault.MedicalInsuranceOrganization,
                            SignInState = outputDefault.SignInState,
                            SignInTime =Convert.ToDateTime(outputDefault.SignInTime)  
                        };
                        medicalInsuranceSignInService.Insert(insertEntity, userBase);
                    }
            }
        }
        /// <summary>
        /// 获取签到入参
        /// </summary>
        /// <param name="param"></param>
        public GetYiHaiBaseParm GetMedicalInsuranceSignInParam(UiInIParam param)
        {
            var  resultData=new GetYiHaiBaseParm();
            var userBase = _webServiceBasicService.GetUserBaseInfo(param.UserId);
            var medicalInsuranceSignList= _yiHaiSqlRepository.QueryMedicalInsuranceSignIn(new QueryMedicalInsuranceSignInParam()
            {
                SignInState = 1,
                User = userBase
            });
            //如果签到不存在自动签到
            if (medicalInsuranceSignList.Count == 0)
            {
                var hospitalOrganization =
                    _systemManageRepository.QueryHospitalOrganizationGrade(userBase.OrganizationCode);
                resultData.TransactionControlXml = XmlSerializeHelper.YinHaiXmlSerialize(new SignInControlXmlDto()
                {
                    OperationName = userBase.UserName
                });
                resultData.TransactionInputXml = XmlSerializeHelper.YinHaiXmlSerialize(new SignInControlXmlDto()
                {
                    OperationName = hospitalOrganization.AdministrativeArea
                });
            }

          return  resultData;
           
        }
        /// <summary>
        /// 获取门诊结算入参
        /// </summary>
        /// <param name="param"></param>
        public GetYiHaiBaseParm GetOutpatientDepartmentParam(GetOutpatientDepartmentUiParam param)
        {
            var resultData = new GetYiHaiBaseParm();
           
            var userBase = _webServiceBasicService.GetUserBaseInfo(param.UserId);
            var xmlData = new MedicalInsuranceXmlDto();
            xmlData.BusinessId = param.BusinessId;
            xmlData.HealthInsuranceNo = "48";//42MZ
            xmlData.TransactionId = param.TransKey;
            xmlData.AuthCode = userBase.AuthCode;
            xmlData.UserId = userBase.UserId;
            xmlData.OrganizationCode = userBase.OrganizationCode;
            var jsonParam = JsonConvert.SerializeObject(xmlData);
            var data = _webServiceBasic.HIS_Interface("39", jsonParam);
            OutpatientPersonJsonDto dataValue = JsonConvert.DeserializeObject<OutpatientPersonJsonDto>(data.Msg);

            //获取初始门诊费用明细
            var iniCostDetail = dataValue.DetailInfo;
            var outpatientBase = dataValue.OutpatientPersonBase;
            //获取未对码的项目
            var unCodeData = iniCostDetail.Where(c => string.IsNullOrEmpty(c.MedicalInsuranceProjectCode) == true)
                .Select(d=> new UnCodeDataDto
                { 名称 = d.DirectoryName,
                  项目编号 = d.DirectoryCode
                }).ToList();
            if (unCodeData.Any())
            {
                string unCodeDataInfo = "医保未对码项目:";
                unCodeDataInfo+= JsonConvert.SerializeObject(unCodeData);
                throw new  Exception(unCodeDataInfo);
            }
            //排除挂号费 
            var costDetail = iniCostDetail;

            if(costDetail.Count==0) throw new Exception("门诊无处方明细不能进行医保报账");
            if (costDetail.Count>=50) throw new Exception("门诊费用明细只能小于50条");
            decimal medicalTreatmentTotalCost = string.IsNullOrEmpty(outpatientBase.MedicalTreatmentTotalCost) == true
                ? Convert.ToDecimal(outpatientBase.MedicalTreatmentTotalCost)
                : 0;
            var controlData = new OutpatientDepartmentControlXmlDto();
            controlData.PaymentCategory = param.PaymentCategory; //【城职普通门诊0201】、【城居普通门诊0203】
            controlData.TotalAmount = medicalTreatmentTotalCost;
            controlData.nums = costDetail.Count;
            controlData.edition = "5.0";
            var dataXml = OutpatientDepartmentDataXml(iniCostDetail, outpatientBase, userBase.OrganizationCode);
            resultData.TransactionControlXml = XmlSerializeHelper.YinHaiXmlSerialize(controlData);
            resultData.TransactionInputXml= XmlSerializeHelper.YinHaiXmlSerialize(dataXml);
            return resultData;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="costDetail"></param>
        /// <param name="outpatientBase"></param>
        /// <param name="organizationCode"></param>
        /// <returns></returns>
        private OutpatientDepartmentDataXmlDto OutpatientDepartmentDataXml(
            List<OutpatientDetailJsonDto> costDetail,
            OutpatientPersonBaseJsonDto outpatientBase,string organizationCode)
        {

          var pairCodeData= _medicalInsuranceSqlRepository.QueryMedicalInsurancePairCode(new QueryMedicalInsurancePairCodeParam()
            {
              DirectoryCodeList = costDetail.Select(c=>c.DirectoryCode).ToList(),
               OrganizationCode = organizationCode
            });
            var resultData = new OutpatientDepartmentDataXmlDto();
            var costDetailData = new List<OutpatientDepartmentDataXmlRowDto>();
            var ordersDetailData = new List<OutpatientDepartmentDataXmlDetailDto>();
            foreach (var item in costDetail)
            {
                var hospitalCodeNo = pairCodeData.Where(c => c.DirectoryCode == item.DirectoryCode)
                    .Select(d => d.FixedEncodingId).FirstOrDefault();
                var costDetailItem = new OutpatientDepartmentDataXmlRowDto()
                {
                    DetailId = CommonHelp.GuidToStr(item.DetailId),
                    ProjectCode=item.MedicalInsuranceProjectCode,
                    DirectoryName=item.DirectoryName,
                    Quantity= item.Quantity,
                    UnitPrice= item.UnitPrice,
                    Amount=item.Amount,
                    ApprovalMark=item.ApprovalMark,
                    BillDepartmentId=item.BillDepartmentId,
                    BillDepartment= item.BillDepartment,
                    BillDoctorName= item.BillDoctorName,
                    OperateDepartmentId= item.OperateDepartmentId,
                    OperateDepartmentName= item.OperateDepartmentName,
                    OperateDoctorName= item.DirectoryName,
                    Operators= item.Operators,
                    DetailInputTime=Convert.ToDateTime(item.BillTime).ToString("yyyy-MM-dd HH:mm:ss"),
                    DetailTime= Convert.ToDateTime(item.BillTime).ToString("yyyy-MM-dd HH:mm:ss"),
                    OperationNo=null,
                    OrdersSortNo= outpatientBase.InvoiceNo,
                    Remark=null,
                    UserMethod="01",
                    PrescriptionNo= outpatientBase.InvoiceNo,
                    InputPrice= item.UnitPrice,
                    ExternalInspectSign="0",
                    ExternalInspectHospitalNo=null,
                    DoctorCode=null,
                    EquipmentCode=null,
                    HospitalPairingCode= hospitalCodeNo,
                    DirectoryCode = CommonHelp.GuidToStr(item.DirectoryCode)

                };
                costDetailData.Add(costDetailItem); 
            }

            foreach (var items in costDetail)
            {
                var hospitalCodeNo = pairCodeData.Where(c => c.DirectoryCode == items.DirectoryCode)
                    .Select(d => d.FixedEncodingId).FirstOrDefault();
                   var ordersDetailItem = new OutpatientDepartmentDataXmlDetailDto()
                {
                    OrdersSortNo= outpatientBase.InvoiceNo,
                    OrdersContent= items.DirectoryName,
                    DoctorName= items.BillDoctorName,
                    DoctorCode= items.BillDoctorId,
                    OrdersDepartmentCode= items.BillDepartmentId,
                    OrdersDepartmentName= items.BillDepartment,
                    HospitalCodeNo= hospitalCodeNo,
                    OrdersType =null,
                    OrdersClassify=null,
                    DoseUnit=items.HospitalPricingUnit,
                    Dose=1,
                    UserRoad=null,
                    EveryTimeDosage=Convert.ToInt32(items.Dosage),
                    EveryTimeDosageUnit= items.HospitalPricingUnit,
                    Dosage=null,
                    DosageUnit= items.HospitalPricingUnit,
                    Frequency=1,
                    UseDays=1


                };
                ordersDetailData.Add(ordersDetailItem);
            }

            resultData.CostDetail = costDetailData;
            resultData.OrdersDetail = ordersDetailData;

            return resultData;
        }
    }
}
