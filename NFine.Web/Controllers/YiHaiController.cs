using BenDing.Domain.Models.Params.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BenDing.Domain.Models.Params.UI;
using BenDing.Domain.Models.Params.YinHai.Ui;
using BenDing.Domain.Models.Params.YinHai.Web;
using BenDing.Repository.Interfaces.Web;
using BenDing.Service.Interfaces.YiHaiWeb;

namespace NFine.Web.Controllers
{/// <summary>
/// 银海医保接口
/// </summary>
    public class YiHaiController : ApiController
    {
        private readonly IYiHaiOutpatientDepartmentService _yiHaiOutpatientDepartmentService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iHaiOutpatientDepartmentService"></param>
        public YiHaiController
        (
            IYiHaiOutpatientDepartmentService iHaiOutpatientDepartmentService
         )
        {
            _yiHaiOutpatientDepartmentService = iHaiOutpatientDepartmentService;
        }

        #region 门诊
        /// <summary>
        /// 获取门诊结算入参
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ApiJsonResultData GetOutpatientDepartmentParam([FromBody]GetOutpatientDepartmentUiParam param)
        {
            return new ApiJsonResultData(ModelState).RunWithTry(y =>
            {
                var data = _yiHaiOutpatientDepartmentService.GetOutpatientDepartmentParam(param);
                y.Data = data;
            });

        }
        /// <summary>
        /// 医保签到
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ApiJsonResultData MedicalInsuranceSignIn([FromBody]MedicalInsuranceSignInUiParam param)
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
        public ApiJsonResultData MedicalInsuranceSignInQuery([FromBody]UiInIParam param)
        {
            return new ApiJsonResultData(ModelState).RunWithTry(y =>
            {
               var  data= _yiHaiOutpatientDepartmentService.GetMedicalInsuranceSignInParam(param);
                y.Data = data;
            });

        }
        /// <summary>
        /// 获取医保签到取消参数
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ApiJsonResultData GetCancelMedicalInsuranceSignInParam([FromBody]CancelMedicalInsuranceSignInParam param)
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
        public ApiJsonResultData CancelMedicalInsuranceSignIn([FromBody]CancelMedicalInsuranceSignInParam param)
        {
            return new ApiJsonResultData(ModelState).RunWithTry(y =>
            {
               _yiHaiOutpatientDepartmentService.CancelMedicalInsuranceSignIn(param);
               
            });

        }


        #endregion
    }
}
