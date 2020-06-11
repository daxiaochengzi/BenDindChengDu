using System.Web.Http;
using BenDing.Domain.Models.Dto.Web;
using BenDing.Domain.Models.Params.Base;
using BenDing.Domain.Models.Params.UI;
using BenDing.Domain.Models.Params.YinHai.OutpatientDepartment;
using BenDing.Domain.Models.Params.YinHai.Ui;
using BenDing.Domain.Models.Params.YinHai.Web;
using BenDing.Repository.Interfaces.Web;
using BenDing.Service.Interfaces;
using BenDing.Service.Interfaces.YiHaiWeb;
namespace NFine.Web.Controllers
{
    /// <summary>
    /// 银海医保接口
    /// </summary>
    public class YiHaiController : ApiController
    {
        private readonly IYiHaiOutpatientDepartmentService _yiHaiOutpatientDepartmentService;
        private readonly IWebServiceBasicService _webServiceBasicService;
        private readonly ISystemManageRepository _systemManageRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iHaiOutpatientDepartmentService"></param>
        public YiHaiController
        (
            IYiHaiOutpatientDepartmentService iHaiOutpatientDepartmentService,
            ISystemManageRepository iSystemManageRepository,
            IWebServiceBasicService iWebServiceBasicService
        )
        {
            _webServiceBasicService = iWebServiceBasicService;
            _systemManageRepository = iSystemManageRepository;
            _yiHaiOutpatientDepartmentService = iHaiOutpatientDepartmentService;
        }
        #region comm

        /// <summary>
        /// 医保签到
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ApiJsonResultData MedicalInsuranceSignIn([FromBody] MedicalInsuranceSignInUiParam param)
        {
            return new ApiJsonResultData(ModelState).RunWithTry(y =>
            {
                _yiHaiOutpatientDepartmentService.MedicalInsuranceSignIn(param);
            });

        }

        /// <summary>
        /// 医保签到查询
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ApiJsonResultData GetMedicalInsuranceSignInParam([FromBody] UiInIParam param)
        {
            return new ApiJsonResultData(ModelState).RunWithTry(y =>
            {
                var data = _yiHaiOutpatientDepartmentService.GetMedicalInsuranceSignInParam(param);
                y.Data = data;
            });

        }

        /// <summary>
        /// 获取医保签到取消参数
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ApiJsonResultData GetCancelMedicalInsuranceSignInParam(
            [FromBody] CancelMedicalInsuranceSignInParam param)
        {
            return new ApiJsonResultData(ModelState).RunWithTry(y =>
            {
                var data = _yiHaiOutpatientDepartmentService.GetCancelMedicalInsuranceSignInParam(param);
                y.Data = data;
            });

        }

        /// <summary>
        /// 医保签到取消
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ApiJsonResultData CancelMedicalInsuranceSignIn([FromBody] CancelMedicalInsuranceSignInParam param)
        {
            return new ApiJsonResultData(ModelState).RunWithTry(y =>
            {
                _yiHaiOutpatientDepartmentService.CancelMedicalInsuranceSignIn(param);
            });

        }

        /// <summary>
        /// 获取医院上传信息参数
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ApiJsonResultData GetHospitalInfoUploadParam([FromBody]UploadHospitalInfoUiParam param)
        {
            return new ApiJsonResultData(ModelState).RunWithTry(y =>
            {
                var data = _yiHaiOutpatientDepartmentService.GetHospitalInfoUploadParam(param);
                y.Data = data;
            });

        }

        /// <summary>
        /// 医院信息上传
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ApiJsonResultData HospitalInfoUpload([FromBody] UploadHospitalInfoUiParam param)
        {
            return new ApiJsonResultData(ModelState).RunWithTry(y =>
            {
                _yiHaiOutpatientDepartmentService.HospitalInfoUpload(param);
            });

        }

        #endregion
        #region 门诊

        /// <summary>
        /// 获取门诊挂号入参
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ApiJsonResultData GetOutpatientRegisterParam([FromBody] UiBaseDataParam param)
        {
            return new ApiJsonResultData(ModelState).RunWithTry(y =>
            {
                var data = _yiHaiOutpatientDepartmentService.GetOutpatientRegisterParam(param);
                y.Data = data;
            });

        }

