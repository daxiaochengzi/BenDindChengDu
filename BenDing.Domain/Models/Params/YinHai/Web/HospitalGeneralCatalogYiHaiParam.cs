using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Params.Base;
using BenDing.Domain.Models.Params.Web;

namespace BenDing.Domain.Models.Params.YinHai.Web
{
   public class HospitalGeneralCatalogYiHaiParam:UserBaseParam
    {  /// <summary>
    /// 目录类型
    /// </summary>
        public string DirectoryType { get; set; }
         /// <summary>
         /// 目录编码
         /// </summary>
        public string DirectoryCode { get; set; }
        

    }
}
