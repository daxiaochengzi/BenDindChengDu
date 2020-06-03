using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.Resident;

namespace BenDing.Domain.Models.Dto.YiHai.OutpatientDepartment
{
   public class QueryOutpatientSettlementCost
    { /// <summary>
        /// 姓名
        /// </summary>

        public string PatientName { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>

        public string IdCardNo { get; set; }
        /// <summary>
        /// 性别
        /// </summary>

        public string PatientSex { get; set; }
        /// <summary>
        /// 业务ID
        /// </summary>

        public string BusinessId { get; set; }
        /// <summary>
        /// 门诊号
        /// </summary>

        public string OutpatientNumber { get; set; }
        /// <summary>
        /// 发票号
        /// </summary>

        public string InvoiceNo { get; set; }
        /// <summary>
        /// 就诊日期
        /// </summary>

        public string VisitDate { get; set; }
        /// <summary>
        /// 科室
        /// </summary>

        public string DepartmentName { get; set; }


        /// <summary>
        /// 诊断医生
        /// </summary>

        public string DiagnosticDoctor { get; set; }

        /// <summary>
        /// 经办人
        /// </summary>

        public string Operator { get; set; }
        /// <summary>
        /// 结算信息
        /// </summary>
        public List<PayMsgData> PayMsg { get; set; } = null;

    }
}
