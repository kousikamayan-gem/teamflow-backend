using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using TeamFlowWeb.Models;

namespace TeamFlowWeb.Services
{
    public class ProjectService
    {
        private readonly ProjectStore _projectStore;
        public ProjectService(ProjectStore projectStore)
        {
            _projectStore = projectStore;
        }
        public Project AddProject(Project project)
        {
            project.Id = _projectStore.NextProjectId;
            _projectStore.Projects.Add(project);
            _projectStore.NextProjectId++;
            return _projectStore.Projects.FirstOrDefault(p=> p.Id == project.Id);
        }
        public TaskItem AddTask(TaskItem task)
        {
            var project = _projectStore.Projects.FirstOrDefault(p => p.Id == task.ProjectId);
            if(project == null)
            {
                return null;
            }
            task.Id = _projectStore.NextTaskId++;
            Console.Write(task.Id);
            task.Status = Status.Open;
            project.Tasks.Add(task);
            return project.Tasks.FirstOrDefault(t=> t.Id == task.Id);
        }
        public List<Project> GetAllProjects()
        {
            return _projectStore.Projects;
        }
        public ICollection<TaskItem> GetTasksByProjectIdService(int projectId)
        {
            var project = _projectStore.Projects.FirstOrDefault(project => project.Id == projectId);
            return project.Tasks;
        }
        public ICollection<TaskItem> GetTasksByUserIdService(int userId)
        {
            Console.WriteLine(_projectStore.Projects.SelectMany(p => p.Tasks).Where(t => t.AssignedToUserId == userId));
            return _projectStore.Projects.SelectMany(p => p.Tasks).Where(t => t.AssignedToUserId == userId).ToList();
        }
    }
}
