using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BenDing.Domain.Models.Dto.YiHai.XmlDto.OutpatientDepartment.QueryUncertainTransaction;
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
                //var ddd = new TestParam();
                //ddd.MedicalInsuranceHospitalizationNo = "3434";
                //var cc = new List<TestParamRow>();
                //cc.Add(new TestParamRow(){SerialNumber = "2333"});
                //ddd.RowDataList = cc;
              
                var outputData = new QueryUncertainTransactionOutputXmlDto();
                var listRow = new List<QueryUncertainTransactionOutputRowXmlDto>();
                listRow.Add(new QueryUncertainTransactionOutputRowXmlDto()
                {
                    SerialNumber = "444444",
                    Key = new List<QueryUncertainTransactionOutputRowKeyXmlDto>()
                    {
                        new QueryUncertainTransactionOutputRowKeyXmlDto()
                        { SettlementNo = "123",
                            VisitNo = "4444",
                            ReimbursementType = "333"
                        },new QueryUncertainTransactionOutputRowKeyXmlDto()
                        {
                            SettlementNo = "555",
                            VisitNo = "555",
                            ReimbursementType = "33343"
                        }
                    }
                });
                outputData.Row = listRow;
               var  ddd = XmlSerializeHelper.YinHaiXmlSerialize(outputData);
                //var csss=  XmlSerializeHelper.YinHaiXmlSerialize(ddd);
               var outputDatas = XmlHelp.DeSerializer<QueryUncertainTransactionOutputXmlDto>(ddd);
            });

        }
    }
}
