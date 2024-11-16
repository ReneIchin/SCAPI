using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCAPI.Models.RESTVELT;

public partial class C_PAISES
{
    [Key]
    public Guid PAIS_ID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string PAIS { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string CLAVE { get; set; } = null!;

    public bool STATUS { get; set; }

    [InverseProperty("PAIS")]
    public virtual ICollection<C_ESTADOS> C_ESTADOS { get; set; } = new List<C_ESTADOS>();
}
