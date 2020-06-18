using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cw11.Models
{
    public class Medicament
    {
        public int IdMedicament { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Descripiton { get; set; }
        [MaxLength(100)]
        public string Type { get; set; }
        public virtual ICollection<Prescription_Medicament> Prescription_Medicaments { get; set; }
    }
}
