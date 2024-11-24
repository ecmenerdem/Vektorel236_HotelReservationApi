﻿using HotelReservation.Domain.Entity;
using HotelReservation.Infrastructure.Persistence.EFCore.Mapping.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Infrastructure.Persistence.EFCore.Mapping
{
    public class UserMap : BaseMap<User>

    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.ToTable("User");
            builder.Property(q => q.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(q => q.LastName).IsRequired().HasMaxLength(100);
            builder.Property(q => q.Username).IsRequired().HasMaxLength(100);
            builder.Property(q => q.Password).IsRequired().HasMaxLength(100);
            builder.Property(q => q.Email).IsRequired().HasMaxLength(100);
            builder.Property(q => q.PhoneNumber).IsRequired().HasMaxLength(20);

            //builder.HasMany(q => q.Reservations).WithOne(q => q.User);
           
        }
    }
}