namespace HotelReservation.Infrastructure.Persistence.EFCore.Mapping
{
    public class UserGroupMap : BaseMap<UserGroup>

    {
        public override void Configure(EntityTypeBuilder<UserGroup> builder)
        {
            base.Configure(builder);


            builder.ToTable("UserGroup");
            builder.Property(q => q.Name).IsRequired().HasMaxLength(100);
            //builder.HasMany(q => q.Reservations).WithOne(q => q.User);
           
        }
    }
}
