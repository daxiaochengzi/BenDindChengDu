using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.OpSpecials
{
    /// <summary>
    /// 工伤门诊结算回退 入参
    /// </summary>
    [XmlRoot("data", IsNullable = false)]
    public class JobInjurySettlementInputDto
    {

        /// <summary>
        /// 明细费用总额
        /// </summary>
        [XmlElement("yka055")]
        public string TotalMoney { get; set; }

        /// <summary>
        /// 本次写入明细条数
        /// </summary>
        [XmlElement("nums")]
        public string DetailNum { get; set; }


        /// <summary>
        /// 发票号
        /// </summary>
        [XmlElementAttribute("yka110")]
        public string InvoiceNo { get; set; }

        /// <summary>
        /// 结算日期
        /// </summary>
        [XmlElement("akc194")]
        public DateTime SettlementDate { get; set; }

        /// <summary>
        /// 疾病诊断明细
        /// </summary>
        [XmlArrayAttribute("ykd018dataset")]
        [XmlArrayItem("row")]
        public List<SettlementInputDetail> Details { get; set; }


    }

    public class SettlementInputDetail
    {
        /// <summary>
        /// 疾病诊断代码-参见疾病诊断代码信息
        /// </summary>
        [XmlElement("ykd018")]
        public string DiagnosticCode { get; set; }

        /// <summary>
        /// 疾病诊断序号
        /// </summary>
        [XmlElement("xh")]
        public string SortNo { get; set; }
    }

}
