using System;
using System.Collections.Generic;
using System.Text;

namespace EFTemplate.Models
{
    public class StudentCard
    {
        public int Id { get; set; }
        public string CardNumber { get; set; } = string.Empty; // Например, "СТ-2024-001"
        public DateTime IssueDate { get; set; } = DateTime.Now;

        // Внешний ключ: билет принадлежит конкретному студенту
        public int StudentId { get; set; }
        public Student? Student { get; set; }
    }
}
