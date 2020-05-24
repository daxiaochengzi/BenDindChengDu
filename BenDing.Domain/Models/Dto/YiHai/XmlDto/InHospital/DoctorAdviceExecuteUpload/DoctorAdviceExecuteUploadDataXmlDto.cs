using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.InHospital.DoctorAdviceExecuteUpload
{
    /// <summary>
    ///	住院医嘱执行上传-交易输入
    /// </summary>
    [XmlRoot("data", IsNullable = false)]
    public class DoctorAdviceExecuteUploadDataXmlDto
    {
        [XmlElement("dataset")]
        public DoctorAdviceExecuteUploadDataDataset DataSet { get; set; }
    }

    [XmlTypeAttribute(AnonymousType = true)]
    public class DoctorAdviceExecuteUploadDataDataset
    {
        [XmlElement("row")]
        public DoctorAdviceExecuteUploadDataRow Row { get; set; }

    }


    [XmlTypeAttribute(AnonymousType = true)]
    public class DoctorAdviceExecuteUploadDataRow
    {  /// <summary>
       /// 医嘱序号----唯一标识一条医嘱记录
       /// </summary>
        [XmlElement("yke112")]
        public string OrdersSortNo { get; set; }

        /// <summary>
        /// 医嘱执行流水号----唯一标识一条医嘱执行记
        /// </summary>
        [XmlElement("yke683")]
        public string OrdersSerialNum  { get; set; }
     
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