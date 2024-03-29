﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.MedicalInsuranceSignIn
{
    /// <summary>
    /// 
    /// </summary>
    [XmlRoot("control", IsNullable = false)]
    public class SignInControlXmlDto
    {  /// <summary>
        /// 操作人员姓名
        /// </summary>
        [XmlElementAttribute("aae011", IsNullable = false)]
        public string OperationName { get; set; }
    }

}
