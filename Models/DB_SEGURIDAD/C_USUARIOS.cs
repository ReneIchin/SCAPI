using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCAPI.Models.DB_SEGURIDAD;

public partial class C_USUARIOS
{
    [Key]
    public Guid USUARIO_ID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string USERNAME { get; set; } = null!;

    [StringLength(500)]
    [Unicode(false)]
    public string PASSWORD { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string? TEL { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? EMAIL { get; set; }

    public DateTime FECHA_REG { get; set; }

    public bool STATUS { get; set; }

    public int? CODIGO_RECUP { get; set; }

    [InverseProperty("USUARIO")]
    public virtual ICollection<USUARIO_EMPRESA> USUARIO_EMPRESA { get; set; } = new List<USUARIO_EMPRESA>();

    [InverseProperty("USUARIO")]
    public virtual ICollection<USUARIO_KEY> USUARIO_KEY { get; set; } = new List<USUARIO_KEY>();

    [InverseProperty("USUARIO")]
    public virtual ICollection<USUARIO_ROLES> USUARIO_ROLES { get; set; } = new List<USUARIO_ROLES>();
}
