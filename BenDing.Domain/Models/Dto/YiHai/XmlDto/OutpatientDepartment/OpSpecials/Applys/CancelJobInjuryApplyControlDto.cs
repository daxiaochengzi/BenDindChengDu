using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.OpSpecials
{
    /// <summary>
    /// 门诊特殊病变更申请交易控制
    /// </summary>
    [XmlRoot("control", IsNullable = false)]
    public class CancelJobInjuryApplyControlDto
    {   
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
        /// 医保经办机构编号
        /// </summary>
        [XmlElementAttribute("yab003")]
        public string AgentOrgCode { get; set; }


    }



}
