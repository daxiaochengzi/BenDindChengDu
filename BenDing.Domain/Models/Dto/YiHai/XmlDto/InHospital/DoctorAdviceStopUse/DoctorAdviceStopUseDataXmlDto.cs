using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.InHospital.DoctorAdviceStopUse
{
    /// <summary>
    ///	住院医嘱停用-交易输入
    /// </summary>
    [XmlRoot("data", IsNullable = false)]
    public class DoctorAdviceStopUseDataXmlDto
    {
        [XmlElement("dataset")]
        [XmlArrayItem("row")]
        public List<DoctorAdviceStopUseDataRow> Rows { get; set; }
    }
    [XmlTypeAttribute(AnonymousType = true)]
    public class DoctorAdviceStopUseDataRow
    {  /// <summary>
       /// 医嘱序号----唯一标识一条医嘱记录
       /// </summary>
        [XmlElement("yke112")]
        public string OrdersSortNo { get; set; }

        /// <summary>
        /// 长期医嘱停嘱日期时间
        /// </summary>
        [XmlElement("yke362")]
        public string StopDocAdviceTime { get; set; }

        /// <summary>
        /// 长期医嘱停医嘱人
        /// </summary>
        [XmlElement("yke684")]
        public string WhoStopDocAdvice { get; set; }
    }
}