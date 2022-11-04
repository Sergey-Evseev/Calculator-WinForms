﻿/*Task 2.Необходимо разработать приложение «Калькулятор»
В верхней части приложения необходимо использовать два поля для ввода текста. 
Первое используется для отображения предыдущих операций, а второе — для ввода текущего числа. 
Оба поля должны запрещать редактировать свое содержимое посредством клавиатурного ввода.
Данные поля будут заполняться автоматически при нажатии на соответствующие кнопки, расположенные ниже.
Кнопки «0» — «9» добавляют соответствующую цифру в конец текущего числа. При этом должны выполняться
проверки, не допускающие неправильного ввода. Например, нельзя вводить числа, начинающиеся с ноля, 
после которого нет десятичной точки.
Кнопка «.» добавляет (если это возможно) десятичную точку в текущее число.
Кнопки «/», «*», «+», «-» выполняют соответствующую операцию над результатом предыдущей операции и текущим числом.
Кнопка «=» вычисляет выражение и выводит результат.
Кнопка «CE» очищает текущее число.
Кнопка «C» очищает текущее число и предыдущее выражение.
Кнопка «<» очищает последний введенный символ в текущем числе.*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_WinForms
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
