using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.InHospital.QueryInHospitalTime
{
    /// <summary>
    ///按入院经办时间入出院信息查询-交易控制
    /// </summary>
    [XmlRoot("control", IsNullable = false)]
    public class QueryInHospitalTimeControlXmlDto
    {

        /// <summary>
        /// 医保经办机构
        /// </summary>
        [XmlElement("yab003")]
        public string HealthCareInstitutions { get; set; }


        /// <summary>
        ///开始时间
        /// </summary>
        [XmlElement("ykc014_b")]
        public string StartTime { get; set; }

        /// <summary>
        ///截止时间
        /// </summary>
        [XmlElement("ykc014_e")]
        public string EndTime { get; set; }
    }
}