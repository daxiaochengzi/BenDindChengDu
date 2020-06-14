using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.OpSpecials
{   /// <summary>
    /// 门诊特殊病、工伤门诊新申请（14A）出参
    /// </summary>
    [XmlRoot("output", IsNullable = false)]
    public class JobInjuryApplyOutputDto
    {
        /// <summary>
        /// 申请流水号
        /// </summary>
        [XmlElementAttribute("ykc112")]
        public string SerialNo { get; set; }
        /// <summary>
        /// 个人编码
        /// </summary>
        [XmlElementAttribute("aac001")]
        public string MedicalInsuranceOrganization { get; set; }
        /// <summary>
        /// 支付类别 【0202：城镇职工门诊特殊病、0204：城乡居民门诊特殊病；0501：工伤门诊】
        /// </summary>
        [XmlElementAttribute("aka130")]
        public string PayType { get; set; }

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
        public string Birthday { get; set; }
        /// <summary>
        /// 医疗人员类别
        /// </summary>
        [XmlElementAttribute("akc021")]
        public string PatientType { get; set; }
        /// <summary>
        /// 医保经办机构编号
        /// </summary>
        [XmlElementAttribute("yab003")]
        public string AgentOrgCode { get; set; }
        /// <summary>
        ///  门特开始时间
        /// </summary>
        [XmlElementAttribute("aae130")]
        public string OpSpecialStartTime { get; set; }
        /// <summary>
        ///  门特结束时间
        /// </summary>
        [XmlElementAttribute("aae131")]
        public string OpSpecialEndTime { get; set; }
        /// <summary>
        ///  资格审批号
        /// </summary>
        [XmlElementAttribute("ykc019")]
        public string ApprovalNo { get; set; }


        /// <summary>
        /// 门特信息列表
        /// </summary>
        [XmlArrayAttribute("dataset")]
        [XmlArrayItem("row")]
        public List<JobInjuryApplyOutputDetail> Details { get; set; }


    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class JobInjuryApplyOutputDetail
    {
        /// <summary>
        /// 门诊特殊病病种编码
        /// </summary>
        [XmlElementAttribute("yka026")]
        public string SickTypeCode { get; set; }
        /// <summary>
        /// 门诊特殊病病种名称
        /// </summary>
        [XmlElementAttribute("yka027")]

        public string SickTypeName { get; set; }
        /// <summary>
        ///病种付费方式
        /// </summary>
        [XmlElementAttribute("yka441")]

        public decimal PayType { get; set; }

    }


}
