﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiSchool.DataAccess.Models;

namespace WebApiSchool.DataAccess.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasOne(u => u.PermissionGroup)
                   .WithMany(pg => pg.Users)
                   .HasForeignKey(u => u.PermissionGroupId);

        //    builder.HasData(new List<User>
        //{
        //    new User
        //    {
        //        Id = 1,
        //        Username = "11",
        //        PasswordHash = "11",
        //        PermissionGroupId = 1
        //    },
        //    new User
        //    {
        //        Id = 2,
        //        Username = "22",
        //        PasswordHash = "22", 
        //        PermissionGroupId = 2
        //    },
        //});
        }
    }
}