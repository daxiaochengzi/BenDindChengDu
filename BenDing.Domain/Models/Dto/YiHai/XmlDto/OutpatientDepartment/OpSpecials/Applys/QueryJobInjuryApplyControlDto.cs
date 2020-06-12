using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.OpSpecials
{
    /// <summary>
    /// 门诊特殊病、工伤门诊、工伤康复住院申请查询（16） 控制
    /// </summary>
    [XmlRoot("control", IsNullable = false)]
    public class QueryJobInjuryApplyControlDto
    {
        /// <summary>
        /// 申请流水号
        /// </summary>
        [XmlElementAttribute("ykc112")]
        public string SerialNo { get; set; }
        /// <summary>
        /// 医保经办机构编号
        /// </summary>
        [XmlElementAttribute("yab003")]
        public string AgentOrgCode { get; set; }

        /// <summary>
        /// 就诊编码
        /// </summary>
        [XmlElementAttribute("akc190")]
        public string VisitCode { get; set; }
        /// <summary>
        /// 个人编码
        /// </summary>
        [XmlElementAttribute("aac001")]
        public string PersonCode { get; set; }
        /// <summary>
        /// 支付类别【0202：城镇职工门诊特殊病、0204：城乡居民门诊特殊病】
        /// </summary>
        [XmlElementAttribute("aka130")]
        public string PayType { get; set; }

        /// <summary>
        /// 查询类型【1为查询门特治疗方案和工伤门诊，2为查询人员申请过的门诊特殊病病种，查询类型默认为1】
        /// </summary>
        [XmlElementAttribute("cxlx")]
        public string QueryType { get; set; }


    }



}
