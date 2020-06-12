using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.OpSpecials
{

    /// <summary>
    /// 门诊特殊病、工伤门诊、工伤康复住院申请查询（16） 出参
    /// </summary>
    [XmlRoot("output", IsNullable = false)]
    public class QueryJobInjuryApplyOutputDto
    {
        /// <summary>
        /// 申请流水号
        /// </summary>
        [XmlElementAttribute("ykc112")]
        public string SerialNo { get; set; }
        /// <summary>
        /// 医院经办人姓名
        /// </summary>
        [XmlElementAttribute("ykc141")]
        public string AgentName { get; set; }

        /// <summary>
        /// 申请的治疗开始时间 【工伤康复住院，工伤门诊：为中心审批生效的开始时间】
        /// </summary>
        [XmlElementAttribute("yae170")]
        public DateTime ApplyStartTime { get; set; }
        ///// <summary>
        ///// 申请的治疗结束时间
        ///// </summary>
        //[XmlElementAttribute("yae171")]
        //public string ApplyEndTime { get; set; }

      
        /// <summary>
        /// 医保经办机构编号
        /// </summary>
        [XmlElementAttribute("yab003")]
        public string AgentOrgCode { get; set; }
        /// <summary>
        /// 个人编码
        /// </summary>
        [XmlElementAttribute("aac001")]
        public string PersonCode { get; set; }
        /// <summary>
        /// 支付类别 【0202：城镇职工门诊特殊病、0204：城乡居民门诊特殊病；0501：工伤门诊】
        /// </summary>
        [XmlElementAttribute("aka130")]
        public string PayType { get; set; }

        /// <summary>
        /// 申请审批标志【00：未审批；10：正常通过；11：特批通过；12：变更通过；20：未通过】
        /// </summary>
        [XmlElementAttribute("yke268")]
        public string ApprovalTag { get; set; }


        /// <summary>
        /// 审批意见
        /// </summary>
        [XmlElementAttribute("yke073")]
        public string ApprovalInfo { get; set; }

        /// <summary>
        /// 治疗明细
        /// </summary>
        [XmlArrayAttribute("datasetxm")]
        [XmlArrayItem("row")]
        public List<QueryJobInjuryApplyOutputDetail> Details { get; set; }
    }
    /// <summary>
    /// 明细
    /// </summary>
    [XmlType(AnonymousType = true)]
    public class QueryJobInjuryApplyOutputDetail
    {
        
        /// <summary>
        /// 医保项目编码
        /// </summary>
        [XmlAttribute("yka094")]
        public string MedicalInsuranceProjectCode { get; set; }

        /// <summary>
        /// 医院项目名称(诊疗项目)
        /// </summary>
        [XmlAttribute("yka095")]
        public string MedicalInsuranceProjectName { get; set; }
        /// <summary>
        /// 用法编号
        /// </summary>
        [XmlAttribute("aka073")]
        public decimal UsageNo { get; set; }
        /// <summary>
        /// 用量
        /// </summary>
        [XmlAttribute("yka293")]
        public decimal UsageCount { get; set; }

        /// <summary>
        /// 用药周期
        /// </summary>
        [XmlAttribute("yka368")]
        public decimal MedicationCycle { get; set; }
        /// <summary>
        ///  物价编码
        /// </summary>
        [XmlAttribute("yaa027")]
        public string PriceCode { get; set; }

        /// <summary>
        ///  病种编码
        /// </summary>
        [XmlAttribute("yka026")]
        public string SickTypeCode { get; set; }

        /// <summary>
        /// 申请审批标志【00：不通过；10：正常通过；13：变更通过】
        /// </summary>
        [XmlElementAttribute("akc175")]
        public string ApprovalTag { get; set; }


        /// <summary>
        /// 审批意见
        /// </summary>
        [XmlElementAttribute("yke073")]
        public string ApprovalInfo { get; set; }


    }

}
