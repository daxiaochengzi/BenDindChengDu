using System;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.InHospital.QueryInHospitalTime
{
    /// <summary>
    /// 按入院经办时间入出院信息查询-交易输出详细
    /// </summary>
    [XmlRoot("output", IsNullable = false)]
    public class QueryInHospitalTimeOutPutXmlDto
    {
        [XmlElement("row")]
        public QueryInHospitalTimeOutPutDataXmlRow Row { get; set; }
    }

    [XmlTypeAttribute(AnonymousType = true)]
    public class QueryInHospitalTimeOutPutDataXmlRow
    {
        /// <summary>
        /// 就诊编号
        /// </summary>
        [XmlElement("akc190")]
        public string InpatientFixedEncoding { get; set; }

        /// <summary>
        /// 个人编号
        /// </summary>
        [XmlElement("aac001")]
        public string PersonalNum { get; set; }


        /// <summary>
        /// 支付类别-代码
        /// </summary>
        [XmlElement("aka130")]
        public string PayType { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [XmlElement("aac003")]
        public string Name { get; set; }

        /// <summary>
        /// 性别-代码
        /// </summary>
        [XmlElement("aac004")]
        public string Sex { get; set; }

        /// <summary>
        /// 住院状态
        /// </summary>
        [XmlElement("ykc023")]
        public string TheHospitalStatus { get; set; }

        /// <summary>
        /// 病历号
        /// </summary>
        [XmlElement("ykc009")]
        public string MedicalRecordNum { get; set; }


        /// <summary>
        /// 住院号
        /// </summary>
        [XmlElement("ykc010")]
        public string InHospitalNum { get; set; }


        /// <summary>
        /// 入院日期
        /// </summary>
        [XmlElement("akc192")]
        public DateTime InHospitalDate { get; set; }
        /// <summary>
        /// 入院诊断-代码
        /// </summary>
        [XmlElement("akc193")]
        public string InHospitalDiagnose { get; set; }


        /// <summary>
        /// 入院科室
        /// </summary>
        [XmlElement("ykc011")]
        public string InHospitalDept { get; set; }

        /// <summary>
        /// 入院床位
        /// </summary>
        [XmlElement("ykc012")]
        public string InHospitalBed { get; set; }

        /// <summary>
        /// 入院原因
        /// </summary>
        [XmlElement("ykc147")]
        public string InHospitalCause { get; set; }


        /// <summary>
        /// 入院经办人姓名
        /// </summary>
        [XmlElement("ykc013")]
        public string InHospitalResponsiblePerson { get; set; }

        /// <summary>
        /// 入院经办时间
        /// </summary>
        [XmlElement("ykc014")]
        public DateTime InHospitalResponsibleTime { get; set; }


        /// <summary>
        /// 病种编码
        /// </summary>
        [XmlElement("yka026")]
        public string DiseasesCode { get; set; }




        /// <summary>
        /// 出院原因
        /// </summary>
        [XmlElement("akc195")]
        public string OutReason { get; set; }

        /// <summary>
        /// 出院日期
        /// </summary>
        [XmlElement("akc194")]
        public DateTime OutDateTime { get; set; }

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
        /// 出院经办人姓名
        /// </summary>
        [XmlElement("ykc017")]
        public string OutResponsiblePerson { get; set; }

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
        /// 入院途径-代码 
        /// </summary>
        [XmlElement("yke660")]
        public string InHospitalway { get; set; }



        /// <summary>
        ///  婚姻状况类别-代码
        /// </summary>
        [XmlElement("yke380")]
        public string MaritalStatus { get; set; }

        /// <summary>
        ///  联系人姓名
        /// </summary>
        [XmlElement("aae004")]
        public string ContactName { get; set; }

        /// <summary>
        ///  联系人关系-代码
        /// </summary>
        [XmlElement("yke661")]
        public string ContactRelation { get; set; }

        /// <summary>
        ///  联系人电话
        /// </summary>
        [XmlElement("aae005")]
        public string ContactPhone { get; set; }


        /// <summary>
        ///   科室编码
        /// </summary>
        [XmlElement("yke662")]
        public string InHospitalDeptNum { get; set; }

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
    }
}
