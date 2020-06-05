using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BenDing.Domain.Models.Params.YinHai.OutpatientDepartment;
using BenDing.Repository.Interfaces.YiHaiWeb;
using BenDing.Service.Interfaces;
using NFine.Application.SystemManage;
using NFine.Code;

namespace NFine.Web.Areas.SystemManage.Controllers
{
    public class BaseRefundController : ControllerBase
    {
        private UserApp userApp = new UserApp();
        private readonly IWebServiceBasicService _webServiceBasicService;
        private readonly IYiHaiSqlRepository _yiHaiSqlRepository;
        
        public BaseRefundController()
        {
            _yiHaiSqlRepository= Bootstrapper.UnityIOC.Resolve<IYiHaiSqlRepository>();
            _webServiceBasicService = Bootstrapper.UnityIOC.Resolve<IWebServiceBasicService>();
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string startTime, string endTime)
        {
            var loginInfo = OperatorProvider.Provider.GetCurrent();
            var user = userApp.GetForm(loginInfo.UserId);
            var param = new BaseRefundUiParam();
            param.EndTime = endTime;
            param.StartTime = startTime;
            param.Limit = pagination.rows;
            param.Page = pagination.page;
            if (string.IsNullOrEmpty(user.F_HisUserId)) throw new Exception("当前用户非基层用户不能操作!!!"); ;
            var userBase = _webServiceBasicService.GetUserBaseInfo(user.F_HisUserId);
            param.OrganizationCode = userBase.OrganizationCode;
            //获取查询结果
            var queryData= _yiHaiSqlRepository.QueryBaseRefund(param);
            var data = new
            {
                rows = queryData.Values.FirstOrDefault(),
                total = pagination.total,
                page = pagination.page,
                records = queryData.Keys.FirstOrDefault()
            };
            return Content(data.ToJson());
        }
    }
}