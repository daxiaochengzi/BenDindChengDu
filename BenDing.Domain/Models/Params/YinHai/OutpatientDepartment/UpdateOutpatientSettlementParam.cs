using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Params.YinHai.OutpatientDepartment
{
  public  class UpdateOutpatientSettlementParam
    {
        public string VisitNo { get; set; }
        /// <summary>
        /// 业务id
        /// </summary>
        public string BusinessId { get; set; }
        /// <summary>
        /// 步骤
        /// </summary>
        public int? ProcessStep { get; set; } = null;
        /// <summary>
        /// 支付类型
        /// </summary>
        public string PayType { get; set; }
        /// <summary>
        /// 个人编号
        /// </summary>
        public  string PersonalCode { get; set; }
    } 
}
