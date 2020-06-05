using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.Base;
using BenDing.Domain.Models.Dto.Web;

namespace BenDing.Domain.Models.Params.YinHai.OutpatientDepartment
{
   public class BaseRefundUiParam: PaginationDto
    {/// <summary>
    /// 开始时间
    /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        /// 组织机构
        /// </summary>
        public string OrganizationCode { get; set; }
    }
}
