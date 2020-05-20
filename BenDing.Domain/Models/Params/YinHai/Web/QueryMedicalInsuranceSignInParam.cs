using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.Web;
using BenDing.Domain.Models.Params.Base;

namespace BenDing.Domain.Models.Params.YinHai.Web
{
   public class QueryMedicalInsuranceSignInParam: UserBaseParam
    {/// <summary>
    /// 签到状态 1为已签
    /// </summary>
        public int? SignInState { get; set; }
    }
}
