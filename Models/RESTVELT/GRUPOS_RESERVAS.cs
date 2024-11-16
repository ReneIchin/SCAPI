using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCAPI.Models.RESTVELT;

public partial class GRUPOS_RESERVAS
{
    [Key]
    public Guid GRUPO_RESERVA_ID { get; set; }

    public Guid TIPO_RESERVA_ID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CHECK_IN { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CHECK_OUT { get; set; }

    public Guid RESERVACION_ID { get; set; }

    public int ESTATUS_ID { get; set; }

    [ForeignKey("ESTATUS_ID")]
    [InverseProperty("GRUPOS_RESERVAS")]
    public virtual C_ESTATUS ESTATUS { get; set; } = null!;

    [ForeignKey("RESERVACION_ID")]
    [InverseProperty("GRUPOS_RESERVAS")]
    public virtual RESERVACION RESERVACION { get; set; } = null!;

    [ForeignKey("TIPO_RESERVA_ID")]
    [InverseProperty("GRUPOS_RESERVAS")]
    public virtual C_TIPOS_RESERVAS TIPO_RESERVA { get; set; } = null!;
}
