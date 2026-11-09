using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using TeamFlowWeb.DTOs;
using TeamFlowWeb.Models;
using TeamFlowWeb.Services;

namespace TeamFlowWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectService _projectService;
        public ProjectController(ProjectService projectService)
        {
            _projectService = projectService;
        }


        [HttpPost("create")]
        public IActionResult CreateProject(NewProject project)
        {
            var newProject = new Project
            {
                ProjectName = project.ProjectName,
                Description = project.Description,
                OwnerId = project.OwnerId
            };
            var response = _projectService.AddProject(newProject);
            if (response == null)
            {
                return BadRequest("Unable to Create Project");
            }
            return Ok(response);
        }
        [HttpPost("{projectId}/tasks")]
        public IActionResult CretateTask(int projectId, NewTask task)
        {

            var newTask = new TaskItem
            {
                Title = task.Title,
                Description = task.Description,
                Priority = task.Priority,
                ProjectId = projectId,
                AssignedToUserId = task.AssignedToUserId
            };
            var respone = _projectService.AddTask(newTask);
            if (respone == null)
            {
                return NotFound("Project does not exist");
            }
            return Ok(newTask);
        }
        [HttpGet("/project")]
        public IActionResult GetProjects()
        {
            return Ok(_projectService.GetAllProjects());
        }

        [HttpGet("{projectId}/tasks")]
        public IActionResult GetTasksByProjectId(int projectId)
        {
            var response = _projectService.GetTasksByProjectIdService(projectId);
            return Ok(response);
        }
        [Authorize]
        [HttpGet("/tasks")]
        public IActionResult GetTasksByUserId()
        {
            var currentUserClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(!int.TryParse(currentUserClaim, out int userId))
             {
                return Unauthorized();
            }
            var response = _projectService.GetTasksByUserIdService(userId);
            return Ok(response);
        }
    }
}
