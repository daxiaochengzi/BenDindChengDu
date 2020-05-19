using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using BenDing.Domain.Models.Params.Web;
using BenDing.Repository.Interfaces.Web;
using BenDing.Repository.Interfaces.YiHaiWeb;
using NFine.Application.BenDingManage;
using NFine.Application.SystemManage;
using NFine.Code;

namespace NFine.Web.Areas.SystemManage.Controllers
{
  
    public class SignInController : ControllerBase
    {
        private readonly ISystemManageRepository _systemManageRepository;
        private UserApp userApp = new UserApp();

        private MedicalInsuranceSignInBase signService = new MedicalInsuranceSignInBase();

        public SignInController()
        {
            _systemManageRepository = Bootstrapper.UnityIOC.Resolve<ISystemManageRepository>();
        }

        [System.Web.Http.HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            var loginInfo = OperatorProvider.Provider.GetCurrent();
 
            var userBase = _systemManageRepository.QueryHospitalOperator(new QueryHospitalOperatorParam()
            {
                Id = loginInfo.UserId
            });
            var data = new
            {
                rows = signService.GetList(pagination, keyword,  userBase.OrganizationCode),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }
    }
}
