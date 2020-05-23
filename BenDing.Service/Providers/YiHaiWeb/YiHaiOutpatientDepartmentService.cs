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
using BenDing.Domain.Models.Dto.YiHai.XmlDto.OutpatientDepartment;
using BenDing.Domain.Models.Enums;
using BenDing.Domain.Models.Params.Base;
using BenDing.Domain.Models.Params.Resident;
using BenDing.Domain.Models.Params.SystemManage;
using BenDing.Domain.Models.Params.UI;
using BenDing.Domain.Models.Params.Web;
using BenDing.Domain.Models.Params.YinHai.OutpatientDepartment;
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
using NFine.Application.SystemManage;
using NFine.Domain._03_Entity.BenDingManage;

namespace BenDing.Service.Providers.YiHaiWeb
{
    public class YiHaiOutpatientDepartmentService : IYiHaiOutpatientDepartmentService
    {

        private UserApp userService = new UserApp();
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
        #region comm
        /// <summary>
        /// 获取签到入参
        /// </summary>
        /// <param name="param"></param>
        public GetYiHaiBaseParm GetMedicalInsuranceSignInParam(UiInIParam param)
        {
            var resultData = new GetYiHaiBaseParm();
            var userBase = _webServiceBasicService.GetUserBaseInfo(param.UserId);
            var medicalInsuranceSignList = _yiHaiSqlRepository.QueryMedicalInsuranceSignIn(new QueryMedicalInsuranceSignInParam()
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
                    OperationName = hospitalOrganization.MedicalInsuranceHandleNo
                });
            }

