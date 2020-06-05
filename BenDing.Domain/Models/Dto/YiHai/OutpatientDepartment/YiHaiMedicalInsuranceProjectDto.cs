using System;

namespace BenDing.Domain.Models.Dto.YiHai.OutpatientDepartment
{
    public  class YiHaiMedicalInsuranceProjectDto
        {/// <summary>
        /// id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 项目编码
        /// </summary>

        public  string ProjectCode { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// 项目等级
        /// </summary>
        public string ProjectLevel { get; set; }
        /// <summary>
        /// 药理类别
        /// </summary>
        public string PharmacologyType { get; set; }
            /// <summary>
            ///大类编码
            /// </summary>
       public string GeneralCoding { get; set; }
        /// <summary>
        /// 剂型
        /// </summary>
        public string Formulation { get; set; }
        /// <summary>
        /// 生产厂家
        /// </summary>
        public string Manufacturer { get; set; }
        /// <summary>
        /// 准字号
        /// </summary>

        public string QuasiFontSize { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string Specification { get; set; }
            /// <summary>
            /// 单位
            /// </summary>

         public string Unit { get; set; }
        /// <summary>
        /// 单位编码
        /// </summary>
        public string UnitCode { get; set; }
            /// <summary>
            /// 基药
            /// </summary>

        public string BaseDrug { get; set; }
        /// <summary>
        /// 限制使用范围
        /// </summary>
        public string LimitPaymentScope { get; set; }
            
        /// <summary>
        /// 工伤住院
        /// </summary>
        public decimal CommonJobInjuredHospitalization { get; set; }
        /// <summary>
        /// 工伤康复住院
        /// </summary>
        public decimal JobInjuredRecoveryHospitalization { get; set; }
        /// <summary>
        /// 普通人员住院
        /// </summary>
        public decimal CommonPersonnelHospitalization { get; set; }
        /// <summary>
        /// 普通人员门诊
        /// </summary>
        public decimal CommonPersonnelOutpatient { get; set; }
        /// <summary>
        /// 工伤门诊
        /// </summary>
        public decimal CommonWorkersOutpatient { get; set; }
        /// <summary>
        /// 普通人员门特
        /// </summary>
        public decimal CommonOutpatientMendel { get; set; }
        /// <summary>
        /// 离休二等乙级门诊
        /// </summary>
        public decimal LeaveDiethylOutpatient { get; set; }
        /// <summary>
        /// 离休二等乙级住院
        /// </summary>
        public decimal LeaveDiethylHospitalization { get; set; }
        /// <summary>
        /// 生育住院
        /// </summary>
        public decimal BirthHospitalization { get; set; }
        /// <summary>
        /// 少儿门诊
        /// </summary>
        public decimal ChildOutpatient { get; set; }
        /// <summary>
        /// 少儿住院
        /// </summary>
        public decimal ChildHospitalization { get; set; }
        /// <summary>
        /// 少儿门特
        /// </summary>
        public decimal ChildOutpatientMendel { get; set; }
        
        /// <summary>
        /// 普通城乡门诊
        /// </summary>
        public decimal CommonResidentOutpatient { get; set; }
        /// <summary>
        /// 普通城乡住院
        /// </summary>
        public decimal CommonResidentHospitalization { get; set; }
        /// <summary>
        /// 普通城乡门特
        /// </summary>
        public decimal CommonResidentOutpatientMendel { get; set; }
        /// <summary>
        /// 职工门诊统筹
        /// </summary>
        public decimal WorkersOutpatientOverallPlanning { get; set; }

        /// <summary>
        /// 城乡门诊统筹
        /// </summary>
        public decimal ResidentOutpatientOverallPlanning { get; set; }
            /// <summary>
            /// 备注
            /// </summary>
         
          public  string Remark { get; set; }
       
    }
}
