using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.OpSpecials
{   /// <summary>
    /// 门诊特殊病、工伤门诊新申请（14A）入参
    /// </summary>
    [XmlRoot("output", IsNullable = false)]
    public class UpdateJobInjuryApplyOutputDto
    {
        /// <summary>
        /// 申请流水号
        /// </summary>
        [XmlElementAttribute("ykc112")]
        public string SerialNo { get; set; }
        /// <summary>
        /// 医保经办机构
        /// </summary>
        [XmlElementAttribute("yab003")]
        public string yab003 { get; set; }
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
      
    
      
       
        


    }
}
