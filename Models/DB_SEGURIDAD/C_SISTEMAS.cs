using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCAPI.Models.DB_SEGURIDAD;

public partial class C_SISTEMAS
{
    [Key]
    public Guid SISTEMA_ID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string SISTEMA { get; set; } = null!;

    public bool STATUS { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string RUTA { get; set; } = null!;

    public DateTime FECHA_REG { get; set; }

    [InverseProperty("SISTEMA")]
    public virtual ICollection<C_GRUPO_MODULO> C_GRUPO_MODULO { get; set; } = new List<C_GRUPO_MODULO>();
}
