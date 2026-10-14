using EFTemplate.Data;
using EFTemplate.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFTemplate.Demos
{
    public static class CrudOperations
    {
        public static void Run(AppDbContext db)
        {
            Console.WriteLine("1. БАЗОВЫЙ CRUD ");

            // Добавлениее
            Console.WriteLine("\n--> Добавляем нового студента...");
            var newStudent = new Student
            {
                FirstName = "Динис",
                LastName = "Морозов",
                Age = 18,
                GroupId = 1 // Привязываем к группе ИТ-101
            };
            db.Students.Add(newStudent);
            db.SaveChanges(); 
            Console.WriteLine($"Студент добавлен с сгенерированным Id: {newStudent.Id}");

            // Чтение по первичному ключу
            Console.WriteLine("\n--> Поиск студента через метод Find (по Id)...");
            var student = db.Students.Find(newStudent.Id);
            Console.WriteLine($"Найден: {student?.FirstName} {student?.LastName}, Возраст: {student?.Age}");

            // Обновление
            Console.WriteLine("\n--> Меняем возраст студента на 22 года...");
            if (student != null)
            {
                student.Age = 22;
                db.SaveChanges(); // EF сам поймет, что изменилось, и сгенерирует SQL UPDATE
                Console.WriteLine("Возраст успешно обновлен в базе.");
            }

            // удаление
            Console.WriteLine("\n--> Удаляем созданного студента...");
            if (student != null)
            {
                db.Students.Remove(student);
                db.SaveChanges(); // Генерирует SQL DELET
                Console.WriteLine("Студент удален из базы.");
            }
        }
    }
}