        /// <summary>
        /// 门诊挂号
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiJsonResultData OutpatientRegister([FromBody] OutpatientRegisterUiParam param)
        {
            return new ApiJsonResultData(ModelState).RunWithTry(y =>
            {
                var data = _yiHaiOutpatientDepartmentService.OutpatientRegister(param);
                y.Data = data;
            });

        }

        /// <summary>
        /// 确认步骤
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiJsonResultData ConfirmProcessStep([FromBody] ConfirmProcessStepUiParam param)
        {
            return new ApiJsonResultData(ModelState).RunWithTry(y =>
            {
                _yiHaiOutpatientDepartmentService.ConfirmProcessStep(param);
            });

        }

        /// <summary>
        /// 获取门诊病人费用明细上传入参
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiJsonResultData GetOutpatientDetailUploadParam([FromBody] GetOutpatientDetailUploadUiParam param)
        {
            return new ApiJsonResultData(ModelState).RunWithTry(y =>
            {
                var data = _yiHaiOutpatientDepartmentService.GetOutpatientDetailUploadParam(param);
                y.Data = data;

            });

        }

        /// <summary>
        /// 门诊病人费用明细上传
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiJsonResultData OutpatientDetailUpload([FromBody] GetOutpatientDetailUploadUiParam param)
        {
            return new ApiJsonResultData(ModelState).RunWithTry(y =>
            {
                _yiHaiOutpatientDepartmentService.OutpatientDetailUpload(param);
            });

        }

        /// <summary>
        /// 获取门诊结算入参
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ApiJsonResultData GetOutpatientSettlementParam([FromBody] GetOutpatientDepartmentUiParam param)
        {
            return new ApiJsonResultData(ModelState).RunWithTry(y =>
            {
                var data = _yiHaiOutpatientDepartmentService.GetOutpatientSettlementParam(param);
                y.Data = data;
            });

        }

        /// <summary>
        /// 门诊结算
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ApiJsonResultData OutpatientSettlement([FromBody] GetOutpatientDepartmentUiParam param)
        {
            return new ApiJsonResultData(ModelState).RunWithTry(y =>
            {
                var data = _yiHaiOutpatientDepartmentService.OutpatientSettlement(param);
                y.Data = data;
            });

        }

        /// <summary>
        /// 获取门诊结算打印参数
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ApiJsonResultData GetOutpatientSettlementPrintParam([FromBody] GetOutpatientSettlementPrintParam param)
        {
            return new ApiJsonResultData(ModelState).RunWithTry(y =>
            {
                y.Data = _yiHaiOutpatientDepartmentService.GetOutpatientSettlementPrintParam(param);
            });

        }

        /// <summary>
        /// 查询门诊结算信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiJsonResultData QueryOutpatientSettlementCost([FromBody] QueryOutpatientSettlementCostUiParam param)
        {
            return new ApiJsonResultData(ModelState).RunWithTry(y =>
            {
                y.Data = _yiHaiOutpatientDepartmentService.QueryOutpatientSettlementCost(param);
            });

        }

        /// <summary>
        /// 获取取消结算参数
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ApiJsonResultData GetCancelOutpatientSettlementParam(
            [FromBody] GetCancelOutpatientSettlementUiParam param)
        {
            return new ApiJsonResultData(ModelState).RunWithTry(y =>
            {
                y.Data = _yiHaiOutpatientDepartmentService.GetCancelOutpatientSettlementParam(param);
            });

        }

        /// <summary>
        /// 取消门诊结算(可手动)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ApiJsonResultData CancelOutpatientSettlement([FromBody] GetCancelOutpatientSettlementUiParam param)
        {
            return new ApiJsonResultData(ModelState).RunWithTry(y =>
            {
                y.Data = _yiHaiOutpatientDepartmentService.CancelOutpatientSettlement(param);
            });

        }

        #endregion
        #region 公共信息

        /// <summary>
        /// 获取医院信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet]
        public ApiJsonResultData GetHospitalInfo([FromUri] UiBaseDataParam param)
        {
            return new ApiJsonResultData(ModelState, new QueryMedicalInsuranceDetailInfoDto()).RunWithTry(y =>
            {
                var userBase = _webServiceBasicService.GetUserBaseInfo(param.UserId);
                //获取医院等级
                var gradeData = _systemManageRepository.QueryHospitalOrganizationGrade(userBase.OrganizationCode);
                y.Data = gradeData;
            });

        }

        #endregion
    }
}
