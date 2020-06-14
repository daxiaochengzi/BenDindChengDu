using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.OpSpecials
{
    /// <summary>
    /// 新门特病种认定查询（122）控制
    /// </summary>
    [XmlRoot("data", IsNullable = false)]
    public class QuerySickTypeCognizanceControlDto
    {     /// <summary>
          /// 医保经办机构
          /// </summary>
        [XmlElementAttribute("yab003")]
        public string AgentOrgCode { get; set; }

        /// <summary>
        /// 个人编码
        /// </summary>
        [XmlElement("aac001")]
        public string PersonCode { get; set; }
    }

}
