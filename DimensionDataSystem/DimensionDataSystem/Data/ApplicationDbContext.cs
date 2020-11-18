using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DimensionDataSystem.Models;

namespace DimensionDataSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DimensionDataSystem.Models.Employee> Employee { get; set; }
        public DbSet<DimensionDataSystem.Models.Company> Company { get; set; }
        public DbSet<DimensionDataSystem.Models.CompanyCost> CompanyCost { get; set; }
        public DbSet<DimensionDataSystem.Models.EmployeeHistory> EmployeeHistory { get; set; }
        public DbSet<DimensionDataSystem.Models.EmployeeInformation> EmployeeInformation { get; set; }
        public DbSet<DimensionDataSystem.Models.JobInformation> JobInformation { get; set; }
        public DbSet<DimensionDataSystem.Models.Survey> Survey { get; set; }
    }
}
