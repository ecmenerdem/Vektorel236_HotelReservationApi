using HotelReservation.Domain.Entity;
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
    public class HotelMap : BaseMap<Hotel>
    {
        public override void Configure(EntityTypeBuilder<Hotel> builder)
        {
            base.Configure(builder);

            builder.ToTable("Hotel");

            builder.HasMany(q=>q.Rooms).WithOne(q=>q.Hotel)
                .HasForeignKey(q=>q.HotelID)
                .OnDelete(DeleteBehavior.Cascade);
           
        }
    }
}
