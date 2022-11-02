using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_WinForms
{
    public partial class Form1 : Form
    {
        //переменные для хранения результата и оператора действия
        Double resultValue = 0;
        String operationPerformed = "";

        
        public Form1()
        {
            InitializeComponent();
        }

        //по нажатии кнопки изменяем текст в текст-боксе
        private void button_click(object sender, EventArgs e)
        {   //если до нажатия кнопки в боксе 0 убираем его
            if (textBox_Result.Text == "0")
            {
                textBox_Result.Clear();
            };

            Button button = (Button)sender; //кастуем объект sender к классу Button
            textBox_Result.Text = textBox_Result.Text + button.Text; //передаем в бокс имя кнопки
        }

        //обработчик нажатий на кнопки действия
        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender; //кастуем объект sender к классу Button
            operationPerformed = button.Text; //в строковую переменную передаем название кнопок действия
            resultValue = Double.Parse(textBox_Result.Text); //в переменную для хранения
            //результата передаем текст бокса приведенный к даблу
        }
        //clear entry (CE) очищает текст бокса
        private void button5_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
        }
        // clear (С) также обнуляет результат
        private void button6_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
            resultValue = 0;
        }

        private void button16_Click(object sender, EventArgs e)
        {

        }
    }
}
