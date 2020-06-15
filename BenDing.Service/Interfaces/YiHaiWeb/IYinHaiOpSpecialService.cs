using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.YiHai.Base;
using BenDing.Domain.Models.Dto.YiHai.OutpatientDepartment;
using BenDing.Domain.Models.Dto.YiHai.XmlDto.OpSpecials;
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
        ///  工伤门诊申请
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        JobInjuryApplyOutputDto JobInjuryApply(JobInjuryApplyInputDto param);

        /// <summary>
        ///  取消工伤门诊申请  
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        CancelJobInjuryApplyOutputDto CacelJobInjuryApply(CancelJobInjuryApplyControlDto param);
        /// <summary>
        ///  修改工伤门诊申请  
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        UpdateJobInjuryApplyOutputDto UpdateJobInjuryApply(UpdateJobInjuryApplyControlDto param);
        /// <summary>
        /// 工伤门诊就诊
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        JobInjuryVisitOutputDto JobInjuryVisit(JobInjuryVisitInputDto param);

        /// <summary>
        /// 修改工伤门诊就诊 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        UpdateJobInjuryVisitOutputDto UpdateJobInjuryVisit(UpdateJobInjuryVisitInputDto param);

        /// <summary>
        /// 修改工伤门诊就诊 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        CancelJobInjuryVisitOutputDto CancelJobInjuryVisit(CancelJobInjuryVisitInputDto param);
    }
}
