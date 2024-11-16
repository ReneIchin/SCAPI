using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCAPI.Models.DB_SEGURIDAD;

public partial class C_ESTATUS
{
    [Key]
    public Guid ESTATUS_ID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string ESTATUS { get; set; } = null!;

    public bool STATUS { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string COLOR { get; set; } = null!;

    [InverseProperty("ESTATUS")]
    public virtual ICollection<M_PAGOS> M_PAGOS { get; set; } = new List<M_PAGOS>();
}
