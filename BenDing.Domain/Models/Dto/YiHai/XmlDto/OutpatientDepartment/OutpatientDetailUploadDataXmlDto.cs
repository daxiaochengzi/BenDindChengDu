using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.OutpatientDepartment
{
    [XmlRoot("data", IsNullable = false)]
    public class OutpatientDetailUploadDataXmlDto
    {

    }
    /// <summary>
    /// 费用明细
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class OutpatientDetailUploadDataCostDetailXmlDto
    {
        /// <summary>
        /// 费用明细ID len(20)
        /// </summary>
        [XmlElementAttribute("yka105", IsNullable = false)]
        public string DetailId { get; set; }
        /// <summary>
        /// 医保项目编码
        /// </summary>
        [XmlElementAttribute("yka094", IsNullable = false)]
        public string ProjectCode { get; set; }
        /// <summary>
        /// 基层项目名称
        /// </summary>
        [XmlElementAttribute("yka095", IsNullable = false)]
        public string DirectoryName { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [XmlElementAttribute("akc226", IsNullable = false)]
        public decimal Quantity { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        [XmlElementAttribute("akc225", IsNullable = false)]
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        [XmlElementAttribute("yka055", IsNullable = false)]
        public decimal Amount { get; set; }
 
        /// <summary>
        /// 审核标志
        /// </summary>
        [XmlElementAttribute("yke186", IsNullable = false)]
        public string ApprovalMark { get; set; }
        

        /// <summary>
        /// 经办人
        /// </summary>
        [XmlElementAttribute("aae011", IsNullable = false)]
        public string Operators { get; set; }
        /// <summary>
        /// 医嘱序号 药品为空
        /// </summary>
        [XmlElementAttribute("yke112", IsNullable = false)]
        public string OrdersSortNo { get; set; }

        /// <summary>
        /// 处方号 len(15)
        /// </summary>
        [XmlElementAttribute("yke134", IsNullable = false)]
        public string PrescriptionNo { get; set; }
        /// <summary>
        /// 门诊费用类型 (码表)
        /// </summary>
        [XmlElementAttribute("yke447", IsNullable = false)]
        public string OutpatientCostType { get; set; }

        /// <summary>
        /// 基层目录编码
        /// </summary>
        [XmlElementAttribute("yke338", IsNullable = false)]
        public string DirectoryCode { get; set; }
        /// <summary>
        /// 医执人员编号  对应医生信息上传中的编码
        /// </summary>
        [XmlElementAttribute("yke419", IsNullable = false)]
        public string OperateDoctorCode { get; set; }

        /// <summary>
        /// 医执人员所属科室 代码yke414
        /// </summary>
        [XmlElementAttribute("yke426", IsNullable = false)]
        public string OperateDoctorDepartment { get; set; }

        /// <summary>
        /// 医执人员执业范围 
        /// </summary>
        [XmlElementAttribute("yke420", IsNullable = false)]
        public string OperateDoctorRange { get; set; }


        /// <summary>
        /// 医院对码流水号
        /// </summary>
        [XmlElementAttribute("ake005", IsNullable = false)]
        public string HospitalPairingCode { get; set; }
        /// <summary>
        /// 医执人员编号  对应医生信息上传中的编码
        /// </summary>
        [XmlElementAttribute("ykf008", IsNullable = false)]
        public string OperateDoctorNo { get; set; }


        ///// <summary>
        ///// 明细录入时间 (yyyy-mm-dd hh:mm:ss)
        ///// </summary>
        //[XmlElementAttribute("yke123", IsNullable = false)]
        //public string DetailInputTime { get; set; }
        ///// <summary>
        ///// 明细发生时间 (yyyy-mm-dd hh:mm:ss)
        ///// </summary>
        //[XmlElementAttribute("yke123", IsNullable = false)]
        //public string DetailTime { get; set; }


        ///// <summary>
        ///// 备注
        ///// </summary>
        //[XmlElementAttribute("aae013", IsNullable = false)]
        //public string Remark { get; set; }

        ///// <summary>
        /////使用方式 （固定值 01）
        ///// </summary>
        //[XmlElementAttribute("yke201", IsNullable = false)]
        //public string UserMethod { get; set; } = "01";

        ///// <summary>
        ///// 药品进价
        ///// </summary>
        //[XmlElementAttribute("yke553", IsNullable = false)]
        //public decimal InputPrice { get; set; }
        ///// <summary>
        ///// 外检标志
        ///// </summary>
        //[XmlElementAttribute("yke676", IsNullable = false)]
        //public string ExternalInspectSign { get; set; }
        ///// <summary>
        ///// 外检医院编码
        ///// </summary>
        //[XmlElementAttribute("yke677", IsNullable = false)]
        //public string ExternalInspectHospitalNo { get; set; }


        ///// <summary>
        ///// 设备编号
        ///// </summary>
        //[XmlElementAttribute("ykf013", IsNullable = false)]
        //public string EquipmentCode { get; set; }


        ///// <summary>
        ///// 药物类型
        ///// </summary>
        //[XmlElementAttribute("yke347", IsNullable = false)]
        //public string DirectoryType { get; set; }
        /////// <summary>
        /////// 药物剂型   码表
        /////// </summary>
        ////[XmlElementAttribute("yke348", IsNullable = false)]
        ////public string DosageCode { get; set; }
        /////// <summary>
        /////// 用药天数
        /////// </summary>
        ////[XmlElementAttribute("yke446", IsNullable = false)]
        ////public string UseDays { get; set; }
        /////// <summary>
        /////// 用药频率
        /////// </summary>
        ////[XmlElementAttribute("yke446", IsNullable = false)]
        ////public string UsedrugFrequency { get; set; }

        ///// <summary>
        ///// 医嘱内容
        ///// </summary>
        //[XmlElementAttribute("YKE113", IsNullable = false)]
        //public string OrderContent { get; set; }
        ///// <summary>
        /////医生姓名
        ///// </summary>
        //[XmlElementAttribute("YKA287", IsNullable = false)]
        //public string DoctorName { get; set; }
        ///// <summary>
        ///// 医嘱开始时间 (yyyy-MM-dd HH:mm:ss)
        ///// </summary>
        //[XmlElementAttribute("YKE361", IsNullable = false)]
        //public string OrderStartTime { get; set; }
        ///// <summary>
        ///// 医嘱执行时间 (yyyy-MM-dd)
        ///// </summary>
        //[XmlElementAttribute("YKE363", IsNullable = false)]
        //public string OrderOperateTime { get; set; }
        ///// <summary>
        ///// 医生编码
        ///// </summary>
        //[XmlElementAttribute("ykf008", IsNullable = false)]
        //public string DoctorCode { get; set; }
        ///// <summary>
        ///// 医嘱科室编码
        ///// </summary>
        //[XmlElementAttribute("aaz307", IsNullable = false)]
        //public string OrderDepartmentId { get; set; }
        ///// <summary>
        ///// 医嘱科室名称
        ///// </summary>
        //[XmlElementAttribute("akf002", IsNullable = false)]
        //public string OrderDepartmentName { get; set; }
        ///// <summary>
        ///// 医执人员编号
        ///// </summary>
        //[XmlElementAttribute("yke419", IsNullable = false)]
        //public string OperateDoctorCode { get; set; }
        ///// <summary>
        ///// 医执人员所属科室 代码yke414
        ///// </summary>
        //[XmlElementAttribute("yke426", IsNullable = false)]
        //public string OperateDoctorDepartment { get; set; }
        ///// <summary>
        ///// 出生日期 datetime
        ///// </summary>
        //[XmlElementAttribute("aac006", IsNullable = false)]
        //public string Birthday { get; set; }
        ///// <summary>
        ///// 就诊年龄 
        ///// </summary>
        //[XmlElementAttribute("yke525", IsNullable = false)]
        //public string Age { get; set; }
        ///// <summary>
        ///// 是否复诊 1是 0 否
        ///// </summary>
        //[XmlElementAttribute("yke509", IsNullable = false)]
        //public int IsSecondVisit { get; set; }
        ///// <summary>
        ///// 是否外伤 1是 0 否
        ///// </summary>
        //[XmlElementAttribute("yke510", IsNullable = false)]
        //public int IsTrauma { get; set; }

        ///// <summary>
        /////科室（病区）编号  代码 yke414
        ///// </summary>
        //[XmlElementAttribute("yke414", IsNullable = false)]
        //public string DepartmentInpatientArea { get; set; }

        ///// <summary>
        ///// 职业
        ///// </summary>
        //[XmlElementAttribute("yke508", IsNullable = false)]
        //public string Occupation { get; set; } = "医生";
        ///// <summary>
        ///// 医院对码流水号
        ///// </summary>
        //[XmlElementAttribute("ake005", IsNullable = false)]
        //public string HospitalPairingCode { get; set; }
        ///// <summary>
        ///// 药品编码/诊疗项目编码本位吗
        ///// </summary>
        //[XmlElementAttribute("yka059", IsNullable = false)]
        //public string DirectoryCodeStandard { get; set; }
    }
    /// <summary>
    /// 挂号信息
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class OutpatientDetailUploadDataRegisterDetailXmlDto
    {
        /// <summary>
        /// 医执人员编号  对应医生信息上传中的编码
        /// </summary>
        [XmlElementAttribute("yka384", IsNullable = false)]
        public string OperateDoctorCode { get; set; }
        /// <summary>
        /// 医执人员编号  对应医生信息上传中的编码
        /// </summary>
        [XmlElementAttribute("yka287", IsNullable = false)]
        public string OperateDoctorName { get; set; }
    }

    /// <summary>
    /// 服务对象
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class OutpatientDetailUploadDatafwdxDetailXmlDto
    { /// <summary>
        /// 经办人
        /// </summary>
        [XmlElementAttribute("aae011", IsNullable = false)]
        public string OperationName { get; set; }
        /// <summary>
        /// 经办时间
        /// </summary>
        [XmlElementAttribute("aae036", IsNullable = false)]
        public string OperationTiem { get; set; }

    }
    /// <summary>
    /// 门诊病历
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]

    public class OutpatientDetailUploadDataDatasetmzblDetailXmlDto
    { /// <summary>
      /// 就医开始时间
      /// </summary>
        [XmlElementAttribute("ykc142", IsNullable = false)]
        public string DiagnosisStartTime { get; set; }
        /// <summary>
        /// 主诉
        /// </summary>
        [XmlElementAttribute("ykc310", IsNullable = false)]
        public string MainLawsuit { get; set; }
        
    }
    /// <summary>
    /// 
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class OutpatientDetailUploadDatadatasetykc328DetailXmlDto
    {/// <summary>
     /// 门诊症状-诊断代码
     /// </summary>
        [XmlElementAttribute("ykc328", IsNullable = false)]
        public string DiagnosisCode { get; set; }
        /// <summary>
        /// 门诊症状-名称
        /// </summary>
        [XmlElementAttribute("ykc311", IsNullable = false)]
        public string DiagnosisName { get; set; }
    }


}
