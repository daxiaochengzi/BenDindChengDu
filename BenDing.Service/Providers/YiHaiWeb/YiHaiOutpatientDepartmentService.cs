using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.Resident;
using BenDing.Domain.Models.Dto.Web;
using BenDing.Domain.Models.Dto.YiHai.Base;
using BenDing.Domain.Models.Dto.YiHai.XmlDto;
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
        public YiHaiOutpatientDepartmentService(
            IWebServiceBasicService iWebServiceBasicService,
            IYiHaiSqlRepository iHaiSqlRepository,
            ISystemManageRepository iSystemManageRepository
            )
        {
            _webServiceBasicService = iWebServiceBasicService;
            _yiHaiSqlRepository = iHaiSqlRepository;
            _systemManageRepository = iSystemManageRepository;
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
            //var   medicalInsuranceSignInService.GetList();
        }
    }
}
