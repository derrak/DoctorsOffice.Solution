using System.Collections.Generic;
using System;

namespace DoctorsOffice.Models
{
  public class Patient
  {
    public Patient()
    {
      this.JoinEntities = new HashSet<DoctorPatient>();
      Completed = false;
    }

    public int PatientId { get; set; }
    public string Name { get; set; }
    public DateTime Birthday { get; set; }
    public bool Completed { get; set; }
    public virtual ICollection<DoctorPatient> JoinEntities { get; set; }
  }
}