using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCAPI.Models.DB_SEGURIDAD;

public partial class USUARIO_EMPRESA
{
    [Key]
    public Guid USUARIO_EMPRESA_ID { get; set; }

    public Guid USUARIO_ID { get; set; }

    public Guid EMPRESA_ID { get; set; }

    [ForeignKey("EMPRESA_ID")]
    [InverseProperty("USUARIO_EMPRESA")]
    public virtual C_EMPRESAS EMPRESA { get; set; } = null!;

    [ForeignKey("USUARIO_ID")]
    [InverseProperty("USUARIO_EMPRESA")]
    public virtual C_USUARIOS USUARIO { get; set; } = null!;
}
