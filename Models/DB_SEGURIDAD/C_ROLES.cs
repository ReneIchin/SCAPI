using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCAPI.Models.DB_SEGURIDAD;

public partial class C_ROLES
{
    [Key]
    public Guid ROL_ID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string ROL { get; set; } = null!;

    public bool STATUS { get; set; }

    [InverseProperty("ROL")]
    public virtual ICollection<PERMISOS_MODULOS> PERMISOS_MODULOS { get; set; } = new List<PERMISOS_MODULOS>();

    [InverseProperty("ROL")]
    public virtual ICollection<USUARIO_ROLES> USUARIO_ROLES { get; set; } = new List<USUARIO_ROLES>();
}
