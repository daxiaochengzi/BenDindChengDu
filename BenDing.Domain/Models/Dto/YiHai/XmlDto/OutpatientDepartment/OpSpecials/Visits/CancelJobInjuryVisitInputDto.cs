using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.OpSpecials
{
    /// <summary>
    /// 取消工伤门诊就诊入参
    /// </summary>
    [XmlRoot("data", IsNullable = false)]
    public class CancelJobInjuryVisitInputDto
    {   
        /// <summary>
        /// 经办人姓名
        /// </summary>
        [XmlElementAttribute("ykc013")]
        public string AgentName { get; set; }     
      


    }

}
