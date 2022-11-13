using System;
using System.Collections.Generic;

namespace _6.Models;

public partial class List
{
    public int ListNumber { get; set; }

    public string Author { get; set; }

    public string Title { get; set; }

    public virtual User AuthorNavigation { get; set; }

    public virtual ICollection<ListSong> ListSongs { get; } = new List<ListSong>();
}
