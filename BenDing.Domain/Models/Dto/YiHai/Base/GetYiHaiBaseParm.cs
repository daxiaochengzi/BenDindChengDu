using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Dto.YiHai.Base
{
    /// <summary>
    /// 获取银海接口参数
    /// </summary>
   public class GetYiHaiBaseParm
    {
        

        /// <summary>
        /// 交易控制
        /// </summary>
        public string TransactionControlXml { get; set; }
        /// <summary>
        /// 交易输入
        /// </summary>
        public string TransactionInputXml { get; set; }
    }
}
