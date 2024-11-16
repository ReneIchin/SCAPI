using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCAPI.Models.DB_SEGURIDAD;

public partial class C_TIPOS_EMPRESAS
{
    [Key]
    public Guid TIPO_EMPRESA_ID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string TIPO_EMPRESA { get; set; } = null!;

    public bool STATUS { get; set; }

    [InverseProperty("TIPO_EMPRESA")]
    public virtual ICollection<C_EMPRESAS> C_EMPRESAS { get; set; } = new List<C_EMPRESAS>();
}
