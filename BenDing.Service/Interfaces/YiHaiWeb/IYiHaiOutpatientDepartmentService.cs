using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.YiHai.Base;
using BenDing.Domain.Models.Params.UI;
using BenDing.Domain.Models.Params.YinHai.Ui;

namespace BenDing.Service.Interfaces.YiHaiWeb
{/// <summary>
/// 银海门诊
/// </summary>
  public  interface IYiHaiOutpatientDepartmentService
    {/// <summary>
    /// 获取签到参数
    /// </summary>
    /// <param name="param"></param>
    /// <returns></returns>
        GetYiHaiBaseParm GetMedicalInsuranceSignInParam(UiInIParam param);
        /// <summary>
        /// 签到
        /// </summary>
        /// <param name="param"></param>
        void MedicalInsuranceSignIn(MedicalInsuranceSignInUiParam param);
    }
}
