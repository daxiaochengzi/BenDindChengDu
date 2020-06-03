using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BenDing.Domain.Models.Dto.YiHai.XmlDto.OutpatientDepartment;
using Newtonsoft.Json;

namespace BenDing.Domain.Models.Dto.YiHai.JsonEntity
{
  public  class OutpatientSettlementOutputJsonDto
    {/// <summary>
        /// 就诊编号
        /// </summary>
        [JsonProperty(PropertyName = "就诊编号")]
        public string VisitNo { get; set; }
        ///// <summary>
        ///// 支付方式
        ///// </summary>
        //[JsonProperty(PropertyName = "支付方式")]

        //public string PayType { get; set; }
        /// <summary>
        /// 个人编号
        /// </summary>
        [JsonProperty(PropertyName = "个人编号")]

        public string PersonalCoding { get; set; }
        /// <summary>
        /// 医院编号
        /// </summary>
        [JsonProperty(PropertyName = "医院编号")]
        public string HospitalNo { get; set; }

        /// <summary>
        /// 结算编号
        /// </summary>
      
        [JsonProperty(PropertyName = "结算编号")]
        public string SettlementNo { get; set; }

        /// <summary>
        /// 合计金额
        /// </summary>
       
        [JsonProperty(PropertyName = "合计金额")]
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// 现金支付
        /// </summary>
    
        [JsonProperty(PropertyName = "现金支付")]
        public decimal SelfPayFeeAmount { get; set; }

        /// <summary>
        /// 社保支付总合计
        /// </summary>
    
        [JsonProperty(PropertyName = "社保支付总合计")]
        public decimal MedicalInsurancePayTotalAmount { get; set; }
        /// <summary>
        /// 账户支付
        /// </summary>
      
        [JsonProperty(PropertyName = "账户支付")]
        public decimal AccountPay { get; set; }
        /// <summary>
        ///  账户类型
        /// </summary>
        [JsonProperty(PropertyName = "账户类型")]
        public string AccountType { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
       
        [JsonProperty(PropertyName = "账户余额")]
        public decimal Balance { get; set; }
    }
}
