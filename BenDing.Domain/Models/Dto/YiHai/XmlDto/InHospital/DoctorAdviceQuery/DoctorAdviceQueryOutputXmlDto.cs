using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.InHospital.DoctorAdviceQuery
{
    /// <summary>
    ///住院医嘱查询-交易输出详细
    /// </summary>
    [XmlRoot("output", IsNullable = false)]
    public class DoctorAdviceQueryOutputXmlDto
    {
        [XmlElement("dataset")]
        [XmlArrayItem("row")]
        public List<DoctorAdviceQueryOutputRow> Rows { get; set; }
    }

    [XmlTypeAttribute(AnonymousType = true)]
    public class DoctorAdviceQueryOutputRow
    {

        /// <summary>
        /// 医嘱序号-唯一标识一条医嘱记录
        /// </summary>
        [XmlElement("yke112")]
        public string OrdersSortNo { get; set; }
        /// <summary>
        /// 医嘱内容
        /// </summary>
        [XmlElement("yke113")]
        public string OrdersContent { get; set; }


        /// <summary>
        /// 医嘱日期-医生下医嘱时间
        /// </summary>
        [XmlElement("yka286")]
        public DateTime DoctorAdvicTime { get; set; }

        /// <summary>
        /// 医生姓名-代码
        /// </summary>
        [XmlElement("yka287")]
        public string DoctorName { get; set; }
        /// <summary>
        /// 医生编码-医院自编码，对应医生信息上传中的编码
        /// </summary>
        [XmlElement("ykf008")]
        public string DoctorCode { get; set; }
        /// <summary>
        /// 医嘱科室编码-医院自编码，对应科室信息上传中的编码
        /// </summary>
        [XmlElement("aaz307")]
        public string DepartmentCode { get; set; }

        /// <summary>
        /// 医嘱科室名称-医院自编名称，对应科室信息上传中的名称
        /// </summary>
        [XmlElement("akf002")]
        public string DepartmentName { get; set; }
        /// <summary>
        /// 医院对码编号-医院自编码，对应三目信息上传中的编码
        /// </summary>
        [XmlElement("ake005")]
        public string HospitalCodeNo { get; set; }
        /// <summary>
        /// 医嘱类别-码表
        /// </summary>
        [XmlElement("yke365")]
        public string OrdersType { get; set; }
        /// <summary>
        /// 医嘱分类-码表
        /// </summary>
        [XmlElement("yke658")]
        public string OrdersClassify { get; set; }


        /// <summary>
        /// 医嘱开始嘱日期时间-医嘱的开始时间
        /// </summary>
        [XmlElement("yke361")]
        public DateTime DoctorAdvicStartTime { get; set; }


        /// <summary>
        /// 剂量单位-采用英文缩写格式：g（克）， mg（毫克）， pg（微克）， ml（毫升）， p（单位）
        /// </summary>
        [XmlElement("yke351")]
        public string DoseUnit { get; set; }
        /// <summary>
        /// 剂量
        /// </summary>
        [XmlElement("yke352")]
        public int Dose { get; set; }

        /// <summary>
        /// 用药途径-编码
        /// </summary>
        [XmlElement("yke355")]
        public string UserRoad { get; set; }
        /// <summary>
        /// 每次用量
        /// </summary>
        [XmlElement("yke654")]
        public int EveryTimeDosage { get; set; }
        /// <summary>
        /// 每次用量单位
        /// </summary>
        [XmlElement("yke655")]
        public string EveryTimeDosageUnit { get; set; }
        /// <summary>
        /// 发药量
        /// </summary>
        [XmlElement("yke656")]
        public int Dosage { get; set; }
        /// <summary>
        /// 发药量单位
        /// </summary>
        [XmlElement("yke657")]
        public string DosageUnit { get; set; }
        /// <summary>
        /// 频次--采用英文缩写格式：qd（每日 1次）， bid（每日 2次），tid（每日3次）， qid（每日 4次）， qn（每晚睡前1次），qod（隔日 1次）， prn（必要时 1次）， q 2h（每 2小时 1次），q6h（每 6 小时1次）
        /// </summary>
        [XmlElement("yke350")]
        public string Frequency { get; set; }

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