using AsmAppDev.Models;
using Microsoft.AspNetCore.Mvc;

namespace AsmAppDev.Repository.IRepository
{
        public interface IJobApplicationRepository : IRepository<JobApplication>
        {
            void Update(JobApplication entity);
        }
}
