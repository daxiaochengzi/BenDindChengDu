using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.Web;
using BenDing.Domain.Models.Dto.YiHai.Web;
using BenDing.Domain.Models.Params.YinHai.OutpatientDepartment;
using BenDing.Domain.Models.Params.YinHai.Web;
using BenDing.Domain.Xml;
using BenDing.Repository.Interfaces.YiHaiWeb;
using Dapper;
using NFine.Code;
using NFine.Domain._03_Entity.BenDingManage;


namespace BenDing.Repository.Providers.YiHaiWeb
{
   public class YiHaiSqlRepository: IYiHaiSqlRepository
    {
        private readonly string _connectionString;
        private readonly Log _log;
        public YiHaiSqlRepository()
        {
            _log = LogFactory.GetLogger("ini".GetType().ToString());
            string conStr = ConfigurationManager.ConnectionStrings["NFineDbContext"].ToString();
            _connectionString = !string.IsNullOrWhiteSpace(conStr) ? conStr : throw new ArgumentNullException(nameof(conStr));

        }
        /// <summary>
        /// 签到查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<MedicalInsuranceSignInEntity>  QueryMedicalInsuranceSignIn(QueryMedicalInsuranceSignInParam param)
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
        /// 码表查询
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


    }

}
