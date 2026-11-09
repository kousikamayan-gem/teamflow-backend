using System;
using System.Collections.Generic;
using System.Text;
using TeamFlowWeb.Models;

namespace TeamFlowWeb.Services
{
    public class ProjectStore
    {
        public List<Project> Projects { get; } = new();
        public int NextProjectId { get; set; } = 1;
        public int NextTaskId { get; set; } = 1;
    }
}
