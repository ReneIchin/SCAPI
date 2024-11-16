using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCAPI.Models.DB_SEGURIDAD;

public partial class USUARIO_ROLES
{
    [Key]
    public Guid USUARIO_ROL_ID { get; set; }

    public Guid USUARIO_ID { get; set; }

    public Guid ROL_ID { get; set; }

    [ForeignKey("ROL_ID")]
    [InverseProperty("USUARIO_ROLES")]
    public virtual C_ROLES ROL { get; set; } = null!;

    [ForeignKey("USUARIO_ID")]
    [InverseProperty("USUARIO_ROLES")]
    public virtual C_USUARIOS USUARIO { get; set; } = null!;
}
