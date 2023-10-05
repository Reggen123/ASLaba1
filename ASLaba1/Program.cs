using System;
using System.Collections.Generic;

namespace ASLaba1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Впишите путь к файлу csv:");
            string path = Console.ReadLine();
            bool IsWorking = false;
            Console.WriteLine("Выбирете вариант действия:");
            Console.WriteLine("1 - Выбрать другой файл.");
            Console.WriteLine("2 - Вывод всех записей файла.");
            Console.WriteLine("3 - Вывод записи по номеру.");
            Console.WriteLine("4 - Удаление записи из файла");
            Console.WriteLine("5 - Добавление записи в файл.");
            Console.WriteLine("6 - Выход.");
            while (!IsWorking)
            {
                string choice = Console.ReadLine();
                switch (int.Parse(choice))
                {
                    case 1:
                        {
                            Console.WriteLine("Впишите путь к файлу csv:");
                            path = Console.ReadLine();
                            break;
                        }
                    case 2:
                        {
                            List<Ability> abilities = CSVParser.Read(@path);
                            Console.WriteLine("ID Name Desc ManaCost Damage ReloadInSec");
                            foreach (var ab in abilities)
                            {
                                Console.WriteLine($"{ab.ID} {ab.Name} {ab.Desc} {ab.ManaCost} {ab.Damage} {ab.ReloadInSec}");
                            }
                            if(abilities.Count == 0)
                            {
                                Console.WriteLine($"Пусто");
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Введите порядковый номер:");
                            string number = Console.ReadLine();
                            Ability ab = CSVParser.Read(@path, int.Parse(number));
                            if(ab == null)
                            {
                                Console.WriteLine("Такой записи не существует, проверьте правильность номера");
                                break;
                            }
                            Console.WriteLine("ID Name Desc ManaCost Damage ReloadInSec");
                            Console.WriteLine($"{ab.ID} {ab.Name} {ab.Desc} {ab.ManaCost} {ab.Damage} {ab.ReloadInSec}");
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Введите порядковый номер:");
                            string number = Console.ReadLine();
                            if(!CSVParser.Delete(@path, int.Parse(number)))
                                Console.WriteLine("Удаление прошло неудачно, проверьте правильность номера");
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Введите данные через запятую:");
                            string[] fields = Console.ReadLine().Split(',');
                            if(!int.TryParse(fields[2], out int s) || !int.TryParse(fields[3], out int s2) || !int.TryParse(fields[4], out int s3))
                            {
                                Console.WriteLine("Данные введены неверно");
                                break;
                            }
                            Ability ab = new Ability(fields[0], fields[1], s, s2, s3);
                            CSVParser.Append(@path, ab);
                            Console.WriteLine("ID Name Desc ManaCost Damage ReloadInSec");
                            Console.WriteLine($"{ab.ID} {ab.Name} {ab.Desc} {ab.ManaCost} {ab.Damage} {ab.ReloadInSec}");
                            break;
                        }
                    case 6:
                        {
                            IsWorking = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Ничего не выбрано!");
                            break;
                        }
                }

            }
        }
    }
}
