using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.OutpatientDepartment
{
  public  class QueryUncertainTransactionDto
    {
        /// <summary>
        /// 交易流水号
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// 就诊编号
        /// </summary>
       
        public string VisitNo { get; set; }
        /// <summary>
        /// 结算编号
        /// </summary>
      
        public string SettlementNo { get; set; }
        /// <summary>
        /// 报销类型
        /// </summary>
     
        public string ReimbursementType { get; set; }
    }
}
