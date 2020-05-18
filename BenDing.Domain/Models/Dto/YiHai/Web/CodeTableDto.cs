using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Dto.YiHai.Web
{
    /// <summary>
    /// 码表数据
    /// </summary>
  public  class CodeTableDto
    {/// <summary>
    /// 码数据
    /// </summary>
        public string CodeData { get; set; }
        /// <summary>
        /// 码数据描述
        /// </summary>
        public string CodeDescribe { get; set; }
        /// <summary>
        /// 对码值
        /// </summary>

        public string CodeValue { get; set; }


    }
}
