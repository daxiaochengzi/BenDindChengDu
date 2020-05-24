using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.InHospital.DoctorAdviceCancell
{
    /// <summary>
    ///	住院医嘱作废-交易输入
    /// </summary>
    [XmlRoot("data", IsNullable = false)]
    public class DoctorAdviceCancellDataXmlDto
    {
        [XmlElement("row")]
        public List<DoctorAdviceCancellDataRow> Rows { get; set; }
    }
    [XmlTypeAttribute(AnonymousType = true)]
    public class DoctorAdviceCancellDataRow
    {
        /// <summary>
        /// 医嘱序号-唯一标识一条医嘱记录
        /// </summary>
        [XmlElement("yke112")]
        public string OrdersSortNo { get; set; }

        /// <summary>
        /// 医嘱作废时间
        /// </summary>
        [XmlElement("yke224")]
        public DateTime CancellTime { get; set; }

        /// <summary>
        /// 作废原因
        /// </summary>
        [XmlElement("yke184")]
        public string CancellReason { get; set; }

        /// <summary>
        /// 医嘱作废人姓名
        /// </summary>
        [XmlElement("ykc213")]
        public string CancellPersonName { get; set; }


    }
}