namespace MappingSystem.DataModels
{
    public class GoogleReservation
    {
        public int Id { get; set; }
        public string GuestName { get; set; }
        public string RoomType { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

         // Custom map function for this class
        public void Map(Reservation source)
        {
            Id = source.Id;
            GuestName = source.GuestName;
            RoomType = source.RoomType;
            CheckIn = source.CheckIn;
            CheckOut = source.CheckOut;
        }
    }
}