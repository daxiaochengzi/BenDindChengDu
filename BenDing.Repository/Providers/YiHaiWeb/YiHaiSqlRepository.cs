using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.Web;
using BenDing.Domain.Models.Dto.YiHai.OutpatientDepartment;
using BenDing.Domain.Models.Dto.YiHai.Web;
using BenDing.Domain.Models.Enums;
using BenDing.Domain.Models.Params.YinHai.OutpatientDepartment;
using BenDing.Domain.Models.Params.YinHai.Web;
using BenDing.Domain.Xml;
using BenDing.Repository.Interfaces.Web;
using BenDing.Repository.Interfaces.YiHaiWeb;
using Dapper;
using NFine.Code;
using NFine.Domain._03_Entity.BenDingManage;


namespace BenDing.Repository.Providers.YiHaiWeb
{
    public class YiHaiSqlRepository : IYiHaiSqlRepository
    {
        private readonly string _connectionString;
        private readonly ISystemManageRepository _iSystemManageRepository;
        private readonly Log _log;
        public YiHaiSqlRepository(
            ISystemManageRepository iSystemManageRepository
            )
        {
               _iSystemManageRepository = iSystemManageRepository;
               _log = LogFactory.GetLogger("ini".GetType().ToString());
            string conStr = ConfigurationManager.ConnectionStrings["NFineDbContext"].ToString();
            _connectionString = !string.IsNullOrWhiteSpace(conStr) ? conStr : throw new ArgumentNullException(nameof(conStr));

        }
        /// <summary>
        /// 签到查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<MedicalInsuranceSignInEntity> QueryMedicalInsuranceSignIn(QueryMedicalInsuranceSignInParam param)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                string strSql = null;
                try
                {
                    strSql = $@"
                                   SELECT [Id]
                                  ,[MedicalInsuranceOrganization]
                                  ,[SignInState]
                                  ,[BatchNo]
                                  ,[SignInTime]
                                  ,[OrganizationCode]
                                  ,[OrganizationName]
                                  ,[CreateTime]
                                  ,[Version]
                                  ,[IsDelete]
                                  ,[UpdateTime]
                                  ,[DeleteTime]
                                  ,[CreateUserId]
                                  ,[DeleteUserId]
                                  ,[UpdateUserId]
                              FROM [dbo].[MedicalInsuranceSignIn] 
                             where CreateUserId='{param.User.UserId}' and OrganizationCode='{param.User.OrganizationCode}' 
                            and IsDelete=0 ";
                    if (param.SignInState != null)
                    {
                        strSql += $" and SignInState={param.SignInState}";
                    }

                    var data = sqlConnection.Query<MedicalInsuranceSignInEntity>(strSql);
                    sqlConnection.Close();
                    return data.ToList();

                }
                catch (Exception e)
                {
                    _log.Debug(strSql);
                    throw new Exception(e.Message);
                }

            }
        }
        /// <summary>
        /// 码表查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<CodeTableDto> CodeTableQuery(string param)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                string strSql = null;
                try
                {
                    strSql = $@"select  replace(aaa100,' ','') as CodeData ,replace(aaa103,' ','') as  CodeDescribe,replace(aaa102,' ','') as CodeValue from [dbo].[CodeTable]  where aaa100='{param}'";
                    var data = sqlConnection.Query<CodeTableDto>(strSql);
                    sqlConnection.Close();
                    return data.ToList();
                }
                catch (Exception e)
                {
                    _log.Debug(strSql);
                    throw new Exception(e.Message);
                }

            }
        }
        /// <summary>
        /// 医院信息查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<HospitalGeneralCatalogEntity> HospitalGeneralCatalog(HospitalGeneralCatalogYiHaiParam param)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                string strSql = null;
                try
                {
                    strSql = $@"SELECT [Id]
                          ,[OrganizationCode]
                          ,[OrganizationName]
                          ,[DirectoryType]
                          ,[DirectoryCode]
                          ,[FixedEncoding]
                          ,[MedicalInsuranceCode]
                          ,[MedicalInsuranceName]
                          ,[InpatientAreaCode]
                          ,[MnemonicCode]
                          ,[DirectoryName]
                          ,[DirectoryCategoryName]
                          ,[Remark]
                          ,[UploadMark]
                          ,[UploadTime]
                          ,[UploadUserId]
                          ,[UploadName]
                          ,[PairCodeUserId]
                          ,[PairCodeUserName]
                          ,[PairCodeTime]
                          ,[CreateTime]
                          ,[Version]
                          ,[UpdateTime]
                          ,[IsDelete]
                          ,[DeleteTime]
                          ,[CreateUserId]
                          ,[DeleteUserId]   
                          ,[UpdateUserId]
                      FROM [dbo].[HospitalGeneralCatalog] 
                      where IsDelete=0  and OrganizationCode='{param.User.OrganizationCode}' ";
                    if (!string.IsNullOrWhiteSpace(param.DirectoryType))
                    {
                        strSql += $" and DirectoryType = '{param.DirectoryType}'";
                    }
                    if (!string.IsNullOrWhiteSpace(param.DirectoryCode))
                    {
                        strSql += $" and DirectoryCode = '{param.DirectoryCode}'";
                    }


                    var data = sqlConnection.Query<HospitalGeneralCatalogEntity>(strSql);
                    sqlConnection.Close();
                    return data.ToList();
                }
                catch (Exception e)
                {
                    _log.Debug(strSql);
                    throw new Exception(e.Message);
                }

            }
        }
        /// <summary>
        /// 更新
        /// </summary>
        public void HospitalInfoUploadUpdate(HospitalInfoUploadUpdateParam param)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                string strSql = null;
                try
                {
                    if (param.FixedEncodingList.Any())
                    {
                        var str = CommonHelp.ListToStr(param.FixedEncodingList);
                        strSql = $@"update [dbo].[HospitalGeneralCatalog] set UpdateTime=GETDATE(),
                          UploadMark=1,UploadName='{param.User.UserName}',UploadUserId='{param.User.UserId}' 
                     where FixedEncoding in({str})";
                        var data = sqlConnection.Execute(strSql);
                        sqlConnection.Close();

                    }
                }
                catch (Exception e)
                {
                    _log.Debug(strSql);
                    throw new Exception(e.Message);
                }

            }
        }
        /// <summary>
        /// 结算流程新增
        /// </summary>
        /// <param name="param"></param>

        public void InsertSettlementProcess(SettlementProcessDto param)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                string strSql = null;
                try
                {
                    strSql = $@"update [dbo].[SettlementProcess] set [IsDelete]=1 ,[DeleteUserId]='{param.CreateUserId}',[DeleteTime]=getDate()
                              where [IsDelete]=0  and [BusinessId]='{param.BusinessId}' and ProcessStep='{param.ProcessStep}';
                              INSERT INTO [dbo].[SettlementProcess]
                               ([Id]
                               ,[BusinessId]
                               ,[ProcessStep]
                               ,[JsonContent]
                               ,[BatchNo]
                               ,[SerialNumber]
                               ,[VerificationCode]
                               ,[IsDelete]
                               ,[CreateUserId]
                               ,[CreateTime]
                              )
                             VALUES
                               ('{param.Id}'
                               ,'{param.BusinessId}'
                               , {param.ProcessStep}
                               ,'{param.JsonContent}'
                               ,'{param.BatchNo}'
                               ,'{param.SerialNumber}'
                               ,'{param.VerificationCode}'
                               ,0
                               ,'{param.CreateUserId}'
                               ,getDate()
                               )";

                    var data = sqlConnection.Execute(strSql);
                    sqlConnection.Close();


                }
                catch (Exception e)
                {
                    _log.Debug(strSql);
                    throw new Exception(e.Message);
                }
            }
        }
        /// <summary>
        /// 结算流程查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<SettlementProcessDto> QuerySettlementProcess(QuerySettlementProcessParam param)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                string strSql = null;
                try
                {
                    strSql = $@"
                      SELECT [Id]
                      ,[BusinessId]
                      ,[ProcessStep]
                      ,[JsonContent]
                      ,[BatchNo]
                      ,[SerialNumber]
                      ,[VerificationCode]
                      ,[IsDelete]
                      ,[Version]
                      ,[CreateTime]
                      ,[CreateUserId]
                  FROM [dbo].[SettlementProcess] where BusinessId='{param.BusinessId}'  and IsDelete=0                           ";
                    if (param.ProcessStep != null)
                    {
                        strSql += $" and ProcessStep={param.ProcessStep}";
                    }

                    var data = sqlConnection.Query<SettlementProcessDto>(strSql);
                    sqlConnection.Close();
                    return data.ToList();

                }
                catch (Exception e)
                {
                    _log.Debug(strSql);
                    throw new Exception(e.Message);
                }

            }
        }
        //更新门诊病人结算状态
        public void UpdateOutpatientSettlement(UpdateOutpatientSettlementParam param)
        {

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                string strSql = null;
                try
                {
                    string strSet = null;
                    if (!string.IsNullOrWhiteSpace(param.VisitNo)) strSet += $" [VisitNo]='{param.VisitNo}',";
                    if (!string.IsNullOrWhiteSpace(param.PersonalCode)) strSet += $" [PersonalCode]='{param.PersonalCode}',";
                    if (!string.IsNullOrWhiteSpace(param.PayType)) strSet += $" [PayType]='{param.PayType}',";
                    if (param.ProcessStep != null) strSet += $" [ProcessStep]={param.ProcessStep},";

                    if (!string.IsNullOrWhiteSpace(strSet))
                    {
                        strSql = $@"update [dbo].[Outpatient] set {strSet.Substring(0, strSet.Length - 1)}
                                ,UpdateTime=getDate(),UpdateUserId='{param.UserId}'
                                 where BusinessId='{param.BusinessId}' and IsDelete=0";
                        sqlConnection.Execute(strSql);
                    }
                    sqlConnection.Close();
                }
                catch (Exception e)
                {
                    _log.Debug(strSql);
                    throw new Exception(e.Message);
                }

            }
        }
        /// <summary>
        /// 查询基层取消结算
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public Dictionary<int, List<BaseRefundDto>> QueryBaseRefund(BaseRefundUiParam param)
        {
            List<BaseRefundDto> dataList;
            var resultData = new Dictionary<int, List<BaseRefundDto>>();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                string querySql = null;
                try
                {
                    sqlConnection.Open();
                    querySql = $@"
                            select [Id],[OutpatientNumber] as OutpatientNo,[PatientName],[IdCardNo],[BusinessId],
                            [VisitNo],[ProcessStep],[UpdateUserId] as OperationName,[UpdateTime] as OperationTime 
                            from [dbo].[Outpatient] where IsDelete=0 and PayType is not null and OrganizationCode='{param.OrganizationCode}'";
                    string countSql = $@"select count(*) from [dbo].[Outpatient] where IsDelete=0  and PayType is not null and OrganizationCode='{param.OrganizationCode}'";
                    string whereSql = "";
                    if (!string.IsNullOrWhiteSpace(param.StartTime))
                    {
                        whereSql += $" and UpdateTime >'{param.StartTime}'";
                    }
                    if (!string.IsNullOrWhiteSpace(param.EndTime))
                    {
                        whereSql += $" and UpdateTime <'{param.EndTime}'";
                    }

                    if (param.Limit != 0 && param.Page > 0)
                    {
                        var skipCount = param.Limit * (param.Page - 1);
                        querySql += whereSql + " order by CreateTime desc OFFSET " + skipCount + " ROWS FETCH NEXT " + param.Limit + " ROWS ONLY;";
                    }
                    string executeSql = countSql + whereSql + ";" + querySql;

                    var result = sqlConnection.QueryMultiple(executeSql);

                    int totalPageCount = result.Read<int>().FirstOrDefault();
                    //所有操作人员
                    var allOperator =  _iSystemManageRepository.QueryHospitalOperatorAllInfo(param.OrganizationCode);
                    dataList = (from t in result.Read<BaseRefundDto>()
                        select new BaseRefundDto
                        {
                            Id = t.Id,
                            InpatientNo = t.InpatientNo,
                            OutpatientNo = t.OutpatientNo,
                            PatientName = t.PatientName,
                            VisitNo = t.VisitNo,
                            IdCardNo = t.IdCardNo,
                            OperationName = allOperator != null
                                ? allOperator.Where(c => c.F_HisUserId == t.OperationName).Select(d => d.F_RealName)
                                    .FirstOrDefault()
                                : t.OperationName,
                            ProcessStep =
                                CommonHelp.ConvertEnumToString<OutpatientSettlementStep>(Convert.ToInt32(t.ProcessStep)),
                            OperationTime = t.OperationTime,
                            BusinessId = t.BusinessId
                        }).ToList();

                          

                    resultData.Add(totalPageCount, dataList);
                    sqlConnection.Close();
                    return resultData;

                }
                catch (Exception e)
                {
                    _log.Debug(querySql);
                    throw new Exception(e.Message);
                }


            }



        }
    }

}
