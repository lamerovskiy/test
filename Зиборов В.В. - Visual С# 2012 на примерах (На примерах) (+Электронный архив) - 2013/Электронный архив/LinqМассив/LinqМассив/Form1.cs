// Решаем две задачи по выбору элементов из массива с помощью стандартных
// запросов технологии LINQ
using System;
using System.Linq;
using System.Windows.Forms;
// Другие директивы using удалены, поскольку они не используются в данной
// программе
namespace LinqМассив
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Технология LINQ"; textBox1.Multiline = true;
            // ЗАДАЧА 1:
            // Из массива имен выбрать имена с количеством букв равным
            // шести, вывести эти имена в текстовое поле TextBox в
            // алфавитном порядке, при этом все буквы перевести в верхний
            // регистр.
            // Решение:
            var СтрокаИмен = "Витя Лариса Лариса Лена Андрей Женя " +
                             "Александр Лариса Виктор Света Оксана Наташа";
            // Из строки имен получаем массив имен, задавая в качестве
            // сепаратора деления подстрок символ пробела:
            var Имена = СтрокаИмен.Split(' ');
            // или проще: 
            // String[] Имена = {
            //           "Витя", "Лариса", "Лариса", "Лена", "Андрей",
            //           "Женя", "Александр", "Лариса", "Виктор", "Света",
            //           "Оксана", "Наташа"};
            textBox1.Text = "ЗАДАЧА 1. В списке имен:" + "\r\n\r\n";
            foreach (String Имя in Имена)
                textBox1.Text = textBox1.Text + Имя + " ";
            // В результате LINQ-запроса получаем список имен с количеством
            // букв равным шести:
            var Запрос = from s in Имена
                         where s.Length == 6
                         orderby s
                         select s.ToUpper(); // - перевод в верхний регистр
            // s - это переменная диапазона схожа с переменной итерации
            // в foreach;
            // where s.Length == 6 - условие выбора;
            // orderby s - сортировать в алфавитном порядке.
            // Удаляем элементы-дубликаты из списка имен:
            Запрос = Запрос.Distinct();
            // Или таким образом:
            // Запрос = Запрос.Union(Запрос);
            textBox1.Text = textBox1.Text + "\r\n\r\n" +
                  "выбираем имена с количеством букв равным шести, при " +
                  "этом избавляемся от дублирования имен:" + "\r\n\r\n";
            foreach (String s in Запрос) 
                // s - переменная итерации в цикле foreach
                     textBox1.Text = textBox1.Text + s + " ";

            textBox1.Text = textBox1.Text + "\r\n\r\n";
            // ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ 
            // ЗАДАЧА 2: Из массива целых чисел X() требуется выбрать числа,
            //           значения которых >= 4, и записать эти числа в
            //           список Y, отсортировав выбранные числа по
            //           возрастанию
            // Решение:
            // Инициализация массива целых чисел:
            int[] X = { 
                 -2, 5, -23, 0, 7, -10, 11, 11, 14, 3, 8, 5, -5, 27, 8 };
            textBox1.Text +=
                        "ЗАДАЧА 2. Из заданного массива X:" + "\r\n\r\n";
            foreach (int число in X)
                 textBox1.Text = textBox1.Text + число.ToString() + "  ";

            textBox1.Text = textBox1.Text + "\r\n\r\n" +
                "выбираем числа, значения " +
                "которых >= 4 и записываем их в список (коллекцию) Y, " +
                "исключая элементы-дубликаты:" + "\r\n\r\n";
            // Y - это список, куда помещается выбранные элементы:
            var Y = from Число in X
                    where Число >= 4
                    orderby Число
                    select Число;
            // Удаляем элементы-дубликаты из списка целых чисел:
            var Z = Y.Distinct();
            // Или таким образом:
            // var Z = Y.Union(Y)
            // Вывод элементов списка Y в текстовое поле TextBox1:
            foreach (int числа in Z)
                textBox1.Text = textBox1.Text + числа.ToString() + " ";
        }
    }
}
