using System;
using System.Collections.Generic;

namespace Cineplex.Models;

public partial class Movie
{
    public int MovieId { get; set; }

    public string? MovieName { get; set; }

    public int? ProducerId { get; set; }

    public virtual ICollection<Show> Shows { get; set; } = new List<Show>();
}
