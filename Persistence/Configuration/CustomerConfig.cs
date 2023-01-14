using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    internal class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.HasKey(p => p.Id);

            builder.Property(n=>n.Name).HasMaxLength(80).IsRequired();   
            builder.Property(n=>n.Tel).HasMaxLength(80).IsRequired();   
            builder.Property(n=>n.Email).HasMaxLength(80).IsRequired();   
            builder.Property(n=>n.CreatedBy).HasMaxLength(80);
            builder.Property(n => n.CreatedBy).IsRequired(false);
            builder.Property(n=>n.LastModifiedBy).IsRequired(false);  
            //builder.Property(n=>n.CreatedDate).IsRequired(false);  
            //builder.Property(n=>n.UpdatedDate).IsRequired(false);  
            
        }
    }
}
