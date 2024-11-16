using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCAPI.Models.RESTVELT;

public partial class C_CIUDAD
{
    [Key]
    public Guid CIUDAD_ID { get; set; }

    public Guid ESTADO_ID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string CIUDAD { get; set; } = null!;

    public bool STATUS { get; set; }

    [ForeignKey("ESTADO_ID")]
    [InverseProperty("C_CIUDAD")]
    public virtual C_ESTADOS ESTADO { get; set; } = null!;

    [InverseProperty("CIUDAD")]
    public virtual ICollection<RESERVACION> RESERVACION { get; set; } = new List<RESERVACION>();
}
