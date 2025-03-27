using System;
using System.Collections.Generic;

namespace AquariumDb;

public partial class GameDatum
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public long Coins { get; set; }

    public long TotalEarnedCoins { get; set; }

    public DateTime? LastSaved { get; set; }

    public virtual User User { get; set; } = null!;
}
