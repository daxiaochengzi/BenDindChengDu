using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.InHospital.OutHandFallback
{
    /// <summary>
    /// 出院办理回退-交易输入
    /// </summary>
    [XmlRoot("data", IsNullable = false)]
    public class OutFallbackDataXmlDto
    {
        /// <summary>
        /// 经办人姓名
        /// </summary>
        [XmlElement("aae011")]
        public string ResponsiblePerson { get; set; }
    }
}