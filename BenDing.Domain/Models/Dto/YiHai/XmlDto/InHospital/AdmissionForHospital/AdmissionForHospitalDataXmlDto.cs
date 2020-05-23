using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.InHospital.AdmissionForHospital
{
    /// <summary>
    /// 入院办理-交易输入
    /// </summary>
    [XmlRoot("data", IsNullable = false)]
    public class AdmissionForHospitalDataXmlDto
    {
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
        /// 经办人姓名
        /// </summary>
        [XmlElement("aae011")]
        public string ResponsiblePerson { get; set; }

        /// <summary>
        /// 入院经办时间
        /// </summary>
        [XmlElement("ykc014")]
        public DateTime InHospitalResponsibleTime { get; set; }

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
        ///   入院科室编码-医院自编码，对应科室信息上传中的编码 如果科室编码发生变化，在23交易中使用该字段输入
        /// </summary>
        [XmlElement("yke662")]
        public string InHospitalDeptNum { get; set; }


        /// <summary>
        ///床号-医院自编码，科室内唯一
        /// </summary>
        [XmlElement("yke413")]
        public string BedNum { get; set; }
    }
}