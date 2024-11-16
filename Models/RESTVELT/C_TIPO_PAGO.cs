using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCAPI.Models.RESTVELT;

public partial class C_TIPO_PAGO
{
    [Key]
    public Guid TPO_PAGO_ID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? TIPO_PAGO { get; set; }

    public bool? STATUS { get; set; }

    [InverseProperty("TIPO_PAGO")]
    public virtual ICollection<RESERVACION> RESERVACION { get; set; } = new List<RESERVACION>();
}
