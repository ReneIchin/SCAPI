using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCAPI.Models.RESTVELT;

public partial class BLOQUEO_HABITACION
{
    [Key]
    public Guid BLOQUEO_HABITACION_ID { get; set; }

    public Guid HABITACION_ID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FECHA_INICIO { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FECHA_FINAL { get; set; }

    public Guid TIPO_BLOQUEO_ID { get; set; }

    public Guid MOTIVO_BLOQUEO_ID { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? DESCRIPCION { get; set; }

    [ForeignKey("HABITACION_ID")]
    [InverseProperty("BLOQUEO_HABITACION")]
    public virtual HABITACIONES HABITACION { get; set; } = null!;

    [ForeignKey("MOTIVO_BLOQUEO_ID")]
    [InverseProperty("BLOQUEO_HABITACION")]
    public virtual C_MOTIVOS_BLOQUEOS MOTIVO_BLOQUEO { get; set; } = null!;

    [ForeignKey("TIPO_BLOQUEO_ID")]
    [InverseProperty("BLOQUEO_HABITACION")]
    public virtual C_TIPO_BLOQUEO TIPO_BLOQUEO { get; set; } = null!;
}
