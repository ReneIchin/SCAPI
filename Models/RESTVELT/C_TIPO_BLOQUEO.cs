using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCAPI.Models.RESTVELT;

public partial class C_TIPO_BLOQUEO
{
    [Key]
    public Guid TIPO_BLOQUEO_ID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string TIPO_BLOQUEO { get; set; } = null!;

    public bool STATUS { get; set; }

    [InverseProperty("TIPO_BLOQUEO")]
    public virtual ICollection<BLOQUEO_HABITACION> BLOQUEO_HABITACION { get; set; } = new List<BLOQUEO_HABITACION>();
}
