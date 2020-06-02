using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.OutpatientDepartment.OutpatientSettlementPrint
{
    /// <summary>
    /// 打印控制参数
    /// </summary>
    [XmlRoot("output", IsNullable = false)]
    public  class OutpatientSettlementPrintControlXmlDto
    {
        /// <summary>
        /// 就诊编号
        /// </summary>
        [XmlElement("akc190", IsNullable = false)]
        public string VisitNo { get; set; }
        /// <summary>
        /// 结算编号
        /// </summary>
        [XmlElement("yka103", IsNullable = false)]
        public  string SettlementNo { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>

        [XmlElementAttribute("aka130", IsNullable = false)]

        public string PayType { get; set; }
        /// <summary>
        /// 个人编号
        /// </summary>
        [XmlElementAttribute("aac001", IsNullable = false)]

        public string PersonalCoding { get; set; }
        /// <summary>
        /// 医保经办机构
        /// </summary>
        [XmlElementAttribute("yab003", IsNullable = false)]
        public string MedicalInsuranceOrganization { get; set; }
    } 
}
