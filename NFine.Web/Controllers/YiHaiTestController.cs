using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BenDing.Domain.Models.Params.UI;
using BenDing.Domain.Models.Params.YinHai;
using BenDing.Domain.Xml;

namespace NFine.Web.Controllers
{
    public class YiHaiTestController : ApiController
    {
        [HttpGet]
        public ApiJsonResultData XmlTestParam([FromUri] UiInIParam param)
        {
            return new ApiJsonResultData(ModelState, new UiInIParam()).RunWithTry(y =>
            {
                var ddd = new TestParam();
                ddd.MedicalInsuranceHospitalizationNo = "3434";
                //
                   var cc = new List<TestParamRow>();
                cc.Add(new TestParamRow(){SerialNumber = "2333"});
                ddd.RowDataList = cc;
              //var csss=  XmlSerializeHelper.YinHaiXmlSerialize(ddd);
            });

        }
    }
}
