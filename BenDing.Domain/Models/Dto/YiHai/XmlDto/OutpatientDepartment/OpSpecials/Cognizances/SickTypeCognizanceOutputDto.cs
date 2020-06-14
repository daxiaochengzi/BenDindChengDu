using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.OpSpecials
{   /// <summary>
    ///  新门特病种认定（120）出参
    /// </summary>
    [XmlRoot("output", IsNullable = false)]
    public class SickTypeCognizanceOutputDto
    {
        /// <summary>
        /// 个人编码
        /// </summary>
        [XmlElement("aac001")]
        public string PersonCode { get; set; }


        /// <summary>
        /// 认证输出明细
        /// </summary>
        [XmlArrayItem("row")]
        public List<SickTypeCognizanceOutputDetail> Details { get; set; }


    }
    [XmlType(AnonymousType = true)]
    public class SickTypeCognizanceOutputDetail
    {
        /// <summary>
        /// 个人编码
        /// </summary>
        [XmlElement("aac001")]
        public string PersonCode { get; set; }


        /// <summary>
        /// 病人姓名
        /// </summary>
        [XmlElement("aac003")]
        public string PatientName { get; set; }

        /// <summary>
        /// 病种编码
        /// </summary>
        [XmlElement("yka026")]
        public string SickTypeCode { get; set; }

        /// <summary>
        /// 病种名称
        /// </summary>
        [XmlElement("yka027")]

        public string SickTypeName { get; set; }

        /// <summary>
        /// 服务机构编号
        /// </summary>
        [XmlElement("akb020")]
        public string ServiceOrgNo { get; set; }


        /// <summary>
        /// 服务机构编号
        /// </summary>
        [XmlElement("akb021")]
        public string ServiceOrgName { get; set; }

        /// <summary>
        /// 认定生效时间
        /// </summary>
        [XmlElement("aae036")]
        public DateTime EffectiveTime { get; set; }
        /// <summary>
        /// 认定状态
        /// </summary>
        [XmlElement("rdzt")]
        public string Status { get; set; }


    }


}
