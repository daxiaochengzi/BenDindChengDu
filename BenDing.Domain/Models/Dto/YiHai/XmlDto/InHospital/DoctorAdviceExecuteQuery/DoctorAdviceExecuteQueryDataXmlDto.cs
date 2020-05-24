using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.InHospital.DoctorAdviceExecuteQuery
{
    /// <summary>
    ///住院医嘱执行查询-交易输入
    /// </summary>
    [XmlRoot("data", IsNullable = false)]
    public class DoctorAdviceExecuteQueryDataXmlDto
    {
        [XmlElement("dataset")]
        public DoctorAdviceExecuteQueryDataSet DataSet { get; set; }
    }

    [XmlTypeAttribute(AnonymousType = true)]
    public class DoctorAdviceExecuteQueryDataSet
    {
        [XmlElement("row")]
        public DoctorAdviceExecuteQueryDataRow Row { get; set; }

    }


    [XmlTypeAttribute(AnonymousType = true)]
    public class DoctorAdviceExecuteQueryDataRow
    {  /// <summary>
       /// 医嘱序号----唯一标识一条医嘱记录
       /// </summary>
        [XmlElement("yke112")]
        public string OrdersSortNo { get; set; }

       
    }
}