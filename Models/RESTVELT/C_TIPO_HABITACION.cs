using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCAPI.Models.RESTVELT;

public partial class C_TIPO_HABITACION
{
    [Key]
    public Guid TIPO_HABITACION_ID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? TIPO_HABITACION { get; set; }

    [StringLength(10)]
    public string? STATUS { get; set; }

    [InverseProperty("TIPO_HABITACION")]
    public virtual ICollection<HABITACIONES> HABITACIONES { get; set; } = new List<HABITACIONES>();
}
