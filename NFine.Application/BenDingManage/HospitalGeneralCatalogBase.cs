using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.Web;
using NFine.Code;
using NFine.Domain._03_Entity.BenDingManage;
using NFine.Domain._04_IRepository.BenDingManage;
using NFine.Repository.BenDingManage;

namespace NFine.Application.BenDingManage
{
   public class HospitalGeneralCatalogBase
    {
        private IHospitalGeneralCatalogRepository service = new HospitalGeneralCatalogRepository();

        public List<HospitalGeneralCatalogEntity> GetList()
        {
            return service.IQueryable().ToList();
        }
        public HospitalGeneralCatalogEntity GetForm(string keyValue)
        {
            return service.FindEntity(Guid.Parse(keyValue));
        }
        public List<HospitalGeneralCatalogEntity> GetList(Pagination pagination, string keyword,string directoryType,string organizationCode)
        {
            var expression = ExtLinq.True<HospitalGeneralCatalogEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.DirectoryName.Contains(keyword));
            }
            if (!string.IsNullOrEmpty(directoryType))
            {
                expression = expression.And(t => t.DirectoryType== directoryType);
            }
            expression = expression.And(t => t.OrganizationCode == organizationCode);
            expression = expression.And(t => t.IsDelete ==false );
            return service.FindList(expression, pagination);
        }
        public void DeleteForm(string keyValue)
        {
            service.Delete(t => t.Id == Guid.Parse(keyValue));
        }
        public void SubmitForm(HospitalGeneralCatalogEntity areaEntity, string keyValue, UserInfoDto user)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                areaEntity.Modify(Guid.Parse(keyValue), user.UserId);
                service.Update(areaEntity);
            }
            else
            {
                areaEntity.Create(user);
                service.Insert(areaEntity);
            }
        }

        public void Insert(HospitalGeneralCatalogEntity inpatientEntity, UserInfoDto user)
        {
            inpatientEntity.Create(user);
            service.Insert(inpatientEntity);
        }

        public void Modify(HospitalGeneralCatalogEntity inpatientEntity, UserInfoDto user, Guid id)
        {
            inpatientEntity.Modify(id, user.UserId);
            service.Update(inpatientEntity);
        }

        public int ExecuteSqlCommand(string strSql)
        {
            return service.ExecuteSqlCommand(strSql);
        }
    }
}
