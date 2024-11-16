using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCAPI.Models.RESTVELT;

public partial class C_MOTIVOS_BLOQUEOS
{
    [Key]
    public Guid MOTIVO_BLOQUEO_ID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string MOTIVO_BLOQUEO { get; set; } = null!;

    public bool STATUS { get; set; }

    [InverseProperty("MOTIVO_BLOQUEO")]
    public virtual ICollection<BLOQUEO_HABITACION> BLOQUEO_HABITACION { get; set; } = new List<BLOQUEO_HABITACION>();
}
