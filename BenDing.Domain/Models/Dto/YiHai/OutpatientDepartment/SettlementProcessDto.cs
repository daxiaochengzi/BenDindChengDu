using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Dto.YiHai.OutpatientDepartment
{/// <summary>
/// 结算流程
/// </summary>
   public class SettlementProcessDto
    {
        public Guid Id { get; set; }
        /// <summary>
        /// 业务id
        /// </summary>
        public string BusinessId { get; set; }
        /// <summary>
        /// 步骤
        /// </summary>
        public  int ProcessStep { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public string JosnContent { get; set; }
        /// <summary>
        /// 交易批次号
        /// </summary>

        public string BatchNo { get; set; }

        /// <summary>
        /// 交易流水号
        /// </summary>

        public string SerialNumber { get; set; }

        /// <summary>
        /// 交易验证码
        /// </summary>

        public string VerificationCode { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 创建人员
        /// </summary>

        public string CreateUserId { get; set; }

    }
}
