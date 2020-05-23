using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.InHospital.AdmissionForHospital
{
    /// <summary>
    /// 入院办理-交易控制
    /// </summary>
    [XmlRoot("control", IsNullable = false)]
    public class AdmissionForHospitalControlXmlDto
    {
        /// <summary>
        /// 版本号
        /// </summary>
        public string Edition { get; set; } = "5.0";
    }
}