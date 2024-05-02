using System;
using System.Collections.Generic;

namespace entity_framework.Modelcls;

public partial class Lsh
{
    public int IdLop { get; set; }

    public string? NameLop { get; set; }

    public virtual ICollection<Sv> Svs { get; set; } = new List<Sv>();
}
