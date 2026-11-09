using System;
using System.Collections.Generic;
using System.Text;

namespace TeamFlowWeb.Models
{
    public class Project
    {
        // Project Id
        public int Id { get; set; }
        // Name
        public string ProjectName { get; set; } = string.Empty;
        // Description
        public string? Description { get; set; }
        // OwnerId
        public int OwnerId { get; set; }
        // Created At
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        // Tasks
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();


    }
}
