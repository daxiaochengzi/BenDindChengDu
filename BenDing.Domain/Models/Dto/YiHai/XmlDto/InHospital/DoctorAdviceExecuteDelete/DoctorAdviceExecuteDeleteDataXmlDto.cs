using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.InHospital.DoctorAdviceExecuteDelete
{
    /// <summary>
    ///		住院医嘱执行删除-交易输入
    /// </summary>
    [XmlRoot("data", IsNullable = false)]
    public class DoctorAdviceExecuteDeleteDataXmlDto
    {
        [XmlElement("dataset")]
        public DoctorAdviceExecuteDeleteDataSet DataSet { get; set; }
    }

    [XmlTypeAttribute(AnonymousType = true)]
    public class DoctorAdviceExecuteDeleteDataSet
    {
        [XmlElement("row")]
        public DoctorAdviceExecuteDeleteDataRow Row { get; set; }

    }


    [XmlTypeAttribute(AnonymousType = true)]
    public class DoctorAdviceExecuteDeleteDataRow
    {  /// <summary>
       /// 医嘱序号----唯一标识一条医嘱记录
       /// </summary>
        [XmlElement("yke112")]
        public string OrdersSortNo { get; set; }

        /// <summary>
        /// 医嘱执行流水号----唯一标识一条医嘱执行记
        /// </summary>
        [XmlElement("yke683")]
        public string OrdersSerialNum { get; set; }
    }
}