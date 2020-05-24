using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.OutpatientDepartment
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
        [XmlElementAttribute("datasetfymx")]
        [XmlArrayItem("row")]
        public List<OutpatientDetailUploadDataCostDetailXmlDto> CostDetail { get; set; }

        /// <summary>
        /// 挂号信息
        /// </summary>
        [XmlElementAttribute("datasetghxx")]
        public OutpatientDetailUploadDataRegisterDetailXmlDto RegisterDetail { get; set; }

        /// <summary>
        /// 服务对象明细
        /// </summary>
        [XmlElementAttribute("datasetfwdx")]
        public OutpatientDetailUploadDataServiceObjectDetailXmlDto ServiceObjectDetail { get; set; }
        /// <summary>
        /// 门诊病历明细
        /// </summary>
        [XmlElementAttribute("datasetmzbl")]
        public OutpatientDetailUploadDataOutpatientMedicalRecordDetailXmlDto MedicalRecordDetail { get; set; }

        /// <summary>
        /// 西药处方
        /// </summary>
        [XmlElementAttribute("datasetxydz")]
        [XmlArrayItem("row")]
        public List<OutpatientWesternDrugPrescriptionDetail> WesternDrugDetail { get; set; }

        /// <summary>
        /// 医嘱明细
        /// </summary>
        [XmlElementAttribute("datasetyz")]
        [XmlArrayItem("row")]
        public List<OutpatientPatientOrdersDetail> OrdersDetail { get; set; }

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
    public class OutpatientDetailUploadDataServiceObjectDetailXmlDto
    { /// <summary>
        /// 经办人
        /// </summary>
        [XmlElementAttribute("aae011", IsNullable = false)]
        public string OperationName { get; set; }
        /// <summary>
        /// 经办时间
        /// </summary>
        [XmlElementAttribute("aae036", IsNullable = false)]
        public string OperationTime { get; set; }

    }
    /// <summary>
    /// 门诊病历
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]

    public class OutpatientDetailUploadDataOutpatientMedicalRecordDetailXmlDto
    { /// <summary>
      /// 就医开始时间
      /// </summary>
        [XmlElementAttribute("ykc142", IsNullable = false)]
        public string DiagnosisStartTime { get; set; }
        /// <summary>
        /// 主诉
        /// </summary>
        [XmlElementAttribute("ykc310", IsNullable = false)]
        public string MainDiagnosis { get; set; }
        /// <summary>
        /// 门诊症状
        /// </summary>
        [XmlElementAttribute("datasetykc328")]
        [XmlArrayItem("row")]
        public List<OutpatientDetailUploadDataSymptomDetailXmlDto> SymptomDetail { get; set; }
        /// <summary>
        /// 诊断明细
        /// </summary>
        [XmlElementAttribute("datasetykc312")]
        [XmlArrayItem("row")]
        public List<OutpatientDetailUploadDataDiagnosisDetailXmlDto> DiagnosisDetail { get; set; }
        /// <summary>
        /// 发病日期
        /// </summary>
        [XmlElementAttribute("ykc314")]
        public string FindDiseaseTime { get; set; }
        /// <summary>
        /// 诊断时间
        /// </summary>
        [XmlElementAttribute("ykc315")]
        public string DiagnosisTime { get; set; }
        /// <summary>
        /// 就诊类型 代码(1.普通就诊,2.急救,3.抢救)
        /// </summary>
        [XmlElementAttribute("yke479")]
        public string VisitType { get; set; }
        /// <summary>
        /// 是否会诊
        /// </summary>
        [XmlElementAttribute("yke480")]
        public int IsConsultation { get; set; }

        /// <summary>
        /// 是否确认诊断
        /// </summary>
        [XmlElementAttribute("yke480")]
        public int IsConfirmDiagnosis { get; set; }
        /// <summary>
        /// 经办人
        /// </summary>
        [XmlElementAttribute("aae011")]
        public string OperatorName { get; set; }
        /// <summary>
        /// 经办时间
        /// </summary>
        [XmlElementAttribute("aae011")]
        public string OperatorTime { get; set; }
        /// <summary>
        /// 职业
        /// </summary>
        [XmlElementAttribute("yke508")]
        public string Job { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        [XmlElementAttribute("yke508")]
        public string Birthday { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [XmlElementAttribute("yke508")]
        public int Age { get; set; }
        /// <summary>
        /// 是否复诊
        /// </summary>
        [XmlElementAttribute("yke509")]
        public  int IsRepeatedDiagnosis { get; set; }
        /// <summary>
        /// 是否外伤
        /// </summary>
        [XmlElementAttribute("yke510")]
        public int IsTrauma { get; set; }
        /// <summary>
        /// 科室病区编号
        /// </summary>
        [XmlElementAttribute("yke414")]
        public string DepartmentAreaCode { get; set; }
        /// <summary>
        /// 医生编号
        /// </summary>
        [XmlElementAttribute("yke419")]
        public string DoctorCode { get; set; }
        /// <summary>
        /// 现病使
        /// </summary>
        [XmlElementAttribute("yke513")]
        public string AntecedentHistory { get; set; }
        /// <summary>
        /// 体格检查
        /// </summary>
        [XmlElementAttribute("yke517")]
        public string PhysiqueInspect { get; set; }
       

    }
    /// <summary>
    /// 
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class OutpatientDetailUploadDataSymptomDetailXmlDto
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
    /// <summary>
    /// 
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class OutpatientDetailUploadDataDiagnosisDetailXmlDto
    {
        /// <summary>
        ///诊断分类  1.中医 2.西医                                              
        /// </summary>
        [XmlElementAttribute("yke526", IsNullable = false)]
        public string DiagnosisType { get; set; }

        /// <summary>
        ///诊断代码
        /// </summary>
        [XmlElementAttribute("ykc312", IsNullable = false)]
        public string DiagnosisCode { get; set; }
        /// <summary>
        ///诊断名称
        /// </summary>
        [XmlElementAttribute("ykc312", IsNullable = false)]
        public string DiagnosisName { get; set; }
      
    }
    /// <summary>
    /// 西药处方
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class OutpatientWesternDrugPrescriptionDetail
    {
        /// <summary>
        ///处方号
        /// </summary>
        [XmlElementAttribute("yke134", IsNullable = false)]
        public string PrescriptionNo { get; set; }
        /// <summary>
        /// 取药人
        /// </summary>
        [XmlElementAttribute("yke346", IsNullable = false)]
        public  string GetDrugPerson { get; set; }
        /// <summary>
        /// 药物开始使用时间
        /// </summary>
        [XmlElementAttribute("yke359", IsNullable = false)]
        public  string UseDrugStartTime { get; set; }
        /// <summary>
        /// 药物结束使用时间
        /// </summary>
        [XmlElementAttribute("yke360", IsNullable = false)]
        public string UseDrugEndTime { get; set; }
    }
    /// <summary>
    /// 病人医嘱
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class OutpatientPatientOrdersDetail
    {  /// <summary>
       /// 医嘱编号
       /// </summary>
        [XmlElementAttribute("yke112", IsNullable = false)]
        public string OrdersNo { get; set; }

        /// <summary>
        /// 医嘱内容
        /// </summary>yke113
        [XmlElementAttribute("yke113", IsNullable = false)]
        public string OrdersContent { get; set; }
        /// <summary>
        /// 医生姓名
        /// </summary>
        [XmlElementAttribute("yka287", IsNullable = false)]
        public  string DoctorName { get; set; }
        /// <summary>
        /// 医嘱开始时间
        /// </summary>
        [XmlElementAttribute("yke361", IsNullable = false)]
        public  string OrdersStartTime { get; set; }
        /// <summary>
        /// 经办人
        /// </summary>
        [XmlElementAttribute("aae011", IsNullable = false)]
        
        public string OperatorName   { get; set; }
        /// <summary>
        /// 医职人员编码
        /// </summary>
        [XmlElementAttribute("ykf008", IsNullable = false)]

        public string DoctorCode { get; set; }
        /// <summary>
        /// 医嘱科室编码
        /// </summary>
        [XmlElementAttribute("aaz307", IsNullable = false)]

        public string OrdersDepartmentCode { get; set; }
        /// <summary>
        /// 医嘱科室名称
        /// </summary>
        [XmlElementAttribute("akf002", IsNullable = false)]

        public string OrdersDepartmentName { get; set; }
        /// <summary>
        /// 项目对码编号
        /// </summary>
        [XmlElementAttribute("ake005", IsNullable = false)]

        public string ProjectPairCode { get; set; }
        /// <summary>
        /// 使用天数
        /// </summary>
        [XmlElementAttribute("yke446", IsNullable = false)]

        public int UseDay { get; set; }
    } 

}
