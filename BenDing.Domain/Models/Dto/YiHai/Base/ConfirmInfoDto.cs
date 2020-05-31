using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Dto.YiHai.Base
{/// <summary>
/// 确认信息
/// </summary>
  public  class ConfirmInfoDto
    {/// <summary>
    /// 交易流水号
    /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// 交易验证码
        /// </summary>
        public  string VerificationCode { get; set; }
    }
}
