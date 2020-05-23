using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.InHospital.DischargeForHospital
{
    /// <summary>
    /// 出院办理-交易输入
    /// </summary>
    [XmlRoot("data", IsNullable = false)]
    public class DischargeForHospitalDatalXmlDto
    {
        /// <summary>
        /// 出院原因
        /// </summary>
        [XmlElement("akc195")]
        public string OutReason { get; set; }

        /// <summary>
        /// 出院日期
        /// </summary>
        [XmlElement("akc194")]
        public string OutDateTime { get; set; }

        /// <summary>
        /// 出院诊断
        /// </summary>
        [XmlElement("akc196")]
        public string OutDiagnose { get; set; }

        /// <summary>
        /// 出院科室
        /// </summary>
        [XmlElement("ykc015")]
        public string OutDept { get; set; }

        /// <summary>
        /// 出院床位
        /// </summary>
        [XmlElement("ykc016")]
        public string OutBed { get; set; }


        /// <summary>
        /// 经办人姓名
        /// </summary>
        [XmlElement("aae011")]
        public string ResponsiblePerson { get; set; }

        /// <summary>
        /// 出院经办时间
        /// </summary>
        [XmlElement("ykc018")]
        public DateTime OutResponsibleTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [XmlElement("aae013")]
        public string Remark { get; set; }

        /// <summary>
        /// 疾病诊断代码-参见疾病诊断代码信息
        /// </summary>
        [XmlElement("ykd018dataset")]
        public DischargeForHospitalDatalXmlDataset Dataset { get; set; }

        /// <summary>
        /// 病人联系电话
        /// </summary>
        [XmlElement("aae005")]
        public string PatientPhone { get; set; }
        /// <summary>
        /// 诊疗过程描述
        /// </summary>
        [XmlElement("ykc324")]
        public string DiagnosticProcedureDesc { get; set; }

        /// <summary>
        /// 中医第一疾病诊断编码-中医第一诊断和西医第一诊断不能同时为空，ICD-10 国际疾病分类标准编码 国际疾病分类标准编码
        /// </summary>
        [XmlElement("yke527")]
        public string ZhDiseaseCodingNoOne { get; set; }

        ///<summary>
        /// 中医第二疾病诊断编码-ICD-10 国际疾病分类标准编码 国际疾病分类标准编码
        /// </summary>
        [XmlElement("yke528")]
        public string ZhDiseaseCodingNoTwo { get; set; }
        ///<summary>
        /// 中医第三疾病诊断编码-ICD-10 国际疾病分类标准编码 国际疾病分类标准编码
        /// </summary>
        [XmlElement("yke529")]
        public string ZhDiseaseCodingNoThree { get; set; }


        /// <summary>
        /// 西医第一疾病诊断编码-中医第一诊断和西医第一诊断不能同时为空，ICD-10 国际疾病分类标准编码 国际疾病分类标准编码
        /// </summary>
        [XmlElement("yke530")]
        public string EnDiseaseCodingNoOne { get; set; }

        ///<summary>
        /// 西医第二疾病诊断编码-ICD-10 国际疾病分类标准编码 国际疾病分类标准编码
        /// </summary>
        [XmlElement("yke531")]
        public string EnDiseaseCodingNoTwo { get; set; }
        ///<summary>
        /// 西医第三疾病诊断编码-ICD-10 国际疾病分类标准编码 国际疾病分类标准编码
        /// </summary>
        [XmlElement("yke532")]
        public string EnDiseaseCodingNoThree { get; set; }

        /// <summary>
        /// 医疗付款方式-码表
        /// </summary>
        [XmlElement("yke659")]
        public string PayWay { get; set; }

        /// <summary>
        /// 出院科室编码-医院自编码，对应科室信息上传中的编码
        /// </summary>
        [XmlElement("yke663")]
        public string OutDeptNum { get; set; }

        /// <summary>
        /// 实际住院天数
        /// </summary>
        [XmlElement("yke664")]
        public int InHospitalDays { get; set; }

        /// <summary>
        /// 离院方式-码表
        /// </summary>
        [XmlElement("yke665")]
        public string LeaveHospitalWay { get; set; }

        /// <summary>
        /// 医院血透标志-是否码表
        /// </summary>
        [XmlElement("yke681")]
        public string HemodialysisSign { get; set; }


    }

    
    [XmlTypeAttribute(AnonymousType = true)]
    public class DischargeForHospitalDatalXmlDataset
    {
        [XmlElement("Row")]
        public DischargeForHospitalDatalXmlRow Row { get; set; }
    }

    [XmlTypeAttribute(AnonymousType = true)]
    public class DischargeForHospitalDatalXmlRow
    {
        /// <summary>
        /// 疾病诊断代码-参见疾病诊断代码信息
        /// </summary>
        [XmlElement("ykd018")]
        public string DiagnosticCode { get; set; }


    }
}
