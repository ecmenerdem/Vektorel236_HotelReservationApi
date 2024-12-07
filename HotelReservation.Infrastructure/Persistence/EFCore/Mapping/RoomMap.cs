namespace HotelReservation.Infrastructure.Persistence.EFCore.Mapping
{
    public class RoomMap : BaseMap<Room>

    {
        public override void Configure(EntityTypeBuilder<Room> builder)
        {
            base.Configure(builder);

            builder.ToTable("Room");


        }
    }
}
