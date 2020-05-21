using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Params.Base;
using BenDing.Domain.Models.Params.Web;

namespace BenDing.Domain.Models.Params.YinHai.OutpatientDepartment
{
  public  class HospitalInfoUploadUpdateParam:UserBaseParam
        {/// <summary>
        /// 项目编号
        /// </summary>
            public List<string>  FixedEncodingList { get; set; }
    }
}
