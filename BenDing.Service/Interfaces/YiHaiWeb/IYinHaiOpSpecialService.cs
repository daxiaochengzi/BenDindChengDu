using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.YiHai.Base;
using BenDing.Domain.Models.Dto.YiHai.OutpatientDepartment;
using BenDing.Domain.Models.Params.Base;
using BenDing.Domain.Models.Params.UI;
using BenDing.Domain.Models.Params.YinHai.OutpatientDepartment;
using BenDing.Domain.Models.Params.YinHai.Ui;
using BenDing.Domain.Models.Params.YinHai.Web;

namespace BenDing.Service.Interfaces.YiHaiWeb
{
    /// <summary>
    /// 银海门特
    /// </summary>
    public interface IYinHaiOpSpecialService
    {
        /// <summary>
        /// 工伤门诊新申请
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        GetYiHaiBaseParm JobInjuryApply(UiInIParam param);

        /// <summary>
        /// 变更工伤门诊申请
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        GetYiHaiBaseParm UpdateJobInjuryApply(UiInIParam param);

        /// <summary>
        /// 工伤门诊新申请
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        GetYiHaiBaseParm CancelJobInjuryApply(UiInIParam param);

        /// <summary>
        /// 工伤门诊、工伤康复住院申请查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        GetYiHaiBaseParm QueryJobInjuryApply(UiInIParam param);
    }
}
