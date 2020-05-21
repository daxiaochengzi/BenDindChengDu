using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.Web;
using BenDing.Domain.Models.Dto.YiHai.Web;
using BenDing.Domain.Models.Params.YinHai.OutpatientDepartment;
using BenDing.Domain.Models.Params.YinHai.Web;
using NFine.Domain._03_Entity.BenDingManage;

namespace BenDing.Repository.Interfaces.YiHaiWeb
{
  public  interface IYiHaiSqlRepository
  {   /// <summary>
      /// 签到查询
      /// </summary>
      /// <param name="param"></param>
      /// <returns></returns>
        List<MedicalInsuranceSignInEntity>  QueryMedicalInsuranceSignIn(QueryMedicalInsuranceSignInParam param);
        /// <summary>
        /// 码表查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
      List<CodeTableDto> CodeTableQuery(string param);
        /// <summary>
        /// 医院信息查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
       List<HospitalGeneralCatalogEntity> HospitalGeneralCatalog(HospitalGeneralCatalogYiHaiParam param);
      /// <summary>
      /// 医院信息上传更新
      /// </summary>
      /// <param name="param"></param>
      void HospitalInfoUploadUpdate(HospitalInfoUploadUpdateParam param);


  }
}
