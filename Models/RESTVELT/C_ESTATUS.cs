using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCAPI.Models.RESTVELT;

public partial class C_ESTATUS
{
    [Key]
    public int ESTATUS_ID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string ESTATUS { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string COLOR_HX { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string CLAVE { get; set; } = null!;

    [InverseProperty("ESTATUS")]
    public virtual ICollection<GRUPOS_RESERVAS> GRUPOS_RESERVAS { get; set; } = new List<GRUPOS_RESERVAS>();

    [InverseProperty("ESTATUS")]
    public virtual ICollection<HABITACIONES> HABITACIONES { get; set; } = new List<HABITACIONES>();

    [InverseProperty("ESTATUS")]
    public virtual ICollection<RESERVACION> RESERVACION { get; set; } = new List<RESERVACION>();
}
