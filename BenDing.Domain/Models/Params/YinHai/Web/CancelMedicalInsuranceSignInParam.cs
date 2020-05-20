using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.Web;
using BenDing.Domain.Models.Params.UI;

namespace BenDing.Domain.Models.Params.YinHai.Web
{
  public  class CancelMedicalInsuranceSignInParam: UiInIParam
    { /// <summary>
        ///id
        /// </summary>

        [Display(Name = "数据Id")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string KeyWord { get; set; }
    }
}
