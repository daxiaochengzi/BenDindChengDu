using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.OpSpecials
{   /// <summary>
    ///  新门特病种认定查询（122）出参
    /// </summary>
    [XmlRoot("output", IsNullable = false)]
    public class QuerySickTypeCognizanceOutputDto
    {
        /// <summary>
        /// 人员类别
        /// </summary>
        [XmlElement("rylb")]
        public string PersonnelCategory { get; set; }


        /// <summary>
        /// 统筹可支付金额
        /// </summary>
        [XmlElement("tckzfje")]
        public decimal TotalPayableAmount { get; set; }


        /// <summary>
        /// 城乡统筹可支付金额
        /// </summary>
        [XmlElement("tckzfjecx")]
        public decimal CityCountryTotalPayableAmount { get; set; }
        /// <summary>
        /// 新门特病种认定查询 出餐明细
        /// </summary>
        [XmlArrayItem("row")]
        public List<QuerySickTypeCognizanceOutputDetail> Details { get; set; }


    }
    [XmlType(AnonymousType = true)]
    public class QuerySickTypeCognizanceOutputDetail
    {

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
        ///病种付费方式
        /// </summary>
        [XmlElementAttribute("yka441")]
        public decimal PayType { get; set; }

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
        /// 认定状态
        /// </summary>
        [XmlElement("rdzt")]
        public string Status { get; set; }


    }


}
