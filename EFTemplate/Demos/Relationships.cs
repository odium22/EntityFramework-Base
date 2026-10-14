using EFTemplate.Data;
using EFTemplate.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFTemplate.Demos
{
    public static class RelationshipsDemo
    {
        public static void Run(AppDbContext db)
        {
            Console.WriteLine("\n 3. СВЯЗИ И КАСКАДНОЕ УДАЛЕНИЕ ");

            // Создаем группу сразу с привязанным студентом в одном графе объекто
            var newGroup = new Group
            {
                Name = "ВРЕМЕННАЯ-99",
                Students = new List<Student>
            {
                new Student { FirstName = "Кирилл", LastName = "Временный", Age = 19 }
            }
            };

            db.Groups.Add(newGroup);
            db.SaveChanges();
            Console.WriteLine($"Группа '{newGroup.Name}' создана со студентом в ней.");

            // Демонстрация каскадного удаление:
            // Если мы удаляем группу EF по умолчанию удалит студента так же
            Console.WriteLine("\n--> Удаляем группу 'ВРЕМЕННАЯ-99'...");
            db.Groups.Remove(newGroup);
            db.SaveChanges();

            // Проверяем, остался ли студент после удалеение группы
            var orphanStudent = db.Students.FirstOrDefault(s => s.LastName == "Временный");
            Console.WriteLine($"Студент после удаления группы найден в базе? -> {(orphanStudent != null ? "ДА" : "НЕТ (удален каскадно)")}");
        }
    }
}
