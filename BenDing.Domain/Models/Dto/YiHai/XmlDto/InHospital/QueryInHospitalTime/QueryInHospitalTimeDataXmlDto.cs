using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.InHospital.QueryInHospitalTime
{
    /// <summary>
    /// 按入院经办时间入出院信息查询-交易输入
    /// </summary>
    [XmlRoot("data", IsNullable = false)]
    public class QueryInHospitalTimeDataXmlDto
    {
        /// <summary>
        /// 文件路径
        /// </summary>
        [XmlElement("dir")]
        public string ResponsiblePerson { get; set; }
    }
}