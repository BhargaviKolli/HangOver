using System;
using System.Collections.Generic;

namespace HangOver1.Models;

public partial class Comment
{
    public int CommentId { get; set; }

    public int PostId { get; set; }

    public int UserId { get; set; }

    public string? Comment1 { get; set; }

    public DateTime? CommentedDate { get; set; }

    public int? CommentRepliedId { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
