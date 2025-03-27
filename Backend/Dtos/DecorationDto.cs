namespace Backend.Dtos {
    public class DecorationDto {
        public int UserId { get; set; }

        public string DecorationType { get; set; } = null!;

        public string Color { get; set; } = null!;

        public double Size { get; set; }

        public int PassiveIncome { get; set; }

        public int Price { get; set; }
    }
}