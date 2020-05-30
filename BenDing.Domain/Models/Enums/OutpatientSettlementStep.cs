using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Enums
{/// <summary>
/// 门诊结算步骤
/// </summary>
    public enum OutpatientSettlementStep
    {/// <summary>
     /// 挂号
     /// </summary>
        Register = 1,
        /// <summary>
        /// 确认挂号
        /// </summary>
        ConfirmRegister = 2,
        /// <summary>
        /// 门诊结算
        /// </summary>
        OutpatientSettlement = 3,
        /// <summary>
        /// 基层结算
        /// </summary>
        HisSettlement = 4,
        /// <summary>
        /// 确认结算
        /// </summary>
        ConfirmSettlement = 5,
        /// <summary>
        /// 取消结算
        /// </summary>
        CancelSettlement=6,
        /// <summary>
        /// 基层取消结算
        /// </summary>
        HisCancelSettlement = 7,
        /// <summary>
        /// 确认取消结算
        /// </summary>
        ConfirmCancelSettlement = 8,
    }
}
