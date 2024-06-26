﻿using AsmAppDev.Models;
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
				new Category { Id = 1, Name = "Business", DateCreate = new DateTime(2024, 10, 27), Availability = true, UserId = "2ad614f8-4ce8-4204-873e-f7d8c53a5e19" },
				new Category { Id = 2, Name = "Information Technology", DateCreate = new DateTime(2024, 10, 28), Availability = true, UserId = "2ad614f8-4ce8-4204-873e-f7d8c53a5e19" },
				new Category { Id = 3, Name = "Sale", DateCreate = new DateTime(2024, 10, 29), Availability = true, UserId = "2ad614f8-4ce8-4204-873e-f7d8c53a5e19" },
				new Category { Id = 4, Name = "Finance", DateCreate = new DateTime(2024, 10, 30), Availability = true, UserId = "2ad614f8-4ce8-4204-873e-f7d8c53a5e19" }
			   );
			modelBuilder.Entity<JobApplication>().HasData(
				new JobApplication { Id = 9, JobId = 1, Email = "Seeker2@gmai.com" }
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
