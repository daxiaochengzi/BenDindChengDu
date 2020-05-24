using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.InHospital.DoctorAdviceExecuteQuery
{
    /// <summary>
    /// 住院医嘱执行查询-交易输出详细
    /// </summary>
    [XmlRoot("output", IsNullable = false)]
    public class DoctorAdviceExecuteQueryOutputXmlDto
    {
        [XmlElement("row")]

        public DoctorAdviceExecuteQueryOutputRow Row { get; set; }
    }

    [XmlTypeAttribute(AnonymousType = true)]
    public class DoctorAdviceExecuteQueryOutputRow
    {
        /// <summary>
        /// 医嘱序号----唯一标识一条医嘱记录
        /// </summary>
        [XmlElement("yke112")]
        public string OrdersSortNo { get; set; }

        /// <summary>
        /// 医嘱执行流水号----唯一标识一条医嘱执行记
        /// </summary>
        [XmlElement("yke683")]
        public string OrdersSerialNum { get; set; }

        /// <summary>
        /// 医嘱执行日期时间
        /// </summary>
        [XmlElement("yke363")]
        public DateTime ExcuteTime { get; set; }

        /// <summary>
        /// 床号
        /// </summary>
        [XmlElement("yke413")]
        public string BedNum { get; set; }

        /// <summary>
        /// 医嘱执行者
        /// </summary>
        [XmlElement("yke674")]
        public string DoPersonName { get; set; }

    }
}