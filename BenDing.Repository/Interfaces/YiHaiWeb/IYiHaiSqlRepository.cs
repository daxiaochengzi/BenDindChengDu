using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.Web;
using BenDing.Domain.Models.Params.YinHai.Web;
using NFine.Domain._03_Entity.BenDingManage;

namespace BenDing.Repository.Interfaces.YiHaiWeb
{
  public  interface IYiHaiSqlRepository
  {   
     List<MedicalInsuranceSignInEntity>  QueryMedicalInsuranceSignIn(QueryMedicalInsuranceSignInParam param);
  }
}
