using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-72LF9DR\\SQLEXPRESS;Initial Catalog=MyDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=TrueData Source=DESKTOP-72LF9DR\\SQLEXPRESS;Initial Catalog=Clinic;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"); // Replace with your actual connection string
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
             .HasOne(d => d.Clinic)
             .WithMany(c => c.Doctors)
             .HasForeignKey(d => d.ClinicId)
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Patient>()
                .HasOne(p => p.Clinic)
                .WithMany(c => c.Patients)
                .HasForeignKey(p => p.ClinicId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Assistant>()
                .HasOne(a => a.Clinic)
                .WithMany(c => c.Assistants)
                .HasForeignKey(a => a.ClinicId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Person>()
                .HasDiscriminator<string>("Role")
                .HasValue<Doctor>("Doctor")
                .HasValue<Patient>("Patient")
                .HasValue<Assistant>("Assistant")
                .HasValue<Admin>("Admin");

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany()
                .HasForeignKey(a => a.DoctorPhoneNumber)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
               .HasOne(a => a.Patient)
               .WithMany(p => p.Appointments)
               .HasForeignKey(a => a.PatientPhoneNumber)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
               .HasOne(a => a.Assistant)
               .WithMany()
               .HasForeignKey(a => a.AssistantPhoneNumber)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Doctor)
                .WithMany()
                .HasForeignKey(p => p.DoctorPhoneNumber)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Patient)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(p => p.PatientPhoneNumber)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    PhoneNumber = "0000000000",
                    Name = "System Admin",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    SSN = "000-00-0000",
                    Gender = "Male",
                    Email = "admin@clinic.com",
                    Address = "HQ",
                    Username = "admin",
                    Password = "$2a$11$hzqmi4sYBglEkL15MJ0lkuHHRU8PObDnRlyoNcCN06E61uE7zGdLG", // You should hash it ideally
                    // Role will be auto-set by discriminator = "Admin"
                }
            );

            base.OnModelCreating(modelBuilder);
        }
        // DbSet properties for your entities
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Person> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Assistant> Assistants { get; set; }

        public DbSet<User> SystemUsers { get; set; }
        public DbSet<Admin> Admins { get; set; }



        }
}
