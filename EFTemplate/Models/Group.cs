using System;
using System.Collections.Generic;
using System.Text;

namespace EFTemplate.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Один ко многим: в группе много студентов
        public List<Student> Students { get; set; } = new();
    }
}
