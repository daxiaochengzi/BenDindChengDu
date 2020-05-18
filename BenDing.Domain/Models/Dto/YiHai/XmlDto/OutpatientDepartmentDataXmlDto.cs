using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto
{
    [XmlRoot("data", IsNullable = false)]
    public class OutpatientDepartmentDataXmlDto
    {   /// <summary>
       /// 费用明细
       /// </summary>
        [XmlElementAttribute("datasetfymx")]
        [XmlArrayItem("row")]
        public List<OutpatientDepartmentDataXmlRowDto> CostDetail { get; set; }
        /// <summary>
        /// 医嘱明细
        /// </summary>
        [XmlElementAttribute("datasetyz")]
        [XmlArrayItem("row")]
        public List<OutpatientDepartmentDataXmlDetailDto> OrdersDetail { get; set; }

        /// <summary>
        /// 离休门诊结算诊断明细(最多24条)
        /// </summary>
        [XmlElementAttribute("datasetyz")]
        [XmlArrayItem("row")]
        public List<OutpatientDepartmentDataXmlDetailQuitDto> QuitDetail { get; set; }
    }
    /// <summary>
    /// 费用明细
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class OutpatientDepartmentDataXmlRowDto
    {
        /// <summary>
        /// 费用明细ID len(20)
        /// </summary>
        [XmlElementAttribute("yka105", IsNullable = false)]
        public string DetailId { get; set; }
        /// <summary>
        /// 医保项目编码
        /// </summary>
        [XmlElementAttribute("yka094", IsNullable = false)]
        public string ProjectCode { get; set; }
        /// <summary>
        /// 基层项目名称
        /// </summary>
        [XmlElementAttribute("yka095", IsNullable = false)]
        public  string DirectoryName { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [XmlElementAttribute("akc226", IsNullable = false)]
        public decimal Quantity { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        [XmlElementAttribute("akc225", IsNullable = false)]
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        [XmlElementAttribute("yka055", IsNullable = false)]
        public decimal Amount { get; set; }

        /// <summary>
        /// 审核标志
        /// </summary>
        [XmlElementAttribute("yke186", IsNullable = false)]
        public string ApprovalMark { get; set; }
        /// <summary>
        /// 开单科室编码
        /// </summary>
        [XmlElementAttribute("yka097", IsNullable = false)]
        public string BillDepartmentId { get; set; }
        /// <summary>
        /// 开单科室名称
        /// </summary>
        [XmlElementAttribute("yka098", IsNullable = false)]
        public string BillDepartment { get; set; }
        /// <summary>
        /// 开单医生姓名
        /// </summary>
        [XmlElementAttribute("yka099", IsNullable = false)]
        public string BillDoctorName { get; set; }
        /// <summary>
        /// 执行科室编码
        /// </summary>
        [XmlElementAttribute("yka100", IsNullable = false)]
        public string OperateDepartmentId { get; set; }
        /// <summary>
        /// 执行科室名称
        /// </summary>
        [XmlElementAttribute("yka101", IsNullable = false)]
        public string OperateDepartmentName { get; set; }
        /// <summary>
        /// 执行医生姓名
        /// </summary>
        [XmlElementAttribute("yka102", IsNullable = false)]
        public string OperateDoctorName { get; set; }

        /// <summary>
        /// 经办人
        /// </summary>
        [XmlElementAttribute("aae011", IsNullable = false)]
        public string Operators { get; set; }


        /// <summary>
        /// 明细录入时间 (yyyy-mm-dd hh:mm:ss)
        /// </summary>
        [XmlElementAttribute("yke123", IsNullable = false)]
        public string DetailInputTime { get; set; }
        /// <summary>
        /// 明细发生时间 (yyyy-mm-dd hh:mm:ss)
        /// </summary>
        [XmlElementAttribute("yke123", IsNullable = false)]
        public string DetailTime { get; set; }
        /// <summary>
        /// 手术编号
        /// </summary>
        [XmlElementAttribute("ykd040", IsNullable = false)]
        public string OperationNo { get; set; }
        /// <summary>
        /// 医嘱序号
        /// </summary>
        [XmlElementAttribute("yke112", IsNullable = false)]
        public string OrdersSortNo { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [XmlElementAttribute("aae013", IsNullable = false)]
        public string Remark { get; set; }

        /// <summary>
        ///使用方式 （固定值 01）
        /// </summary>
        [XmlElementAttribute("yke201", IsNullable = false)]
        public string UserMethod { get; set; } = "01";
        /// <summary>
        /// 处方号 len(15)
        /// </summary>
        [XmlElementAttribute("yke134", IsNullable = false)]
        public string PrescriptionNo { get; set; }
        /// <summary>
        /// 药品进价
        /// </summary>
        [XmlElementAttribute("yke553", IsNullable = false)]
        public decimal InputPrice { get; set; }
        /// <summary>
        /// 外检标志
        /// </summary>
        [XmlElementAttribute("yke676", IsNullable = false)]
        public string ExternalInspectSign { get; set; }
        /// <summary>
        /// 外检医院编码
        /// </summary>
        [XmlElementAttribute("yke677", IsNullable = false)]
        public string ExternalInspectHospitalNo { get; set; }

        /// <summary>
        /// 外检医院编码
        /// </summary>
        [XmlElementAttribute("ykf008", IsNullable = false)]
        public string DoctorCode { get; set; }
        /// <summary>
        /// 设备编号
        /// </summary>
        [XmlElementAttribute("ykf013", IsNullable = false)]
        public string EquipmentCode { get; set; }
        /// <summary>
        /// 医院对码流水号
        /// </summary>
        [XmlElementAttribute("ake005", IsNullable = false)]
        public string HospitalPairingCode { get; set; }
        /// <summary>
        /// 药品编码/诊疗项目编码
        /// </summary>
        [XmlElementAttribute("yka059", IsNullable = false)]
        public string DirectoryCode { get; set; }
        
        //yke112
    }
    /// <summary>
    /// 医嘱明细
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class OutpatientDepartmentDataXmlDetailDto
    {
        /// <summary>
        /// 医嘱序号
        /// </summary>
        [XmlElementAttribute("yke112", IsNullable = false)]
        public string OrdersSortNo { get; set; }
        /// <summary>
        /// 医嘱内容
        /// </summary>
        [XmlElementAttribute("yke113", IsNullable = false)]
        public string OrdersContent { get; set; }
        /// <summary>
        /// 医生姓名
        /// </summary>
        [XmlElementAttribute("yka287", IsNullable = false)]
        public string DoctorName { get; set; }
        /// <summary>
        /// 医生编码
        /// </summary>
        [XmlElementAttribute("ykf008", IsNullable = false)]
        public string DoctorCode { get; set; }
        /// <summary>
        /// 医嘱科室编码
        /// </summary>
        [XmlElementAttribute("aaz307", IsNullable = false)]
        public string OrdersDepartmentCode { get; set; }

        /// <summary>
        /// 医嘱科室名称
        /// </summary>
        [XmlElementAttribute("akf002", IsNullable = false)]
        public string OrdersDepartmentName { get; set; }
        /// <summary>
        /// 医院对码编号
        /// </summary>
        [XmlElementAttribute("ake005", IsNullable = false)]
        public string HospitalCodeNo { get; set; }
        /// <summary>
        /// 医嘱类别
        /// </summary>
        [XmlElementAttribute("yke365", IsNullable = false)]
        public string OrdersType { get; set; }
        /// <summary>
        /// 医嘱分类
        /// </summary>
        [XmlElementAttribute("yke658", IsNullable = false)]
        public string OrdersClassify { get; set; }
        /// <summary>
        /// 剂量单位
        /// </summary>
        [XmlElementAttribute("yke351", IsNullable = false)]
        public string DoseUnit { get; set; }
        /// <summary>
        /// 剂量
        /// </summary>
        [XmlElementAttribute("yke351", IsNullable = false)]
        public int Dose { get; set; } = 1;

        /// <summary>
        /// 用药途径
        /// </summary>
        [XmlElementAttribute("yke351", IsNullable = false)]
        public string UserRoad { get; set; }
        /// <summary>
        /// 每次用量
        /// </summary>
        [XmlElementAttribute("yke654", IsNullable = false)]
        public int EveryTimeDosage { get; set; } = 1;
        /// <summary>
        /// 每次用量单位
        /// </summary>
        [XmlElementAttribute("yke655", IsNullable = false)]
        public string EveryTimeDosageUnit { get; set; }
        /// <summary>
        /// 发药量
        /// </summary>
        [XmlElementAttribute("yke656", IsNullable = false)]
        public string Dosage { get; set; }
        /// <summary>
        /// 发药量单位
        /// </summary>
        [XmlElementAttribute("yke657", IsNullable = false)]
        public string DosageUnit { get; set; }
        /// <summary>
        /// 频次
        /// </summary>
        [XmlElementAttribute("yke350", IsNullable = false)]
        public int Frequency { get; set; }=1;
        /// <summary>
        /// 使用天数
        /// </summary>
        [XmlElementAttribute("yke446", IsNullable = false)]
        public  int  UseDays { get; set; } = 1;

    }
    /// <summary>
    /// 离职人员诊断
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class OutpatientDepartmentDataXmlDetailQuitDto
    {  /// <summary>
      /// 诊断编码
      /// </summary>
        [XmlElementAttribute("ykd018", IsNullable = false)]
        public   string  DiagnosticCode { get; set; }
        /// <summary>
        /// 诊断内容
        /// </summary>
        [XmlElementAttribute("yke122", IsNullable = false)]
        public string DiagnosticContent { get; set; }
    }


}
