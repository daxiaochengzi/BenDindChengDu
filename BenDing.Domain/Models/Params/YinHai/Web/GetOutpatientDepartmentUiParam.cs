using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Params.Base;

namespace BenDing.Domain.Models.Params.YinHai.Web
{
  public  class GetOutpatientDepartmentUiParam: UiBaseDataParam
    {
        /// <summary>
        /// 支付类别
        /// </summary>
        [Display(Name = "支付类别")]
        [Required(ErrorMessage = "{0}不能为空!!!")]

        public string PaymentCategory { get; set; }
    }
}
