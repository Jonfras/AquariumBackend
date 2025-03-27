namespace Backend.Dtos {
    public class FishDto {
        public int UserId { get; set; }

        public string FishType { get; set; } = null!;

        public string? Name { get; set; }

        public string Color { get; set; } = null!;

        public double Size { get; set; }

        public int ClickBonus { get; set; }

        public int Price { get; set; }
    }
}
