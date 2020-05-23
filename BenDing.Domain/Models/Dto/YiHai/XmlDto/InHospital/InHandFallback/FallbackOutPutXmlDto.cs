using System.Collections.Generic;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.InHospital.InHandFallback
{
    /// <summary>
    /// 入院办理回退-输出
    /// </summary>
    [XmlRoot("output", IsNullable = false)]
    public class FallbackOutPutXmlDto
    {
        /// <summary>
        /// row
        /// </summary>
        [XmlArrayItem("row")]
        public List<FallbackOutPutXmlRow> DetailRow { get; set; }
    }

    /// <summary>
    /// 输出-Row
    /// </summary>
    [XmlTypeAttribute(AnonymousType = true)]
    public class FallbackOutPutXmlRow
    {
        /// <summary>
        /// 交易流水号
        /// </summary>
        [XmlElement("yke014")]
        public string TransserialNum { get; set; }

        [XmlElement("key")]
        public FallbackOutPutXmlKeyDto Key { get; set; }

    }
    /// <summary>
    /// Row-key
    /// </summary>
    [XmlTypeAttribute(AnonymousType = true)]
    public class FallbackOutPutXmlKeyDto
    {
        /// <summary>
        /// 就诊编号 len(20)
        /// </summary>
        [XmlElementAttribute("akc190")]
        public string InpatientFixedEncoding { get; set; }
    }
}