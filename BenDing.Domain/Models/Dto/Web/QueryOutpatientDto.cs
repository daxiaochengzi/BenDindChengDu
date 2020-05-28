using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Dto.Web
{/// <summary>
/// 
/// </summary>
   public class QueryOutpatientDto: BaseOutpatientInfoDto
    {
        public string VisitNo { get; set; }
        public  int? ProcessStep { get; set; }
    }
}
