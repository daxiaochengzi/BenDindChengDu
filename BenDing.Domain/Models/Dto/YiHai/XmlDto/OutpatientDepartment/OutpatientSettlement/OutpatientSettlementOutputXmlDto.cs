﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.OutpatientDepartment
{  /// <summary>
    /// 门诊结算回参
    /// </summary>
    [XmlRoot("output", IsNullable = false)]
    public class OutpatientSettlementOutputXmlDto
    {   /// <summary>
        /// 就诊编号
        /// </summary>
        [XmlElementAttribute("akc190", IsNullable = false)]
        public string VisitNo { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>

        [XmlElementAttribute("aka130", IsNullable = false)]

        public string PayType { get; set; }
        /// <summary>
        /// 个人编号
        /// </summary>
        [XmlElementAttribute("aac001", IsNullable = false)]

        public string PersonalCoding { get; set; }
        /// <summary>
        /// 医院编号
        /// </summary>
        [XmlElementAttribute("akb020", IsNullable = false)]
        public string HospitalNo { get; set; }

        /// <summary>
        /// 结算编号
        /// </summary>
        [XmlElementAttribute("yka103", IsNullable = false)]
        public string SettlementNo { get; set; }

        /// <summary>
        /// 合计金额
        /// </summary>
        [XmlElementAttribute("yka055", IsNullable = false)]
        public decimal TotalAmount { get; set; }
       /// <summary>
       /// 现金支付
       /// </summary>
        [XmlElementAttribute("ykh012", IsNullable = false)]
        public decimal SelfPayFeeAmount { get; set; }
        
        /// <summary>
        /// 社保支付总合计
        /// </summary>
        [XmlElementAttribute("yka107", IsNullable = false)]
        public decimal MedicalInsurancePayTotalAmount { get; set; }
        /// <summary>
        /// 账户支付
        /// </summary>
        [XmlElementAttribute("yka065", IsNullable = false)]
        public decimal AccountPay { get; set; }
        /// <summary>
        /// 个人账户信息
        /// </summary>
        [XmlArrayAttribute("grzhye")]
        [XmlArrayItem("row")]
        public List<PatientAccountInfo>  AccountInfo { get; set; }


    }
    /// <summary>
    /// 个人账户信息
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class PatientAccountInfo
    {/// <summary>
     ///  账户类型
     /// </summary>
        [XmlElementAttribute("ykc303")]
        public string AccountType { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
        [XmlElementAttribute("ykc194")]
        public decimal Balance { get; set; }
    }
}
