using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManagement.Core.Domain._FundCode;
using System.Data.Entity.ModelConfiguration;


namespace DataManagement.Persistence.EntityConfigurations._FundCode
{
    internal class InputFileStatusConfiguration
        : EntityTypeConfiguration<InputFileStatus>
    {
        public InputFileStatusConfiguration()
        {
            Property(c => c.Id)
            .IsRequired();

            Property(c => c.FileName)
             .IsOptional()
             .HasMaxLength(200);

            Property(c => c.EmailCommentPickup)
            .IsOptional()
            .HasMaxLength(200);

        }
    }
}

