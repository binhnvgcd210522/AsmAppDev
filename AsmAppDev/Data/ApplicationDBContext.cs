using AsmAppDev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AsmAppDev.Data
{
	public class ApplicationDBContext : DbContext
	{
		public DbSet<Employer> Employers { get; set; }
		public DbSet<JobSeeker> JobSeekers { get; set; }
		public DbSet<Admin> Admins { get; set; }
		public DbSet<Job> Jobs { get; set; }
		public DbSet<Category> Categories { get; set; }


		public ApplicationDBContext(DbContextOptions options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Category>().HasData(
				new Category { Id = 1, Name = "Business", Description = "Senior" },
				new Category { Id = 2, Name = "Information Technology", Description = "So Hard" },
				new Category { Id = 3, Name = "Sale", Description = "Sale everything" },
				new Category { Id = 4, Name = "Finance", Description = "Earn money" }
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
