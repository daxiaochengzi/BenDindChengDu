using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Dto.Web
{
   public class QueryHospitalOperatorDto
    {
        /// <summary>
        /// 基层账户
        /// </summary>
        public string HisUserAccount { get; set; }
        /// <summary>
        /// 基层id
        /// </summary>
        public string HisUserId { get; set; }
        /// <summary>
        /// 基层密码
        /// </summary>
        public string HisUserPwd { get; set; }
        /// <summary>
        /// 厂商编号
        /// </summary>
        public  string ManufacturerNumber { get; set; }
        /// <summary>
        /// 组织机构
        /// </summary>
        public  string OrganizationCode { get; set; }
        /// <summary>
        /// 账户名称
        /// </summary>

        public  string AccountName { get; set; }
    }
}
