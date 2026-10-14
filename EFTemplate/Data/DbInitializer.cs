using EFTemplate.Models;
using System;
using System.Collections.Generic;
using System.Text;
using EFTemplate.Models;

namespace EFTemplate.Data
{
    public static class DbInitializer
    {
        public static void ResetAndSeed(AppDbContext context)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n[БАЗА ДАННЫХ] Удаление старой версии SQLite...");
            // 1. ПОЛНОЕ УДАЛЕНИЕ: стирает старый файл, исключая рассинхрон моделей
            context.Database.EnsureDeleted();

            Console.WriteLine("[БАЗА ДАННЫХ] Создание чистой структуры по текущим моделям...");
            // 2. Создание файла и таблиц заново
            context.Database.EnsureCreated();
            Console.ResetColor();

            // 3. Начальное заполнение
            var itGroup = new Group { Name = "ИТ-101" };
            var designGroup = new Group { Name = "ДИЗ-201" };

            var student1 = new Student
            {
                FirstName = "Алексей",
                LastName = "Смирнов",
                Age = 19,
                Group = itGroup,
                Card = new StudentCard { CardNumber = "СТ-101-01" }
            };

            var student2 = new Student
            {
                FirstName = "Мария",
                LastName = "Иванова",
                Age = 20,
                Group = itGroup,
                Card = new StudentCard { CardNumber = "СТ-101-02" }
            };

            context.Groups.AddRange(itGroup, designGroup);
            context.Students.AddRange(student1, student2);

            // Фиксация изменений в БД
            context.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[БАЗА ДАННЫХ] База успешно пересоздана и наполнена!\n");
            Console.ResetColor();
        }
    }
}
