using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.CancelMedicalInsuranceSignIn
{
    [XmlRoot("data", IsNullable = false)]
    public  class CancelMedicalInsuranceSignInDataXmlDto
    {   /// <summary>
        /// 社保基金支付总额 0.00
        /// </summary>
        [XmlElementAttribute("sbjjzfze", IsNullable = false)]
        public decimal MedicalInsurancePayTotalAmount { get; set; }
        /// <summary>
        /// 社保基金支付总额 0.00
        /// </summary>
        [XmlElementAttribute("jybs", IsNullable = false)]
        public int TransactionFrequency { get; set; }
    }
}
