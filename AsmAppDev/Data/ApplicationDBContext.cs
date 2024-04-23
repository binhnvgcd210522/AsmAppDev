using AsmAppDev.Models;
using AsmAppDev.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AsmAppDev.Data
{
	public class ApplicationDBContext : IdentityDbContext
	{
		public DbSet<ApplicationUser> ApplicationUsers { get; set; }
		public DbSet<Job> Jobs { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<JobApplication> JobApplications { get; set; }

		public ApplicationDBContext(DbContextOptions options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Category>().HasData(
				new Category { Id = 1, Name = "Business", DateCreate = new DateTime(2024, 10, 27), Availability = true, UserId = "da94d7cd-6ac4-4c5d-9195-289b8e8ce846" },
				new Category { Id = 2, Name = "Information Technology", DateCreate = new DateTime(2024, 10, 28), Availability = true, UserId = "da94d7cd-6ac4-4c5d-9195-289b8e8ce846" },
				new Category { Id = 3, Name = "Sale", DateCreate = new DateTime(2024, 10, 29), Availability = true, UserId = "da94d7cd-6ac4-4c5d-9195-289b8e8ce846" },
				new Category { Id = 4, Name = "Finance", DateCreate = new DateTime(2024, 10, 30), Availability = true, UserId = "da94d7cd-6ac4-4c5d-9195-289b8e8ce846" }
			   );
			modelBuilder.Entity<JobApplication>().HasData(
				new JobApplication { Id = 9, JobId = 1, UserId = "9eb14563-29d9-4045-8167-9efdefa94604" },
				new JobApplication { Id = 10, JobId = 2, UserId = "9eb14563-29d9-4045-8167-9efdefa94604" }
				);
            modelBuilder.Entity<Job>().HasData(
				new Job
				{
					Id = 1,
					Title = "Project manager",
					Description = "Hello",
					requiredQualification = "Microsoft",
					Deadline = new DateTime(2024, 6, 10),
					CategoryId = 1
				},
				new Job
				{
					Id = 2,
					Title = "Grab",
					Description = "Driving",
					requiredQualification = "Drive License",
					Deadline = new DateTime(2024, 7, 12),
					CategoryId = 3
				},
				new Job
				{
					Id = 3,
					Title = "Back-end Developer",
					Description = "Back-end engineering job with high salary",
					requiredQualification = "IT degree",
					Deadline = new DateTime(2024, 7, 10),
					CategoryId = 2
				}
			);

		}
	}
}
