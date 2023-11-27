using DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using static BLL.TaskStatusModel;

namespace BLL
{
    public class TaskService : ITaskService
    {
        IDbRepository context;

        public TaskService(IDbRepository context)
        {
            this.context = context;
        }

        public void CancelTask(int taskId)
        {
            Task task = context.Task.GetItem(taskId);
            task.TaskStatusId = (int)TaskStatusEnum.ToDo;
            task.TaskStatus = context.TaskStatus.GetItem(task.TaskStatusId);
            task.EmployeeId = null;
            task.Employee = null;

            context.Task.Update(task);
            context.Save();
        }

        public void ChangeTaskStatus(int taskId, TaskStatusModel.TaskStatusEnum status)
        {
            Task task = context.Task.GetItem(taskId);
            task.TaskStatusId = (int)status;
            task.TaskStatus = context.TaskStatus.GetItem(task.TaskStatusId);
            context.Task.Update(task);
            context.Save();
        }

        public void CreateTask(TaskModel task)
        {
            if (task.Id == -1)
                task.Id = context.Task.GetList().FirstOrDefault() == null ? 1 : context.Task.GetList().OrderByDescending(i => i.Id).FirstOrDefault().Id + 1;

            Task realTask = new Task
            {
                Id = task.Id,
                Description = task.Description,
                Title = task.Title,
                ProjectId = task.ProjectId,
                EmployeeId = task.EmployeeId,
                Employee = task.EmployeeId == -1 || task.EmployeeId == null ? null : context.Employee.GetItem((int)task.EmployeeId),
                Project = context.Project.GetItem(task.ProjectId),
                TaskStatusId = task.TaskStatusId,
                TaskStatus = context.TaskStatus.GetItem(task.TaskStatusId)
            };

            context.Task.Create(realTask);

            context.Save();
        }

        public List<TaskModel> GetCompleteTasks()
        {
            return context.Task.GetList().Where(i => i.TaskStatusId == 4).Select(i => new TaskModel(i)).ToList();
        }

        public List<TaskModel> GetProgressTasks()
        {
            return context.Task.GetList().Where(i => i.TaskStatusId == 2).Select(i => new TaskModel(i)).ToList();
        }

        public TaskModel GetTask(int taskId)
        {
            return new TaskModel(context.Task.GetItem(taskId));
        }

        public List<TaskModel> GetTasks()
        {
            return context.Task.GetList().Select(i => new TaskModel(i)).ToList();
        }

        public List<TaskModel> GetTestTasks()
        {
            return context.Task.GetList().Where(i => i.TaskStatusId == 3).Select(i => new TaskModel(i)).ToList();
        }

        public List<TaskModel> GetToDoTasks()
        {
            return context.Task.GetList().Where(i => i.TaskStatusId == 1).Select(i => new TaskModel(i)).ToList();
        }

        public void MoveTaskForward(int taskId)
        {
            Task task = context.Task.GetItem(taskId);
            if (task.TaskStatusId == (int)TaskStatusEnum.Complete)
                return;
            task.TaskStatusId++;

            context.Task.Update(task);
            context.Save();

        }

        public void SetTaskToEmployee(int taskId, int employeeId)
        {
            Task task = context.Task.GetItem(taskId);
            task.EmployeeId = employeeId;
            task.Employee = context.Employee.GetItem(employeeId);
            task.TaskStatusId = (int)TaskStatusEnum.Progress;
            task.TaskStatus = context.TaskStatus.GetItem(task.TaskStatusId);
            context.Task.Update(task);
            context.Save();
        }

        public void UpdateTask(TaskModel task)
        {
            Task realTask = context.Task.GetItem(task.Id);
            realTask.Title = task.Title;
            realTask.Description = task.Description;
            if (task.EmployeeId != null)
            {
                realTask.EmployeeId = task.EmployeeId;
                realTask.Employee = context.Employee.GetItem((int)task.EmployeeId);

                if  (realTask.TaskStatusId == (int)TaskStatusEnum.ToDo)
                {
                    realTask.TaskStatusId++;
                    realTask.TaskStatus = context.TaskStatus.GetItem(realTask.TaskStatusId);
                }
            }

            context.Task.Update(realTask);
            context.Save();
        }
    }
}
