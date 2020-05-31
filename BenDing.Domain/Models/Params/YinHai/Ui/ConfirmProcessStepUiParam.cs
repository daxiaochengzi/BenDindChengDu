using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Enums;
using BenDing.Domain.Models.Params.Base;

namespace BenDing.Domain.Models.Params.YinHai.Ui
{
    public class ConfirmProcessStepUiParam : UiBaseDataParam
    {/// <summary>
    /// 结果json
    /// </summary>
        public string ResultJson { get; set; }
       /// <summary>
       /// 门诊结算步骤
       /// </summary>
        public OutpatientSettlementStep SettlementStep { get; set; }
    }
}
