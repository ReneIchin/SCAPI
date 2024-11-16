using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCAPI.Models.DB_SEGURIDAD;

public partial class C_TIPO_PAGO
{
    [Key]
    public Guid TIPO_PAGO_ID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string TIPO_PAGO { get; set; } = null!;

    public bool STATUS { get; set; }

    [InverseProperty("TIPO_PAGO")]
    public virtual ICollection<C_EMPRESAS> C_EMPRESAS { get; set; } = new List<C_EMPRESAS>();
}
