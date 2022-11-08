using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
namespace Engineering_calculator
{
    public partial class Form2 : Form
    {
        private SQLiteConnection SQLiteConn1;
        public Form2()
        {
            InitializeComponent();
            SQLiteConn1 = new SQLiteConnection();
            
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            if(form1.flag == true)
            {
                tabControl1.SelectTab(tabPage2);
            }
            
        }
        public bool OpenDBFile()//Функция запрашивает путь к файлу БД и осуществляет подключение
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.Filter = "Текстовые файлы (*.db)|*.db|Все файлы(*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                //создание подключения к БД
                SQLiteConn1 = new SQLiteConnection("Data Source=" + openFileDialog.FileName + ";Version=3;");
                SQLiteConn1.Open();
                //canConnect = true;
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = SQLiteConn1;
                return true;
            }
            else return false;
        }
        bool flagforchekbd=false;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenDBFile();
            flagforchekbd = true;
        }
        private void button41_Click(object sender, EventArgs e)
        {
            if (flagforchekbd == false)
            {
                MessageBox.Show("Выполните подключение к базе данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (textBox5.Text == "" || textBox6.Text == "")
                {
                    MessageBox.Show("Введите исходные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string drob = textBox5.Text;
                    string drob2 = textBox6.Text;
                    CNatDrob cNatDrob1 = new CNatDrob(drob);
                    CNatDrob CNatdrob2 = new CNatDrob(drob2);
                    string type = "";
                    string b = "";
                    string end = "";
                    if (comboBox3.SelectedIndex == 0)
                    {
                        CNatDrob sum = cNatDrob1 + CNatdrob2;
                        b = CNatDrob.sum;
                        textBox7.Text = b;
                        type = "'Сложение'";
                    }
                    if (comboBox3.SelectedIndex == 1)
                    {

                        CNatDrob minus = cNatDrob1 - CNatdrob2;
                        b = CNatDrob.subtraction;
                        textBox7.Text = b;
                        type = "'Вычитание'";
                    }
                    if (comboBox3.SelectedIndex == 2)
                    {
                        CNatDrob product = cNatDrob1 * CNatdrob2;
                        b = CNatDrob.multiplication;
                        textBox7.Text = b;
                        type = "'Умножение'";
                    }
                    if (comboBox3.SelectedIndex == 3)
                    {
                        CNatDrob del = cNatDrob1 / CNatdrob2;
                        b = CNatDrob.division;
                        textBox7.Text = b;
                        type = "'Деление'";
                    }

                    if (comboBox3.SelectedIndex == 4)
                    {
                        type = "'Сравнение'";
                        bool result = cNatDrob1 > CNatdrob2;
                        if (result == true)
                        {
                            textBox7.Text = "Дробь 1 больше дроби 2";
                        }
                        bool result2 = cNatDrob1 < CNatdrob2;
                        if (result2 == true)
                        {
                            textBox7.Text = "Дробь 1 меньше дроби 2";
                        }
                        //type = "'Сравнение'";
                    }
                    string endresult = "";
                    if (type != "Сравнение")
                    {
                        endresult = "'" + textBox7.Text + "'";
                    }
                    else
                    {
                        endresult = textBox7.Text;
                    }



                    string enddrob1 = "'" + textBox5.Text + "'";
                    string enddrob2 = "'" + textBox6.Text + "'";
                    string sql = "INSERT INTO [drob] ('Drob1','Drob2','type','res') VALUES (" + enddrob1 + "," + enddrob2 + "," + type + "," + endresult + ")";
                    SQLiteCommand command2 = new SQLiteCommand(sql, SQLiteConn1);
                    command2.ExecuteNonQuery().ToString();
                }

            }
        }

        void validationofcorrectE(KeyPressEventArgs e, string textbox)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && (ch != '/' || textbox.Contains("/")))
            {
                e.Handled = true;
            }
        }

        void validationofcorrect(KeyPressEventArgs e, string textbox)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && (ch != ',' || textbox.Contains(",")))
            {
                e.Handled = true;
            }
        }
        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            validationofcorrect(e, textBox8.Text);
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            validationofcorrectE(e, textBox5.Text);
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            validationofcorrectE(e, textBox6.Text);
        }

        private void button44_Click(object sender, EventArgs e)
        {
            if (flagforchekbd == false)
            {
                MessageBox.Show("Выполните подключение к базе данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (textBox8.Text == "")
                {
                    MessageBox.Show("Введите исходные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (radioButton1.Checked)
                    {
                        float Celsius = float.Parse(textBox8.Text);
                        string result = (((9 * Celsius) / 5) + 32).ToString();
                        string end = result.Replace(',', '.');
                        textBox9.Text = end;
                        string type1 = "'Целсий-Фаренгейт'";
                        string startnumber = textBox8.Text.Replace(',', '.');
                        string sql = "INSERT INTO [Convert] ('Исходноезначение','Тип перевода','Результат') VALUES (" + startnumber + "," + type1 + "," + end + ")";
                        SQLiteCommand command2 = new SQLiteCommand(sql, SQLiteConn1);
                        command2.ExecuteNonQuery().ToString();
                    }
                    if (radioButton2.Checked)
                    {
                        float Farengeit = float.Parse(textBox8.Text);
                        string result = (((Farengeit - 32) * 5) / 9).ToString();
                        string end = result.Replace(',', '.');
                        textBox9.Text = end;
                        string type1 = "'Фаренгейт-Целсий'";
                        string startnumber = textBox8.Text.Replace(',', '.');
                        string sql = "INSERT INTO [Convert] ('Исходноезначение','Тип перевода','Результат') VALUES (" + startnumber + "," + type1 + "," + end + ")";
                        SQLiteCommand command2 = new SQLiteCommand(sql, SQLiteConn1);
                        command2.ExecuteNonQuery().ToString();
                    }

                    if (radioButton3.Checked)
                    {
                        float Kelvin = float.Parse(textBox8.Text);
                        string result = ((((9 * Kelvin) / 5) + 32) + 273.15).ToString();
                        string end = result.Replace(',', '.');
                        textBox9.Text = end;
                        string startnumber = textBox8.Text.Replace(',', '.');
                        string type1 = "'Кельвин'";
                        string sql = "INSERT INTO [Convert] ('Исходноезначение','Тип перевода','Результат') VALUES (" + startnumber + "," + type1 + "," + end + ")";
                        SQLiteCommand command2 = new SQLiteCommand(sql, SQLiteConn1);
                        command2.ExecuteNonQuery().ToString();
                    }
                }
            }
        }
    }
}