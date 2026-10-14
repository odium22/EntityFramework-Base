using EFTemplate.Data;
using EFTemplate.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFTemplate.Demos
{
    public static class ChangeTracker
    {
        public static void Run(AppDbContext db)
        {
            Console.WriteLine("\n 2. CHANGE TRACKER (ТРЕКЕР СОСТОЯНИЙ) ");

            // Создали объект в памяти (он пока оторван от EF)
            var student = new Student { FirstName = "Тест", LastName = "Тестовый", Age = 25, GroupId = 1 };
            Console.WriteLine($"1. Новый объект в памяти: State = {db.Entry(student).State}"); 

            // Добавили в контекст
            db.Students.Add(student);
            Console.WriteLine($"2. После db.Students.Add(): State = {db.Entry(student).State}"); 

            // Сохранили
            db.SaveChanges();
            Console.WriteLine($"3. После db.SaveChanges(): State = {db.Entry(student).State}"); 

            // Просто поменяли имя в C#
            student.FirstName = "Олег";
            Console.WriteLine($"4. Изменили свойство в коде: State = {db.Entry(student).State}");

            // Пометили на удаление
            db.Students.Remove(student);
            Console.WriteLine($"5. После db.Students.Remove(): State = {db.Entry(student).State}"); 

            db.SaveChanges();
            Console.WriteLine($"6. После удаления и SaveChanges(): State = {db.Entry(student).State}"); 
        }
    }
}
