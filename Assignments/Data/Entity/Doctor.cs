using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Entity;

[Table("Doctor")]
public partial class Doctor
{
    [Key]
    public int DoctorId { get; set; }

    [Column(". Specialist", TypeName = "character varying")]
    public string Specialist { get; set; } = null!;

    [InverseProperty("Doctort")]
    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
