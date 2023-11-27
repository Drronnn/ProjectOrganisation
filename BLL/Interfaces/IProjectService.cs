using System.Collections.Generic;

namespace BLL
{
    public enum ProjectCreationResult { Success, FailureFullContract, FailureNoMoneyForContract};
    public interface IProjectService
    {
        
        List<ProjectModel> GetProjects();
        ProjectCreationResult CreateProject(ProjectModel project);
    }
}
