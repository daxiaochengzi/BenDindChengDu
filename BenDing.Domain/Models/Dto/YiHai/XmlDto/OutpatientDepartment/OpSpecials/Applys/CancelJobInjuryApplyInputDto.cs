using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.OpSpecials
{
    /// <summary>
    /// 门诊特殊病变更申请（14B）入参
    /// </summary>
    [XmlRoot("data", IsNullable = false)]
    public class CancelJobInjuryApplyInputDto
    {   /// <summary>
        /// 诊断信息
        /// </summary>
        [XmlElementAttribute("ykc112")]
        public string Diagnosis { get; set; }
        /// <summary>
        /// 医院经办人姓名
        /// </summary>
        [XmlElementAttribute("aae011")]
        public string OperatorName { get; set; }
        /// <summary>
        /// 申请的治疗开始时间
        /// </summary>
        [XmlElementAttribute("yae170")]
        public DateTime ApplyStartTime { get; set; }
        /// <summary>
        /// 申请的治疗结束时间
        /// </summary>
        [XmlElementAttribute("yae171")]
        public string ApplyEndTime { get; set; }


        /// <summary>
        /// 治疗明细
        /// </summary>
        [XmlArrayAttribute("dataset")]
        [XmlArrayItem("row")]
        public List<CancelJobInjuryApplyInputDetail> Details { get; set; }
    }
    /// <summary>
    /// 费用明细
    /// </summary>
    [XmlType(AnonymousType = true)]
    public class CancelJobInjuryApplyInputDetail
    {

        /// <summary>
        /// 流水号
        /// </summary>
        [XmlAttribute("yka105")]
        public string BusinessId { get; set; }
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


    }

}
