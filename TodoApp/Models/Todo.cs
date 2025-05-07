using System;
using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models
{
    public enum TodoStatus { Pending, InProgress, Completed }
    public enum TodoPriority { Low, Medium, High }

    public class Todo
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        
        public required string Title { get; set; }

        public string? Description { get; set; }
        public TodoStatus Status { get; set; }
        public TodoPriority Priority { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Due Date")]
        public DateTime? DueDate { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }

}
