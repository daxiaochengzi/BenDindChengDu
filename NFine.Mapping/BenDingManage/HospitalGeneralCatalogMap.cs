using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFine.Domain._03_Entity.BenDingManage;

namespace NFine.Mapping.BenDingManage
{
   public class HospitalGeneralCatalogMap : EntityTypeConfiguration<HospitalGeneralCatalogEntity>
    {
        public HospitalGeneralCatalogMap()
        {
            this.ToTable("HospitalGeneralCatalog");
            this.HasKey(t => t.Id);
        }
    }
}
