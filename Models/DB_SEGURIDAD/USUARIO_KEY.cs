using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCAPI.Models.DB_SEGURIDAD;

public partial class USUARIO_KEY
{
    [Key]
    public Guid USER_KEY_ID { get; set; }

    public Guid USUARIO_ID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string API_KEY { get; set; } = null!;

    public bool STATUS { get; set; }

    [ForeignKey("USUARIO_ID")]
    [InverseProperty("USUARIO_KEY")]
    public virtual C_USUARIOS USUARIO { get; set; } = null!;
}
