using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Enums
{
    public enum ProcessStepEnum
    {
        挂号 = 1,
        确认挂号 = 2,
        门诊结算 = 3,
        确认结算 = 4,
        取消结算 = 5,
        确认取消结算 = 6,
    }
}
