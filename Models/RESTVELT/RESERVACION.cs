using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCAPI.Models.RESTVELT;

public partial class RESERVACION
{
    [Key]
    public Guid RESERVACION_ID { get; set; }

    public Guid HABITACION_ID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string NOMBRE { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? APELLIDOS { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string TELEFONO { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? EMAIL { get; set; }

    public Guid CIUDAD_ID { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string FOLIO_RESERVA { get; set; } = null!;

    [Unicode(false)]
    public string? DESCRIPCION { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FECHA_REG { get; set; }

    [Unicode(false)]
    public string USER_REG { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime FECHA_ULT_ACT { get; set; }

    [Unicode(false)]
    public string USER_ULT_ACT { get; set; } = null!;

    public Guid TIPO_PAGO_ID { get; set; }

    public int ESTATUS_ID { get; set; }

    [ForeignKey("CIUDAD_ID")]
    [InverseProperty("RESERVACION")]
    public virtual C_CIUDAD CIUDAD { get; set; } = null!;

    [ForeignKey("ESTATUS_ID")]
    [InverseProperty("RESERVACION")]
    public virtual C_ESTATUS ESTATUS { get; set; } = null!;

    [InverseProperty("RESERVACION")]
    public virtual ICollection<GRUPOS_RESERVAS> GRUPOS_RESERVAS { get; set; } = new List<GRUPOS_RESERVAS>();

    [ForeignKey("HABITACION_ID")]
    [InverseProperty("RESERVACION")]
    public virtual HABITACIONES HABITACION { get; set; } = null!;

    [ForeignKey("TIPO_PAGO_ID")]
    [InverseProperty("RESERVACION")]
    public virtual C_TIPO_PAGO TIPO_PAGO { get; set; } = null!;
}
