using System.Collections.Generic;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.OutpatientDepartment.OutpatientDetailUpload
{
    /// <summary>
    /// 门诊明细上传
    /// </summary>
    [XmlRoot("data", IsNullable = false)]
    public class OutpatientDetailUploadDataXmlDto
    {

        /// <summary>
        /// 费用明细
        /// </summary>
        [XmlElement("datasetfymx")]
        [XmlArrayItem("row")]
        public List<OutpatientDetailUploadDataCostDetailXmlDto> CostDetail { get; set; }

        /// <summary>
        /// 挂号信息
        /// </summary>
        [XmlElement("datasetghxx")]
        public OutpatientDetailUploadDataRegisterDetailXmlDto RegisterDetail { get; set; }

        /// <summary>
        /// 服务对象明细
        /// </summary>
        [XmlElement("datasetfwdx")]
        public OutpatientDetailUploadDataServiceObjectDetailXmlDto ServiceObjectDetail { get; set; }
        /// <summary>
        /// 门诊病历明细
        /// </summary>
        [XmlElement("datasetmzbl")]
        public OutpatientDetailUploadDataOutpatientMedicalRecordDetailXmlDto MedicalRecordDetail { get; set; }

        /// <summary>
        /// 西药处方
        /// </summary>
        [XmlElement("datasetxydz")]
        [XmlArrayItem("row")]
        public List<OutpatientWesternDrugPrescriptionDetail> WesternDrugDetail { get; set; }

        /// <summary>
        /// 医嘱明细
        /// </summary>
        [XmlElement("datasetyz")]
        [XmlArrayItem("row")]
        public List<OutpatientPatientOrdersDetail> OrdersDetail { get; set; }

    }
       /// <summary>
        /// 费用明细
        /// </summary>
        [XmlType(AnonymousType = true)]
     public class OutpatientDetailUploadDataCostDetailXmlDto
    {
        /// <summary>
        /// 费用明细ID len(20)
        /// </summary>
        [XmlElement("yka105", IsNullable = false)]
        public string DetailId { get; set; }
        /// <summary>
        /// 医保项目编码
        /// </summary>
        [XmlElement("yka094", IsNullable = false)]
        public string ProjectCode { get; set; }
        /// <summary>
        /// 基层项目名称
        /// </summary>
        [XmlElement("yka095", IsNullable = false)]
        public string DirectoryName { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [XmlElement("akc226", IsNullable = false)]
        public decimal Quantity { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        [XmlElement("akc225", IsNullable = false)]
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        [XmlElement("yka055", IsNullable = false)]
        public decimal Amount { get; set; }
 
        /// <summary>
        /// 审核标志
        /// </summary>
        [XmlElement("yke186", IsNullable = false)]
        public string ApprovalMark { get; set; }
        

        /// <summary>
        /// 经办人
        /// </summary>
        [XmlElement("aae011", IsNullable = false)]
        public string Operators { get; set; }
        /// <summary>
        /// 医嘱序号 药品为空
        /// </summary>
        [XmlElement("yke112", IsNullable = false)]
        public string OrdersSortNo { get; set; }

        /// <summary>
        /// 处方号 len(15)
        /// </summary>
        [XmlElement("yke134", IsNullable = false)]
        public string PrescriptionNo { get; set; }
        /// <summary>
        /// 门诊费用类型 (码表)
        /// </summary>
        [XmlElement("yke447", IsNullable = false)]
        public string OutpatientCostType { get; set; }

        /// <summary>
        /// 基层目录编码
        /// </summary>
        [XmlElement("yke338", IsNullable = false)]
        public string DirectoryCode { get; set; }
        /// <summary>
        /// 医执人员编号  对应医生信息上传中的编码
        /// </summary>
        [XmlElement("yke419", IsNullable = false)]
        public string OperateDoctorCode { get; set; }

        /// <summary>
        /// 医执人员所属科室 代码yke414
        /// </summary>
        [XmlElement("yke426", IsNullable = false)]
        public string OperateDoctorDepartment { get; set; }

        /// <summary>
        /// 医执人员执业范围 
        /// </summary>
        [XmlElement("yke420", IsNullable = false)]
        public string OperateDoctorRange { get; set; }


        /// <summary>
        /// 医院对码流水号
        /// </summary>
        [XmlElement("ake005", IsNullable = false)]
        public string HospitalPairingCode { get; set; }
        /// <summary>
        /// 医执人员编号  对应医生信息上传中的编码
        /// </summary>
        [XmlElement("ykf008", IsNullable = false)]
        public string OperateDoctorNo { get; set; }


       
    }
    /// <summary>
    /// 挂号信息
    /// </summary>
    [XmlType(AnonymousType = true)]
    public class OutpatientDetailUploadDataRegisterDetailXmlDto
    {
        /// <summary>
        /// 医执人员编号  对应医生信息上传中的编码
        /// </summary>
        [XmlElement("yka384", IsNullable = false)]
        public string OperateDoctorCode { get; set; }
        /// <summary>
        /// 医执人员名称
        /// </summary>
        [XmlElement("yka287", IsNullable = false)]
        public string OperateDoctorName { get; set; }
    }

    /// <summary>
    /// 服务对象
    /// </summary>
    [XmlType(AnonymousType = true)]
    public class OutpatientDetailUploadDataServiceObjectDetailXmlDto
    { /// <summary>
        /// 经办人
        /// </summary>
        [XmlElement("aae011", IsNullable = false)]
        public string OperationName { get; set; }
        /// <summary>
        /// 经办时间
        /// </summary>
        [XmlElement("aae036", IsNullable = false)]
        public string OperationTime { get; set; }

    }
    /// <summary>
    /// 门诊病历
    /// </summary>
    [XmlType(AnonymousType = true)]

    public class OutpatientDetailUploadDataOutpatientMedicalRecordDetailXmlDto
    { /// <summary>
      /// 就医开始时间
      /// </summary>
        [XmlElement("ykc142", IsNullable = false)]
        public string DiagnosisStartTime { get; set; }
        /// <summary>
        /// 主诉
        /// </summary>
        [XmlElement("ykc310", IsNullable = false)]
        public string MainDiagnosis { get; set; }
        /// <summary>
        /// 门诊症状
        /// </summary>
        [XmlElement("datasetykc328")]
        [XmlArrayItem("row")]
        public List<OutpatientDetailUploadDataSymptomDetailXmlDto> SymptomDetail { get; set; }
        /// <summary>
        /// 诊断明细
        /// </summary>
        [XmlElement("datasetykc312")]
        [XmlArrayItem("row")]
        public List<OutpatientDetailUploadDataDiagnosisDetailXmlDto> DiagnosisDetail { get; set; }
        /// <summary>
        /// 发病日期
        /// </summary>
        [XmlElement("ykc314")]
        public string FindDiseaseTime { get; set; }
        /// <summary>
        /// 诊断时间
        /// </summary>
        [XmlElement("ykc315")]
        public string DiagnosisTime { get; set; }
        /// <summary>
        /// 就诊类型 代码(1.普通就诊,2.急救,3.抢救)
        /// </summary>
        [XmlElement("yke479")]
        public string VisitType { get; set; }
        /// <summary>
        /// 是否会诊
        /// </summary>
        [XmlElement("yke480")]
        public int IsConsultation { get; set; }

        /// <summary>
        /// 是否确认诊断
        /// </summary>
        [XmlElement("yke480")]
        public int IsConfirmDiagnosis { get; set; }
        /// <summary>
        /// 经办人
        /// </summary>
        [XmlElement("aae011")]
        public string OperatorName { get; set; }
        /// <summary>
        /// 经办时间
        /// </summary>
        [XmlElement("aae011")]
        public string OperatorTime { get; set; }
        /// <summary>
        /// 职业
        /// </summary>
        [XmlElement("yke508")]
        public string Job { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        [XmlElement("yke508")]
        public string Birthday { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [XmlElement("yke508")]
        public int Age { get; set; }
        /// <summary>
        /// 是否复诊
        /// </summary>
        [XmlElement("yke509")]
        public  int IsRepeatedDiagnosis { get; set; }
        /// <summary>
        /// 是否外伤
        /// </summary>
        [XmlElement("yke510")]
        public int IsTrauma { get; set; }
        /// <summary>
        /// 科室病区编号
        /// </summary>
        [XmlElement("yke414")]
        public string DepartmentAreaCode { get; set; }
        /// <summary>
        /// 医生编号
        /// </summary>
        [XmlElement("yke419")]
        public string DoctorCode { get; set; }
        /// <summary>
        /// 现病使
        /// </summary>
        [XmlElement("yke513")]
        public string AntecedentHistory { get; set; }
        /// <summary>
        /// 体格检查
        /// </summary> T36.5℃
        [XmlElement("yke517")]
        public string PhysiqueInspect { get; set; }
       

    }
    /// <summary>
    /// 
    /// </summary>
    [XmlType(AnonymousType = true)]
    public class OutpatientDetailUploadDataSymptomDetailXmlDto
    {/// <summary>
     /// 门诊症状-诊断代码
     /// </summary>
        [XmlElement("ykc328", IsNullable = false)]
        public string DiagnosisCode { get; set; }
        /// <summary>
        /// 门诊症状-名称
        /// </summary>
        [XmlElement("ykc311", IsNullable = false)]
        public string DiagnosisName { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    [XmlType(AnonymousType = true)]
    public class OutpatientDetailUploadDataDiagnosisDetailXmlDto
    {
        /// <summary>
        ///诊断分类  1.中医 2.西医                                              
        /// </summary>
        [XmlElement("yke526", IsNullable = false)]
        public string DiagnosisType { get; set; }

        /// <summary>
        ///诊断代码
        /// </summary>
        [XmlElement("ykc312", IsNullable = false)]
        public string DiagnosisCode { get; set; }
        /// <summary>
        ///诊断名称
        /// </summary>
        [XmlElement("ykc312", IsNullable = false)]
        public string DiagnosisName { get; set; }
      
    }
    /// <summary>
    /// 西药处方
    /// </summary>
    [XmlType(AnonymousType = true)]
    public class OutpatientWesternDrugPrescriptionDetail
    {
        /// <summary>
        ///处方号
        /// </summary>
        [XmlElement("yke134", IsNullable = false)]
        public string PrescriptionNo { get; set; }
        /// <summary>
        /// 取药人
        /// </summary>
        [XmlElement("yke346", IsNullable = false)]
        public  string GetDrugPerson { get; set; }
        /// <summary>
        /// 药物开始使用时间
        /// </summary>
        [XmlElement("yke359", IsNullable = false)]
        public  string UseDrugStartTime { get; set; }
        /// <summary>
        /// 药物结束使用时间
        /// </summary>
        [XmlElement("yke360", IsNullable = false)]
        public string UseDrugEndTime { get; set; }
    }
    /// <summary>
    /// 病人医嘱
    /// </summary>
    [XmlType(AnonymousType = true)]
    public class OutpatientPatientOrdersDetail
    {  /// <summary>
       /// 医嘱编号
       /// </summary>
        [XmlElement("yke112", IsNullable = false)]
        public string OrdersNo { get; set; }

        /// <summary>
        /// 医嘱内容
        /// </summary>yke113
        [XmlElement("yke113", IsNullable = false)]
        public string OrdersContent { get; set; }
        /// <summary>
        /// 医生姓名
        /// </summary>
        [XmlElement("yka287", IsNullable = false)]
        public  string DoctorName { get; set; }
        /// <summary>
        /// 医嘱开始时间
        /// </summary>
        [XmlElement("yke361", IsNullable = false)]
        public  string OrdersStartTime { get; set; }
        /// <summary>
        /// 经办人
        /// </summary>
        [XmlElement("aae011", IsNullable = false)]
        
        public string OperatorName   { get; set; }
        /// <summary>
        /// 医职人员编码
        /// </summary>
        [XmlElement("ykf008", IsNullable = false)]

        public string DoctorCode { get; set; }
        /// <summary>
        /// 医嘱科室编码
        /// </summary>
        [XmlElement("aaz307", IsNullable = false)]

        public string OrdersDepartmentCode { get; set; }
        /// <summary>
        /// 医嘱科室名称
        /// </summary>
        [XmlElement("akf002", IsNullable = false)]

        public string OrdersDepartmentName { get; set; }
        /// <summary>
        /// 项目对码编号
        /// </summary>
        [XmlElement("ake005", IsNullable = false)]

        public string ProjectPairCode { get; set; }
        /// <summary>
        /// 使用天数
        /// </summary>
        [XmlElement("yke446", IsNullable = false)]

        public int UseDay { get; set; }
    } 

}
