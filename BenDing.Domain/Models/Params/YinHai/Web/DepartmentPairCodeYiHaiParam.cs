using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Params.YinHai.Web
{
   public class DepartmentPairCodeYiHaiParam
    {
        public string keyword { get; set; }
        /// <summary>
        /// 医保科室编码
        /// </summary>
        public  string MedicalInsuranceCode { get; set; }
        /// <summary>
        /// 医保对码科室名称
        /// </summary>
        public string MedicalInsuranceName { get; set; }
        /// <summary>
        /// 病区编号
        /// </summary>
        public  string InpatientAreaCode { get; set; }
        /// <summary>
        /// 病区责任人
        /// </summary>
        public string InpatientAreaDutyPerson { get; set; }
    }
}
