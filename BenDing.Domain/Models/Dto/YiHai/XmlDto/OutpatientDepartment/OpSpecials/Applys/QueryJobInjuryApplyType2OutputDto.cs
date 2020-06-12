using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.OpSpecials
{

    /// <summary>
    /// 门诊特殊病、工伤门诊、工伤康复住院申请查询（16） 出参--查询类型2
    /// </summary>
    [XmlRoot("output", IsNullable = false)]
    public class QueryJobInjuryApplyType2OutputDto
    {


        /// <summary>
        /// 门诊特殊病信息明细
        /// </summary>
        [XmlArrayAttribute("datasetxm")]
        [XmlArrayItem("row")]
        public List<QueryJobInjuryApplyType2OutputDetail> Details { get; set; }
    }
    /// <summary>
    /// 门诊特殊病信息
    /// </summary>
    [XmlType(AnonymousType = true)]
    public class QueryJobInjuryApplyType2OutputDetail
    {

        /// <summary>
        /// 病种编码
        /// </summary>
        [XmlAttribute("yka026")]
        public string SickTypeCode { get; set; }

        /// <summary>
        /// 病种名称
        /// </summary>
        [XmlAttribute("yka027")]
        public string SickTypeName { get; set; }
        /// <summary>
        /// 病种付费方式
        /// </summary>
        [XmlAttribute("yka441")]
        public string PayType { get; set; }



    }

}
