using System;
using System.Collections.Generic;

namespace AquariumDb;

public partial class Fish
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string FishType { get; set; } = null!;

    public string? Name { get; set; }

    public string Color { get; set; } = null!;

    public double Size { get; set; }

    public int ClickBonus { get; set; }

    public int Price { get; set; }

    public double? PositionX { get; set; }

    public double? PositionY { get; set; }

    public DateTime? PurchasedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
