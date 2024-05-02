using System;
using System.Collections.Generic;

namespace entity_framework.Modelcls;

public partial class Sv
{
    public string Mssv { get; set; } = null!;

    public string NameSv { get; set; } = null!;

    public double Dtb { get; set; }

    public bool? Gender { get; set; }

    public DateTime? Ns { get; set; }

    public int? IdLop { get; set; }

    public virtual Lsh? IdLopNavigation { get; set; }
}
