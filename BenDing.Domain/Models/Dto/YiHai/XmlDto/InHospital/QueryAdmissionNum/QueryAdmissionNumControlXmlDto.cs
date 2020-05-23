﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.InHospital.QueryAdmissionNum
{
    /// <summary>
    ///按就诊编号入出院信息查询-交易控制
    /// </summary>
    [XmlRoot("control", IsNullable = false)]
    public class QueryAdmissionNumControlXmlDto
    {
        /// <summary>
        /// 就诊编码
        /// </summary>
        [XmlElementAttribute("akc190")]
        public string OperatorName { get; set; }

        /// <summary>
        /// 个人编码
        /// </summary>
        [XmlElement(" aac001")]
        public string PersonNum { get; set; }


        /// <summary>
        /// 支付类别-代码
        /// </summary>
        [XmlElement(" aka130")]
        public string PayCategory { get; set; }

        /// <summary>
        /// 医保经办机构
        /// </summary>
        [XmlElement("yab003")]
        public string HealthCareInstitutions { get; set; }
    }
}