using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dependencies;
using BenDing.Repository.Interfaces.Web;
using BenDing.Repository.Interfaces.YiHaiWeb;
using BenDing.Repository.Providers.Web;
using BenDing.Repository.Providers.YiHaiWeb;
using BenDing.Service.Interfaces;
using BenDing.Service.Interfaces.YiHaiWeb;
using BenDing.Service.Providers;
using BenDing.Service.Providers.YiHaiWeb;
using NFine.Domain._04_IRepository.BenDingManage;
using NFine.Repository.BenDingManage;
using NFine.Web.Model;
using StructureMap;
using Unity;

namespace NFine.Web
{/// <summary>
/// 
/// </summary>
    public class Bootstrapper
    {/// <summary>
    /// 
    /// </summary>
        public static void Initialise()
        {
            var container = BuildUnityContainer();
            // DependencyResolver.SetResolver(new UnityDependencyResolver(container));//MVC注入
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

        }/// <summary>
        /// 
        /// </summary>
        public class UnityIOC
        {
            /// <summary>
            /// IOC 容器
            /// </summary>
            public static IUnityContainer container = null;

            /// <summary>
            /// 获取 接口 的实例化对象
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <returns></returns>
            public static T Resolve<T>()
            {
                try
                {
                    if (container == null)
                    {
                        Initialise();
                    }
                }
                catch (System.Exception ex)
                {
                    throw new System.Exception("IOC实例化出错!" + ex.Message);
                }

                return container.Resolve<T>();
            }

            /// <summary>
            /// 初始化
            /// </summary>
            public static void Initialise()
            {
                ////创建容器
                //container = new UnityContainer();
                ////注册映射
                //container.RegisterType<IUserService, UserService>();
                container = BuildUnityContainer();
            }
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            #region Service
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IWebServiceBasicService, WebServiceBasicService>();
            container.RegisterType<IResidentMedicalInsuranceService, ResidentMedicalInsuranceService>();
            container.RegisterType<IOutpatientDepartmentService, OutpatientDepartmentService>();
            container.RegisterType<IWorkerMedicalInsuranceService, WorkerMedicalInsuranceService>();
            container.RegisterType<IOutpatientDepartmentNewService, OutpatientDepartmentNewService>();
            container.RegisterType<IResidentMedicalInsuranceNewService, ResidentMedicalInsuranceNewService>();
            container.RegisterType<IWorkerMedicalInsuranceNewService, WorkerMedicalInsuranceNewService>();
            container.RegisterType<IYiHaiOutpatientDepartmentService, YiHaiOutpatientDepartmentService>();
            
            #endregion
            #region Repository
            container.RegisterType<IResidentMedicalInsuranceRepository, ResidentMedicalInsuranceRepository>();
            container.RegisterType<IMedicalInsuranceSqlRepository, MedicalInsuranceSqlRepository>();
            container.RegisterType<IWebBasicRepository, WebBasicRepository>();
            container.RegisterType<IHisSqlRepository, HisSqlRepository>();
            container.RegisterType<ISystemManageRepository, SystemManageRepository>();
            container.RegisterType<IOutpatientDepartmentRepository, OutpatientDepartmentRepository>();
            container.RegisterType<IWorkerMedicalInsuranceRepository, WorkerMedicalInsuranceRepository>();
            container.RegisterType<IMedicalInsuranceSignInRepository, MedicalInsuranceSignRepository>();
            container.RegisterType<IYiHaiOutpatientDepartmentRepository, YiHaiOutpatientDepartmentRepository>();
            container.RegisterType<IYiHaiSqlRepository, YiHaiSqlRepository>();
            
            #endregion
            return container;
        }
        
    }

}