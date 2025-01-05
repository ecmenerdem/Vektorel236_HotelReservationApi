namespace HotelReservation.Infrastructure.Persistence.EFCore.Context
{
    public class HotelReservationAPIContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=LAB5-OGRETMEN\\SQLEXPRESS;initial catalog=HotelReservationDB;integrated security=True;trustservercertificate=True");
            }

            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserGroup> UserGroup { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new RoomMap());
            modelBuilder.ApplyConfiguration(new HotelMap());
            modelBuilder.ApplyConfiguration(new ReservationMap());
            modelBuilder.ApplyConfiguration(new UserGroupMap());
        }
    }
}
