using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace BenDing.Domain.Models.Params.YinHai
{
    [XmlRoot("data", IsNullable = false)]
    public class TestParam
    {
        /// <summary>
        /// 医保住院号
        /// </summary>
        [XmlElement("akc190", IsNullable = false)]
        public string MedicalInsuranceHospitalizationNo { get; set; }

        /// <summary>
        ///  
        /// </summary>
        [XmlArrayAttribute("datasetyz")]
        [XmlArrayItem("row")]
        public List<TestParamRow> RowDataList { get; set; }
    }
}

[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class TestParamRow
{/// <summary>
 /// 流水号
 /// </summary>
    [XmlElementAttribute("ykc120", IsNullable = false)]
        public string SerialNumber { get; set; }

    }

    

