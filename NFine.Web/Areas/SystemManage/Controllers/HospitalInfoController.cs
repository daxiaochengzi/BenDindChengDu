using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using BenDing.Domain.Models.Params.Web;
using BenDing.Service.Interfaces;
using NFine.Application.BenDingManage;
using NFine.Application.SystemManage;
using NFine.Code;
using NFine.Domain.Entity.SystemManage;
using NFine.Domain.Params;
using NFine.Domain._03_Entity.BenDingManage;

namespace NFine.Web.Areas.SystemManage.Controllers
{
    public class HospitalInfoController : ControllerBase
    {
        private HospitalGeneralCatalogBase hospitalGeneralCatalogBase = new HospitalGeneralCatalogBase();
        private UserApp userApp = new UserApp();
        private readonly IWebServiceBasicService _webServiceBasicService;
        // 
        /// <summary>
        /// 
        /// </summary>
        public HospitalInfoController()
        {
            _webServiceBasicService = Bootstrapper.UnityIOC.Resolve<IWebServiceBasicService>();
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string keyword,string directoryType)
        {
            var loginInfo = OperatorProvider.Provider.GetCurrent();
            var user = userApp.GetForm(loginInfo.UserId);
            if (string.IsNullOrEmpty(user.F_HisUserId)) throw new Exception("当前用户非基层用户不能操作!!!");
            var userBase = _webServiceBasicService.GetUserBaseInfo(user.F_HisUserId);
            var data = new
            {
                rows = hospitalGeneralCatalogBase.GetList(pagination, keyword, directoryType, userBase.OrganizationCode),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }
        [System.Web.Http.HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(HospitalGeneralCatalogNFineParam param)
        {
             var loginInfo = OperatorProvider.Provider.GetCurrent();
             var user = userApp.GetForm(loginInfo.UserId);
             if (string.IsNullOrEmpty(user.F_HisUserId)) throw new Exception("当前用户非基层用户不能操作!!!"); ;
             var userBase= _webServiceBasicService.GetUserBaseInfo(user.F_HisUserId);
            var inputInpatientInfo = new InformationParam()
            {
                AuthCode = userBase.AuthCode,
                OrganizationCode = userBase.OrganizationCode,
                DirectoryType = param.DirectoryType,
                
            };
            var resultData = _webServiceBasicService.SaveInformation(userBase, inputInpatientInfo);
            //hospitalGeneralCatalogBase.SubmitForm(organizeEntity, keyValue, userBase);
            return Success("更新"+ resultData.Count+"条信息!!!");
        }
        [System.Web.Http.HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            hospitalGeneralCatalogBase.DeleteForm(keyValue);
            return Success("删除成功。");
        }
    }
}
