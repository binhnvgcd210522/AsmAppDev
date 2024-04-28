using AsmAppDev.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace AsmAppDev.Repository.IRepository
{
    public interface IJobApplicationRepository : IRepository<JobApplication>
    {
        IEnumerable<JobApplication> GetAllJobApp(Expression<Func<JobApplication, bool>> filter = null);
        void Update(JobApplication entity);
    }
}
