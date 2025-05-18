using Instagram.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Dal.EntityConfigurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Account");
        builder.HasKey(a => a.AccountId);
        builder.Property(a => a.Username)
            .IsRequired(true)
            .HasMaxLength(50);
        builder.HasIndex(a => a.Username)
            .IsUnique(true);
        builder.Property(a => a.Bio)
            .IsRequired(false)
            .HasMaxLength(200);
        builder.HasMany(a => a.Posts).
            WithOne(p => p.Account).
            HasForeignKey(a => a.AccountId);
        builder.HasMany(a => a.Comments).
              WithOne(p => p.Account).
            HasForeignKey(a => a.CommentId);


    }
}
