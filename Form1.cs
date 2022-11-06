using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Calculator_WinForms
{
    public partial class Form1 : Form
    {
        //переменные для хранения результата и оператора действия
        Double resultValue = 0;
        String operationPerformed = "";

        //значение меняется на true при каждом нажатии кнопок действия
        //и на false при нажатии цифровых кнопок
        bool isOperationPerformed = false;

        
        public Form1()
        {
            InitializeComponent();
        }

        //при нажатии цифр. кнопки изменяем текст в текст-боксе
        private void button_click(object sender, EventArgs e)
        {
            Button button = (Button)sender; //кастуем объект sender к классу Button
            
            //если до нажатия цифр. кнопки в боксе стоит 0 при условии что с нажатием приходит не запятая,
            //либо введена операция, то очищаем поле
            if (  ((textBox_Result.Text == "0") && (button.Text != ",")) || (isOperationPerformed))
            {
                textBox_Result.Clear();
            };
            isOperationPerformed = false; //после нажатия цифровых кнопок переменная меняется на false 
            

            //проверка на двойную запятую
            if (button.Text == ",") //если с нажатием приходит запятая
            {
                //если текст бокс не содержит запятую
                if (!textBox_Result.Text.Contains(","))
                    textBox_Result.Text = textBox_Result.Text + button.Text;
            } 
            else 
            textBox_Result.Text = textBox_Result.Text + button.Text; //передаем в бокс имя кнопки
        }

        //обработчик нажатий на кнопки действия
        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender; //кастуем объект sender к классу Button

            if (resultValue != 0)
            {
                button16.PerformClick();
                operationPerformed = button.Text; //в строковую переменную передаем название кнопок действия
                //в лейбл текущей операции передаем строку с текущим результатом и действием
                //здесь конкатенация дабл resultValue и строки operationPerformed
                labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true; //после нажатия кнопок действия переменная становится true 
            }
            else
            {
                operationPerformed = button.Text; 
                resultValue = Double.Parse(textBox_Result.Text); //в переменную для хранения
                                                                 //результата передаем текст бокса приведенный к даблу                                                                                 
                labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true; 
            }
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
        private void backSpace_Click(object sender, EventArgs e)
        {
            if (textBox_Result.TextLength > 0)
            {
                textBox_Result.Text = textBox_Result.Text.Substring(0, (textBox_Result.TextLength - 1));
            }
            else
            {
                textBox_Result.Text = "0";
            }
        }

        //обработчик нажатия на кнопку равно
        private void button16_Click(object sender, EventArgs e)
        {
            switch (operationPerformed) //свич по строковой переменной хранящей действие
            {
                case "+":  //дабл переменную значения складываем с приведенным к дабл текстом бокса
                           //и все приводим к строке
                    textBox_Result.Text = (resultValue + Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "-":
                    textBox_Result.Text = (resultValue - Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "*":
                    textBox_Result.Text = (resultValue * Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "/":
                    textBox_Result.Text = (resultValue / Double.Parse(textBox_Result.Text)).ToString();
                    break;
                default:
                    break;
            }
            resultValue = Double.Parse(textBox_Result.Text);
            labelCurrentOperation.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }        
    }
}
