using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Dto.Web
{/// <summary>
/// 
/// </summary>
   public class QueryOutpatientDto: BaseOutpatientInfoDto
    {/// <summary>
    /// 就诊编号
    /// </summary>
        public string VisitNo { get; set; }
        /// <summary>
        /// 结算步骤
        /// </summary>
        public  int? ProcessStep { get; set; }
        /// <summary>
        /// 支付类别
        /// </summary>
        public  string PayType { get; set; }
        /// <summary>
        /// 个人编号
        /// </summary>
        public  string PersonalCode { get; set; }
    }
}
