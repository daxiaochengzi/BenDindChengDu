using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BenDing.Domain.Models.Dto.OutpatientDepartment;
using BenDing.Domain.Models.Dto.YiHai.Base;
using BenDing.Domain.Models.Dto.YiHai.MedicalInsuranceSignIn;
using BenDing.Domain.Models.Dto.YiHai.XmlDto.OutpatientDepartment.QueryUncertainTransaction;
using BenDing.Domain.Models.Params.Web;
using BenDing.Domain.Models.Params.YinHai.OutpatientDepartment;
using BenDing.Domain.Xml;
using BenDing.Repository.Interfaces.Web;
using BenDing.Service.Interfaces.YiHaiWeb;
using Newtonsoft.Json;
using NFine.Application.SystemManage;
using NFine.Code;

namespace NFine.Web.Areas.SystemManage.Controllers
{
    public class UncertainTransactionController : ControllerBase
    {
        private readonly IYiHaiOutpatientDepartmentService _yiHaiOutpatientDepartmentService;
        private readonly ISystemManageRepository _systemManageRepository;
        private UserApp userApp = new UserApp();
     
        public UncertainTransactionController()
        {
            _systemManageRepository = Bootstrapper.UnityIOC.Resolve<ISystemManageRepository>();
            _yiHaiOutpatientDepartmentService = Bootstrapper.UnityIOC.Resolve<IYiHaiOutpatientDepartmentService>();
        }
        [HttpGet]
        [HandlerAuthorize]
        public override ActionResult Index()
        {
            var loginInfo = OperatorProvider.Provider.GetCurrent();
            var userBase = _systemManageRepository.QueryHospitalOperator(new QueryHospitalOperatorParam()
            {
                Id = loginInfo.UserId
            });
           
            ViewBag.empid = userBase.HisUserId;
            return View();
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination,string resultJson)
        {
         
            var dataList = new List<QueryUncertainTransactionDto>();
            if (!string.IsNullOrWhiteSpace(resultJson))
            {
                var resultDto = JsonConvert.DeserializeObject<DealModelDto>(resultJson);
                var outputData = XmlHelp.DeSerializer<QueryUncertainTransactionOutputXmlDto>(resultDto.TransactionOutputXml);
                var outputDataList = outputData.Row;
                foreach (var item in outputDataList)
                {
                    var itemRowKey = item.Key;
                    foreach (var key in itemRowKey)
                    {
                        var itemRow = new QueryUncertainTransactionDto()
                        {
                            SerialNumber = item.SerialNumber,
                            ReimbursementType = key.ReimbursementType,
                            SettlementNo = key.SettlementNo,
                            VisitNo = key.SettlementNo
                        };
                        dataList.Add(itemRow);
                    }


                }
              
            }

           
            var data = new
            {
                rows = dataList,
                total = dataList.Count,
                page = pagination.page,
                records = dataList.Count
            };
            return Content(data.ToJson());
        }

    }
  
}