using System;
using System.Collections.Generic;

namespace _6.Models;

public partial class Song
{
    public int SongNumber { get; set; }

    public string Name { get; set; }

    public string Author { get; set; }

    public string AudioPath { get; set; }

    public string? Lyric { get; set; }

    public string? ImgPath { get; set; }

    public bool IsHide { get; set; }

    public virtual User AuthorNavigation { get; set; }

    public virtual ICollection<ListSong> ListSongs { get; } = new List<ListSong>();
}
