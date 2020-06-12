using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.OpSpecials
{
    /// <summary>
    /// 工伤门诊回退入参
    /// </summary>
    [XmlRoot("data", IsNullable = false)]
    public class CacelJobInjurySettlementInputDto
    {   /// <summary>
        /// 费用总额
        /// </summary>
        [XmlElementAttribute("yka055")] 
        public decimal TotolAmount { get; set; }
        /// <summary>
        /// 社保支付总合计
        /// </summary>
        [XmlElement("yka107", IsNullable = false)]
        public decimal MedicalInsurancePayTotalAmount { get; set; }
        /// <summary>
        /// 个人账户支付
        /// </summary>
        [XmlElement("yka065", IsNullable = false)]
        public decimal PersonAccountPay { get; set; }


    }

}
