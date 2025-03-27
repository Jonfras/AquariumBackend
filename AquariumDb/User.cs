using System;
using System.Collections.Generic;

namespace AquariumDb;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? LastLogin { get; set; }

    public virtual ICollection<AuthToken> AuthTokens { get; set; } = new List<AuthToken>();

    public virtual ICollection<Decoration> Decorations { get; set; } = new List<Decoration>();

    public virtual ICollection<Fish> Fish { get; set; } = new List<Fish>();

    public virtual ICollection<GameDatum> GameData { get; set; } = new List<GameDatum>();
}
