namespace HotelReservation.WebHelper.DTO.User
{
    public class UpdateUserRequestDTO
    {
        public Guid Guid { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Sifre { get; set; }
        public string EPosta { get; set; }
        public string TelNo { get; set; }
        public Guid? GroupGUID { get; set; }
    }
}
