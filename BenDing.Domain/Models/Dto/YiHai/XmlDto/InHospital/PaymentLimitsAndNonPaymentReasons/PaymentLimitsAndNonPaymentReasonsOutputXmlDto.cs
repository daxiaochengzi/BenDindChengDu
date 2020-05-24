using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.InHospital.PaymentLimitsAndNonPaymentReasons
{
    /// <summary>
    /// 查询住院和门诊统筹支付限额和不支付原因-输出
    /// </summary>
    [XmlRoot("output", IsNullable = false)]
    public class PaymentLimitsAndNonPaymentReasonsOutputXmlDto
    {
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
        ///不能支付统筹原因
        /// </summary>
        [XmlElement("fsyy")]
        public string Reason { get; set; }

        /// <summary>
        /// 报销比例
        /// </summary>
        [XmlElementAttribute("ykc125")]
        public decimal ReimbursementProportion { get; set; }



    }
}