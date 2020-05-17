namespace BenDing.Domain.Models.Dto.YiHai.Base
{/// <summary>
/// 银海医保接口返回值
/// </summary>
  public  class DealModelDto
    {
        /// <summary>
        /// 交易编号
        /// </summary>
        public string TransactionNumber { get; set; }
        /// <summary>
        /// 交易控制
        /// </summary>
        public string TransactionControlXml { get; set; }
        /// <summary>
        /// 交易输入
        /// </summary>
        public string TransactionInputXml { get; set; }
        /// <summary>
        /// 批次编号
        /// </summary>
        public string BatchNo { get; set; }
        /// <summary>
        /// 交易流水号
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// 交易验证码
        /// </summary>
        public string VerificationCode { get; set; }

        /// <summary>
        ///交易输出
        /// </summary>
        public string TransactionOutputXml { get; set; }


        /// <summary>
        /// 返回代码，小于0时，返回错误
        /// </summary>
        public int along_appcode = -1;

    


        ///// <summary>
        ///// 当前调用名称
        ///// </summary>
        //public string DealName = string.Empty;

        /// <summary>
        /// 返回XML时，解析的Xpath 
        /// </summary>
        public string ResultXmlXpath { get; set; }


        /// <summary>
        /// 输出文件路径
        /// </summary>
        public string OutputFilePath { get; set; }



        /// <summary>
        /// 判断银海接口是否返回成功
        /// </summary>
        /// <returns></returns>
        public bool IsYanHaiSuccess
        {
            get { return along_appcode >= 0; }
        }
        /// <summary>
        /// 错误等信息
        /// </summary>
        public string Msg { get; set; }
    }
}
