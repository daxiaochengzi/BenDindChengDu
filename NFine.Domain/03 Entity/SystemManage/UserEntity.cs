﻿/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author: NFine
 * Description: NFine快速开发平台
 * Website：http://www.nfine.cn
*********************************************************************************/
using System;

namespace NFine.Domain.Entity.SystemManage
{
    public class UserEntity : IEntity<UserEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string F_Id { get; set; }
        public string F_Account { get; set; }
        public string F_RealName { get; set; }
        public string F_NickName { get; set; }
        public string F_HeadIcon { get; set; }
        /// <summary>
        ///  性别 true==男
        /// </summary>
        public bool? F_Gender { get; set; }
        public DateTime? F_Birthday { get; set; }
        public string F_MobilePhone { get; set; }
        public string F_Email { get; set; }
        public string F_WeChat { get; set; }
        public string F_ManagerId { get; set; }
        public int? F_SecurityLevel { get; set; }
        public string F_Signature { get; set; }
        public string F_OrganizeId { get; set; }
        public string F_DepartmentId { get; set; }
        public string F_RoleId { get; set; }
        public string F_DutyId { get; set; }
        public bool? F_IsAdministrator { get; set; }
        public int? F_SortCode { get; set; }
        public bool? F_DeleteMark { get; set; }
        public bool? F_EnabledMark { get; set; }
        public string F_Description { get; set; }
        public DateTime? F_CreatorTime { get; set; }
        public string F_CreatorUserId { get; set; }
        public DateTime? F_LastModifyTime { get; set; }
        public string F_LastModifyUserId { get; set; }
        public DateTime? F_DeleteTime { get; set; }
        public string F_DeleteUserId { get; set; }
        /// <summary>
        ///his用户Id
        /// </summary>
        public string F_HisUserId { get; set; }
        ///// <summary>
        ///// 是否基层账户
        ///// </summary>
        public bool? F_IsHisAccount { get; set; }
        /// <summary>
        /// 基层账户密码
        /// </summary>
        public string F_HisUserPwd { get; set; }
        /// <summary>
        /// 厂商编号
        /// </summary>
        public  string F_ManufacturerNumber { get; set; }
        /// <summary>
        /// 医执人员类别
        /// </summary>
        public string F_DoctorType { get; set; }
        /// <summary>
        /// 医生治疗范围
        /// </summary>
        public string F_DoctorTreatmentRange { get; set; }

        /// <summary>
        /// 医执人员年龄(取证书年龄)
        /// </summary>

        public int? F_DoctorJobAge { get; set; } = 0;

        /// <summary>
        /// 医执人员职称
        /// </summary>
        public string F_DoctorTitle { get; set; }
        /// <summary>
        /// 医执人员职务
        /// </summary>
        public string F_DoctorJob { get; set; }
        /// <summary>
        ///  科室（病区）编号
        /// </summary>
        public string F_DepartmentInpatientAreaNo { get; set; }
        /// <summary>
        /// 医生从业时间
        /// </summary>

        public DateTime? F_DoctorDiagnosisStartTime { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string F_IdCardNo { get; set; }
        /// <summary>
        /// 医生执业编号
        /// </summary>
        public string F_DoctorPracticeNo { get; set; }
        /// <summary>
        /// 医生资格编号
        /// </summary>
        public string F_DoctorQualificationNo { get; set; }

    }
}
