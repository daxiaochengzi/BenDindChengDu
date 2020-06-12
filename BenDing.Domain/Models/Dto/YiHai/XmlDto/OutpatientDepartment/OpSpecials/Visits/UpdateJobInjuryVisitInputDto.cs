using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.OpSpecials
{
    /// <summary>
    /// 修改工伤门诊就诊 入参
    /// </summary>
    [XmlRoot("data", IsNullable = false)]
    public class UpdateJobInjuryVisitInputDto
    {   /// <summary>
        /// 就诊开始时间
        /// </summary>
        [XmlElementAttribute("akc192")]
        public string VisitStartTime { get; set; }
        /// <summary>
        /// 就诊登记经办人
        /// </summary>
        [XmlElementAttribute("ykc013")]
        public string AgentName { get; set; }
        /// <summary>
        /// 就诊登记经办时间
        /// </summary>
        [XmlElementAttribute("ykc014")]
        public string VisitRegTime { get; set; }


    }

}
