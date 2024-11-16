using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCAPI.Models.DB_SEGURIDAD;

public partial class C_MODULOS
{
    [Key]
    public Guid MODULO_ID { get; set; }

    public Guid GRUPO_MODULO_ID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string MODULO { get; set; } = null!;

    public int ORDEN { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ICONO { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? RUTA { get; set; }

    public DateTime FECHA_REG { get; set; }

    public bool STATUS { get; set; }

    [ForeignKey("GRUPO_MODULO_ID")]
    [InverseProperty("C_MODULOS")]
    public virtual C_GRUPO_MODULO GRUPO_MODULO { get; set; } = null!;

    [InverseProperty("MODULO")]
    public virtual ICollection<PERMISOS_MODULOS> PERMISOS_MODULOS { get; set; } = new List<PERMISOS_MODULOS>();
}
