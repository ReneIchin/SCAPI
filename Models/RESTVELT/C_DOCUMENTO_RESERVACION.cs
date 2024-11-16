using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCAPI.Models.RESTVELT;

public partial class C_DOCUMENTO_RESERVACION
{
    [Key]
    public Guid DOC_RESERVACION_ID { get; set; }

    public Guid RESERVACION_ID { get; set; }

    [Column(TypeName = "image")]
    public byte[] FILE_COMP { get; set; } = null!;
}
