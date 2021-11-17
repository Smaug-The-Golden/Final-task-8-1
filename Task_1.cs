using System;
using System.IO;

namespace Final_task_8_1
{
    class Task_1
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now);
            double erase_time = TimeSelect();
            string dir_path = DirSelect();

            if (TimeSpan.Compare((DateTime.Now - Directory.GetLastAccessTime(dir_path)), TimeSpan.FromMinutes(erase_time)) >= 1)
            {
                try
                {
                    Directory.Delete(dir_path, true);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("\nУдаление каталога успешно завершено!");
                    Console.ResetColor();
                    Console.ReadLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("Возникла некоторая исключительная ситуация. Выполнение программы прервано!");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nУдаление каталога не возможно! Прошло недостаточно времени для удаления ");
                Console.ResetColor();
                Console.ReadLine();
            }

        }

        static double TimeSelect()
        {
            Console.WriteLine("\t\nУкажите время в минутах, по истечению которого будет произведена очистка каталога: ");
            double erase_time;
            do
            {
                if (double.TryParse(Console.ReadLine(), out erase_time) && erase_time >= 1 && erase_time <= double.MaxValue)
                {
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nВы ввели некорректное значение!\nПожалуйста, введите целое положительное число: ");
                Console.ResetColor();
            }
            while (true);
            return (erase_time);
        }

        static string DirSelect()
        {
            Console.WriteLine("\nУкажите путь до каталога: ");
            string dir_path = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            if (Directory.Exists(dir_path))
                Console.WriteLine($"\nКаталог существует, он был создан: {Directory.GetCreationTime(dir_path)} \n" +
                                    $"Время последней записи в данный каталог: {Directory.GetLastWriteTime(dir_path)} \n" +
                                    $"Время последнего обращения к данному каталогу: {Directory.GetLastAccessTime(dir_path)}");
            else
            {
                do
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nКаталога по данному адресу не существует!\nПожалуйста, укажите путь до каталога еще раз: ");
                    Console.ResetColor();
                    dir_path = Console.ReadLine();
                }
                while (!Directory.Exists(dir_path));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nКаталог существует, он был создан: {Directory.GetCreationTime(dir_path)} \n" +
                                    $"Время последней записи в данный каталог: {Directory.GetLastWriteTime(dir_path)} \n" +
                                    $"Время последнего обращения к данному каталогу: {Directory.GetLastAccessTime(dir_path)}");
            }
            Console.ResetColor();
            return (dir_path);
        }
    }
}
