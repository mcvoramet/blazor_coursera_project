using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class Event
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Event title is required")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; } = DateTime.Now.AddDays(1);

        [Required(ErrorMessage = "Location is required")]
        [StringLength(200, ErrorMessage = "Location cannot exceed 200 characters")]
        public string Location { get; set; } = string.Empty;

        [Range(0, 10000, ErrorMessage = "Capacity must be between 0 and 10,000")]
        public int Capacity { get; set; } = 100;

        public string ImageUrl { get; set; } = string.Empty;

        public bool IsPublished { get; set; } = false;

        public string OrganizerId { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }
    }
}
