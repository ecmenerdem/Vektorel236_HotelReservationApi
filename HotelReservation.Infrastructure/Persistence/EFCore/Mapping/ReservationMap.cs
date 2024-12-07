namespace HotelReservation.Infrastructure.Persistence.EFCore.Mapping
{
    public class ReservationMap : BaseMap<Reservation>

    {
        public override void Configure(EntityTypeBuilder<Reservation> builder)
        {
            base.Configure(builder);

            builder.ToTable("Reservation");
            builder.Property(q=>q.NumberOfGuest).IsRequired();
            builder.Property(q=>q.CheckInDate).IsRequired();
            builder.Property(q=>q.CheckInDate).IsRequired();
           
            builder.HasOne(q=>q.User).WithMany(q=>q.Reservations)
                .HasForeignKey(q=>q.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(q=>q.Room).WithMany(q=>q.Reservations)
                .HasForeignKey(q=>q.RoomID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
