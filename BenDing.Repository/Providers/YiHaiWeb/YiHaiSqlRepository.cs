using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.Web;
using BenDing.Domain.Models.Dto.YiHai.Web;
using BenDing.Domain.Models.Params.YinHai.Web;
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
    }

}
