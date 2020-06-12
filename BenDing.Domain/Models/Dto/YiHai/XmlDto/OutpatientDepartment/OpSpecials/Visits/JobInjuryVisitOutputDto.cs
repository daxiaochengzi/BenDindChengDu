using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.OpSpecials
{   /// <summary>
    /// 工伤门诊就诊  出参
    /// </summary>
    [XmlRoot("output", IsNullable = false)]
    public class JobInjuryVisitOutputDto
    {
        /// <summary>
        /// 定点服务机构
        /// </summary>
        [XmlElementAttribute("akb020")]
        public string PointServiceOrg { get; set; }
        /// <summary>
        /// 医保经办机构编号
        /// </summary>
        [XmlElementAttribute("yab003")]
        public string AgentOrgCode { get; set; }

        /// <summary>
        /// 支付类别【0202：城镇职工门诊特殊病、0204：城乡居民门诊特殊病；0501：工伤门诊】
        /// </summary>
        [XmlElementAttribute("aka130")]
        public string PayType { get; set; }

        /// <summary>
        /// 就诊编码
        /// </summary>
        [XmlElementAttribute("akc190")]
        public string VisitCode { get; set; }
        /// <summary>
        /// 个人编码
        /// </summary>
        [XmlElementAttribute("aac001")]
        public string PersonCode { get; set; }
        /// <summary>
        /// 病人姓名
        /// </summary>
        [XmlElementAttribute("aac003")]
        public string PatientName { get; set; }
        /// <summary>
        /// 病人性别 1男 2女
        /// </summary>
        [XmlElementAttribute("aac004")]
        public string PatientSex { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        [XmlElementAttribute("aac006")]
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 医疗人员类别
        /// </summary>
        [XmlElementAttribute("akc021")]
        public string PatientType { get; set; }


        /// <summary>
        ///  病种编码
        /// </summary>
        [XmlAttribute("yka026")]
        public string SickTypeCode { get; set; }

        /// <summary>
        /// 起付线
        /// </summary>
        [XmlElementAttribute("yka115")]

        public decimal Deductible { get; set; }

        /// <summary>
        ///本次医疗支付限额
        /// </summary>
        [XmlElement("yka119")]
        public decimal LimitMoney { get; set; }

        /// <summary>
        ///其他说明
        /// </summary>
        [XmlElement("aae013")]
        public decimal OtherInfo { get; set; }

    }
}
