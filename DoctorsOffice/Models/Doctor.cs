using System.Collections.Generic;

namespace DoctorsOffice.Models
{
  public class Doctor
  {
    public Doctor()
    {
      this.JoinEntities = new HashSet<DoctorSpecialty>();
      this.JoinEntities2 = new HashSet<DoctorPatient>();
    }

    public int DoctorId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<DoctorSpecialty> JoinEntities { get; set; }
    public virtual ICollection<DoctorPatient> JoinEntities2 { get; set; }
  }
}