using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.InHospital.DischargeForHospital
{
    /// <summary>
    /// 出院办理-交易控制
    /// </summary>
    [XmlRoot("control", IsNullable = false)]
    public class DischargeForHospitalControlXmlDto
    {
        /// <summary>
        /// 入院办理返回
        /// </summary>
        [XmlElementAttribute("akc190")]
        public string InpatientFixedEncoding { get; set; }

        /// <summary>
        /// 个人编号
        /// </summary>
        [XmlElement("aac001")]
        public string PersonalNum { get; set; }

        /// <summary>
        ///  支付类别-代码
        /// </summary>
        [XmlElement("aka130")]
        public string PayType { get; set; }

        /// <summary>
        /// 医保经办机构
        /// </summary>
        [XmlElement("yab003")]
        public string HealthCareInstitutions { get; set; }


        /// <summary>
        /// 接口版本标志
        /// </summary>
        [XmlElement("edition")]
        public string Edition { get; set; } = "5.0";

    }
}