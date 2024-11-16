using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCAPI.Models.RESTVELT;

public partial class C_ESTADOS
{
    [Key]
    public Guid ESTADO_ID { get; set; }

    public Guid PAIS_ID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string ESTADO { get; set; } = null!;

    public bool STATUS { get; set; }

    [InverseProperty("ESTADO")]
    public virtual ICollection<C_CIUDAD> C_CIUDAD { get; set; } = new List<C_CIUDAD>();

    [ForeignKey("PAIS_ID")]
    [InverseProperty("C_ESTADOS")]
    public virtual C_PAISES PAIS { get; set; } = null!;
}
