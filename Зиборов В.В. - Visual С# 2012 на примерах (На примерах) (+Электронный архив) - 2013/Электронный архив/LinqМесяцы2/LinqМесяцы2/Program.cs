﻿// Программа создает список месяцев в году с указанием их названия и
// количеством дней в месяце. Затем создает запрос на группировку этих
// данных, то есть следует создать одну группу месяцев, в которых
// содержится 31 день и другую группу, в которую входят прочие месяцы.
// Результат этого запроса программа выводит на консоль
using System;
using System.Collections.Generic;
using System.Linq;
// Другие директивы using удалены, поскольку они не используются в данной
// программе
namespace LinqМесяцы2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задаем цвет текста на консоли для большей выразительности:
            Console.ForegroundColor = ConsoleColor.White;
            // Создаем список месяцев - их 12:
            var Месяцы = new List<Месяц>();
            // Инициализация списка:
            for (var i = 0; i <= 11; i++)
                Месяцы.Add(
                    new Месяц
                    {
                        Название = System.Globalization.
                                          CultureInfo.CurrentUICulture.
                                          DateTimeFormat.MonthNames[i],
                        Дней = DateTime.DaysInMonth(2012, i + 1)
                    });
            // Запрос на группировку данных, записанных в список Месяцы. 
            // Этот список делим на две групппы, одна группа включает в себя
            // месяцы, содержащие 31 день, в вторая - прочие месяцы:
            var Запрос = from Месяц Мес in Месяцы
                         group Мес by new { Критерий = (Мес.Дней == 31) }
                         into ГруппыМесяцев
                         select ГруппыМесяцев;
            // Этот запрос можно прочитать так: список месяцев разделить на
            // две группы. В одной группе содержатся месяцы, количество дней
            // в которых равно 31 дню, а во второй группе - прочие месяцы
            // Здесь критерием (True или False) является равенство дней 31.
            // В запрос выводим группу месяцев и критерий.
            // Выводим результаты запроса на консоль:
            Console.WriteLine("Две группы месяцев: ");
            foreach (var Гр in Запрос)
                if (Гр.Key.Критерий == true)
                {
                    Console.WriteLine(
                        "\r\n" + "Месяцы, содержащие 31 день: " + "\r\n");
                    foreach (var М in Гр)
                        Console.WriteLine("{0} - {1}", М.Название, М.Дней);
                }
                else
                {
                    Console.WriteLine(
                           "\r\n" + "Прочие месяцы: " + "\r\n");
                    foreach (var М in Гр)
                        Console.WriteLine("{0} - {1}", М.Название, М.Дней);
                }
            Console.ReadKey();
        }
    }
    public class Месяц
    {
        public String Название;
        public int Дней;
    }
}
