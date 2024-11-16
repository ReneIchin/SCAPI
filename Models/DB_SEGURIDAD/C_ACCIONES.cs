using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCAPI.Models.DB_SEGURIDAD;

public partial class C_ACCIONES
{
    [Key]
    public Guid ACCION_ID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string ACCION { get; set; } = null!;

    public bool STATUS { get; set; }

    [InverseProperty("ACCION")]
    public virtual ICollection<PERMISOS_MODULOS> PERMISOS_MODULOS { get; set; } = new List<PERMISOS_MODULOS>();
}
