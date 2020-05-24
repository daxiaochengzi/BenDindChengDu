﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.InHospital.PaymentLimitsAndNonPaymentReasons
{
    /// <summary>
    ///查询住院和门诊统筹支付限额和不支付原因-交易控制
    /// </summary>
    [XmlRoot("control", IsNullable = false)]
    public class PaymentLimitsAndNonPaymentReasonsControlXmlDto
    {
        /// <summary>
        /// 就诊编码
        /// </summary>
        [XmlElementAttribute("akc190")]
        public string OperatorName { get; set; }

        /// <summary>
        /// 个人编码
        /// </summary>
        [XmlElement(" aac001")]
        public string PersonNum { get; set; }


        /// <summary>
        /// 医保经办机构
        /// </summary>
        [XmlElement("yab003")]
        public string HealthCareInstitutions { get; set; }

        /// <summary>
        /// 支付类别-代码
        /// </summary>
        [XmlElement(" aka130")]
        public string PayCategory { get; set; }

    }
}