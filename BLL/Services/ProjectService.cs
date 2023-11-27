using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace BLL.Services
{
    public class ProjectService : IProjectService
    {
        IDbRepository context;

        public ProjectService(IDbRepository context)
        {
            this.context = context;
        }
        public ProjectCreationResult CreateProject(ProjectModel project)
        {
            var projectOnContract = context.Project.GetList().Where(i => i.ContractId == project.ContractId).ToList();

            if (context.Contract.GetItem(project.ContractId).ProjectCount == projectOnContract.Count())
                return ProjectCreationResult.FailureFullContract;

            decimal newTotalCost = project.Price + projectOnContract.Sum(i => i.Price);

            if (newTotalCost > context.Contract.GetItem(project.ContractId).Price)
                return ProjectCreationResult.FailureNoMoneyForContract;

            if (project.Id == -1)
                project.Id = context.Project.GetList().FirstOrDefault() == null ? 1 : context.Project.GetList().OrderByDescending(i => i.Id).FirstOrDefault().Id + 1;

            Project p = new Project
            {
                Id = project.Id,
                EndDate = project.EndDate,
                StartDate = project.StartDate,
                ContractId  = project.ContractId,
                Name = project.Name,
                Price = project.Price,
                Contract = context.Contract.GetItem(project.ContractId),
                Task = new List<Task>(),
            };

            context.Project.Create(p);

            context.Save();

            return ProjectCreationResult.Success;
        }

        public List<ProjectModel> GetProjects()
        {
            return context.Project.GetList().Select(i => new ProjectModel(i)).ToList();
        }

    }
}