            return resultData;

        }
        /// <summary>
        /// 签到
        /// </summary>
        /// <param name="param"></param>
        public void MedicalInsuranceSignIn(MedicalInsuranceSignInUiParam param)
        {
            var userBase = _webServiceBasicService.GetUserBaseInfo(param.UserId);
            var resultDto = JsonConvert.DeserializeObject<DealModelDto>(param.ResultJson);
            var outputData = XmlHelp.DeSerializer<MedicalInsuranceSignInXmlDto>(resultDto.TransactionOutputXml);
            if (outputData != null && outputData.Row.Any())
            {
                var entityId = Guid.NewGuid();
                var outputDefault = outputData.Row.FirstOrDefault();
                if (outputDefault != null)
                {
                    var insertEntity = new MedicalInsuranceSignInEntity()
                    {
                        BatchNo = outputDefault.BatchNo,
                        MedicalInsuranceOrganization = outputDefault.MedicalInsuranceOrganization,
                        SignInState = outputDefault.SignInState,
                        SignInTime = Convert.ToDateTime(outputDefault.SignInTime),
                        OrganizationCode = userBase.OrganizationCode,
                        OrganizationName = userBase.OrganizationName,
                        TransactionFrequency = 0,
                        MedicalInsurancePayTotalAmount = 0,
                        CreateUserName = userBase.UserName,
                        Id = entityId

                    };
                    medicalInsuranceSignInService.Insert(insertEntity, userBase);
                }

                _systemManageRepository.AddHospitalLog(new AddHospitalLogParam()
                {
                    User = userBase,
                    Remark = "签到",
                    JoinOrOldJson = param.ResultJson,
                    RelationId = entityId
                });
            }
        }
       
        /// <summary>
        /// 获取取消签到参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public GetYiHaiBaseParm GetCancelMedicalInsuranceSignInParam(CancelMedicalInsuranceSignInParam param)
        {
            var resultData = new GetYiHaiBaseParm();
            var userBase = _webServiceBasicService.GetUserBaseInfo(param.UserId);
            var signData = medicalInsuranceSignInService.GetForm(Guid.Parse(param.KeyWord));
            if (signData.SignInState == 0) throw new Exception("当前签到已取消");
            resultData.TransactionControlXml = XmlSerializeHelper.YinHaiXmlSerialize(new CancelMedicalInsuranceSignInControlXmlDto()
            {
                BatchNo = signData.BatchNo,
                MedicalInsuranceOrganization = signData.MedicalInsuranceOrganization
            });

            resultData.TransactionInputXml = XmlSerializeHelper.YinHaiXmlSerialize(new CancelMedicalInsuranceSignInDataXmlDto()
            {
                TransactionFrequency = signData.TransactionFrequency,
                MedicalInsurancePayTotalAmount = signData.MedicalInsurancePayTotalAmount
            });

            return resultData;
        }
        /// <summary>
        /// 取消签到
        /// </summary>
        /// <param name="param"></param>
        public void CancelMedicalInsuranceSignIn(CancelMedicalInsuranceSignInParam param)
        {
            var userBase = _webServiceBasicService.GetUserBaseInfo(param.UserId);
            var signInEntity = medicalInsuranceSignInService.GetForm(Guid.Parse(param.KeyWord));
            signInEntity.UpdateUserName = userBase.UserName;
            signInEntity.SignInState = 0;
            medicalInsuranceSignInService.Modify(signInEntity, userBase, Guid.Parse(param.KeyWord));
            _systemManageRepository.AddHospitalLog(new AddHospitalLogParam()
            {
                User = userBase,
                Remark = "取消签到",
                RelationId = Guid.Parse(param.KeyWord)
            });
        }


        #endregion
        #region 门诊
        /// <summary>
        /// 获取门诊挂号入参
        /// </summary>
        /// <returns></returns>
        public GetYiHaiBaseParm GetOutpatientRegisterParam(UiBaseDataParam param)
        {
            var resultData = new GetYiHaiBaseParm();
            var baseUser = _webServiceBasicService.GetUserBaseInfo(param.UserId);
            baseUser.TransKey = param.TransKey;

            var outpatientDetailParam = new OutpatientDetailParam()
            {
                User = baseUser,
                BusinessId = param.BusinessId,
            };
            var data = _webServiceBasicService.GetOutpatientDetailPerson(outpatientDetailParam);
            var registerData = data.FirstOrDefault(d => d.DirectoryName.Contains("挂号"));
            if (registerData == null) throw new Exception("当前病人没有挂号费,不能进行医保门诊挂号");

            var controlXmlData = new OutpatientRegisterControlXmlDto()
            {
                TotalAmount = registerData.Amount,
                Nums = 1,
            };
            //获取科室
            var hospitalGeneralCatalogData = _yiHaiSqlRepository.HospitalGeneralCatalog(new HospitalGeneralCatalogYiHaiParam()
            {
                User = baseUser,
                DirectoryType = "0",
                DirectoryCode = registerData.DirectoryCode
            }).FirstOrDefault();
            if (hospitalGeneralCatalogData == null) throw new Exception("当前科室中间库中不存在,请更新中间库科室");
            if (hospitalGeneralCatalogData.MedicalInsuranceCode == null) throw new Exception("科室未医保对码");
            var detailRow = new List<OutpatientRegisterDataXmlRow>();
            detailRow.Add(new OutpatientRegisterDataXmlRow()
            {
                DirectoryName = hospitalGeneralCatalogData.DirectoryName,
                MedicalInsuranceProjectCode = hospitalGeneralCatalogData.MedicalInsuranceCode,
                DocumentNo = CommonHelp.GuidToStr(param.BusinessId),
                HappenTime = Convert.ToDateTime(registerData.BillTime).ToString("yyyy-MM-dd HH:mm:ss"),
                InputTime = Convert.ToDateTime(registerData.BillTime).ToString("yyyy-MM-dd HH:mm:ss"),
                Num = registerData.Amount > 0 ? 1 : 0,
                Price = registerData.Amount > 0 ? registerData.Amount : 1,
                Operator = baseUser.UserName,
                TotalAmount = registerData.Amount

            });
            var xmlData = new OutpatientRegisterDataXmlDto()
            {
                RegisterType = "1",
                MedicalInsuranceDepartmentCode = hospitalGeneralCatalogData.MedicalInsuranceCode,
                OperatorTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                OperatorName = baseUser.UserName,
                BaseDepartmentName = hospitalGeneralCatalogData.DirectoryName,
                BaseDepartmentCode = hospitalGeneralCatalogData.FixedEncoding,
                DetailRow = detailRow

            };
            resultData.TransactionControlXml = XmlSerializeHelper.YinHaiXmlSerialize(controlXmlData);
            resultData.TransactionInputXml = XmlSerializeHelper.YinHaiXmlSerialize(xmlData);
            return resultData;
        }
        /// <summary>
        /// 门诊挂号
        /// </summary>
        /// <param name="param"></param>
        public void OutpatientRegister(OutpatientRegisterUiParam param)
        {
            var baseUser = _webServiceBasicService.GetUserBaseInfo(param.UserId);
            var resultDto = JsonConvert.DeserializeObject<DealModelDto>(param.ResultJson);
            var outputData = XmlHelp.DeSerializer<OutpatientRegisterOutputXmlDto>(resultDto.TransactionOutputXml);
            //中间层数据写入
            var saveData = new MedicalInsuranceDto
            {
                AdmissionInfoJson = param.ResultJson,
                BusinessId = param.BusinessId,
                Id = Guid.NewGuid(),
                IsModify = false,
                InsuranceType = 999,
                MedicalInsuranceState = MedicalInsuranceState.MedicalInsuranceHospitalized,
                MedicalInsuranceHospitalizationNo = outputData.InpatientFixedEncoding,
              
                IdentityMark = outputData.PayType
            };
            //存中间库
            _medicalInsuranceSqlRepository.SaveMedicalInsurance(baseUser, saveData);

            //日志写入
            _systemManageRepository.AddHospitalLog(new AddHospitalLogParam()
            {
                User = baseUser,
                JoinOrOldJson = JsonConvert.SerializeObject(param.ResultJson),
                Remark = "门诊挂号"
            });

        }
        /// <summary>
        /// 获取门诊结算入参
        /// </summary>
        /// <param name="param"></param>
        public GetYiHaiBaseParm GetOutpatientSettlementParam(GetOutpatientDepartmentUiParam param)
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
                .Select(d => new UnCodeDataDto
                {
                    名称 = d.DirectoryName,
                    项目编号 = d.DirectoryCode
                }).ToList();
            if (unCodeData.Any())
            {
                string unCodeDataInfo = "医保未对码项目:";
                unCodeDataInfo += JsonConvert.SerializeObject(unCodeData);
                throw new Exception(unCodeDataInfo);
            }
            //排除挂号费 
            var costDetail = iniCostDetail;

            if (costDetail.Count == 0) throw new Exception("门诊无处方明细不能进行医保报账");
            if (costDetail.Count >= 50) throw new Exception("门诊费用明细只能小于50条");
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
            resultData.TransactionInputXml = XmlSerializeHelper.YinHaiXmlSerialize(dataXml);
            return resultData;
        }

        /// <summary>
        /// 获取门诊明细上传入参
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public GetYiHaiBaseParm GetOutpatientDetailUploadParam(GetOutpatientDepartmentUiParam param)
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
                .Select(d => new UnCodeDataDto
                {
                    名称 = d.DirectoryName,
                    项目编号 = d.DirectoryCode
                }).ToList();
            if (unCodeData.Any())
            {
                string unCodeDataInfo = "医保未对码项目:";
                unCodeDataInfo += JsonConvert.SerializeObject(unCodeData);
                throw new Exception(unCodeDataInfo);
            }
            //获取未对码的诊断
            var unDiagnosisCodeData = dataValue.DiagnosisList.Where(c => c.ProjectCode == null).ToList();
           
            if (unDiagnosisCodeData.Any())
            {
                string unPairCodeInfo = "诊断未对码信息:";
                unPairCodeInfo += JsonConvert.SerializeObject(unCodeData);
                throw new Exception(unPairCodeInfo);
            }
            return resultData;
        }
        /// <summary>
        /// 获取门诊取消结算入参
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public GetYiHaiBaseParm GetCancelOutpatientSettlementParam(GetOutpatientDepartmentUiParam param)
        {
            var resultData = new GetYiHaiBaseParm();

            return resultData;
        }

        /// <summary>
        /// 获取医院信息上传参数
        /// </summary>
        /// <returns></returns>
        public GetYiHaiBaseParm GetHospitalInfoUploadParam(UploadHospitalInfoUiParam param)
        {
            var resultData = new GetYiHaiBaseParm();
             var  userBase = _webServiceBasicService.GetUserBaseInfo(param.UserId);
         
               var hospitalGeneralCatalogList = _yiHaiSqlRepository.HospitalGeneralCatalog(new HospitalGeneralCatalogYiHaiParam()
            {
                User = userBase,
               });
            var dataXml = GetUploadHospitalInfoDataXml(hospitalGeneralCatalogList, userBase);
            var hospitalInfo = _systemManageRepository.QueryHospitalOrganizationGrade(userBase.OrganizationCode);
            var controlXml = new ControlXmlBaseDto()
            {
                MedicalInsuranceHandleNo = hospitalInfo.MedicalInsuranceHandleNo
            };
            resultData.TransactionControlXml = XmlSerializeHelper.YinHaiXmlSerialize(controlXml);
            resultData.TransactionInputXml = XmlSerializeHelper.YinHaiXmlSerialize(dataXml);

            return resultData;
        }
        /// <summary>
        /// 医院信息上传
        /// </summary>
        /// <param name="param"></param>
        public void HospitalInfoUpload(UploadHospitalInfoUiParam param)
        {
            var resultData = new GetYiHaiBaseParm();
           
            var userBase = _webServiceBasicService.GetUserBaseInfo(param.UserId);
            var resultDto = JsonConvert.DeserializeObject<DealModelDto>(param.ResultJson);
            var inputData = XmlHelp.DeSerializer<UploadHospitalInfoDataXmlDto>(resultDto.TransactionInputXml);
            //获取当前医院所有信息
            var hospitalGeneralCatalogList = _yiHaiSqlRepository.HospitalGeneralCatalog(new HospitalGeneralCatalogYiHaiParam()
            {
                User = userBase,
            });

            //项目编码
            var fixedEncodingList=new  List<string>();
            if (inputData.BedDetail.Any())
            {
                //获取科室编号
                var departmentFixedEncodingList = inputData.BedDetail.Select(c => c.DepartmentCode).ToList();
                var badNoList = inputData.BedDetail.Select(c => c.BadNo).ToList();
                //获取病区目录编号
                var inpatientAreaDirectoryCodeList = hospitalGeneralCatalogList.Where(
                        c => departmentFixedEncodingList.Contains(c.FixedEncoding))
                    .Select(d => d.InpatientAreaCode).ToList();
                var badNoFixedEncodingList = hospitalGeneralCatalogList.Where(
                    c => inpatientAreaDirectoryCodeList.Contains(c.Remark)
                         && badNoList.Contains(c.DirectoryName)).
                    Select(a=>a.FixedEncoding)
                    .ToList();
                fixedEncodingList.AddRange(badNoFixedEncodingList);
            }

            if (inputData.DoctorDetail.Any())
            {//获取科室编号
                var doctorFixedEncodingList = inputData.DoctorDetail.Select(c => c.DoctorNo).ToList();
                fixedEncodingList.AddRange(doctorFixedEncodingList);
            }
            if (inputData.DepartmentDetail.Any())
            {//获取科室编号
                var departmentFixedEncodingList = inputData.DepartmentDetail.Select(c => c.DepartmentCode).ToList();
                fixedEncodingList.AddRange(departmentFixedEncodingList);
            }

            _yiHaiSqlRepository.HospitalInfoUploadUpdate(new HospitalInfoUploadUpdateParam()
            {
                User = userBase,
                FixedEncodingList = fixedEncodingList
            });

            _systemManageRepository.AddHospitalLog(new AddHospitalLogParam()
            {
                User = userBase,
                Remark = "住院信息上传",
                JoinOrOldJson = JsonConvert.SerializeObject(fixedEncodingList)
              
            });

        }
        #endregion

        private UploadHospitalInfoDataXmlDto GetUploadHospitalInfoDataXml(List<HospitalGeneralCatalogEntity> param, UserInfoDto user)
        {
            var resultData = new UploadHospitalInfoDataXmlDto();
            //排除已上传数据
            var paramNew = param.Where(c => c.UploadMark == false).ToList();
            //判断是否存在未对码的科室
            var departmentCount = paramNew.Count(c => c.DirectoryType == "0" && c.MedicalInsuranceCode == null);
            if (departmentCount > 0) throw new Exception("当前存在未对码的科室,不能上传医院科室信息!!!");
            //总床位数
            int badCount = param.Count(d => d.DirectoryType == "3");
            //获取科室数据
            var departmentData = paramNew.Where(c => c.DirectoryType == "0").ToList();
            //获取床位数据
            var badData = paramNew.Where(c => c.DirectoryType == "3").ToList();
            //获取医生数据
            var doctorDataIni = paramNew.Where(c => c.DirectoryType == "1").ToList();
            //获取病区数据
            var inpatientAreaData = paramNew.Where(c => c.DirectoryType == "1").ToList();
            //总床位数
            resultData.BedNum.TotalBadNum = badCount;
            //床位xml数据
            var badXmlData = new List<UploadHospitalInfoDataBedXmlDto>();
            foreach (var item in badData)
            {
                var inpatientAreaItemData = inpatientAreaData
                    .FirstOrDefault(c => c.DirectoryCode == item.DirectoryCode);
                if (inpatientAreaItemData == null) throw new Exception("当前床位未分配病区");
                var departmentItemData =
                    departmentData.FirstOrDefault(c => c.InpatientAreaCode == inpatientAreaItemData.DirectoryCode);
                var itemData = new UploadHospitalInfoDataBedXmlDto()
                {
                    BadInpatientAreaName = inpatientAreaItemData.DirectoryName,
                    BadNo = item.DirectoryName,
                    BedPrice = 0,
                    BedType = "3",
                    DepartmentCode = departmentItemData.FixedEncoding,
                    DepartmentInpatientAreaNo = departmentItemData.MedicalInsuranceCode,
                    OperatorName = user.UserName,
                    OperatorTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

                };
                badXmlData.Add(itemData);
            }
            //添加床位明细数据
            if (badXmlData.Any()) resultData.BedDetail = badXmlData;
            var departmentXmlData = new List<UploadHospitalInfoDataDepartmentXmlDto>();
            foreach (var item in departmentData)
            {
                var badCounts = param.Count(c => c.DirectoryType == "3" && c.Remark == item.InpatientAreaCode);
                var itemData = new UploadHospitalInfoDataDepartmentXmlDto()
                {
                    DepartmentInpatientAreaNo = item.MedicalInsuranceCode,
                    DepartmentCode = item.FixedEncoding,
                    DepartmentName = item.DirectoryName,
                    LiablePerson = item.InpatientAreaDutyPerson,
                    BadNum = badCounts

                };
                departmentXmlData.Add(itemData);
            }
            //添加科室明细数据
            if (departmentXmlData.Any()) resultData.DepartmentDetail = departmentXmlData;

            var doctorXmlData = new List<UploadHospitalInfoDataDoctorXmlDto>();
            //获取医院所有医保人员
            var hospitalOperator = _systemManageRepository.QueryHospitalOperatorAllInfo(user.OrganizationCode);

            if (hospitalOperator.Any() == false) throw new Exception("当前医院无可上传医生,请添加医生!!!");

            var userIdList = hospitalOperator.Select(c => c.F_HisUserId).ToList();
            //获取已填医保资料医生
            var doctorData = doctorDataIni.Where(d => userIdList.Contains(d.DirectoryCode)).ToList();
            foreach (var item in doctorData)
            {
                var userInfoData = hospitalOperator.FirstOrDefault(c => c.F_HisUserId == item.DirectoryCode);
                var departmentItemData = departmentData.FirstOrDefault(c => c.DirectoryCode == item.Remark);
                var itemData = new UploadHospitalInfoDataDoctorXmlDto()
                {
                    DepartmentInpatientAreaNo = departmentItemData.MedicalInsuranceCode,
                    DoctorAddress = null,
                    DoctorAge = Convert.ToInt32(userInfoData.F_DoctorJobAge),
                    DoctorDiagnosisStartTime = Convert.ToDateTime(userInfoData.F_DoctorDiagnosisStartTime).ToString("yyyy-MM-dd HH:mm:ss"),
                    DoctorIdCardNo = userInfoData.F_IdCardNo,
                    DoctorJob = userInfoData.F_DoctorJob,
                    DoctorName = item.DirectoryName,
                    DoctorNo = item.FixedEncoding,
                    DoctorPracticeNo = userInfoData.F_DoctorPracticeNo,
                    DoctorQualificationNo = userInfoData.F_DoctorQualificationNo,
                    DoctorTelephone = null,
                    DoctorTitle = userInfoData.F_DoctorTitle,
                    DoctorTreatmentRange = userInfoData.F_DoctorTreatmentRange,
                    DoctorType = userInfoData.F_DoctorType,
                    PrescriptionRight = "1",
                    DoctorSex = userInfoData.F_Gender == true ? "1" : "2"
                };
                doctorXmlData.Add(itemData);

            }
            //添加科室明细数据
            if (doctorXmlData.Any()) resultData.DoctorDetail = doctorXmlData;

            return resultData;
        }
        /// <summary>
        /// 获取门诊明细上传
        /// </summary>
        /// <returns></returns>
        private OutpatientDetailUploadDataXmlDto OutpatientDetailUploadDataXml(
            List<OutpatientDetailJsonDto> costDetail,
            OutpatientPersonJsonDto dataValue,
            string organizationCode
            )
        {
            //获取初始门诊费用明细
            var outpatientBase = dataValue.OutpatientPersonBase;
            //获取医院所有医生
            var operatorAllInfo= _systemManageRepository.QueryHospitalOperatorAllInfo(organizationCode);
            //获取诊断列表
            var diagnosisList = dataValue.DiagnosisList;

        
            var pairCodeData = _medicalInsuranceSqlRepository.QueryMedicalInsurancePairCode(new QueryMedicalInsurancePairCodeParam()
            {
                DirectoryCodeList = costDetail.Select(c => c.DirectoryCode).ToList(),
                OrganizationCode = organizationCode
            });
            var resultData = new OutpatientDetailUploadDataXmlDto();
            var uploadCostDetail = new List<OutpatientDetailUploadDataCostDetailXmlDto>();
            resultData.DetailRow = uploadCostDetail;
            //挂号信息
            resultData.RegisterDetail=new OutpatientDetailUploadDataRegisterDetailXmlDto()
            { //医生编号需从门诊基础信息中获取编码
                OperateDoctorCode =CommonHelp.GuidToStr(operatorAllInfo.Where(c => c.F_RealName == outpatientBase.DiagnosticDoctor)
                    .Select(d => d.F_HisUserId).FirstOrDefault()) ,
                OperateDoctorName = outpatientBase.DiagnosticDoctor
            };
            var mainDiagnosis = diagnosisList.Where(c => c.IsMainDiagnosis == "是")
                .Select(d => d.DiseaseName)
                .FirstOrDefault();
        
              var medicalRecordDetail = new OutpatientDetailUploadDataOutpatientMedicalRecordDetailXmlDto()
            {
                DiagnosisStartTime= outpatientBase.VisitDate ,
                MainDiagnosis = mainDiagnosis
                };
            resultData.MedicalRecordDetail = medicalRecordDetail;
            foreach (var item in costDetail)
            {
                
                //流水号
                string detailFixedEncoding = CommonHelp.GuidToStr(item.DetailId);
                string ordersSortNo = item.CostDocumentType == "3" ? detailFixedEncoding : null;
                //获取医生
                var operatorInfo = operatorAllInfo.FirstOrDefault(c => c.F_HisUserId == item.BillDoctorId);

                var itemDetail = new OutpatientDetailUploadDataCostDetailXmlDto()
                {

                    DetailId = detailFixedEncoding,
                    ProjectCode = item.MedicalInsuranceProjectCode,
                    DirectoryName = item.DirectoryName,
                    Quantity= item.Quantity,
                    UnitPrice = item.UnitPrice,
                    Amount = item.Amount,
                    ApprovalMark= item.ApprovalMark,
                    Operators= outpatientBase.Operator,
                    OrdersSortNo= ordersSortNo,
                    PrescriptionNo= outpatientBase.InvoiceNo,
                    OutpatientCostType= GetOutpatientCostType(item.CostDocumentType),
                    DirectoryCode= CommonHelp.GuidToStr(item.DirectoryCode),
                    OperateDoctorDepartment = CommonHelp.GuidToStr(item.OperateDepartmentId),
                    OperateDoctorRange= operatorInfo.F_DoctorTreatmentRange,
                    HospitalPairingCode=null,
                    OperateDoctorNo= CommonHelp.GuidToStr(item.BillDoctorId)
                };
                uploadCostDetail.Add(itemDetail);
            }

            return resultData;
        }
        /// <summary>
        /// 获取门诊费用
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        private string GetOutpatientCostType(string param)
        {
            string resultData = null;
            switch (param)
            {
                case "0":
                    resultData = "03";
                 break;
                case "1":
                    resultData = "01";
                    break;
                case "2":
                    resultData = "04";
                    break;
                case "3":
                    resultData = "10";
                    break;
            }
           
           


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
            OutpatientPersonBaseJsonDto outpatientBase, string organizationCode)
        {

            var pairCodeData = _medicalInsuranceSqlRepository.QueryMedicalInsurancePairCode(new QueryMedicalInsurancePairCodeParam()
            {
                DirectoryCodeList = costDetail.Select(c => c.DirectoryCode).ToList(),
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
                    ProjectCode = item.MedicalInsuranceProjectCode,
                    DirectoryName = item.DirectoryName,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    Amount = item.Amount,
                    ApprovalMark = item.ApprovalMark,
                    BillDepartmentId = item.BillDepartmentId,
                    BillDepartment = item.BillDepartment,
                    BillDoctorName = item.BillDoctorName,
                    OperateDepartmentId = item.OperateDepartmentId,
                    OperateDepartmentName = item.OperateDepartmentName,
                    OperateDoctorName = item.DirectoryName,
                    Operators = item.Operators,
                    DetailInputTime = Convert.ToDateTime(item.BillTime).ToString("yyyy-MM-dd HH:mm:ss"),
                    DetailTime = Convert.ToDateTime(item.BillTime).ToString("yyyy-MM-dd HH:mm:ss"),
                    OperationNo = null,
                    OrdersSortNo = outpatientBase.InvoiceNo,
                    Remark = null,
                    UserMethod = "01",
                    PrescriptionNo = outpatientBase.InvoiceNo,
                    InputPrice = item.UnitPrice,
                    ExternalInspectSign = "0",
                    ExternalInspectHospitalNo = null,
                    DoctorCode = null,
                    EquipmentCode = null,
                    HospitalPairingCode = hospitalCodeNo,
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
                    OrdersSortNo = outpatientBase.InvoiceNo,
                    OrdersContent = items.DirectoryName,
                    DoctorName = items.BillDoctorName,
                    DoctorCode = items.BillDoctorId,
                    OrdersDepartmentCode = items.BillDepartmentId,
                    OrdersDepartmentName = items.BillDepartment,
                    HospitalCodeNo = hospitalCodeNo,
                    OrdersType = null,
                    OrdersClassify = null,
                    DoseUnit = items.HospitalPricingUnit,
                    Dose = 1,
                    UserRoad = null,
                    EveryTimeDosage = Convert.ToInt32(items.Dosage),
                    EveryTimeDosageUnit = items.HospitalPricingUnit,
                    Dosage = null,
                    DosageUnit = items.HospitalPricingUnit,
                    Frequency = 1,
                    UseDays = 1


                };
                ordersDetailData.Add(ordersDetailItem);
            }

            resultData.CostDetail = costDetailData;
            resultData.OrdersDetail = ordersDetailData;

            return resultData;
        }
    }
}
