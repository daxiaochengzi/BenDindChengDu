using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.Resident;
using BenDing.Domain.Models.Dto.YiHai.Base;

namespace BenDing.Domain.Models.Dto.YiHai.OutpatientDepartment
{/// <summary>
/// 门诊结算信息
/// </summary>
   public class OutpatientSettlementInfoDto: ConfirmInfoDto
    {  /// <summary>
        /// 结算信息
        /// </summary>
        public List<PayMsgData> PayMsg { get; set; } = null;
    }
}
