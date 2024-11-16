using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCAPI.Models.RESTVELT;

public partial class HABITACIONES
{
    [Key]
    public Guid HABITACION_ID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string HABITACION { get; set; } = null!;

    public Guid TIPO_HABITACION_ID { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal COSTO { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string UBICACION { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime FECHA_REG { get; set; }

    [Unicode(false)]
    public string USER_REG { get; set; } = null!;

    public Guid EMPRESA_ID { get; set; }

    public int ESTATUS_ID { get; set; }

    public int CANT_ADULTO { get; set; }

    public int CANT_NINIO { get; set; }

    [InverseProperty("HABITACION")]
    public virtual ICollection<BLOQUEO_HABITACION> BLOQUEO_HABITACION { get; set; } = new List<BLOQUEO_HABITACION>();

    [ForeignKey("EMPRESA_ID")]
    [InverseProperty("HABITACIONES")]
    public virtual C_EMPRESAS EMPRESA { get; set; } = null!;

    [ForeignKey("ESTATUS_ID")]
    [InverseProperty("HABITACIONES")]
    public virtual C_ESTATUS ESTATUS { get; set; } = null!;

    [InverseProperty("HABITACION")]
    public virtual ICollection<RESERVACION> RESERVACION { get; set; } = new List<RESERVACION>();

    [ForeignKey("TIPO_HABITACION_ID")]
    [InverseProperty("HABITACIONES")]
    public virtual C_TIPO_HABITACION TIPO_HABITACION { get; set; } = null!;
}
