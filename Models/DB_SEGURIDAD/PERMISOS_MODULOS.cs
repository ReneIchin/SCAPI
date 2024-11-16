using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCAPI.Models.DB_SEGURIDAD;

public partial class PERMISOS_MODULOS
{
    [Key]
    public Guid PERMISO_MODULO_ID { get; set; }

    public Guid MODULO_ID { get; set; }

    public Guid ACCION_ID { get; set; }

    public Guid ROL_ID { get; set; }

    public Guid? EMPRESA_ID { get; set; }

    [ForeignKey("ACCION_ID")]
    [InverseProperty("PERMISOS_MODULOS")]
    public virtual C_ACCIONES ACCION { get; set; } = null!;

    [ForeignKey("EMPRESA_ID")]
    [InverseProperty("PERMISOS_MODULOS")]
    public virtual C_EMPRESAS? EMPRESA { get; set; }

    [ForeignKey("MODULO_ID")]
    [InverseProperty("PERMISOS_MODULOS")]
    public virtual C_MODULOS MODULO { get; set; } = null!;

    [ForeignKey("ROL_ID")]
    [InverseProperty("PERMISOS_MODULOS")]
    public virtual C_ROLES ROL { get; set; } = null!;
}
