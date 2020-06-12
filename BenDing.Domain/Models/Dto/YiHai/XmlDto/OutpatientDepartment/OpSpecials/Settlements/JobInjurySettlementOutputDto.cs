using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.OpSpecials
{   /// <summary>
    /// 工伤门诊结算回退 入参
    /// </summary>
    [XmlRoot("output", IsNullable = false)]
    public class JobInjurySettlementOutputDto
    {
        /// <summary>
        /// 就诊编码
        /// </summary>
        [XmlElementAttribute("akc190")]
        public string VisitCode { get; set; }


        /// <summary>
        /// 结算编号
        /// </summary>
        [XmlElement("yka103", IsNullable = false)]
        public string SettlementNo { get; set; }

        /// <summary>
        /// 支付类别【0202：城镇职工门诊特殊病、0204：城乡居民门诊特殊病；0501：工伤门诊】
        /// </summary>
        [XmlElementAttribute("aka130")]
        public string PayType { get; set; }

        /// <summary>
        /// 报销类别
        /// </summary>
        [XmlElementAttribute("ykd007")]
        public string ReimbursementType { get; set; }

        /// <summary>
        /// 个人编码
        /// </summary>
        [XmlElementAttribute("aac001")]
        public string PersonCode { get; set; }

        /// <summary>
        /// 医院编码
        /// </summary>
        [XmlElement("akb020")]
        public string ServiceOrganizationNo { get; set; }

        /// <summary>
        ///  经办人姓名
        /// </summary>
        [XmlElementAttribute("aae011")]
        public string OperationName { get; set; }

        /// <summary>
        /// 经办时间
        /// </summary>
        [XmlElement("aae036")]
        public DateTime HandleTime { get; set; }


        /// <summary>
        /// 明细费用总额
        /// </summary>
        [XmlElement("yka055")]
        public decimal TotalMoney { get; set; }

        /// <summary>
        ///  全自费
        /// </summary>
        [XmlElementAttribute("yka056")]
        public decimal TotalSelfPay { get; set; }

        /// <summary>
        /// 符合范围
        /// </summary>
        [XmlElementAttribute("yka111")]
        public decimal UseRange { get; set; }

        /// <summary>
        ///  挂钩自付
        /// </summary>
        [XmlElementAttribute("yka057")]
        public decimal HookSelfPay { get; set; }


        /// <summary>
        ///  帐户余额
        /// </summary>
        [XmlElementAttribute("ykc177")]
        public decimal AccountBalance { get; set; }


        /// <summary>
        /// 社保支付总合计
        /// </summary>
        [XmlElement("yka107", IsNullable = false)]
        public decimal MedicalInsurancePayTotalAmount { get; set; }
        /// <summary>
        /// 账户支付
        /// </summary>
        [XmlElement("yka065", IsNullable = false)]
        public decimal PersonAccountPay { get; set; }

        /// <summary>
        /// 个人账户共济标志【1 是 ；0否】
        /// </summary>
        [XmlElement("yka719", IsNullable = false)]
        public decimal PersonAccountFreemasonryTag { get; set; }
        /// <summary>
        /// 现金支付
        /// </summary>
        [XmlElementAttribute("ykh012")]
        public decimal CashPayment { get; set; }


        /// <summary>
        /// 医保经办机构
        /// </summary>
        [XmlElementAttribute("yab003")]
        public string AgentOrgCode { get; set; }
        /// <summary>
        /// 疾病诊断明细
        /// </summary>
        [XmlArrayAttribute("datayka065")]
        public List<AccountFreemasonryDetail> AccountFreemasonryDetails { get; set; }

        /// <summary>
        /// 疾病诊断明细
        /// </summary>
        [XmlArrayAttribute("dataset")]
        [XmlArrayItem("row")]
        public List<SettlementDetail> SettlementDetails { get; set; }
    }

    /// <summary>
    /// 家庭共济账户明细
    /// </summary>
    public class AccountFreemasonryDetail
    {
        /// <summary>
        /// 疾病诊断代码-参见疾病诊断代码信息
        /// </summary>
        [XmlElement("num")]
        public string DiagnosticCode { get; set; }

        /// <summary>
        /// 疾病诊断明细
        /// </summary>
        [XmlArrayAttribute("dataset")]
        [XmlArrayItem("row")]
        public List<AccountFreemasonryDataset> Datas { get; set; }

    }

    public class AccountFreemasonryDataset
    {
        /// <summary>
        /// 社保编码
        /// </summary>
        [XmlElementAttribute("aac001")]
        public string SocialSecurityCode { get; set; }

        /// <summary>
        ///身份证
        /// </summary>
        [XmlElementAttribute("aac002", IsNullable = false)]
        public string IdCardNo { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [XmlElement("aac003")]
        public string Name { get; set; }

        /// <summary>
        /// 账户支付
        /// </summary>
        [XmlElement("yka065", IsNullable = false)]
        public decimal PersonAccountPay { get; set; }

        /// <summary>
        /// 所属行政区划
        /// </summary>
        [XmlElementAttribute("yab003")]
        public string AgentOrgCode { get; set; }

        /// <summary>
        ///  帐户余额
        /// </summary>
        [XmlElementAttribute("ykc177")]
        public decimal AccountBalance { get; set; }

        /// <summary>
        ///  人员关系【1 父母 2 子女 3 配偶 4 其他 5 本人】
        /// </summary>
        [XmlElementAttribute("ykc178")]
        public int Relationship { get; set; }
    }

    public class SettlementDetail
    {
        /// <summary>
        /// 参保中心
        /// </summary>
        [XmlElementAttribute("yab139")]
        public string InsuranceCenter { get; set; }
        /// <summary>
        /// 费用分段标准
        /// </summary>
        [XmlElementAttribute("aka213")]

        public string CostSegment { get; set; }
        /// <summary>
        ///起付线
        /// </summary>
        [XmlElementAttribute("yka115")]

        public decimal Deductible { get; set; }
        /// <summary>
        ///进入起付线
        /// </summary>
        [XmlElementAttribute("yka058")]
        public decimal InputDeductible { get; set; }
        /// <summary>
        /// 报销比例
        /// </summary>
        [XmlElementAttribute("ykc125")]
        public decimal ReimbursementProportion { get; set; }

        /// <summary>
        /// 社保基金支付金额
        /// </summary>
        [XmlElementAttribute("yka107")]
        public decimal MedicalInsurancePayTotal { get; set; }

        /// <summary>
        /// 个人账户支付
        /// </summary>
        [XmlElementAttribute("yka065")]
        public decimal AccountPay { get; set; }

        /// <summary>
        /// 就诊结算方式
        /// </summary>
        [XmlElementAttribute("ykc121")]
        public string SettlementType { get; set; }
        /// <summary>
        /// 清算分中心
        /// </summary>
        [XmlElementAttribute("ykb037")]
        public string SettlementPlaceCenter { get; set; }
        /// <summary>
        /// 清算方式
        /// </summary>
        [XmlElementAttribute("yka054")]
        public string CenterSettlementType { get; set; }
        /// <summary>
        /// 清算类别  城镇职工:城镇职工门;城乡居民城:乡居民门诊;
        /// </summary>
        [XmlElementAttribute("yka316")]
        public string CenterSettlementCostType { get; set; }
    }
}
