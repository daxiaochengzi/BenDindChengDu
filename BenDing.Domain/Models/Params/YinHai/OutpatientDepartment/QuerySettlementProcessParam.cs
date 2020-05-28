using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Params.YinHai.OutpatientDepartment
{
   public class QuerySettlementProcessParam
    { /// <summary>
    /// 业务id
    /// </summary>
        public string BusinessId { get; set; }
        /// <summary>
        /// 步骤
        /// </summary>
        public int? ProcessStep { get; set; }
    }
}
