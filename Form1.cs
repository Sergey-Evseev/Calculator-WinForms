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

        //====== переменные для хранения первоначальных размеров формы кнопок
        private Rectangle originalFormSize;
        private Rectangle button1OriginalRectangle;
        private Rectangle button2OriginalRectangle;
        private Rectangle button3OriginalRectangle;
        private Rectangle button4OriginalRectangle;
        private Rectangle button5OriginalRectangle;
        private Rectangle button6OriginalRectangle;
        private Rectangle button7OriginalRectangle;
        private Rectangle button8OriginalRectangle;
        private Rectangle button9OriginalRectangle;
        private Rectangle button10OriginalRectangle;        
        private Rectangle button12OriginalRectangle;
        private Rectangle button13OriginalRectangle;
        private Rectangle button14OriginalRectangle;
        private Rectangle button15OriginalRectangle;
        private Rectangle button16OriginalRectangle;
        private Rectangle button17OriginalRectangle;
        private Rectangle button18OriginalRectangle;        
        private Rectangle button20OriginalRectangle;
        private Rectangle textBox_ResultOriginalRectangle;
        private Rectangle labelCurrentOperationOriginalRectangle;
        private Rectangle backSpaceOriginalRectangle;
                       
        
        public Form1()
        {
            InitializeComponent();            
        }       
        

        //при нажатии цифр. кнопки изменяем текст в текст-боксе
        private void button_click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender; //кастуем объект sender к классу Button
            
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
            System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender; //кастуем объект sender к классу Button

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
        
        //присваивает текстовому полю подстроку длиной -1
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

        //обработчик нажатия на кнопку "равно"
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
            //========первоначальные размеры формы и кнопок - инициализация переменных originalRectangle======== 
            originalFormSize = new Rectangle(this.Location.X, this.Location.Y, this.Size.Width, this.Size.Height);
            button1OriginalRectangle = new Rectangle(button1.Location.X, button1.Location.Y, button1.Width, button1.Height);                 
            button2OriginalRectangle = new Rectangle(button2.Location.X, button2.Location.Y, button2.Width, button2.Height);                 
            button3OriginalRectangle = new Rectangle(button3.Location.X, button3.Location.Y, button3.Width, button3.Height);                 
            button4OriginalRectangle = new Rectangle(button4.Location.X, button4.Location.Y, button4.Width, button4.Height);                 
            button5OriginalRectangle = new Rectangle(button5.Location.X, button5.Location.Y, button5.Width, button5.Height);                 
            button6OriginalRectangle = new Rectangle(button6.Location.X, button6.Location.Y, button6.Width, button6.Height);                 
            button7OriginalRectangle = new Rectangle(button7.Location.X, button7.Location.Y, button7.Width, button7.Height);                 
            button8OriginalRectangle = new Rectangle(button8.Location.X, button8.Location.Y, button8.Width, button8.Height);                 
            button9OriginalRectangle = new Rectangle(button9.Location.X, button9.Location.Y, button9.Width, button9.Height);                 
            button10OriginalRectangle = new Rectangle(button10.Location.X, button10.Location.Y, button10.Width, button10.Height);                 
            button12OriginalRectangle = new Rectangle(button12.Location.X, button12.Location.Y, button12.Width, button12.Height);                 
            button13OriginalRectangle = new Rectangle(button13.Location.X, button13.Location.Y, button13.Width, button13.Height);                 
            button14OriginalRectangle = new Rectangle(button14.Location.X, button14.Location.Y, button14.Width, button14.Height);                 
            button15OriginalRectangle = new Rectangle(button15.Location.X, button15.Location.Y, button15.Width, button15.Height);                 
            button16OriginalRectangle = new Rectangle(button16.Location.X, button16.Location.Y, button16.Width, button16.Height);                 
            button17OriginalRectangle = new Rectangle(button17.Location.X, button17.Location.Y, button17.Width, button17.Height);                 
            button18OriginalRectangle = new Rectangle(button18.Location.X, button18.Location.Y, button18.Width, button18.Height);                 
            button20OriginalRectangle = new Rectangle(button20.Location.X, button20.Location.Y, button20.Width, button20.Height);                 
            textBox_ResultOriginalRectangle = new Rectangle(textBox_Result.Location.X, textBox_Result.Location.Y, textBox_Result.Width, textBox_Result.Height);                 
            labelCurrentOperationOriginalRectangle = new Rectangle(labelCurrentOperation.Location.X, labelCurrentOperation.Location.Y, labelCurrentOperation.Width, labelCurrentOperation.Height);                 
            backSpaceOriginalRectangle = new Rectangle(backSpace.Location.X, backSpace.Location.Y, backSpace.Width, backSpace.Height);                 

        }

        //=======метод вычисления новых координат и размеров============
        private void resizeControl(Rectangle r, Control c)
        {
            float xRatio = (float)(this.Width) / (float)(originalFormSize.Width);
            float yRatio = (float)(this.Height) / (float)(originalFormSize.Height);

            int newX = (int)(r.Location.X * xRatio);
            int newY = (int)(r.Location.Y * yRatio);

            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * xRatio);

            //изменяем параметры элемента на новые
            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);
        }
        
        
        //========обработчик изменения формы ============
        //настройки формы в Properties: Autosize: True, AutoSizeMode: GrowOnly
        private void Form1_Resize(object sender, EventArgs e)
        { //при каждом изменении  формы будет вызываться метод изменяющий размеры контрола
            resizeControl(button1OriginalRectangle, button1);
            resizeControl(button2OriginalRectangle, button2);
            resizeControl(button3OriginalRectangle, button3);
            resizeControl(button4OriginalRectangle, button4);
            resizeControl(button5OriginalRectangle, button5);
            resizeControl(button6OriginalRectangle, button6);
            resizeControl(button7OriginalRectangle, button7);
            resizeControl(button8OriginalRectangle, button8);
            resizeControl(button9OriginalRectangle, button9);
            resizeControl(button10OriginalRectangle, button10);
            resizeControl(button12OriginalRectangle, button12);
            resizeControl(button13OriginalRectangle, button13);
            resizeControl(button14OriginalRectangle, button14);
            resizeControl(button15OriginalRectangle, button15);
            resizeControl(button16OriginalRectangle, button16);
            resizeControl(button17OriginalRectangle, button17);
            resizeControl(button18OriginalRectangle, button18);
            resizeControl(button20OriginalRectangle, button20);
            resizeControl(textBox_ResultOriginalRectangle, textBox_Result);
            resizeControl(labelCurrentOperationOriginalRectangle, labelCurrentOperation);
            resizeControl(backSpaceOriginalRectangle, backSpace);
        }
    }
}
