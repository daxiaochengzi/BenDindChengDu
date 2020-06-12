using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.OpSpecials
{
    /// <summary>
    /// 工伤门诊回退  控制
    /// </summary>
    [XmlRoot("control", IsNullable = false)]
    public class CacelJobInjurySettlementControlDto
    {
        /// <summary>
        /// 就诊编码
        /// </summary>
        [XmlElementAttribute("akc190")]
        public string VisitCode { get; set; }

        /// <summary>
        /// 结算编号
        /// </summary>
        [XmlElementAttribute("yka103")]
        public string SettlementNo { get; set; }
        /// <summary>
        /// 支付类别【0202：城镇职工门诊特殊病、0204：城乡居民门诊特殊病；0501：工伤门诊】
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
