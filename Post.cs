using System;
using System.Collections.Generic;

namespace HangOver1.Models;

public partial class Post
{
    public int PostId { get; set; }

    public int? UserId { get; set; }

    public string? Caption { get; set; }

    public byte[]? ImageUrl { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

    public virtual User? User { get; set; }
}
