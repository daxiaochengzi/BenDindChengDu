using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Dto.YiHai.Web
{
   public class MedicalInsuranceSignInDto
    {/// <summary>
     /// Id
     /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 业务ID
        /// </summary>
        [DisplayName("医保机构")]
        [StringLength(50)]
        public string MedicalInsuranceOrganization { get; set; }
        /// <summary>
        /// 签到状态
        /// </summary>
        [DisplayName("签到状态")]

        public int SignInState { get; set; }
        /// <summary>
        /// 批次号
        /// </summary>
        [DisplayName("批次号")]
        [StringLength(50)]
        public string BatchNo { get; set; }
        /// <summary>
        /// 签到时间
        /// </summary>
        [DisplayName("签到时间")]
        public DateTime? SignInTime { get; set; }

        /// <summary>
        /// 组织机构编号
        /// </summary>
        [DisplayName("组织机构编号")]
        [StringLength(100)]
        public string OrganizationCode { get; set; }
        /// <summary>
        /// 组织机构名称
        /// </summary>
        [DisplayName("组织机构名称")]
        [StringLength(100)]
        public string OrganizationName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 删除标记[0:默认,1:删除]
        /// </summary>
        [DisplayName("删除标记[0:默认,1:删除]")]
        public bool IsDelete { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [DisplayName("更新时间")]
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        [DisplayName("删除时间")]
        public DateTime? DeleteTime { get; set; }
        /// <summary>
        /// 操作员ID-[创建]
        /// </summary>
        [DisplayName("操作员ID-[创建]")]
        [StringLength(100)]
        public string CreateUserId { get; set; }
        /// <summary>
        /// 操作员ID-[删除]
        /// </summary>
        [DisplayName("操作员ID-[删除]")]
        [StringLength(100)]
        public string DeleteUserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("更新操作员")]
        [StringLength(100)]
        public string UpdateUserId { get; set; }
    }
}
