using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFine.Domain.BenDing.Infrastructure;

namespace NFine.Domain._03_Entity.BenDingManage
{
  public  class HospitalGeneralCatalogEntity: IBenDingEntity<HospitalGeneralCatalogEntity>, IBenDingCreationAudited, IBenDingDeleteAudited, IBenDingModificationAudited
    {
        public Guid Id { get; set; }
        /// <summary>
        /// 机构编码[取接口30返回的ID]
        /// </summary>
        [DisplayName("机构编码[取接口30返回的ID]")]
        [StringLength(100)]
        public string OrganizationCode { get; set; }
        /// <summary>
        /// 组织机构名称
        /// </summary>
        [DisplayName("组织机构名称")]
        [StringLength(200)]
        public string OrganizationName { get; set; }
        
        /// <summary>
        /// 目录类型[0科室、1医生、2病区、3床位]
        /// </summary>
        [DisplayName("目录类型[0科室、1医生、2病区、3床位]")]
        [StringLength(100)]
        public string DirectoryType { get; set; }
        /// <summary>
        /// 目录编码
        /// </summary>
        [DisplayName("目录编码")]
        [StringLength(100)]
        public string DirectoryCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("")]
        [StringLength(20)]
        public string FixedEncoding { get; set; }
        /// <summary>
        /// 助记码
        /// </summary>
        [DisplayName("助记码")]
        [StringLength(100)]
        public string MnemonicCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("")]
        [StringLength(100)]
        public string DirectoryName { get; set; }
        /// <summary>
        /// 目录类别名称
        /// </summary>
        [DisplayName("目录类别名称")]
        [StringLength(100)]
        public string DirectoryCategoryName { get; set; }
        /// <summary>
        /// 备注[目录类型1： 返回医生所在科室的编码;目录类型3： 返回床位所在的病区编码.]
        /// </summary>
        [DisplayName("备注[目录类型1： 返回医生所在科室的编码;目录类型3： 返回床位所在的病区编码.]")]
        [StringLength(100)]
        public string Remark { get; set; }
        /// <summary>
        /// 医保对码
        /// </summary>
        [DisplayName("医保对码")]
        [StringLength(100)]
        public string MedicalInsuranceCode { get; set; }
        /// <summary>
        /// 医保科室名称
        /// </summary>
        [DisplayName("医保科室名称")]
        [StringLength(500)]
        public string MedicalInsuranceName { get; set; }
        /// <summary>
        /// 病区编号
        /// </summary>
        [DisplayName("病区编号")]
        [StringLength(100)]
        public string InpatientAreaCode { get; set; }
        /// <summary>
        /// 病区责任人
        /// </summary>
        [DisplayName("病区责任人")]
        [StringLength(100)]
        public string InpatientAreaDutyPerson { get; set; }
        

        /// <summary>
        /// 对码人员
        /// </summary>
        [DisplayName("对码人员")]
        [StringLength(100)]
        public string PairCodeUserId { get; set; }
        /// <summary>
        /// 对码人员名称
        /// </summary>
        [DisplayName("对码人员名称")]
        [StringLength(100)]
        public string PairCodeUserName { get; set; }
        /// <summary>
        /// 对码人员名称
        /// </summary>
        [DisplayName("对码时间")]
     
        public DateTime? PairCodeTime { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [DisplayName("更新时间")]
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 删除标记[0:默认,1:删除]
        /// </summary>
        [DisplayName("删除标记[0:默认,1:删除]")]
        public bool IsDelete { get; set; }
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
        /// 上传人员id
        /// </summary>
        [DisplayName("上传人员id")]
        [StringLength(100)]
        public string UpdateUserId { get; set; }
        /// <summary>
        /// 上传人员
        /// </summary>
        [DisplayName("上传人员")]
        [StringLength(100)]
        public string UploadName { get; set; }
        
        /// <summary>
        /// 上传标志
        /// </summary>
        [DisplayName("上传标志")]
        public bool? UploadMark { get; set; }
        /// <summary>
        /// 上传时间
        /// </summary>
        [DisplayName("上传时间")]
        public DateTime? UploadTime { get; set; }
        /// <summary>
        /// 上传人
        /// </summary>
        [DisplayName("上传人")]
        [StringLength(100)]
        public string UploadUserId { get; set; }

        
    }
}
