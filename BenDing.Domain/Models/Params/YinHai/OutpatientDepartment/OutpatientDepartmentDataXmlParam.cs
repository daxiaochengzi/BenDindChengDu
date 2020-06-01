using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.JsonEntity;

namespace BenDing.Domain.Models.Params.YinHai.OutpatientDepartment
{
    public class OutpatientDepartmentDataXmlParam
    {
        /// <summary>
        /// 费用明细
        /// </summary>
        public List<OutpatientDetailJsonDto> CostDetail { get; set; }

        /// <summary>
        /// 病人疾病信息
        /// </summary>
        public OutpatientPersonBaseJsonDto OutpatientBase { get; set; }

        /// <summary>
        /// 组织机构
        /// </summary>
        public string OrganizationCode { get; set; }

        /// <summary>
        ///是否职工
        /// </summary>
        public bool IsWorkers { get; set; }

        /// <summary>
        /// 科室医保编码
        /// </summary>
        public string DepartmentMedicalInsuranceCode { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        public string DepartmentName { get; set; }
    }
}
