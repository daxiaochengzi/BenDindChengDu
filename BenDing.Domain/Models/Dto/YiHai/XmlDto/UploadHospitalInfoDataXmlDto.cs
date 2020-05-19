using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto
{
    [XmlRoot("data", IsNullable = false)]
    public class UploadHospitalInfoDataXmlDto
    {/// <summary>
    /// 开放总床数
    /// </summary>
        [XmlElementAttribute("datasetyyjbxx")]
        public UploadHospitalInfoBeDNumData BedNum { get; set; }

        /// <summary>
        /// 床位明细
        /// </summary>
        [XmlElementAttribute("datasetcw")]
        [XmlArrayItem("row")]
        public List<UploadHospitalInfoDataBedXmlDto> BedDetail { get; set; }


        /// <summary>
        /// 科室明细
        /// </summary>
        [XmlElementAttribute("datasetks")]
        [XmlArrayItem("row")]
        public List<UploadHospitalInfoDataDepartmentXmlDto> DepartmentDetail { get; set; }
        /// <summary>
        /// 医生
        /// </summary>
        [XmlElementAttribute("datasetyzry")]
        [XmlArrayItem("row")]
        public List<UploadHospitalInfoDataDoctorXmlDto> DoctorDetail { get; set; }

    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class UploadHospitalInfoBeDNumData
    {/// <summary>
        /// 床位合计数量
        /// </summary>
        [XmlElementAttribute("yke411", IsNullable = false)]
        public int TotalBadNum { get; set; }
    }

    /// <summary>
    /// 床位明细
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class UploadHospitalInfoDataBedXmlDto
    {/// <summary>
    /// 床位 [0.00]
    /// </summary>
        [XmlElementAttribute("yke410", IsNullable = false)]
        public decimal BedPrice { get; set; }

        /// <summary>
        /// 床位类别 (普通病床 -3)
        /// </summary>
        [XmlElementAttribute("yke411", IsNullable = false)]
        public string BedType { get; set; } = "3";
        /// <summary>
        /// 科室（病区）编号 (其他 -02230600)
        /// </summary>
        [XmlElementAttribute("yke414", IsNullable = false)]
        public string DepartmentInpatientAreaNo { get; set; } = "02230600";
        /// <summary>
        /// 医院科室自定义编码
        /// </summary>
        [XmlElementAttribute("yke506", IsNullable = false)]
        public string DepartmentCode { get; set; }
        /// <summary>
        /// 床位病区名称
        /// </summary>
        [XmlElementAttribute("yke412", IsNullable = false)]
        public string BadInpatientAreaName { get; set; }

        /// <summary>
        /// 床号
        /// </summary>
        [XmlElementAttribute("yke413", IsNullable = false)]
        public string BadNo { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [XmlElementAttribute("aae013", IsNullable = false)]
        public string Remark { get; set; }
        /// <summary>
        /// 经办人名称
        /// </summary>
        [XmlElementAttribute("aae011", IsNullable = false)]
        public string OperatorName { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        [XmlElementAttribute("aae036", IsNullable = false)]
        public string OperatorTime { get; set; }
    }
    /// <summary>
    /// 科室明细
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class UploadHospitalInfoDataDepartmentXmlDto
    {
        /// <summary>
        /// 科室（病区）编号 (其他 -02230600)
        /// </summary>
        [XmlElementAttribute("yke414", IsNullable = false)]
        public string DepartmentInpatientAreaNo { get; set; } = "02230600";
        /// <summary>
        /// 医院科室自定义编码
        /// </summary>
        [XmlElementAttribute("yke506", IsNullable = false)]
        public string DepartmentCode { get; set; }

        /// <summary>
        /// 科室名称
        /// </summary>
        [XmlElementAttribute("YKE415", IsNullable = false)]
        public string DepartmentName { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        [XmlElementAttribute("yke416", IsNullable = false)]
        public string LiablePerson{ get; set; }

        /// <summary>
        /// 床位数
        /// </summary>
        [XmlElementAttribute("yke417", IsNullable = false)]
        public int BadNum { get; set; }
        
    }
    /// <summary>
    /// 医生明细
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class UploadHospitalInfoDataDoctorXmlDto
    {/// <summary>
     /// 医执人员类别 (码表)
     /// </summary>
        [XmlElementAttribute("yke418", IsNullable = false)]
        public string DoctorType { get; set; }
        /// <summary>
        ///医生编号
        /// </summary>
        [XmlElementAttribute("yke419", IsNullable = false)]
        public string DoctorNo { get; set; }
        /// <summary>
        ///医生姓名
        /// </summary>
        [XmlElementAttribute("aac003", IsNullable = false)]
        public string DoctorName { get; set; }

        /// <summary>
        ///医生身份证
        /// </summary>
        [XmlElementAttribute("aac002", IsNullable = false)]
        public string DoctorIdCardNo { get; set; }
        /// <summary>
        ///医生性别
        /// </summary>
        [XmlElementAttribute("aac004", IsNullable = false)]
        public string DoctorSex { get; set; }
        /// <summary>
        ///医生治疗范围 (码表)
        /// </summary>
        [XmlElementAttribute("yke420", IsNullable = false)]
        public string DoctorTreatmentRange { get; set; }
        /// <summary>
        ///医生执业编号
        /// </summary>
        [XmlElementAttribute("yke421", IsNullable = false)]
        public string DoctorPracticeNo { get; set; }

        /// <summary>
        ///医生资格编号
        /// </summary>
        [XmlElementAttribute("yke422", IsNullable = false)]
        public string DoctorQualificationNo { get; set; }

        /// <summary>
        ///处方权
        /// </summary>
        [XmlElementAttribute("yke423", IsNullable = false)]
        public string PrescriptionRight { get; set; } = "1";

        /// <summary>
        ///医生年龄
        /// </summary>
        [XmlElementAttribute("akc023", IsNullable = false)]
        public int DoctorAge { get; set; }
        /// <summary>
        ///医执人员职称
        /// </summary>
        [XmlElementAttribute("yke424", IsNullable = false)]
        public string DoctorTitle { get; set; }

        /// <summary>
        ///医执人员职务
        /// </summary>
        [XmlElementAttribute("yke425", IsNullable = false)]
        public string DoctorJob { get; set; }
        /// <summary>
        /// 科室（病区）编号 (其他 -02230600)
        /// </summary>
        [XmlElementAttribute("yke414", IsNullable = false)]
        public string DepartmentInpatientAreaNo { get; set; } = "02230600";

        /// <summary>
        /// 医生诊断开始时间
        /// </summary>
        [XmlElementAttribute("yke431", IsNullable = false)]
        public string DoctorDiagnosisStartTime { get; set; }

        /// <summary>
        /// 医生执业地点
        /// </summary>
        [XmlElementAttribute("yke431", IsNullable = false)]
        public string DoctorAddress { get; set; }

        
        /// <summary>
        /// 医生联系电话
        /// </summary>
        [XmlElementAttribute("aae005", IsNullable = false)]
        public string DoctorTelephone { get; set; }

    }



}
