using AsmAppDev.Data;
using AsmAppDev.Models;
using AsmAppDev.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace AsmAppDev.Repository
{
    public class JobApplicationRepository : Repository<JobApplication>, IJobApplicationRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public JobApplicationRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void Update(JobApplication entity)
        {
            _dbContext.JobApplications.Update(entity);
        }
    }
}
