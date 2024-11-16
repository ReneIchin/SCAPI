using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCAPI.Models.DB_SEGURIDAD;

public partial class M_PAGOS
{
    [Key]
    public Guid PAGO_ID { get; set; }

    public Guid EMPRESA_ID { get; set; }

    public Guid TIPO_CONTRATO_ID { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal IMPORTE { get; set; }

    public DateTime FECHA_INICIO { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FECHA_FINAL { get; set; }

    public int DIAS_ESPERA { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FECHA_PAGO { get; set; }

    public Guid ESTATUS_ID { get; set; }

    [Unicode(false)]
    public string USER_REG { get; set; } = null!;

    [ForeignKey("EMPRESA_ID")]
    [InverseProperty("M_PAGOS")]
    public virtual C_EMPRESAS EMPRESA { get; set; } = null!;

    [ForeignKey("ESTATUS_ID")]
    [InverseProperty("M_PAGOS")]
    public virtual C_ESTATUS ESTATUS { get; set; } = null!;

    [ForeignKey("TIPO_CONTRATO_ID")]
    [InverseProperty("M_PAGOS")]
    public virtual C_TIPO_CONTRATO TIPO_CONTRATO { get; set; } = null!;
}
