using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;


namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.InHospital.AdmissionForHospital
{
    /// <summary>
    /// 入院办理-输出
    /// </summary>
    [XmlRoot("output", IsNullable = false)]
    public class AdmissionForHospitalOutPutXmlDto
    {
        /// <summary>
        /// 服务机构编号
        /// </summary>
        [XmlElement("akb020")]
        public string ServiceOrganizationNo { get; set; }

        /// <summary>
        /// 医保经办机构
        /// </summary>
        [XmlElement("yab003")]
        public string HealthCareInstitutions { get; set; }

        /// <summary>
        /// 支付类别-代码
        /// </summary>
        /// 【如果选择普通入院，返回支付类别为城职普通入院或城居普通入院】
        /// 【如果选择外伤入院，返回支付类别为城职外伤入院或城居外伤入院】
        [XmlElement("aka130")]
        public string PayType { get; set; }

        /// <summary>
        /// 就诊编号-唯一标识一次住院，中心生成
        /// </summary>
        [XmlElementAttribute("akc190")]
        public string InpatientFixedEncoding { get; set; }

        /// <summary>
        /// 个人编号
        /// </summary>
        [XmlElement("aac001")]
        public string PersonalNum { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [XmlElement("aac003")]
        public string Name { get; set; }

        /// <summary>
        /// 性别-代码
        /// </summary>
        [XmlElement("aac004")]
        public string Sex { get; set; }

        /// <summary>
        ///   出生日期
        /// </summary>
        [XmlElement("aac006")]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        ///医疗人员类别-代码。如果是城乡居民则返回城乡居民来源类别
        /// </summary>
        [XmlElement("akc021")]
        public string MedicalPersonnelType  { get; set; }

        /// <summary>
        /// 病种编码
        /// </summary>
        [XmlElement("yka026")]
        public string DiseasesCode { get; set; }

        /// <summary>
        ///本次起付线
        /// </summary>
        [XmlElement("yka115")]
        public decimal PayMoney { get; set; }

        /// <summary>
        ///本次医疗支付限额
        /// </summary>
        [XmlElement("yka119")]
        public decimal LimitMoney { get; set; }

        /// <summary>
        /// 其他说明
        /// </summary>
        [XmlElement("aae013")]
        public string Other { get; set; }
    }
}