using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCAPI.Models.DB_SEGURIDAD;

public partial class C_GRUPO_MODULO
{
    [Key]
    public Guid GRUPO_MODULO_ID { get; set; }

    public Guid SISTEMA_ID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string GRUPO_MODULO { get; set; } = null!;

    public int ORDEN { get; set; }

    public bool STATUS { get; set; }

    [InverseProperty("GRUPO_MODULO")]
    public virtual ICollection<C_MODULOS> C_MODULOS { get; set; } = new List<C_MODULOS>();

    [ForeignKey("SISTEMA_ID")]
    [InverseProperty("C_GRUPO_MODULO")]
    public virtual C_SISTEMAS SISTEMA { get; set; } = null!;
}
