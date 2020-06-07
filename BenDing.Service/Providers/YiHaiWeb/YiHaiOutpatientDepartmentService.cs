using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.JsonEntity;
using BenDing.Domain.Models.Dto.OutpatientDepartment;
using BenDing.Domain.Models.Dto.Resident;
using BenDing.Domain.Models.Dto.Web;
using BenDing.Domain.Models.Dto.YiHai.Base;
using BenDing.Domain.Models.Dto.YiHai.CancelMedicalInsuranceSignIn;
using BenDing.Domain.Models.Dto.YiHai.JsonEntity;
using BenDing.Domain.Models.Dto.YiHai.MedicalInsuranceSignIn;
using BenDing.Domain.Models.Dto.YiHai.OutpatientDepartment;
using BenDing.Domain.Models.Dto.YiHai.OutpatientSettlement;
using BenDing.Domain.Models.Dto.YiHai.Web;
using BenDing.Domain.Models.Dto.YiHai.XmlDto;
using BenDing.Domain.Models.Dto.YiHai.XmlDto.OutpatientDepartment;
using BenDing.Domain.Models.Dto.YiHai.XmlDto.OutpatientDepartment.CancelOutpatientSettlement;
using BenDing.Domain.Models.Dto.YiHai.XmlDto.OutpatientDepartment.OutpatientDetailUpload;
using BenDing.Domain.Models.Dto.YiHai.XmlDto.OutpatientDepartment.OutpatientSettlementPrint;
using BenDing.Domain.Models.Dto.YiHai.XmlDto.OutpatientDetailUpload;
using BenDing.Domain.Models.Dto.YiHai.XmlDto.OutpatientRegister;
using BenDing.Domain.Models.Enums;
using BenDing.Domain.Models.HisXml;
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
        private readonly IWebBasicRepository _webServiceBasicRepository;
        private readonly IMedicalInsuranceSqlRepository _medicalInsuranceSqlRepository;
        private readonly IHisSqlRepository _hisSqlRepository; 
        public YiHaiOutpatientDepartmentService(
            IWebServiceBasicService iWebServiceBasicService,
            IYiHaiSqlRepository iHaiSqlRepository,
            ISystemManageRepository iSystemManageRepository,
            IWebBasicRepository iWebBasicRepository,
            IMedicalInsuranceSqlRepository insuranceSqlRepository,
            IHisSqlRepository hisSqlRepository
            )
        {
            _webServiceBasicService = iWebServiceBasicService;
            _yiHaiSqlRepository = iHaiSqlRepository;
            _systemManageRepository = iSystemManageRepository;
            _webServiceBasicRepository = iWebBasicRepository;
            _medicalInsuranceSqlRepository = insuranceSqlRepository;
            _hisSqlRepository = hisSqlRepository;
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
            var outputData = XmlHelp.DeSerializer<MedicalInsuranceSignInOutputXmlDto>(resultDto.TransactionOutputXml);
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
            if (!data.Any()) throw new Exception("当前病人没处方信息不能进行医保报账!!!");
            //获取挂号数据
            var registerData = data.FirstOrDefault(c=>c.IsRegisteredProject==1);
            //获取第一个项目数据
            var firstProjectData = data.FirstOrDefault(c => c.IsRegisteredProject == 0);
            if (firstProjectData==null) throw new Exception("当前病人没处方信息不能进行医保报账!!!");
            var controlXmlData = new OutpatientRegisterControlXmlDto()
            {
                TotalAmount = registerData?.Amount ?? 0,
                Nums = 1,
            };
          
             //获取科室
             var hospitalGeneralCatalogData = _yiHaiSqlRepository.HospitalGeneralCatalog(new HospitalGeneralCatalogYiHaiParam()
            {
                User = baseUser,
                DirectoryType = "0",
                DirectoryCode = firstProjectData.BillDepartmentId
            }).FirstOrDefault();
            if (hospitalGeneralCatalogData == null) throw new Exception("当前科室中间库中不存在,请更新中间库科室");
            if (hospitalGeneralCatalogData.MedicalInsuranceCode == null) throw new Exception("科室未医保对码");
            var detailRow = new List<OutpatientRegisterDataXmlRow>();
            
            if (registerData != null)
            {
               var itemRegisterData =new OutpatientRegisterDataXmlRow()
                {
                    DirectoryName = hospitalGeneralCatalogData.DirectoryName,
                    MedicalInsuranceProjectCode = hospitalGeneralCatalogData.MedicalInsuranceCode,
                    BusinessId = CommonHelp.GuidToStr(param.BusinessId),
                    HappenTime = Convert.ToDateTime(registerData.BillTime).ToString("yyyy-MM-dd HH:mm:ss"),
                    InputTime = Convert.ToDateTime(registerData.BillTime).ToString("yyyy-MM-dd HH:mm:ss"),
                    Num = registerData.Amount > 0 ? 1 : 0,
                    Price = registerData.Amount > 0 ? registerData.Amount : 1,
                    Operator = baseUser.UserName,
                    TotalAmount = registerData.Amount

                };
                detailRow.Add(itemRegisterData);
            }
            else
            {
                var itemRegisterData = new OutpatientRegisterDataXmlRow()
                {
                    DirectoryName ="免费挂号",
                    BusinessId = CommonHelp.GuidToStr(param.BusinessId),
                    HappenTime = Convert.ToDateTime(firstProjectData.BillTime).ToString("yyyy-MM-dd HH:mm:ss"),
                    InputTime = Convert.ToDateTime(firstProjectData.BillTime).ToString("yyyy-MM-dd HH:mm:ss"),
                    Num =   0,
                    Price = 1,
                    Operator = baseUser.UserName,
                    TotalAmount =0

                };
                detailRow.Add(itemRegisterData);
            }

            var xmlData = new OutpatientRegisterDataXmlDto()
            {
                RegisterType = firstProjectData.EmergencySigns=="1"?"2":"1",
                MedicalInsuranceDepartmentCode = hospitalGeneralCatalogData.MedicalInsuranceCode,
                OperatorTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                OperatorName = baseUser.UserName,
                BaseDepartmentName = hospitalGeneralCatalogData.DirectoryName,
                BaseDepartmentCode = hospitalGeneralCatalogData.FixedEncoding,
                DetailRow = detailRow

            };
            resultData.TransactionControlXml = XmlSerializeHelper.YinHaiXmlSerialize(controlXmlData);
            resultData.TransactionInputXml = XmlSerializeHelper.YinHaiXmlSerialize(xmlData);
            //保存病人信息
            var paramIni = new GetOutpatientPersonParam {User = baseUser, IsSave = true, UiParam = param};
            _webServiceBasicService.GetOutpatientPerson(paramIni);
            return resultData;
        }
        /// <summary>
        /// 门诊挂号
        /// </summary>
        /// <param name="param"></param>
        public ConfirmInfoDto OutpatientRegister(OutpatientRegisterUiParam param)
        {
            var baseUser = _webServiceBasicService.GetUserBaseInfo(param.UserId);
            var resultDto = JsonConvert.DeserializeObject<DealModelDto>(param.ResultJson);
            var outputData = XmlHelp.DeSerializer<OutpatientRegisterOutputXmlDto>(resultDto.TransactionOutputXml);
            var entityId = Guid.NewGuid();
            _yiHaiSqlRepository.InsertSettlementProcess(new SettlementProcessDto()
            {   Id = entityId,
                BusinessId = param.BusinessId,
                CreateUserId = param.UserId,
                ProcessStep = (int)OutpatientSettlementStep.Register,
                SerialNumber = resultDto.SerialNumber,
                BatchNo = resultDto.BatchNo,
                VerificationCode = resultDto.VerificationCode,
                CreateTime = DateTime.Now,
                JsonContent = param.ResultJson

            });
            //更新门诊病人状态
            _yiHaiSqlRepository.UpdateOutpatientSettlement(
                new UpdateOutpatientSettlementParam
                {
                    BusinessId = param.BusinessId,
                    ProcessStep = (int)OutpatientSettlementStep.Register,
                    VisitNo = outputData.VisitNo,
                    PayType = outputData.PayType
                });
            //日志写入
            _systemManageRepository.AddHospitalLog(new AddHospitalLogParam()
            {
                User = baseUser,
                JoinOrOldJson = JsonConvert.SerializeObject(param.ResultJson),
                Remark = "门诊挂号",
                RelationId = entityId,
            });

            var resultData = new ConfirmInfoDto()
            {
                SerialNumber = resultDto.SerialNumber,
                VerificationCode = resultDto.VerificationCode
            };

            return resultData;
        }
        /// <summary>
        /// 获取门诊明细上传入参
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public GetYiHaiBaseParm GetOutpatientDetailUploadParam(GetOutpatientDetailUploadUiParam param)
        {

            var resultData = new GetYiHaiBaseParm();
            var userBase = _webServiceBasicService.GetUserBaseInfo(param.UserId);
            userBase.TransKey = param.TransKey;
            //获取门诊病人信息
            var outpatientInfo = _hisSqlRepository.QueryOutpatient(new QueryOutpatientParam()
            {
                BusinessId = param.BusinessId
            });
            var xmlData = new MedicalInsuranceXmlDto();
            xmlData.BusinessId = param.BusinessId;
            xmlData.HealthInsuranceNo = "48";//42MZ
            xmlData.TransactionId = param.TransKey;
            xmlData.AuthCode = userBase.AuthCode;
            xmlData.UserId = userBase.UserId;
            xmlData.OrganizationCode = userBase.OrganizationCode;
            var jsonParam = JsonConvert.SerializeObject(xmlData);
            var data = _webServiceBasicRepository.HIS_Interface("39", jsonParam);
            OutpatientPersonJsonDto dataValue = JsonConvert.DeserializeObject<OutpatientPersonJsonDto>(data.Msg);

            //获取初始门诊费用明细
            var iniCostDetail = dataValue.DetailInfo;
            var outpatientBase = dataValue.OutpatientPersonBase;

            //获取未对码的项目
            var unCodeData = iniCostDetail.Where(c => string.IsNullOrEmpty(c.MedicalInsuranceProjectCode))
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
            //诊断信息
            var diagnosisList = new List<InpatientDiagnosisDataDto>();
            if (dataValue.WestMedicineDiagnosisList.Any())
            {
                diagnosisList = dataValue.WestMedicineDiagnosisList;
            }
            else
            {
                diagnosisList = dataValue.ChineseMedicineDiagnosisList;
            }
            //获取未对码的诊断
            var unDiagnosisCodeData = diagnosisList.Where(c => c.ProjectCode == null).ToList();

            if (unDiagnosisCodeData.Any())
            {
                string unPairCodeInfo = "诊断未对码信息:";
                unPairCodeInfo += JsonConvert.SerializeObject(unCodeData);
                throw new Exception(unPairCodeInfo);
            }
            //排除挂号费 
            var costDetail = iniCostDetail.Where(c => c.IsRegisteredProject == 0).ToList();
            if (costDetail == null) throw new Exception("当前病人没有处方数据，不能进行医保报账!!!");
            //获取第一个项目数据
            var firstProjectData = costDetail.FirstOrDefault(c => c.IsRegisteredProject == 0);
            //获取结算步骤数据
            var processData = _yiHaiSqlRepository.QuerySettlementProcess(
                new QuerySettlementProcessParam()
                {
                    BusinessId = param.BusinessId,
                    ProcessStep = (int)OutpatientSettlementStep.Register
                });
            //获取挂号信息
            var registerData = processData.FirstOrDefault();
            if (registerData == null) throw new Exception("中间库未查到挂号信息，请检查挂号是否成功!!!");
            var resultDto = JsonConvert.DeserializeObject<DealModelDto>(registerData.JsonContent);
            var outputData = XmlHelp.DeSerializer<OutpatientRegisterOutputXmlDto>(resultDto.TransactionOutputXml);

            //获取所有科室
            var departmentList = _yiHaiSqlRepository.HospitalGeneralCatalog(new HospitalGeneralCatalogYiHaiParam()
            {
                DirectoryType = "0",
                User = userBase
            });
            //科室信息
            var departmentInfo = departmentList.FirstOrDefault(c => c.DirectoryCode == firstProjectData.BillDepartmentId);
            if (departmentInfo == null) throw new Exception("科室:" + outpatientBase.DepartmentName + "在中心库不存在,请在后台管理中更新");
            if (string.IsNullOrEmpty(departmentInfo.InpatientAreaCode)) throw new Exception("科室:" + outpatientBase.DepartmentName + "未设置病区,请在后台管理中设置");
            //获取输入数据
            var inputXmlData = OutpatientDetailUploadDataXml(costDetail, dataValue, userBase.OrganizationCode, outputData, departmentInfo);

            //设置病区编号
            inputXmlData.MedicalRecordDetail.DepartmentAreaCode = departmentInfo.InpatientAreaCode;
            resultData.TransactionInputXml = XmlSerializeHelper.YinHaiXmlSerialize(inputXmlData);
            //获取登录人员信息
            var hospitalOperatorInfo = _systemManageRepository.QueryHospitalOperator(new QueryHospitalOperatorParam()
            {
                UserId = param.UserId
            });

            var controlXmlData = new OutpatientDetailUploadControlXmlDto()
            {
                Edition = "5.0",
                MedicalInsuranceOrganization = hospitalOperatorInfo.MedicalInsuranceHandleNo,
                Nums = costDetail.Count(),
                PersonalCode = outpatientInfo.PersonalCode,
                PayType = outpatientInfo.PayType,
                VisitNo = outpatientInfo.VisitNo,
                TotalAmount = CommonHelp.ValueToDouble(costDetail.Sum(c => c.Amount))
            };

            resultData.TransactionControlXml = XmlSerializeHelper.YinHaiXmlSerialize(controlXmlData);
            //保存门诊明细
            var outpatientDetailParam = new OutpatientDetailParam()
            {
                User = userBase,
                BusinessId = param.BusinessId,
                IsSave = true

            };
            _webServiceBasicService.GetOutpatientDetailPerson(outpatientDetailParam);
            return resultData;
        }
        /// <summary>
        /// 门诊明细上传
        /// </summary>
        /// <param name="param"></param>
        public void OutpatientDetailUpload(GetOutpatientDetailUploadUiParam param)
        {
            var resultDto = JsonConvert.DeserializeObject<DealModelDto>(param.ResultJson);
            var outputData = XmlHelp.DeSerializer<OutpatientDetailUploadOutputXmlDto>(resultDto.TransactionOutputXml);
            var userBase = _webServiceBasicService.GetUserBaseInfo(param.UserId);

            if (outputData.CostDetail.Any())
            {
                var detailIdList = outputData.CostDetail.Select(d => d.DetailId).ToList();
                _hisSqlRepository.UpdateOutpatientDetail(userBase, detailIdList);
            }


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
            var data = _webServiceBasicRepository.HIS_Interface("39", jsonParam);
            OutpatientPersonJsonDto dataValue = JsonConvert.DeserializeObject<OutpatientPersonJsonDto>(data.Msg);
            //获取门诊病人信息
           var outpatientInfo=  _hisSqlRepository.QueryOutpatient(new QueryOutpatientParam()
            {
                BusinessId = param.BusinessId
            });
            bool isWorkers = true;
            if (outpatientInfo != null)
            {
                if (outpatientInfo.PayType == "0203")
                {
                    isWorkers = false;
                }
            }

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
            var costDetail = new List<OutpatientDetailJsonDto>(); ;
            //居民
            if (isWorkers==false)
            {
                costDetail = iniCostDetail.Where(c => c.IsRegisteredProject == 0).ToList();
            }
            else //职工不需要排除
            {
                costDetail = iniCostDetail;
            }
            if (costDetail.Count == 0) throw new Exception("门诊无处方明细不能进行医保报账");
            if (costDetail.Count >= 50) throw new Exception("门诊费用明细只能小于50条");
            //获取第一个项目数据
            var firstProjectData = costDetail.FirstOrDefault(c => c.IsRegisteredProject == 0);

            //获取科室
            var hospitalGeneralCatalogData = _yiHaiSqlRepository.HospitalGeneralCatalog(new HospitalGeneralCatalogYiHaiParam()
            {
                User = userBase,
                DirectoryType = "0",
                DirectoryCode = firstProjectData.BillDepartmentId
            }).FirstOrDefault();
            if (hospitalGeneralCatalogData == null) throw new Exception("当前科室中间库中不存在,请更新中间库科室");
            if (hospitalGeneralCatalogData.MedicalInsuranceCode == null) throw new Exception("科室未医保对码");
            decimal medicalTreatmentTotalCost = string.IsNullOrEmpty(outpatientBase.MedicalTreatmentTotalCost) == true
                ? Convert.ToDecimal(outpatientBase.MedicalTreatmentTotalCost)
                : 0;
            //居民排除挂号费
            if (isWorkers==false)
            {
                medicalTreatmentTotalCost =CommonHelp.ValueToDouble(costDetail.Sum(c => c.Amount));
            }
            var controlData = new OutpatientSettlementControlXmlDto();
            //controlData.PaymentCategory = param.PaymentCategory; //【城职普通门诊0201】、【城居普通门诊0203】
            controlData.TotalAmount = medicalTreatmentTotalCost;
            controlData.nums = costDetail.Count;
            controlData.edition = "5.0";
            controlData.SettlementSign = isWorkers==false?0:1;
            //1.更新门诊明细判断是
            //2.否费用全部更新
            var xmlParam = new OutpatientDepartmentDataXmlParam()
            {
                CostDetail = iniCostDetail,
                IsWorkers = isWorkers,
                OrganizationCode = userBase.OrganizationCode,
                OutpatientBase = outpatientBase,
                DepartmentMedicalInsuranceCode = hospitalGeneralCatalogData.MedicalInsuranceCode,
                DepartmentName = hospitalGeneralCatalogData.DirectoryName
            };
            var dataXml = OutpatientDepartmentDataXml(xmlParam);
            resultData.TransactionControlXml = XmlSerializeHelper.YinHaiXmlSerialize(controlData);
            resultData.TransactionInputXml = XmlSerializeHelper.YinHaiXmlSerialize(dataXml);
            return resultData;
        }
        /// <summary>
        /// 门诊结算
        /// </summary>
        /// <param name="param"></param>
        public ConfirmInfoDto OutpatientSettlement(GetOutpatientDepartmentUiParam param)
        {
            var resultData = new ConfirmInfoDto();
            var baseUser = _webServiceBasicService.GetUserBaseInfo(param.UserId);
            baseUser.TransKey = param.TransKey;
            var resultDto = JsonConvert.DeserializeObject<DealModelDto>(param.ResultJson);
            var outputData = XmlHelp.DeSerializer<OutpatientSettlementOutputXmlDto>(resultDto.TransactionOutputXml);
            //获取门诊病人信息
            var outpatientInfo = _hisSqlRepository.QueryOutpatient(new QueryOutpatientParam()
            {
                BusinessId = param.BusinessId
            });
            //更新门诊病人状态
            _yiHaiSqlRepository.UpdateOutpatientSettlement(
                new UpdateOutpatientSettlementParam {
                    BusinessId=param.BusinessId,
                    ProcessStep=(int)OutpatientSettlementStep.OutpatientSettlement,
                    VisitNo= outputData.VisitNo
                });
            _yiHaiSqlRepository.InsertSettlementProcess(new SettlementProcessDto() {
                Id = Guid.NewGuid(),
                BatchNo = resultDto.BatchNo,
                SerialNumber = resultDto.SerialNumber,
                JsonContent = param.ResultJson,
                ProcessStep = (int)OutpatientSettlementStep.OutpatientSettlement,
                BusinessId = param.BusinessId,
                CreateUserId = param.UserId,
                CreateTime = DateTime.Now,
                VerificationCode= resultDto.VerificationCode
            });
          
            //账户余额
            decimal accountBalance = 0;
            if (outputData.AccountInfo.Any())
            {
                accountBalance = outputData.AccountInfo.FirstOrDefault().Balance;
            }

            //回参构建
            var xmlData = new OutpatientDepartmentCostXml()
            {
                AccountBalance = accountBalance,
                MedicalInsuranceOutpatientNo = outputData.VisitNo,
                CashPayment = outputData.SelfPayFeeAmount,
                SettlementNo = outputData.VisitNo,
                AllAmount = outputData.TotalAmount,
                PatientName = outpatientInfo.PatientName,
                AccountAmountPay = outputData.AccountPay,
                MedicalInsurancePayTotalAmount = outputData.MedicalInsurancePayTotalAmount,
                MedicalInsuranceType = outpatientInfo.PayType == "0201" ? "1" : outpatientInfo.PayType,
            };

            var strXmlBackParam = XmlSerializeHelper.HisXmlSerialize(xmlData);
            var saveXml = new SaveXmlDataParam()
            {
                User = baseUser,
                MedicalInsuranceBackNum = "11",
                MedicalInsuranceCode = "48",
                BusinessId = param.BusinessId,
                BackParam = strXmlBackParam
            };
            //存基层
            _webServiceBasicRepository.SaveXmlData(saveXml);
            //更新门诊病人状态
            _yiHaiSqlRepository.UpdateOutpatientSettlement(
                new UpdateOutpatientSettlementParam
                {
                    BusinessId = param.BusinessId,
                    ProcessStep = (int)OutpatientSettlementStep.HisSettlement,
                    VisitNo = outputData.VisitNo
                });
            _yiHaiSqlRepository.InsertSettlementProcess(new SettlementProcessDto()
            {
                Id = Guid.NewGuid(),
                BatchNo = resultDto.BatchNo,
                SerialNumber = resultDto.SerialNumber,
                JsonContent = param.ResultJson,
                ProcessStep = (int)OutpatientSettlementStep.HisSettlement,
                BusinessId = param.BusinessId,
                CreateUserId = param.UserId,
                CreateTime = DateTime.Now,
                VerificationCode = resultDto.VerificationCode
            });
            //日志写入
            _systemManageRepository.AddHospitalLog(new AddHospitalLogParam()
            {
                User = baseUser,
                JoinOrOldJson = JsonConvert.SerializeObject(param.ResultJson),
                Remark = "门诊挂号"
            });
            return resultData;
        }
        /// <summary>
        /// 获取门诊结算打印参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public GetYiHaiBaseParm GetOutpatientSettlementPrintParam(GetOutpatientSettlementPrintParam param)
        {
            var resultData = new GetYiHaiBaseParm();
            //获取结算步骤数据
           var settlementProcessData= _yiHaiSqlRepository.QuerySettlementProcess(new QuerySettlementProcessParam()
            {
               BusinessId = param.BusinessId,
               ProcessStep = (int)OutpatientSettlementStep.OutpatientSettlement,
            });
            if (settlementProcessData.Any()==false) throw new Exception("获取门诊结算数据失败!!!");

           var hospitalOperator= _systemManageRepository.QueryHospitalOperator(new QueryHospitalOperatorParam()
            {
                UserId = param.UserId
            });
            var settlementJsonData= settlementProcessData.FirstOrDefault();
            var resultDto = JsonConvert.DeserializeObject<DealModelDto>(settlementJsonData.JsonContent);
            var outputData = XmlHelp.DeSerializer<OutpatientSettlementOutputXmlDto>(resultDto.TransactionOutputXml);
            var controlData = new OutpatientSettlementPrintControlXmlDto
            {
                PayType = outputData.PayType,
                SettlementNo = outputData.SettlementNo,
                PersonalCoding = outputData.PersonalCoding,
                VisitNo = outputData.VisitNo,
                MedicalInsuranceOrganization = hospitalOperator.MedicalInsuranceHandleNo
            };
            var dataXml = new DataXmlBaseDto();
            resultData.TransactionControlXml = XmlSerializeHelper.YinHaiXmlSerialize(controlData);
            resultData.TransactionInputXml = XmlSerializeHelper.YinHaiXmlSerialize(dataXml);
            return resultData;

        }
        /// <summary>
        /// 查询门诊结算信息
        /// </summary>
        public QueryOutpatientSettlementCost QueryOutpatientSettlementCost(QueryOutpatientSettlementCostUiParam param)
        {
            //获取结算步骤数据
            var settlementProcessData = _yiHaiSqlRepository.QuerySettlementProcess(new QuerySettlementProcessParam()
            {
                BusinessId = param.BusinessId,
                ProcessStep = (int)OutpatientSettlementStep.OutpatientSettlement,
            });
            if (settlementProcessData.Any() == false) throw new Exception("获取门诊结算数据失败!!!");

            //获取门诊病人信息
            var outpatientInfo = _hisSqlRepository.QueryOutpatient(new QueryOutpatientParam()
            {
                BusinessId = param.BusinessId
            });
            if (outpatientInfo.ProcessStep!=(int) OutpatientSettlementStep.ConfirmSettlement) throw new Exception("当前病人没有确认结算信息不能,取消结算!!!");
            var resultData = new QueryOutpatientSettlementCost()
            {    BusinessId = param.BusinessId,
                DepartmentName = outpatientInfo.DepartmentName,
                DiagnosticDoctor = outpatientInfo.DiagnosticDoctor,
                IdCardNo = outpatientInfo.IdCardNo,
                InvoiceNo = outpatientInfo.InvoiceNo,
                Operator = outpatientInfo.Operator,
                OutpatientNumber = outpatientInfo.OutpatientNumber,
                PatientName = outpatientInfo.PatientName,
                VisitDate = outpatientInfo.VisitDate

            };
            var settlementJsonData = settlementProcessData.FirstOrDefault();
            var resultDto = JsonConvert.DeserializeObject<DealModelDto>(settlementJsonData.JsonContent);
            var outputData = XmlHelp.DeSerializer<OutpatientSettlementOutputXmlDto>(resultDto.TransactionOutputXml);
            var outputJson= AutoMapper.Mapper.Map<OutpatientSettlementOutputJsonDto>(outputData);
            if (outputData.AccountInfo.Any() && outputData.AccountInfo.Count>0)
            {
                var accountInfoData = outputData.AccountInfo.FirstOrDefault();
                outputJson.AccountType = accountInfoData.AccountType;
                outputJson.Balance = accountInfoData.Balance;
            }

            resultData.PayMsg=CommonHelp.GetPayMsg(JsonConvert.SerializeObject(outputJson));


            return resultData;
        }
       
        /// <summary>
        /// 不确定交易查询
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, List<QueryUncertainTransactionDto>> QueryUncertainTransaction()
        {


            var resultData = new Dictionary<int, List<QueryUncertainTransactionDto>>();
            var dataList = new List<QueryUncertainTransactionDto>()
            {
                new QueryUncertainTransactionDto()
                {
                    VisitNo = "00002005289161163",
                    SerialNumber = "11C0000SJ37F6E2F2",
                    SettlementNo = "0000S293400211",
                   ReimbursementType = "0203"
                }
            };
            resultData.Add(1, dataList);
            return resultData;
        }

        /// <summary>
        /// 确认步骤
        /// </summary>
        /// <param name="param"></param>
        public void ConfirmProcessStep(ConfirmProcessStepUiParam param)
        {
            var baseUser = _webServiceBasicService.GetUserBaseInfo(param.UserId);
            var resultDto = JsonConvert.DeserializeObject<DealModelDto>(param.ResultJson);
            
            var entityId = Guid.NewGuid();
            _yiHaiSqlRepository.InsertSettlementProcess(new SettlementProcessDto()
            {
                Id = entityId,
                BusinessId = param.BusinessId,
                CreateUserId = param.UserId,
                ProcessStep = (int)param.SettlementStep,
                SerialNumber = resultDto.SerialNumber,
                BatchNo = resultDto.BatchNo,
                VerificationCode = resultDto.VerificationCode,
                CreateTime = DateTime.Now,
                JsonContent = resultDto.TransactionOutputXml

            });
            //更新门诊病人状态
            _yiHaiSqlRepository.UpdateOutpatientSettlement(
                new UpdateOutpatientSettlementParam
                {
                    BusinessId = param.BusinessId,
                    ProcessStep = (int)param.SettlementStep,
                    UserId = param.UserId
                });
            //日志写入
            _systemManageRepository.AddHospitalLog(new AddHospitalLogParam()
            {
                User = baseUser,
                JoinOrOldJson = JsonConvert.SerializeObject(param.ResultJson),
                Remark = param.SettlementStep.ToString(),
                RelationId = entityId,
            });

        }
        /// <summary>
        /// 获取门诊取消结算入参
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public GetYiHaiBaseParm GetCancelOutpatientSettlementParam(GetCancelOutpatientSettlementUiParam param)
        {
            var resultData = new GetYiHaiBaseParm();
            var settlementProcessData = _yiHaiSqlRepository.QuerySettlementProcess(new QuerySettlementProcessParam()
            {
                BusinessId = param.BusinessId,
                ProcessStep = (int)OutpatientSettlementStep.OutpatientSettlement,
            });
            var settlementJsonData = settlementProcessData.FirstOrDefault();
            if (settlementJsonData==null) throw  new  Exception("获取门诊结算信息失败!!!");
            var resultDto = JsonConvert.DeserializeObject<DealModelDto>(settlementJsonData.JsonContent);
            var outputData = XmlHelp.DeSerializer<OutpatientSettlementOutputXmlDto>(resultDto.TransactionOutputXml);
            var controlData = new CancelOutpatientSettlementDataXmlDto
            {
                AccountPay = outputData.AccountPay,
                MedicalInsurancePayTotalAmount = outputData.MedicalInsurancePayTotalAmount,
                TotalAmount = outputData.TotalAmount
            };

            var dataXml = new CancelOutpatientSettlementControlXmlDto
            {
               PayType = outputData.PayType,
               SettlementNo = outputData.SettlementNo,
               VisitNo = outputData.VisitNo
            };
            resultData.TransactionControlXml = XmlSerializeHelper.YinHaiXmlSerialize(controlData);
            resultData.TransactionInputXml = XmlSerializeHelper.YinHaiXmlSerialize(dataXml);
            return resultData;
           
        }
        /// <summary>
        /// 取消结算
        /// </summary>
        /// <param name="param"></param>
        public ConfirmInfoDto CancelOutpatientSettlement(GetCancelOutpatientSettlementUiParam param)
        {
          
            var baseUser = _webServiceBasicService.GetUserBaseInfo(param.UserId);
            baseUser.TransKey = param.TransKey;
            var resultDto = JsonConvert.DeserializeObject<DealModelDto>(param.ResultJson);
            var resultData = new ConfirmInfoDto()
            {
                SerialNumber = resultDto.SerialNumber,
                VerificationCode = resultDto.VerificationCode
            };
            //获取门诊病人信息
            var outpatientInfo = _hisSqlRepository.QueryOutpatient(new QueryOutpatientParam()
            {
                BusinessId = param.BusinessId
            });
         
            if (outpatientInfo.ProcessStep !=(int)OutpatientSettlementStep.ConfirmSettlement && outpatientInfo.ProcessStep!=8) throw new Exception("当前病人未确认结算,不能取消结算!!!");
            if (outpatientInfo.ProcessStep == (int)OutpatientSettlementStep.ConfirmCancelSettlement ) throw new Exception("当前病人已确认取消结算,不能再次取消结算!!!");
            var entityId = Guid.NewGuid();
            _yiHaiSqlRepository.InsertSettlementProcess(new SettlementProcessDto()
            {
                Id = entityId,
                BusinessId = param.BusinessId,
                CreateUserId = param.UserId,
                ProcessStep = (int)OutpatientSettlementStep.CancelSettlement,
                SerialNumber = resultDto.SerialNumber,
                BatchNo = resultDto.BatchNo,
                VerificationCode = resultDto.VerificationCode,
                CreateTime = DateTime.Now,
                JsonContent = resultDto.TransactionOutputXml

            });
            //更新门诊病人状态
            _yiHaiSqlRepository.UpdateOutpatientSettlement(
            new UpdateOutpatientSettlementParam
            {
                BusinessId = param.BusinessId,
                ProcessStep = (int)OutpatientSettlementStep.CancelSettlement,

            });
            //回参构建
            var xmlData = new OutpatientDepartmentCostCancelXml()
            {
                SettlementNo = outpatientInfo.VisitNo
            };
            var strXmlBackParam = XmlSerializeHelper.HisXmlSerialize(xmlData);
            var saveXml = new SaveXmlDataParam()
            {
                User = baseUser,
                MedicalInsuranceBackNum = outpatientInfo.VisitNo,
                MedicalInsuranceCode = "42MZ",
                BusinessId = param.BusinessId,
                BackParam = strXmlBackParam
            };
            ////存基层
            _webServiceBasicRepository.SaveXmlData(saveXml);

            _yiHaiSqlRepository.InsertSettlementProcess(new SettlementProcessDto()
            {
                Id = Guid.NewGuid(),
                BusinessId = param.BusinessId,
                CreateUserId = param.UserId,
                ProcessStep = (int)OutpatientSettlementStep.HisCancelSettlement,
                SerialNumber = resultDto.SerialNumber,
                BatchNo = resultDto.BatchNo,
                VerificationCode = resultDto.VerificationCode,
                CreateTime = DateTime.Now,
                JsonContent = resultDto.TransactionOutputXml

            });
            //更新门诊病人状态
            _yiHaiSqlRepository.UpdateOutpatientSettlement(
            new UpdateOutpatientSettlementParam
            {
                BusinessId = param.BusinessId,
                ProcessStep = (int)OutpatientSettlementStep.HisCancelSettlement,

            });
            //添加日志
            var logParam = new AddHospitalLogParam()
            {
                JoinOrOldJson = JsonConvert.SerializeObject(param),
                User = baseUser,
                Remark = "门诊取消结算",
                RelationId = outpatientInfo.Id,
            };
            _systemManageRepository.AddHospitalLog(logParam);
           
            return resultData;
        }


        /// <summary>
        /// 获取医院信息上传参数
        /// </summary>
        /// <returns></returns>
        public GetYiHaiBaseParm GetHospitalInfoUploadParam(UploadHospitalInfoUiParam param)
        {
            var resultData = new GetYiHaiBaseParm();
            var userBase = _webServiceBasicService.GetUserBaseInfo(param.UserId);

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
            var fixedEncodingList = new List<string>();
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
                    Select(a => a.FixedEncoding)
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
        /// <summary>
        /// 获取科室明细
        /// </summary>
        /// <param name="param"></param>
        /// <param name="user"></param>
        /// <returns></returns>
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
            var inpatientAreaData = paramNew.Where(c => c.DirectoryType == "2").ToList();
            //总床位数
            resultData.BedNum =new UploadHospitalInfoBeDNumData()
            {
                TotalBadNum = badCount
            }; 
            //床位xml数据
            var badXmlData = new List<UploadHospitalInfoDataBedXmlDto>();
            foreach (var item in badData)
            {
                var inpatientAreaItemData = inpatientAreaData
                    .FirstOrDefault(c => c.DirectoryCode == item.Remark);
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
            ////添加床位明细数据
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
            ////添加科室明细数据
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
            ////添加医保资料医生
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
            string organizationCode,
            OutpatientRegisterOutputXmlDto patientInfo,
            HospitalGeneralCatalogEntity hospitalGeneralCatalog
            )
        {
            //获取门诊信息
            var outpatientBase = dataValue.OutpatientPersonBase;
            //获取医院所有医生
            var operatorAllInfo = _systemManageRepository.QueryHospitalOperatorAllInfo(organizationCode);
            //获取第一个项目数据
            var firstProjectData = costDetail.FirstOrDefault(c => c.IsRegisteredProject == 0);
            //获取诊断列表
            var diagnosisList = new List<InpatientDiagnosisDataDto>();
            //是否西医诊断
            var isWestMedicineDiagnosis = true;
            if (dataValue.WestMedicineDiagnosisList.Any())
            {
                diagnosisList = dataValue.WestMedicineDiagnosisList;
            }
            else
            {
                diagnosisList = dataValue.ChineseMedicineDiagnosisList;
                isWestMedicineDiagnosis = false;
            }
            //var pairCodeData = _medicalInsuranceSqlRepository.QueryMedicalInsurancePairCode(new QueryMedicalInsurancePairCodeParam()
            //{
            //    DirectoryCodeList = costDetail.Select(c => c.DirectoryCode).ToList(),
            //    OrganizationCode = organizationCode
            //});
            var resultData = new OutpatientDetailUploadDataXmlDto();
            var uploadCostDetail = new List<OutpatientDetailUploadDataCostDetailXmlDto>();

            //医生编码 
            var operateDoctorCode = CommonHelp.GuidToStr(firstProjectData.BillDoctorId);
            //收费时间
            var visitDate = firstProjectData.BillTime;
            //获取主诊断
            var mainDiagnosis = diagnosisList.FirstOrDefault(c => c.IsMainDiagnosis == "是");

            //诊断症状
            var symptomDetail = diagnosisList.Select(d => new OutpatientDetailUploadDataSymptomDetailXmlDto()
            {
                DiagnosisName = d.DiseaseName,
                DiagnosisCode = d.ProjectCode
            }).ToList();

            //西药处方
            var westernDrugDetail = new List<OutpatientWesternDrugPrescriptionDetail>();
            //医嘱
            var ordersDetail = new List<OutpatientPatientOrdersDetail>();
            //医嘱序号
            int ordersNo = 0;
            //门诊病历
            var medicalRecordDetail = new OutpatientDetailUploadDataOutpatientMedicalRecordDetailXmlDto()
            {
                Age = CommonHelp.GetAgeByBirthdate(Convert.ToDateTime(patientInfo.Birthday)),
                Birthday = patientInfo.Birthday,
                AntecedentHistory = mainDiagnosis.DiseaseName,
                DepartmentAreaCode = hospitalGeneralCatalog.MedicalInsuranceCode,
                DiagnosisStartTime = visitDate,
                DiagnosisTime = visitDate,
                DoctorCode = operateDoctorCode,
                FindDiseaseTime = visitDate,
                IsConfirmDiagnosis = 1,
                IsConsultation = 1,
                IsRepeatedDiagnosis = 0,
                IsTrauma = 0,
                Job = "工人",
                MainDiagnosis = mainDiagnosis.DiseaseName,
                OperatorName = outpatientBase.Operator,
                WestMedicineFirstDiagnosis = isWestMedicineDiagnosis == true? mainDiagnosis.ProjectCode:null,
                PhysiqueInspect = "T36.5℃",
                VisitType = "1",
                ChineseMedicineFirstDiagnosis =isWestMedicineDiagnosis == false ? mainDiagnosis.ProjectCode : null,
                SymptomDetail = symptomDetail,

            };
            foreach (var item in costDetail)
            {

                //流水号
                string detailFixedEncoding = CommonHelp.GuidToStr(item.DetailId);
                string ordersSortNo = isWestMedicineDiagnosis==false ? detailFixedEncoding : null;
                //获取医生
                var operatorInfo = operatorAllInfo.FirstOrDefault(c => c.F_HisUserId == item.BillDoctorId);

                var itemDetail = new OutpatientDetailUploadDataCostDetailXmlDto()
                {
                    Amount = item.Amount,
                    ApprovalMark = item.ApprovalMark,
                    DetailId = detailFixedEncoding,
                    DirectoryCode = CommonHelp.GuidToStr(item.DirectoryCode),
                    DirectoryName = item.DirectoryName,
                    ProjectCode = item.MedicalInsuranceProjectCode,
                    OperateDoctorCode = operateDoctorCode,
                    OperateDoctorDepartment = hospitalGeneralCatalog.MedicalInsuranceCode,
                    OperateDoctorNo = CommonHelp.GuidToStr(item.BillDoctorId),
                    Operators = outpatientBase.Operator,
                    PrescriptionNo = outpatientBase.InvoiceNo,
                    OutpatientCostType = GetOutpatientCostType(item.DirectoryCategoryName),
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    OrdersSortNo = ordersSortNo,
                    DetailInputTime = firstProjectData.BillTime,
                    DetailHappenTime = firstProjectData.BillTime,
                    OperateDoctorRange = operatorInfo.F_DoctorTreatmentRange,
                };
                uploadCostDetail.Add(itemDetail);


                //用药天数
                int useDays =!string.IsNullOrWhiteSpace(item.UseDrugDay)?Convert.ToInt32(item.UseDrugDay):0 ;
                //医嘱序号加一
                ordersNo++;
                var useDrugEndTime = Convert.ToDateTime(item.BillTime).AddDays(useDays).ToString("yyyy-MM-dd HH:mm:ss");
                
                if (item.DirectoryCategoryName=="西药费"|| item.DirectoryCategoryName == "中药费"|| item.DirectoryCategoryName == "中成药")
                {

                    westernDrugDetail.Add(new OutpatientWesternDrugPrescriptionDetail()
                    {
                        PrescriptionNo = outpatientBase.InvoiceNo,
                        GetDrugPerson = dataValue.OutpatientPersonBase.PatientName,
                        UseDrugStartTime = item.BillTime,
                        UseDrugEndTime = useDrugEndTime
                    });
                }
                else if (item.DirectoryCategoryName == "诊疗")
                {

                    ordersDetail.Add(new OutpatientPatientOrdersDetail()
                    {
                        OperatorName = outpatientBase.Operator,
                        DoctorName = item.BillDoctorName,
                        DoctorCode = CommonHelp.GuidToStr(item.OperateDoctorId),
                        OrdersContent = item.DirectoryName,
                        OrdersDepartmentCode = CommonHelp.GuidToStr(item.BillDepartmentId),
                        OrdersDepartmentName = item.BillDepartment,
                        OrdersStartTime = item.BillTime,
                        ProjectPairCode = item.MedicalInsuranceProjectCode,
                        UseDay = useDays,
                        OrdersNo = ordersNo.ToString()
                    });
                }
            }

            //服务对象
            resultData.ServiceObjectDetail = new OutpatientDetailUploadDataServiceObjectDetailXmlDto()
            {
                OperationName = outpatientBase.Operator,
                OperationTime = visitDate,
            };
            //挂号信息
            resultData.RegisterDetail = new OutpatientDetailUploadDataRegisterDetailXmlDto()
            { //医生编号需从门诊基础信息中获取编码
                OperateDoctorCode = operateDoctorCode,
                OperateDoctorName = outpatientBase.DiagnosticDoctor
            };
            //诊断明细
            var diagnosisDetail = diagnosisList.Select(d => new OutpatientDetailUploadDataDiagnosisDetailXmlDto()
            {
                DiagnosisCode = d.ProjectCode,
                DiagnosisName = d.DiseaseName,
                DiagnosisType = isWestMedicineDiagnosis==true ? "2" : "1",
            }).ToList();
            resultData.OrdersDetail = ordersDetail;
            resultData.WesternDrugDetail = westernDrugDetail;
            //赋值诊断
            medicalRecordDetail.DiagnosisDetail = diagnosisDetail;
            resultData.MedicalRecordDetail = medicalRecordDetail;
            resultData.CostDetail = uploadCostDetail;
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
               case "挂号费":
                    resultData = "01";
                    break;
                case "血液费":
                    resultData = "01";
                    break;
                case "手术费":
                    resultData = "01";
                    break;
                case "麻醉费":
                    resultData = "01";
                    break;
                case "输血费":
                    resultData = "01";
                    break;
                case "疫苗费":
                    resultData = "01";
                    break;
                case "放射检查":
                    resultData = "01";
                    break;
                case "放射治疗":
                    resultData = "01";
                    break;
                case "婴儿费":
                    resultData = "01";
                    break;
                case "氧气费":
                    resultData = "01";
                    break;
                case "中成药":
                    resultData = "01";
                    break;
                case "接生费":
                    resultData = "01";
                    break;
                case "化验费":
                    resultData = "01";
                    break;
                case "治疗费":
                    resultData = "01";
                    break;
                case "诊疗费":
                    resultData = "01";
                    break;
                case "护理费":
                    resultData = "01";
                    break;
                case "材料费":
                    resultData = "01";
                    break;
                case "西药房":
                    resultData = "01";
                    break;
                case "中药费":
                    resultData = "01";
                    break;
                case "其他费用":
                    resultData = "01";
                    break;
                case "住院床位费":
                    resultData = "01";
                    break;
            }




            return resultData;

        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="param"></param>
       /// <returns></returns>
        private OutpatientSettlementDataXmlDto OutpatientDepartmentDataXml(
            OutpatientDepartmentDataXmlParam param)
        {
            var pairCodeData = _medicalInsuranceSqlRepository.QueryMedicalInsurancePairCode(new QueryMedicalInsurancePairCodeParam()
            {
                DirectoryCodeList = param.CostDetail.Select(c => c.DirectoryCode).ToList(),
                OrganizationCode = param.OrganizationCode
            });
            var resultData = new OutpatientSettlementDataXmlDto();
            //居民
            if (param.IsWorkers == false)
            {
                var serialNumberList = param.CostDetail.Select(c => new OutpatientDepartmentDataXmlSerialNumberDto()
                {
                    SerialNumber =CommonHelp.GuidToStr(c.DetailId)
                }).ToList();
                resultData.SerialNumber = serialNumberList;
            }
            else //职工
            {
                var costDetailData = new List<OutpatientDepartmentDataXmlRowDto>();
                var ordersDetailData = new List<OutpatientDepartmentDataXmlDetailDto>();
                foreach (var item in param.CostDetail)
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
                        OperateDoctorName = item.OperateDoctorName,
                        Operators = item.Operators,
                        DetailInputTime = Convert.ToDateTime(item.BillTime).ToString("yyyy-MM-dd HH:mm:ss"),
                        DetailTime = Convert.ToDateTime(item.BillTime).ToString("yyyy-MM-dd HH:mm:ss"),
                        OperationNo = null,
                        OrdersSortNo = param.OutpatientBase.InvoiceNo,
                        Remark = null,
                        UserMethod = "01",
                        PrescriptionNo = param.OutpatientBase.InvoiceNo,
                        ExternalInspectSign = "0",
                        ExternalInspectHospitalNo = null,
                        DoctorCode = null,
                        EquipmentCode = null,
                        HospitalPairingCode = hospitalCodeNo,
                        DirectoryCode = CommonHelp.GuidToStr(item.DirectoryCode)

                    };
                    costDetailData.Add(costDetailItem);
                }
                foreach (var items in param.CostDetail)
                {
                    var hospitalCodeNo = pairCodeData.Where(c => c.DirectoryCode == items.DirectoryCode)
                        .Select(d => d.FixedEncodingId).FirstOrDefault();
                    var ordersDetailItem = new OutpatientDepartmentDataXmlDetailDto()
                    {
                        OrdersSortNo = param.OutpatientBase.InvoiceNo,
                        OrdersContent = items.DirectoryName,
                        DoctorName = items.BillDoctorName,
                        DoctorCode =CommonHelp.GuidToStr(items.BillDoctorId) ,
                        OrdersDepartmentCode = items.BillDepartmentId,
                        OrdersDepartmentName = param.DepartmentName,
                        HospitalCodeNo = hospitalCodeNo,
                        OrdersType = null,
                        OrdersClassify = null,
                        DoseUnit ="",
                        Dose = 1,
                        UserRoad = null,
                        EveryTimeDosage = Convert.ToInt32(items.Dosage),
                        EveryTimeDosageUnit = items.HospitalPricingUnit,
                        Dosage = null,
                        DosageUnit = items.HospitalPricingUnit,
                        Frequency = "",
                        UseDays =!string.IsNullOrWhiteSpace(items.UseDrugDay)?Convert.ToInt32(items.UseDrugDay):0


                    };
                    ordersDetailData.Add(ordersDetailItem);
                }
                resultData.CostDetail = costDetailData;
                resultData.OrdersDetail = ordersDetailData;
            }

           
            return resultData;
        }
    }
}
