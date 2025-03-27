using System;
using System.Collections.Generic;

namespace AquariumDb;

public partial class Decoration
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string DecorationType { get; set; } = null!;

    public string Color { get; set; } = null!;

    public double Size { get; set; }

    public int PassiveIncome { get; set; }

    public int Price { get; set; }

    public double? PositionX { get; set; }

    public double? PositionY { get; set; }

    public string AssetPath { get; set; } = null!;

    public DateTime? PurchasedAt { get; set; }

    public virtual User User { get; set; } = null!;

}
