﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.CancelMedicalInsuranceSignIn
{
    [XmlRoot("Control", IsNullable = false)]
    public class CancelMedicalInsuranceSignInControlXmlDto
    {/// <summary>
     /// 批次号
     /// </summary>
        [XmlElementAttribute("yke189", IsNullable = false)]
        public string BatchNo { get; set; }
        /// <summary>
        /// 医保经办机构
        /// </summary>
        [XmlElementAttribute("yab003", IsNullable = false)]
        public string MedicalInsuranceOrganization { get; set; }
    }
}
