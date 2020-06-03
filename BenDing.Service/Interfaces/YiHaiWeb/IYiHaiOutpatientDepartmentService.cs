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
        /// <summary>
        /// 获取门诊结算入参
        /// </summary>
        /// <param name="param"></param>
        GetYiHaiBaseParm GetOutpatientSettlementParam(GetOutpatientDepartmentUiParam param);
        /// <summary>
        /// 门诊结算
        /// </summary>
        /// <param name="param"></param>
        ConfirmInfoDto OutpatientSettlement(GetOutpatientDepartmentUiParam param);
        /// <summary>
        /// 获取医院上传信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        GetYiHaiBaseParm GetHospitalInfoUploadParam(UploadHospitalInfoUiParam param);
        /// <summary>
        /// 医院信息上传
        /// </summary>
        /// <param name="param"></param>
        void HospitalInfoUpload(UploadHospitalInfoUiParam param);
        /// <summary>
        /// 获取取消签到参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        GetYiHaiBaseParm GetCancelMedicalInsuranceSignInParam(CancelMedicalInsuranceSignInParam param);
        /// <summary>
        /// 取消签到
        /// </summary>
        /// <param name="param"></param>
        void CancelMedicalInsuranceSignIn(CancelMedicalInsuranceSignInParam param);
        /// <summary>
        /// 获取门诊挂号入参
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        GetYiHaiBaseParm GetOutpatientRegisterParam(UiBaseDataParam param);
        /// <summary>
        /// 门诊挂号
        /// </summary>
        /// <param name="param"></param>
        ConfirmInfoDto  OutpatientRegister(OutpatientRegisterUiParam param);
        /// <summary>
        /// 获取门诊明细上传入参
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        GetYiHaiBaseParm GetOutpatientDetailUploadParam(GetOutpatientDetailUploadUiParam param);
        /// <summary>
        /// 门诊明细上传
        /// </summary>
        /// <param name="param"></param>
        void OutpatientDetailUpload(GetOutpatientDetailUploadUiParam param);
        /// <summary>
        /// 确认步骤
        /// </summary>
        /// <param name="param"></param>
        void ConfirmProcessStep(ConfirmProcessStepUiParam param);

        GetYiHaiBaseParm GetOutpatientSettlementPrintParam(GetOutpatientSettlementPrintParam param);
        /// <summary>
        /// 获取门诊取消结算参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
         GetYiHaiBaseParm GetCancelOutpatientSettlementParam(GetCancelOutpatientSettlementUiParam param);
        /// <summary>
        /// 取消结算
        /// </summary>
        /// <param name="param"></param>
        ConfirmInfoDto CancelOutpatientSettlement(GetCancelOutpatientSettlementUiParam param);
        /// <summary>
        /// 查询门诊结算信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        QueryOutpatientSettlementCost QueryOutpatientSettlementCost(QueryOutpatientSettlementCostUiParam param);
    }
}
