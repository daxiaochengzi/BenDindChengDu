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
   public class MedicalInsuranceSignInBase
    {
        private IMedicalInsuranceSignInRepository service = new MedicalInsuranceSignRepository();

        public List<MedicalInsuranceSignInEntity> GetList()
        {
            return service.IQueryable().ToList();
        }
        public MedicalInsuranceSignInEntity GetForm(Guid keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public List<MedicalInsuranceSignInEntity> GetList(Pagination pagination, string keyword, string organizationCode)
        {
            var expression = ExtLinq.True<MedicalInsuranceSignInEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.CreateUserName.Contains(keyword));
            }
            expression = expression.And(t => t.OrganizationCode == organizationCode);
            expression = expression.And(t => t.IsDelete == false);
            return service.FindList(expression, pagination);
        }
        public void DeleteForm(Guid keyValue)
        {
            service.Delete(t => t.Id == keyValue);
        }

        public void Insert(MedicalInsuranceSignInEntity inpatientEntity, UserInfoDto user)
        {
            inpatientEntity.Create(user);
            service.Insert(inpatientEntity);
        }

        public void Modify(MedicalInsuranceSignInEntity inpatientEntity, UserInfoDto user, Guid id)
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
