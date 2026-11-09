using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;

namespace TeamFlowWeb.Models
{
    public enum Status
    {
        Open,
        InProgress,
        Done
    };
    public enum Priority
    {
        Low,
        Medium,
        High
    }
    public class TaskItem
    {
        // Task ID
        public int Id { get; set; }
        // Task Title
        public string Title { get; set; } = string.Empty;
        // Task Description
        public string Description { get; set; } = string.Empty;
        // Status
        public Status Status { get; set; }
        // Priority
        public Priority Priority { get; set; }
        // ProjectId
        public int ProjectId { get; set; }
        // AssignedToUserId
        public int AssignedToUserId { get; set; }
        // CreatedAt
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
