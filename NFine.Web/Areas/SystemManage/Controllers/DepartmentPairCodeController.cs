using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BenDing.Domain.Models.Params.Web;
using BenDing.Domain.Models.Params.YinHai.Web;
using BenDing.Repository.Interfaces.YiHaiWeb;
using BenDing.Service.Interfaces;
using NFine.Application.BenDingManage;
using NFine.Application.SystemManage;
using NFine.Code;
using NFine.Domain._03_Entity.BenDingManage;

namespace NFine.Web.Areas.SystemManage.Controllers
{
    public class DepartmentPairCodeController : ControllerBase
    {
        private HospitalGeneralCatalogBase hospitalGeneralCatalogBase = new HospitalGeneralCatalogBase();
        private readonly IYiHaiSqlRepository _yiHaiSqlRepository;
        private UserApp userApp = new UserApp();
        private readonly IWebServiceBasicService _webServiceBasicService;

        public DepartmentPairCodeController()
        {
            _yiHaiSqlRepository = Bootstrapper.UnityIOC.Resolve<IYiHaiSqlRepository>();
            _webServiceBasicService = Bootstrapper.UnityIOC.Resolve<IWebServiceBasicService>();
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetCodeTableGridJson(string keyword)
        {
            var data = _yiHaiSqlRepository.CodeTableQuery(keyword);
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetInpatientAreaCodeGridJson()
        {
            var loginInfo = OperatorProvider.Provider.GetCurrent();
            var user = userApp.GetForm(loginInfo.UserId);
            if (string.IsNullOrEmpty(user.F_HisUserId)) throw new Exception("当前用户非基层用户不能操作!!!"); ;
            var userBase = _webServiceBasicService.GetUserBaseInfo(user.F_HisUserId);

            var data = _yiHaiSqlRepository.HospitalGeneralCatalog(new HospitalGeneralCatalogYiHaiParam()
            {
                DirectoryType = "2",
                User = userBase
            });
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string keyword )
        {
            var loginInfo = OperatorProvider.Provider.GetCurrent();
            var user = userApp.GetForm(loginInfo.UserId);
            if (string.IsNullOrEmpty(user.F_HisUserId)) throw new Exception("当前用户非基层用户不能操作!!!");
            var userBase = _webServiceBasicService.GetUserBaseInfo(user.F_HisUserId);
            var data = new
            {
                rows = hospitalGeneralCatalogBase.GetList(pagination, keyword, "0", userBase.OrganizationCode),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }
        [System.Web.Http.HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(DepartmentPairCodeYiHaiParam param)
        {
            var loginInfo = OperatorProvider.Provider.GetCurrent();
            var user = userApp.GetForm(loginInfo.UserId);
            if (string.IsNullOrEmpty(user.F_HisUserId)) throw new Exception("当前用户非基层用户不能操作!!!"); ;
            var userBase = _webServiceBasicService.GetUserBaseInfo(user.F_HisUserId);
            var hospitalGeneralCatalogEntity = hospitalGeneralCatalogBase.GetForm(param.keyword);

            hospitalGeneralCatalogEntity.MedicalInsuranceCode = param.MedicalInsuranceCode;
            hospitalGeneralCatalogEntity.InpatientAreaCode = param.InpatientAreaCode;
            hospitalGeneralCatalogEntity.PairCodeTime = DateTime.Now;
            hospitalGeneralCatalogEntity.PairCodeUserId = userBase.UserId;
            hospitalGeneralCatalogEntity.PairCodeUserName = userBase.UserName;
            hospitalGeneralCatalogEntity.MedicalInsuranceName = param.MedicalInsuranceName;
            hospitalGeneralCatalogEntity.InpatientAreaDutyPerson = param.InpatientAreaDutyPerson;
            hospitalGeneralCatalogBase.Modify(hospitalGeneralCatalogEntity, userBase, Guid.Parse(param.keyword));

            return Success("操作成功");
        }
    }
}
