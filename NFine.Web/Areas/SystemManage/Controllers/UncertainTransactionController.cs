using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BenDing.Domain.Models.Params.YinHai.OutpatientDepartment;
using BenDing.Service.Interfaces.YiHaiWeb;
using NFine.Code;

namespace NFine.Web.Areas.SystemManage.Controllers
{
    public class UncertainTransactionController : ControllerBase
    {
        private readonly IYiHaiOutpatientDepartmentService _yiHaiOutpatientDepartmentService;
      

        public UncertainTransactionController()
        {
            _yiHaiOutpatientDepartmentService = Bootstrapper.UnityIOC.Resolve<IYiHaiOutpatientDepartmentService>();
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string startTime, string endTime)
        {
            //获取查询结果
            var queryData = _yiHaiOutpatientDepartmentService.QueryUncertainTransaction();
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