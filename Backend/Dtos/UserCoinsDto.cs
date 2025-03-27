namespace Backend.Dtos {
    public class UserCoinsDto {
        public int UserId { get; set; }
        public long Coins { get; set; }
        public DateTime LastSaved { get; set; }
    }
}
