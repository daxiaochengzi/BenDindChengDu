using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.InHospital.HospitalSubsidiaryWrite
{
    /// <summary>
    /// 	住院费用明细写入-交易输出详细
    /// </summary>
    [XmlRoot("output", IsNullable = false)]
    public class HospitalSubsidiaryWriteOutPutXmlDto
    {
        [XmlElement("dataset")]
        [XmlArrayItem("row")]
        public List<HospitalSubsidiaryWriteOutRow> Rows { get; set; }
    }
    [XmlTypeAttribute(AnonymousType = true)]
    public class HospitalSubsidiaryWriteOutRow
    {
        /// <summary>
        /// 记账流水号
        /// </summary>
        [XmlElement("yka105")]
        public string DocumentNo { get; set; }

        /// <summary>
        /// 项目限价
        /// </summary>
        [XmlElementAttribute("yka299")]
        public decimal LimitPrice { get; set; }

        /// <summary>
        ///自付比例
        /// </summary>
        [XmlElementAttribute("yka096")]
        public decimal SelfPayProportion { get; set; }
        /// <summary>
        ///  全自费
        /// </summary>
        [XmlElementAttribute("yka056")]
        public decimal TotalSelfPay { get; set; }

        /// <summary>
        ///  挂钩自付
        /// </summary>
        [XmlElementAttribute("yka057")]
        public decimal HookSelfPay { get; set; }
        /// <summary>
        /// 符合范围
        /// </summary>
        [XmlElementAttribute("yka111")]
        public decimal UseRange { get; set; }
        /// <summary>
        /// 限制使用
        /// </summary>
        [XmlElementAttribute("yke011")]
        public string LimitUse { get; set; }
    }
}