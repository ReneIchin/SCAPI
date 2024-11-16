using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCAPI.Models.RESTVELT;

public partial class C_TIPOS_RESERVAS
{
    [Key]
    public Guid TIPO_RESERVA_ID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? TIPO_RESERVA { get; set; }

    public bool? STATUS { get; set; }

    [InverseProperty("TIPO_RESERVA")]
    public virtual ICollection<GRUPOS_RESERVAS> GRUPOS_RESERVAS { get; set; } = new List<GRUPOS_RESERVAS>();
}
