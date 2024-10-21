namespace MappingSystem.DataModels
{
     public class Reservation
    {
        public int Id { get; set; }
        public string GuestName { get; set; }
        public string RoomType { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
