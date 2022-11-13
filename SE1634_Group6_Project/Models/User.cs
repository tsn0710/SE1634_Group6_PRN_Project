using System;
using System.Collections.Generic;

namespace _6.Models;

public partial class User
{
    public string UserName { get; set; }

    public string Password { get; set; }

    public int Role { get; set; }

    public virtual ICollection<List> Lists { get; } = new List<List>();

    public virtual ICollection<Song> Songs { get; } = new List<Song>();
}
