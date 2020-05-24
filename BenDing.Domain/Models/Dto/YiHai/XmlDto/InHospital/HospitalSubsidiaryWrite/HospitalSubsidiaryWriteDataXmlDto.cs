using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.YiHai.XmlDto.InHospital.HospitalSubsidiaryWrite
{
    /// <summary>
    /// 	住院费用明细写入-交易输入
    /// </summary>
    [XmlRoot("data")]
    public class HospitalSubsidiaryWriteDataXmlDto
    {
        [XmlArrayItem("row")]
        public List<HospitalSubsidiaryWriteDataRow> Rows { get; set; }
    }
    /// <summary>
    ///详细信息
    /// </summary>
    [XmlTypeAttribute(AnonymousType = true)]
    public class HospitalSubsidiaryWriteDataRow
    {
        /// <summary>
        /// 记账流水号-唯一标识一条明细
        /// </summary>
        [XmlElement("yka105")]
        public string DocumentNo { get; set; }

        /// <summary>
        /// 医保项目编码-见医保目录信息
        /// </summary>
        [XmlElement("yka094")]
        public string MedicalInsuranceProjectCode { get; set; }

        /// <summary>
        /// 医院项目名称(诊疗项目)
        /// </summary>
        [XmlElement("yka095")]
        public string DirectoryName { get; set; }

        /// <summary>
        ///  数量 (可以为0)-本条明细数量
        /// </summary>

        [XmlElement("akc226")]
        public int Num { get; set; }
        /// <summary>
        ///  单价-单价保留四位小数
        /// </summary>
        [XmlElement("akc225")]
        public decimal Price { get; set; }

        /// <summary>
        ///  费用总额-单条明细费用总额保留4位小数，结算时汇总费用总额保留2位小数
        /// </summary>
        [XmlElement("yka055")]
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// 审核标志-需要医院审核后才能报销的项目，审核标志由医院控制
        /// </summary>
        [XmlElement("yke186")]
        public string ApprovalMark { get; set; }

        /// <summary>
        /// 开单科室编码1
        /// </summary>
        [XmlElement("yka097")]
        public string BillDepartmentId { get; set; }

        /// <summary>
        /// 开单科室名称1
        /// </summary>
        [XmlElement("yka098")]
        public string BillDepartment { get; set; }

        /// <summary>
        /// 开单医生1
        /// </summary>
        [XmlElement("yka099")]
        public string BillDoctorName { get; set; }


        /// <summary>
        /// 受单科室编码1
        /// </summary>
        [XmlElement("yka100")]
        public string OperateDepartmentId { get; set; }
        /// <summary>
        /// 受单科室名称1
        /// </summary>
        [XmlElement("yka101")]
        public string OperateDepartmentName { get; set; }
        /// <summary>
        /// 受单医生1
        /// </summary>
        [XmlElement("yka102")]
        public string OperateDoctorName { get; set; }



        /// <summary>
        /// 经办人姓名1
        /// </summary>
        [XmlElement("aae011")]
        public string Operators { get; set; }


        /// <summary>
        /// 明细录入时间 (yyyy-mm-dd hh:mm:ss)--医院收费员录入明细时间
        /// </summary>
        [XmlElement("aae036")]
        public string DetailInputTime { get; set; }
        /// <summary>
        /// 明细发生时间 (yyyy-mm-dd hh:mm:ss)--明细实际发生时间
        /// </summary>
        [XmlElement("yke123")]
        public string DetailTime { get; set; }
        /// <summary>
        /// 手术编号-用于唯一标识住院期间一次手术中使用的所有项目
        /// </summary>
        [XmlElement("ykd040")]
        public string OperationNo { get; set; }


        /// <summary>
        /// 医嘱记录序号1-明细隶属住院医嘱
        /// </summary>
        [XmlElement("yke112")]
        public string OrdersSortNo { get; set; }
        /// <summary>
        /// 备注1
        /// </summary>
        [XmlElement("aae013")]
        public string Remark { get; set; }

        /// <summary>
        ///中药使用方式-单方、复方参看代码表
        /// </summary>
        [XmlElement("yke201")]
        public string UserMethod { get; set; } = "01";


        /// <summary>
        /// 处方号 len(15)-单方、复方参看代码表
        /// </summary>
        [XmlElement("yke134")]
        public string PrescriptionNo { get; set; }
        /// <summary>
        /// 药品进价--药品进货价格
        /// </summary>
        [XmlElement("yke553")]
        public decimal InputPrice { get; set; }

        /// <summary>
        /// 病种编码 (注释：新门特新增，新门特必传)201308
        /// </summary>
        [XmlElement("yka026")]
        public string DiseasesCode { get; set; }

          /// <summary>
        /// 外检标志
        /// </summary>
        [XmlElement("yke676")]
        public string ExternalInspectSign { get; set; }
        /// <summary>
        /// 外检医院编码-对应外检项目所在医院的医院编码akb020字段
        /// </summary>
        [XmlElement("yke677")]
        public string ExternalInspectHospitalNo { get; set; }

        /// <summary>
        /// 医职人员编码-医院自编码，对应医职人员信息上传字段
        /// </summary>
        [XmlElement("ykf008")]
        public string DoctorCode { get; set; }

        /// <summary>
        /// 出院带药标志
        /// </summary>
        [XmlElement("yke680")]
        public string DischargeLabel { get; set; }
        /// <summary>
        /// 设备编号-医院自编码，对应设备信息中字段
        /// </summary>
        [XmlElement("ykf013")]
        public string EquipmentCode { get; set; }
        /// <summary>
        /// 医院对码流水号
        /// </summary>
        [XmlElement("ake005")]
        public string HospitalPairingCode { get; set; }
        /// <summary>
        /// 药品编码/诊疗项目编码
        /// </summary>
        [XmlElement("yka059")]
        public string DirectoryCode { get; set; }

        /// <summary>
        /// 医嘱执行流水号----与yke112医嘱记录序号属于一对多的关系，即一条医嘱记录序号对应多条医嘱执行流水号
        /// </summary>
        [XmlElement("yke683")]
        public string OrdersSerialNum { get; set; }

    }
}