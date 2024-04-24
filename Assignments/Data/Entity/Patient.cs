using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Entity;

[Table("Patient")]
public partial class Patient
{
    [Key]
    public int Id { get; set; }

    [Column(" FirstName", TypeName = "character varying")]
    public string FirstName { get; set; } = null!;

    [Column(TypeName = "character varying")]
    public string LastName { get; set; } = null!;

    [Column("DoctortId ")]
    public int DoctortId { get; set; }

    public short Age { get; set; }

    [Column(TypeName = "character varying")]
    public string Email { get; set; } = null!;

    [Column(TypeName = "character varying")]
    public string PhoneNo { get; set; } = null!;

    public int Gender { get; set; }

    public int Disease { get; set; }

    [Column(TypeName = "character varying")]
    public string Specialist { get; set; } = null!;

    [ForeignKey("DoctortId")]
    [InverseProperty("Patients")]
    public virtual Doctor Doctort { get; set; } = null!;
}
