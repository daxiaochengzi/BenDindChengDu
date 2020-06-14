using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.OpSpecials
{
    /// <summary>
    /// 新门特病种认定（120）控制
    /// </summary>
    [XmlRoot("data", IsNullable = false)]
    public class SickTypeCognizanceControlDto
    {     /// <summary>
          /// 医保经办机构
          /// </summary>
        [XmlElementAttribute("yab003")]
        public string AgentOrgCode { get; set; }
    }

}
