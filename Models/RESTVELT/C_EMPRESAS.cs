using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCAPI.Models.RESTVELT;

public partial class C_EMPRESAS
{
    [Key]
    public Guid EMPRESA_ID { get; set; }

    public Guid? EMPRESA_CLAVE_ID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? EMPRESA { get; set; }

    public bool? STATUS { get; set; }

    [InverseProperty("EMPRESA")]
    public virtual ICollection<HABITACIONES> HABITACIONES { get; set; } = new List<HABITACIONES>();
}
