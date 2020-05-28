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
        public int? ProcessStep { get; set; } = null;
    } 
}
