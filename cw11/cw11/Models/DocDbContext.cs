using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Models
{
    public class DocDbContext : DbContext
    {
        public DocDbContext() { }

        public DocDbContext(DbContextOptions options)
        : base(options)
        {

        }
        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }

        public DbSet<Prescription> Prescriptions { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //PK
            builder.Entity<Medicament>().HasKey(q => q.IdMedicament);
            builder.Entity<Prescription>().HasKey(q => q.IdPrescription);
            builder.Entity<Prescription_Medicament>().HasKey(q =>
                new {
                    q.IdMedicament,
                    q.IdPrescription
                });

            //REF
            builder.Entity<Prescription_Medicament>().HasOne(t => t.Medicament).WithMany(t => t.Prescription_Medicaments).HasForeignKey(t => t.IdMedicament);
            builder.Entity<Prescription_Medicament>().HasOne(t => t.Prescription).WithMany(t => t.Prescription_Medicaments).HasForeignKey(t => t.IdPrescription);

            //DATA
            var doctors = new List<Doctor>();
            doctors.Add(new Doctor {
                IdDoctor = 1,
                FirstName = "Doc1",
                LastName = "aaaaa",
                Email = "aaaa@gmail.com"
            });

            doctors.Add(new Doctor {
                IdDoctor = 2,
                FirstName = "Doc2",
                LastName = "bbbbb",
                Email = "bbbb@gmail.com" });

            builder.Entity<Doctor>().HasData(doctors);

            var patients = new List<Patient>();
            patients.Add(new Patient {
                IdPatient = 1,
                FirstName = "Pat1",
                LastName = "ccccc",
                BirthDate = new DateTime()
            });

            patients.Add(new Patient {
                IdPatient = 2,
                FirstName = "Pat2",
                LastName = "ddddd",
                BirthDate = new DateTime()
            });

            builder.Entity<Patient>().HasData(patients);

            var prescriptions = new List<Prescription>();
            prescriptions.Add(new Prescription {
                IdPrescription = 1,
                Date = new DateTime(),
                DueDate = new DateTime(),
                IdDoctor = 1,
                IdPatient = 1
            });

            prescriptions.Add(new Prescription {
                IdPrescription = 2,
                Date = new DateTime(),
                DueDate = new DateTime(),
                IdDoctor = 2,
                IdPatient = 2
            });

            builder.Entity<Prescription>().HasData(prescriptions);

            var medicaments = new List<Medicament>();
            medicaments.Add(new Medicament {
                IdMedicament = 1,
                Name = "Med1",
                Descripiton = "asfeefef",
                Type = "Med"
            });

            medicaments.Add(new Medicament { 
                IdMedicament = 2,
                Name = "Med2",
                Descripiton = "asdhafiuafiu",
                Type = "Med"
            });

            builder.Entity<Medicament>().HasData(medicaments);

            var prescriptionsMedicament = new List<Prescription_Medicament>();
            prescriptionsMedicament.Add(new Prescription_Medicament { 
                IdMedicament = 1,
                IdPrescription = 1,
                Dose = 10,
                Details = "dgsgaefaefaesgfaefg"
            });

            prescriptionsMedicament.Add(new Prescription_Medicament {
                IdMedicament = 2,
                IdPrescription = 1,
                Dose = 12,
                Details = "fesfsrggegfe"
            });

            builder.Entity<Prescription_Medicament>().HasData(prescriptionsMedicament);
        }
    }
}
