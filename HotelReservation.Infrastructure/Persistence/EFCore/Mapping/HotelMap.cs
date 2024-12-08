
using Microsoft.Data.SqlClient;

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
