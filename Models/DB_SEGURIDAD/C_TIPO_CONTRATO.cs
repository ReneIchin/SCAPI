using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCAPI.Models.DB_SEGURIDAD;

public partial class C_TIPO_CONTRATO
{
    [Key]
    public Guid TIPO_CONTRATO_ID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string TIPO_CONTRATO { get; set; } = null!;

    public int DIAS_COBRO { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal IMPORTE { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string CONCEPTO { get; set; } = null!;

    public bool STATUS { get; set; }

    [InverseProperty("TIPO_CONTRATO")]
    public virtual ICollection<C_EMPRESAS> C_EMPRESAS { get; set; } = new List<C_EMPRESAS>();

    [InverseProperty("TIPO_CONTRATO")]
    public virtual ICollection<M_PAGOS> M_PAGOS { get; set; } = new List<M_PAGOS>();
}
