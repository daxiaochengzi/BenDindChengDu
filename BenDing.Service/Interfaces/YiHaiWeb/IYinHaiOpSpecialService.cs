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
        /// 获取 工伤门诊申请  参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        GetYiHaiBaseParm GetJobInjuryApplyParam(UiInIParam param);

        /// <summary>
        /// 获取 取消工伤门诊申请  参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        GetYiHaiBaseParm GetCacelJobInjuryApplyParam(GetCancelOutpatientSettlementUiParam param);
        /// <summary>
        /// 获取 修改工伤门诊申请  参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        GetYiHaiBaseParm GetUpdateJobInjuryApplyParam(GetCancelOutpatientSettlementUiParam param);
        /// <summary>
        /// 获取 查询工伤门诊申请  参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        GetYiHaiBaseParm GetQueryJobInjuryApplyParam(GetCancelOutpatientSettlementUiParam param);

        /// <summary>
        /// 获取 病种认证  参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        GetYiHaiBaseParm GetSickTypeCognizanceParam(GetCancelOutpatientSettlementUiParam param);
        /// <summary>
        /// 获取 查询病种认证  参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        GetYiHaiBaseParm GetQuerySickTypeCognizanceParam(GetCancelOutpatientSettlementUiParam param);
        /// <summary>
        /// 获取 工伤门诊回退 参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        GetYiHaiBaseParm GetJobInjurySettlementParam(GetCancelOutpatientSettlementUiParam param);
        /// <summary>
        /// 获取 取消工伤门诊回退 参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        GetYiHaiBaseParm GetCancelJobInjurySettlementParam(GetCancelOutpatientSettlementUiParam param);

        /// <summary>
        /// 获取 工伤门诊就诊 参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        GetYiHaiBaseParm GetJobInjuryVisitParam(GetCancelOutpatientSettlementUiParam param);
        /// <summary>
        ///  获取 取消工伤门诊就诊 参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        GetYiHaiBaseParm GetCancelJobInjuryVisitParam(GetCancelOutpatientSettlementUiParam param);

        /// <summary>
        ///  获取 修改工伤门诊就诊 参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        GetYiHaiBaseParm GetUpdateJobInjuryVisitParam(GetCancelOutpatientSettlementUiParam param);
    }
}
