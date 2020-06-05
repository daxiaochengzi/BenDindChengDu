using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Dto.YiHai.OutpatientDepartment
{
   public class BaseRefundDto
    {/// <summary>
    /// Id
    /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 就诊编号
        /// </summary>
        public  string VisitNo { get; set; }
        /// <summary>
        /// 病人姓名
        /// </summary>
        public  string PatientName { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdCardNo { get; set; }
        /// <summary>
        /// 门诊号
        /// </summary>
        public string OutpatientNo { get; set; }
        /// <summary>
        /// 住院号
        /// </summary>
        public string InpatientNo { get; set; }
        
        /// <summary>
        /// 就诊步骤
        /// </summary>

        public  string ProcessStep { get; set; }
        /// <summary>
        /// 操作人员
        /// </summary>
        public string OperationName { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperationTime { get; set; }
    }
}
