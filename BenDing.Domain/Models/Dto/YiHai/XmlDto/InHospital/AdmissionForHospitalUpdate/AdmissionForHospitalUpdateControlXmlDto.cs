using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.InHospital.AdmissionForHospitalUpdate
{
    /// <summary>
    ///入院办理信息修改-交易控制
    /// </summary>
    [XmlRoot("control", IsNullable = false)]
    public class AdmissionForHospitalUpdateControlXmlDto
    {
        /// <summary>
        /// 就诊编号 len(20)
        /// </summary>
        [XmlElement("akc190")]
        public string InpatientFixedEncoding { get; set; }
        /// <summary>
        /// 医保个人编号 
        /// </summary>
        [XmlElement("aac001")]
        public string PersonalCoding { get; set; }
        /// <summary>
        /// 支付类别 (城职门诊0201,城居门诊0203)
        /// </summary>
        [XmlElement("aka130")]
        public string PayType { get; set; }

        /// <summary>
        /// 医保经办机构
        /// </summary>
        [XmlElement("yab003")]
        public string HealthCareInstitutions { get; set; }

        /// <summary>
        /// 是否改变清算方式 可选。1：改变；其他或不传：不改变
        /// </summary>
        [XmlElement("change")]
        public int IsChangePayWay { get; set; }

        /// <summary>
        /// 改变后的清算方式-  01：按项目清算（默认）；02：按日包干；03：单病种
        /// </summary>
        [XmlElement("yka054")]
        public int ChangeAfterPayWay { get; set; }

        /// <summary>
        ///  接口版本标志
        /// </summary>
        [XmlElement("edition")]
        public string Edition { get; set; } = "5.0";
    }
}