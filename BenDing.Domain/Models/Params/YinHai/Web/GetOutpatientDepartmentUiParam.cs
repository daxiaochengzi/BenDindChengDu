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
        public string ResultJson { get; set; }
    }
}
