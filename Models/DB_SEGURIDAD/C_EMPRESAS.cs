using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCAPI.Models.DB_SEGURIDAD;

public partial class C_EMPRESAS
{
    [Key]
    public Guid EMPRESA_ID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string EMPRESA { get; set; } = null!;

    [StringLength(13)]
    [Unicode(false)]
    public string RFC { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? RAZON_SOCIAL { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? TELEFONO { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? EMAIL { get; set; }

    public Guid TIPO_EMPRESA_ID { get; set; }

    public Guid TIPO_PAGO_ID { get; set; }

    [Unicode(false)]
    public string WEB_RUTA { get; set; } = null!;

    [Column(TypeName = "image")]
    public byte[] IMG_LOGO { get; set; } = null!;

    public DateTime FECHA_REG { get; set; }

    public DateTime? FECHA_ULT_ACT { get; set; }

    [Unicode(false)]
    public string? USUARIO_REG { get; set; }

    public bool? STATUS { get; set; }

    public Guid TIPO_CONTRATO_ID { get; set; }

    public DateOnly? FECHA_INI_PRUEBA { get; set; }

    public DateOnly? FECHA_FIN_PRUEBA { get; set; }

    [InverseProperty("EMPRESA")]
    public virtual ICollection<M_PAGOS> M_PAGOS { get; set; } = new List<M_PAGOS>();

    [InverseProperty("EMPRESA")]
    public virtual ICollection<PERMISOS_MODULOS> PERMISOS_MODULOS { get; set; } = new List<PERMISOS_MODULOS>();

    [ForeignKey("TIPO_CONTRATO_ID")]
    [InverseProperty("C_EMPRESAS")]
    public virtual C_TIPO_CONTRATO TIPO_CONTRATO { get; set; } = null!;

    [ForeignKey("TIPO_EMPRESA_ID")]
    [InverseProperty("C_EMPRESAS")]
    public virtual C_TIPOS_EMPRESAS TIPO_EMPRESA { get; set; } = null!;

    [ForeignKey("TIPO_PAGO_ID")]
    [InverseProperty("C_EMPRESAS")]
    public virtual C_TIPO_PAGO TIPO_PAGO { get; set; } = null!;

    [InverseProperty("EMPRESA")]
    public virtual ICollection<USUARIO_EMPRESA> USUARIO_EMPRESA { get; set; } = new List<USUARIO_EMPRESA>();
}
