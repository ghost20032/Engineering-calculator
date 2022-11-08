using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Data.SQLite;

namespace Engineering_calculator
{
    public partial class Form1 : Form
    {
        Double results = 0;
        String operation = "";
        bool enter_value = false;
        private SQLiteConnection SQLiteconn;
        private SQLiteConnection SQLiteConn;
        public SQLiteConnection SQLiteConnform2;
        private DataTable dTable;
        public Form1()
        {
            InitializeComponent();
            SQLiteconn = new SQLiteConnection();
            SQLiteconn = new SQLiteConnection("Data Source=  " + "DBforSqlite" + "  ;Version=3;");
            dTable = new DataTable();
            /*if(textBox1.Text =="")
            {
                *//*button12.Enabled = true; button16.Enabled = true; button20.Enabled = true; button19.Enabled = true; button17.Enabled = true; button22.Enabled = true; button24.Enabled = true; button26.Enabled = true; button38.Enabled = true;
                button18.Enabled = true; button23.Enabled = true; button25.Enabled = true; button27.Enabled = true; button37.Enabled = true; button21.Enabled = true; button31.Enabled = true; button28.Enabled = true; button29.Enabled = true;
                button30.Enabled = true; button32.Enabled = true; button35.Enabled = true; button34.Enabled = true; button36.Enabled = true; button33.Enabled = true;*//*
               
                
                button12.Enabled = false; button16.Enabled = false; button20.Enabled = false; button19.Enabled = false; button17.Enabled = false; button22.Enabled = false; button24.Enabled = false; button26.Enabled = false; button38.Enabled = false;
                button18.Enabled = false; button23.Enabled = false; button25.Enabled = false; button27.Enabled = false; button37.Enabled = false; button21.Enabled = false; button31.Enabled = false; button28.Enabled = false; button29.Enabled = false;
                button30.Enabled = false; button32.Enabled = false; button35.Enabled = false; button34.Enabled = false; button36.Enabled = false; button33.Enabled = false;

            }

            else
            {
                
            }*/

        }
        private void GetTableNames()
        {
            string SQLQuery = "SELECT name FROM sqlite_master WHERE type='table' ORDER BY name;";
            SQLiteCommand command = new SQLiteCommand(SQLQuery, SQLiteConn);
            SQLiteDataReader reader = command.ExecuteReader();
            comboBox4.Items.Clear();
            while (reader.Read())
            {
                comboBox4.Items.Add(reader[0].ToString());
            }
        }

        //SQL-запрос на отображение всей таблицы
        private string SQL_AllTable()
        {
            return "SELECT * FROM [" + comboBox4.SelectedItem + "] order by 1";
        }

        //отображение таблицы данных dTable в компоненте dataGridView1
        private void ShowTable(string SQLQuery)
        {
            dTable.Clear();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(SQLQuery, SQLiteConn);
            adapter.Fill(dTable);
            dataGridView4.Columns.Clear();
            dataGridView4.Rows.Clear();

            for (int col = 0; col < dTable.Columns.Count; col++)
            {
                string ColName = dTable.Columns[col].ColumnName;
                dataGridView4.Columns.Add(ColName, ColName);
                dataGridView4.Columns[col].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            for (int row = 0; row < dTable.Rows.Count; row++)
            {
                dataGridView4.Rows.Add(dTable.Rows[row].ItemArray);
            }
        }

        private void button_click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "0") || (enter_value))
                textBox1.Text = "";
            enter_value = false;

            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (textBox1.Text.Contains("."))
                    textBox1.Text = textBox1.Text + button.Text;
            }
            else
                textBox1.Text = textBox1.Text + button.Text;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "0") || (enter_value))
                textBox1.Text = "";
            enter_value = false;

            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (textBox1.Text.Contains("."))
                    textBox1.Text = textBox1.Text + button.Text;
            }
            else
                textBox1.Text = textBox1.Text + button.Text;
            button14.Enabled = false;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";

        }

        private void button8_Click(object sender, EventArgs e) //удаление одного элемента 
        {
            if (textBox1.Text.Length > 0)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
            }
        }

        private void arithmetic_operator(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {
                MessageBox.Show("Введите исходные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                button14.Enabled = true;
                Button button = (Button)sender;
                operation = button.Text;
                results = double.Parse(textBox1.Text);
                textBox1.Text = "";
                label1.Text = System.Convert.ToString(results) + " " + operation;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            button14.Enabled = true;
            label1.Text = "";
            switch (operation)
            {
                case "+":
                    textBox1.Text = (results + double.Parse(textBox1.Text)).ToString();
                    break;

                case "-":
                    textBox1.Text = (results - double.Parse(textBox1.Text)).ToString();
                    break;

                case "*":
                    textBox1.Text = (results * double.Parse(textBox1.Text)).ToString();
                    break;

                case "/":
                    textBox1.Text = (results / double.Parse(textBox1.Text)).ToString();
                    break;
                case "Mod":
                    textBox1.Text = (results % double.Parse(textBox1.Text)).ToString();
                    break;
                case "Exp":
                    double i = Double.Parse(textBox1.Text);
                    double q;
                    q = results;
                    textBox1.Text = Math.Exp(i * Math.Log(q * 4)).ToString();
                    break;
            }
        }


        void checkempty()
        {
            if(textBox1.Text ==String.Empty)
            {

            }
        }
        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = "3,1415926535";
        }

        private void button18_Click(object sender, EventArgs e) //логарифм
        {
            if(textBox1.Text==String.Empty)
            {
                MessageBox.Show("Введите исходные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                double ilog = Double.Parse(textBox1.Text);
                ilog = Math.Log10(ilog);
                textBox1.Text = System.Convert.ToString(ilog);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {
                MessageBox.Show("Введите исходные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                double sqrt = Double.Parse(textBox1.Text);
                sqrt = Math.Sqrt(sqrt);
                textBox1.Text = System.Convert.ToString(sqrt);
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {
                MessageBox.Show("Введите исходные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                double sinh = Double.Parse(textBox1.Text);
                sinh = Math.Sinh(sinh);
                textBox1.Text = System.Convert.ToString(sinh);
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {
                MessageBox.Show("Введите исходные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                double sin = Double.Parse(textBox1.Text);
                sin = Math.Sin(sin);
                textBox1.Text = System.Convert.ToString(sin);
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {
                MessageBox.Show("Введите исходные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                double cosh = Double.Parse(textBox1.Text);
                cosh = Math.Cosh(cosh);
                textBox1.Text = System.Convert.ToString(cosh);
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {
                MessageBox.Show("Введите исходные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                double cos = Double.Parse(textBox1.Text);
                cos = Math.Cos(cos);
                textBox1.Text = System.Convert.ToString(cos);
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {
                MessageBox.Show("Введите исходные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                double tanh = Double.Parse(textBox1.Text);
                tanh = Math.Tanh(tanh);
                textBox1.Text = System.Convert.ToString(tanh);
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {
                MessageBox.Show("Введите исходные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                double tan = Double.Parse(textBox1.Text);
                tan = Math.Tan(tan);
                textBox1.Text = System.Convert.ToString(tan);
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {
                MessageBox.Show("Введите исходные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int a = int.Parse(textBox1.Text);
                textBox1.Text = System.Convert.ToString(a, 2);
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {
                MessageBox.Show("Введите исходные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int a = int.Parse(textBox1.Text);
                textBox1.Text = System.Convert.ToString(a, 16);
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {
                MessageBox.Show("Введите исходные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int a = int.Parse(textBox1.Text);
                textBox1.Text = System.Convert.ToString(a, 8);
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {
                MessageBox.Show("Введите исходные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int a = int.Parse(textBox1.Text);
                textBox1.Text = System.Convert.ToString(a);
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {
                MessageBox.Show("Введите исходные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Double a;
                a = Math.Pow(Convert.ToDouble(textBox1.Text), 2);
                textBox1.Text = System.Convert.ToString(a);
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {
                MessageBox.Show("Введите исходные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Double a;
                a = Math.Pow(Convert.ToDouble(textBox1.Text), 3);
                textBox1.Text = System.Convert.ToString(a);
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {
                MessageBox.Show("Введите исходные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Double a;
                a = Convert.ToDouble(1.0 / Convert.ToDouble(textBox1.Text));
                textBox1.Text = System.Convert.ToString(a);
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {
                MessageBox.Show("Введите исходные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                double log = Double.Parse(textBox1.Text);
                log = Math.Log(log);
                textBox1.Text = System.Convert.ToString(log);
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {
                MessageBox.Show("Введите исходные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Double a;
                a = Convert.ToDouble(textBox1.Text) / Convert.ToDouble(100);
                textBox1.Text = System.Convert.ToString(a);
            }
        }
        int n, m;
        private void button39_Click(object sender, EventArgs e)
        {

            int.TryParse(textBox2.Text, out n);
            dataGridView1.RowCount = n;
            dataGridView1.ColumnCount = n;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dataGridView1.Columns[j].Width = 60;
                }
            }

            int.TryParse(textBox3.Text, out m);
            dataGridView2.RowCount = m;
            dataGridView2.ColumnCount = m;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    dataGridView2.Columns[j].Width = 60;
                }
            }
        }

        private void button40_Click(object sender, EventArgs e)
        {

        }
        void trans()
        {
            if (comboBox1.SelectedIndex == 0)
            {
                try
                {
                    int n;
                    int.TryParse(textBox2.Text, out n);
                    dataGridView3.RowCount = n;
                    dataGridView3.ColumnCount = n;
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            dataGridView3[i, j].Value = dataGridView1[j, i].Value;
                            if (j == n - 1)
                                break;
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Введите матрицу");
                }
            }
            if (comboBox1.SelectedIndex == 1)
            {
                try
                {
                    int n;
                    int.TryParse(textBox3.Text, out n);
                    dataGridView3.RowCount = n;
                    dataGridView3.ColumnCount = n;
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            dataGridView3[i, j].Value = dataGridView2[j, i].Value;
                            if (j == n - 1)
                                break;
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Введите матрицу");
                }
            }
        }



        private void button43_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                int n = dataGridView1.RowCount;
                int m = dataGridView1.ColumnCount;
                int x = int.Parse(textBox4.Text);
                dataGridView3.RowCount = n;
                dataGridView3.ColumnCount = m;
                int[,] a = new int[n, m];
                int[,] c = new int[n, m];
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                        a[i, j] = Convert.ToInt32(dataGridView1[i, j].Value);
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                    {
                        c[i, j] = a[i, j] * x;
                        dataGridView3[i, j].Value = c[i, j];
                    }
            }
            if (comboBox1.SelectedIndex == 1)
            {
                int n = dataGridView2.RowCount;
                int m = dataGridView2.ColumnCount;
                int x = int.Parse(textBox4.Text);
                dataGridView3.RowCount = n;
                dataGridView3.ColumnCount = m;
                int[,] a = new int[n, m];
                int[,] c = new int[n, m];
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                        a[i, j] = Convert.ToInt32(dataGridView2[i, j].Value);
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                    {
                        c[i, j] = a[i, j] * x;
                        dataGridView3[i, j].Value = c[i, j];
                    }
            }
        }




        void addition()
        {
            try
            {
                if (textBox2.Text == textBox3.Text)
                {
                    int n;
                    int.TryParse(textBox2.Text, out n);
                    dataGridView3.RowCount = n;
                    dataGridView3.ColumnCount = n;
                    int[,] a = new int[n, n];
                    int[,] b = new int[n, n];
                    int[,] c = new int[n, n];
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < n; j++)
                            a[i, j] = Convert.ToInt32(dataGridView1[i, j].Value);
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < n; j++)
                            b[i, j] = Convert.ToInt32(dataGridView2[i, j].Value);
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < n; j++)
                        {
                            c[i, j] = a[i, j] + b[i, j];
                            dataGridView3[i, j].Value = c[i, j];
                        }
                }
                else
                    MessageBox.Show("Складывать можно только матрицы одинакового размера");
            }
            catch (Exception)
            {
                MessageBox.Show("Непредвиденная ошибка");
            }
        }


        void subtraction()
        {
            try
            {
                if (textBox2.Text == textBox3.Text)
                {
                    int n;
                    int.TryParse(textBox2.Text, out n);
                    dataGridView3.RowCount = n;
                    dataGridView3.ColumnCount = n;
                    int[,] a = new int[n, n];
                    int[,] b = new int[n, n];
                    int[,] c = new int[n, n];
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < n; j++)
                            a[i, j] = Convert.ToInt32(dataGridView1[i, j].Value);
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < n; j++)
                            b[i, j] = Convert.ToInt32(dataGridView2[i, j].Value);
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < n; j++)
                        {
                            c[i, j] = a[i, j] - b[i, j];
                            dataGridView3[i, j].Value = c[i, j];
                        }
                }
                else
                    MessageBox.Show("Ошибка", "Вычитать можно только матрицы одинакового размера");
            }
            catch (Exception)
            {
                MessageBox.Show("Непредвиденная ошибка");
            }
        }


        void multiplication()
        {
            if (textBox2.Text == textBox3.Text)
            {
                int n, v;
                int.TryParse(textBox2.Text, out n);
                dataGridView3.RowCount = n;
                dataGridView3.ColumnCount = n;
                int[,] a = new int[n, n];
                int[,] b = new int[n, n];
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        a[j, i] = Convert.ToInt32(dataGridView1[i, j].Value);
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        b[j, i] = Convert.ToInt32(dataGridView2[i, j].Value);

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        v = 0;
                        for (int r = 0; r < n; r++)
                            v += a[i, r] * b[r, j];
                        dataGridView3[i, j].Value = v;

                    }
                }
            }

            else
                MessageBox.Show("Ошибка", "Умножать матрицы можно только когда количество столбцов первой матрицы равно количеству строк второй матрицы");
        }

        private void button40_Click_1(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                multiplication();
            }
            if (comboBox2.SelectedIndex == 1)
            {
                addition();
            }
            if (comboBox2.SelectedIndex == 2)
            {
                subtraction();
            }
            if (comboBox2.SelectedIndex == 3)
            {
                trans();
            }


        }

        

        string iOperation = "";


        private int MinValue(int a, int b)
        {
            if (a >= b)
                return b;
            else
                return a;
        }
        private void button42_Click(object sender, EventArgs e)
        {
            double sum = 0;
            int[,] matrix;
            matrix = new int[dataGridView1.RowCount, dataGridView1.ColumnCount];
            for (int row = 0; row < dataGridView1.RowCount; row++)
            {
                for (int col = 0; col < dataGridView1.ColumnCount; col++)
                {
                    matrix[row, col] = int.Parse(dataGridView1.Rows[row].Cells[col].Value.ToString());
                }
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            iOperation = "C";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            iOperation = "F";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            iOperation = "K";
        }

       
        public bool OpenDBFile()//Функция запрашивает путь к файлу БД и осуществляет подключение
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.Filter = "Текстовые файлы (*.db)|*.db|Все файлы(*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                //создание подключения к БД
                SQLiteConn = new SQLiteConnection("Data Source=" + openFileDialog.FileName + ";Version=3;");
                SQLiteConn.Open();
                //canConnect = true;
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = SQLiteConn;
                return true;
            }
            else return false;
        }


        private void button45_Click(object sender, EventArgs e)
        {
            if (flagforcheckBD == false)
            {
                MessageBox.Show("Выполните подключение к базе данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (textBox10.Text == "" || textBox11.Text == "" || textBox12.Text == "" || textBox13.Text == "")
                {
                    MessageBox.Show("Введите исходные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    double test = Math.Cos((Convert.ToDouble(textBox12.Text) * Math.PI) / 180);
                    double deltaX = Convert.ToDouble(textBox13.Text) * Math.Cos((Convert.ToDouble(textBox12.Text) * Math.PI) / 180);
                    double deltaY = Convert.ToDouble(textBox13.Text) * Math.Sin((Convert.ToDouble(textBox12.Text) * Math.PI) / 180);
                    double Xy = Convert.ToDouble(textBox10.Text) + deltaX;
                    double Yy = Convert.ToDouble(textBox11.Text) + deltaY;
                    textBox14.Text = Convert.ToString(Xy);
                    textBox15.Text = Convert.ToString(Yy);
                    string X = Convert.ToString(textBox14.Text);
                    string Y = Convert.ToString(textBox15.Text);
                    string resX = X.Replace(',', '.');
                    string resY = Y.Replace(',', '.');
                    string type = "'Прямая'";
                    string sql = "INSERT INTO [Geodezy] ('КоординатаХа','КоординатаУа','Угол','Расстояние','КоординатаХb','КоординатаYb','Типзадачи') VALUES (" + textBox10.Text + "," + textBox11.Text + "," + textBox12.Text + "," + textBox13.Text + "," + resX + "," + resY + "," + type + ")";
                    SQLiteCommand command2 = new SQLiteCommand(sql, SQLiteConn);
                    command2.ExecuteNonQuery().ToString();
                }
            }
        }

        private void button46_Click(object sender, EventArgs e)
        {
            if (flagforcheckBD == false)
            {
                MessageBox.Show("Выполните подключение к базе данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (textBox16.Text == "" || textBox17.Text == "" || textBox18.Text == "" || textBox19.Text == "")
                {
                    MessageBox.Show("Введите исходные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    double corner = 0;
                    double deltaX = Convert.ToDouble(textBox17.Text) - Convert.ToDouble(textBox19.Text);
                    double deltaY = Convert.ToDouble(textBox16.Text) - Convert.ToDouble(textBox18.Text);
                    double tgr = Math.Abs(deltaY) / Math.Abs(deltaX);
                    double res = Math.Atan(tgr);
                    double res2 = (res * 180) / Math.PI;
                    if (deltaX > 0 && deltaY > 0)
                    {
                        corner = res2;
                    }

                    if (deltaX < 0 && deltaY > 0)
                    {
                        corner = 180 - res2;
                    }

                    if (deltaX < 0 && deltaY < 0)
                    {
                        corner = res2 - 180;
                    }

                    if (deltaX > 0 && deltaY < 0)
                    {
                        corner = 360 - res2;
                    }
                    double S = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
                    textBox21.Text = Convert.ToString(corner);
                    textBox20.Text = Convert.ToString(S);
                    string corner1 = Convert.ToString(textBox21.Text);
                    string S1 = Convert.ToString(textBox20.Text);
                    string rescorner = corner1.Replace(',', '.');
                    string resS = S1.Replace(',', '.');
                    string type = "'Обратная'";
                    string sql = "INSERT INTO [Geodezy] ('КоординатаХа','КоординатаУа','Угол','Расстояние','КоординатаХb','КоординатаYb','Типзадачи') VALUES (" + textBox19.Text + "," + textBox18.Text + "," + rescorner + "," + resS + "," + textBox17.Text + "," + textBox16.Text + "," + type + ")";
                    SQLiteCommand command2 = new SQLiteCommand(sql, SQLiteConn);
                    command2.ExecuteNonQuery().ToString();
                }
            }
        }

        bool flagforcorrect = false;
        void validationofcorrectE(KeyPressEventArgs e, string textbox)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && (ch != ',' || textbox.Contains(",")))
            {
                e.Handled = true;
            }
            if (flagforcorrect == true)
            {
                if (!Char.IsDigit(ch) && ch != 8 && (ch != ' ' || textBox3.Text.Contains("")))
                {
                    e.Handled = true;
                }
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            validationofcorrectE(e, textBox10.Text);
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            validationofcorrectE(e, textBox11.Text);
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            validationofcorrectE(e, textBox12.Text);
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            validationofcorrectE(e, textBox13.Text);
        }

        private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
        {
            validationofcorrectE(e, textBox19.Text);
        }

        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
        {

            validationofcorrectE(e, textBox18.Text);
        }

        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
        {
            validationofcorrectE(e, textBox17.Text);
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            validationofcorrectE(e, textBox16.Text);
        }


        private void textBox22_KeyPress(object sender, KeyPressEventArgs e)
        {
            validationofcorrectE(e, textBox22.Text);
        }

        private void button48_Click(object sender, EventArgs e)
        {
            if (flagforcheckBD == false)
            {
                MessageBox.Show("Выполните подключение к базе данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (textBox22.Text == "" || textBox23.Text == "" || textBox24.Text == "" || textBox25.Text == "" || textBox26.Text == "" || textBox27.Text == "" || textBox29.Text == "" || textBox28.Text == "" || textBox30.Text == "" || textBox31.Text == "")
                {
                    MessageBox.Show("Введите исходные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    double valueB1 = Convert.ToDouble(textBox27.Text) + (Convert.ToDouble(textBox26.Text) / 60) + (Convert.ToDouble(textBox29.Text) / 3600);
                    double valueB2 = Convert.ToDouble(textBox28.Text) + (Convert.ToDouble(textBox31.Text) / 60) + (Convert.ToDouble(textBox30.Text) / 3600);
                    textBox35.Text = Convert.ToString(valueB1);
                    textBox34.Text = Convert.ToString(valueB2);
                    double Yp = ((Convert.ToDouble(textBox23.Text) / Math.Tan((valueB2 * Math.PI) / 180)) + (Convert.ToDouble(textBox24.Text) / Math.Tan((valueB1 * Math.PI) / 180)) + Convert.ToDouble(textBox22.Text) - Convert.ToDouble(textBox25.Text)) / ((1 / Math.Tan((valueB1 * Math.PI) / 180)) + 1 / Math.Tan((valueB2 * Math.PI) / 180));
                    double Xp = ((Convert.ToDouble(textBox22.Text) / Math.Tan((valueB2 * Math.PI) / 180)) + (Convert.ToDouble(textBox25.Text) / Math.Tan((valueB1 * Math.PI) / 180)) - Convert.ToDouble(textBox23.Text) + Convert.ToDouble(textBox24.Text)) / ((1 / Math.Tan((valueB1 * Math.PI) / 180)) + 1 / Math.Tan((valueB2 * Math.PI) / 180));
                    textBox32.Text = Convert.ToString(Xp);
                    textBox33.Text = Convert.ToString(Yp);
                    string x1 = textBox22.Text.Replace(',', '.');
                    string y1 = textBox23.Text.Replace(',', '.');
                    string x2 = textBox25.Text.Replace(',', '.');
                    string y2 = textBox24.Text.Replace(',', '.');
                    string B1 = textBox35.Text.Replace(',', '.');
                    string B2 = textBox34.Text.Replace(',', '.');
                    string rXp = textBox32.Text.Replace(',', '.');
                    string rXy = textBox34.Text.Replace(',', '.');
                    string sql = "INSERT INTO [cornernotch] ('x1','y1','x2','y2','B1','B2','resultXp','resultYp') VALUES (" + x1 + "," + y1 + "," + x2 + "," + y2 + "," + B1 + "," + B2 + "," + rXp + "," + rXy + ")";
                    SQLiteCommand command2 = new SQLiteCommand(sql, SQLiteConn);
                    command2.ExecuteNonQuery().ToString();
                }
            }
        }
        public bool flag = false;
        private void button49_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }

        private void button50_Click(object sender, EventArgs e)
        {
            flag = true;
            Form2 form = new Form2();
            form.Show();


        }

        private void textBox23_KeyPress(object sender, KeyPressEventArgs e)
        {
            validationofcorrectE(e, textBox23.Text);
        }

        private void textBox25_KeyPress(object sender, KeyPressEventArgs e)
        {
            validationofcorrectE(e, textBox25.Text);
        }

        private void textBox24_KeyPress(object sender, KeyPressEventArgs e)
        {
            validationofcorrectE(e, textBox24.Text);
        }

        private void textBox27_KeyPress(object sender, KeyPressEventArgs e)
        {
            validationofcorrectE(e, textBox27.Text);
        }

        private void textBox26_KeyPress(object sender, KeyPressEventArgs e)
        {
            validationofcorrectE(e, textBox26.Text);
        }

        private void textBox29_KeyPress(object sender, KeyPressEventArgs e)
        {
            validationofcorrectE(e, textBox29.Text);
        }

        private void textBox28_KeyPress(object sender, KeyPressEventArgs e)
        {
            validationofcorrectE(e, textBox28.Text);
        }

        private void textBox31_KeyPress(object sender, KeyPressEventArgs e)
        {
            validationofcorrectE(e, textBox31.Text);
        }

        private void textBox30_KeyPress(object sender, KeyPressEventArgs e)
        {
            validationofcorrectE(e, textBox30.Text);
        }
        bool flagforcheckBD = false;

        private void button51_Click(object sender, EventArgs e)
        {
            if (flagforcheckBD == false)
            {
                MessageBox.Show("Выполните подключение к базе данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (textBox36.Text == "" || textBox37.Text == "" || textBox39.Text == "" || textBox38.Text == "" || textBox43.Text == "" || textBox42.Text == "" || textBox44.Text == "")
                {
                    MessageBox.Show("Введите исходные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int onesm = Convert.ToInt32(textBox44.Text);
                    double endresult = (Convert.ToDouble(textBox38.Text) + Convert.ToDouble(textBox43.Text) + Convert.ToDouble(textBox42.Text) + Convert.ToDouble(textBox39.Text)) / 100;
                    double gorizont = Convert.ToDouble(textBox36.Text) - endresult;

                    double longs = gorizont / onesm;
                    textBox40.Text = endresult.ToString();
                    textBox45.Text = gorizont.ToString();
                    textBox46.Text = longs.ToString();
                    string dlina = textBox36.Text.Replace(',', '.');
                    string ugol = textBox37.Text.Replace(',', '.');
                    string thirty = textBox39.Text.Replace(',', '.');
                    string seventy = textBox38.Text.Replace(',', '.');
                    string zerofive = textBox43.Text.Replace(',', '.');
                    string zeroeight = textBox42.Text.Replace(',', '.');
                    string itogom = textBox40.Text.Replace(',', '.');
                    string gorizonte = textBox45.Text.Replace(',', '.');
                    string gorizontecm = textBox46.Text.Replace(',', '.');
                    string sql = "INSERT INTO [gorizont] ('Длина','Угол','Поправки300','70','0.5','0.8','Масштаб1см','Итогом','Горизонтальное проложение','Длинапроложения') VALUES (" + dlina + "," + ugol + "," + thirty + "," + seventy + "," + zerofive + "," + zeroeight + "," + textBox44.Text + "," + itogom + "," + gorizonte + "," + gorizontecm + ")";
                    SQLiteCommand command2 = new SQLiteCommand(sql, SQLiteConn);
                    command2.ExecuteNonQuery().ToString();
                }
            }
        }

        private void textBox41_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox36_KeyPress(object sender, KeyPressEventArgs e)
        {
            validationofcorrectE(e, textBox36.Text);
        }

        private void textBox37_KeyPress(object sender, KeyPressEventArgs e)
        {
            validationofcorrectE(e, textBox37.Text);
        }

        private void textBox39_KeyPress(object sender, KeyPressEventArgs e)
        {
            validationofcorrectE(e, textBox39.Text);
        }

        private void textBox38_KeyPress(object sender, KeyPressEventArgs e)
        {
            validationofcorrectE(e, textBox38.Text);
        }

        private void textBox43_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox43_KeyPress(object sender, KeyPressEventArgs e)
        {
            validationofcorrectE(e, textBox43.Text);
        }

        private void textBox42_KeyPress(object sender, KeyPressEventArgs e)
        {
            validationofcorrectE(e, textBox42.Text);
        }

        private void textBox44_KeyPress(object sender, KeyPressEventArgs e)
        {
            validationofcorrectE(e, textBox44.Text);
        }

        private void button47_Click(object sender, EventArgs e)
        {
            OpenDBFile();
            flagforcheckBD = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            validationofcorrectmatrix(e, textBox2.Text);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            validationofcorrectmatrix(e, textBox3.Text);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            validationofcorrectmatrix(e, textBox4.Text);
        }

        private void button41_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void button42_Click_1(object sender, EventArgs e)
        {
            List<Label> list = new List<Label>();
            list.Add(label11); list.Add(label15); list.Add(label13); list.Add(label16); list.Add(label17); list.Add(label12);
            list.Add(label23); list.Add(label25); list.Add(label24); list.Add(label26); list.Add(label30); list.Add(label27);
            list.Add(label28); list.Add(label31); list.Add(label32); list.Add(label14); list.Add(label34); list.Add(label33);
            list.Add(label3); list.Add(label4); list.Add(label5); list.Add(label6); list.Add(label2); list.Add(label7);

            if (comboBox3.SelectedIndex == 0)
            {
                foreach (var item in list)
                {
                    item.ForeColor = System.Drawing.Color.White;
                }
            }
            if (comboBox3.SelectedIndex == 1)
            {
                foreach (var item in list)
                {
                    item.ForeColor = System.Drawing.Color.Black;
                }
            }
            if (comboBox3.SelectedIndex == 2)
            {
                foreach (var item in list)
                {
                    item.ForeColor = System.Drawing.Color.Red;
                }
            }
            if (comboBox3.SelectedIndex == 3)
            {
                foreach (var item in list)
                {
                    item.ForeColor = System.Drawing.Color.Pink;
                }
            }
            if (comboBox3.SelectedIndex == 4)
            {
                foreach (var item in list)
                {
                    item.ForeColor = System.Drawing.Color.Green;
                }
            }
            if (comboBox3.SelectedIndex == 5)
            {
                foreach (var item in list)
                {
                    item.ForeColor = System.Drawing.Color.Blue;
                }
            }
        }

        private void button44_Click(object sender, EventArgs e)
        {
            if (OpenDBFile() == true)
            {
                GetTableNames();
                comboBox4.Enabled = true;
                //button2.Enabled = true;
            }
        }

        private void button52_Click(object sender, EventArgs e)
        {
            dTable.Clear();
            dTable.Columns.Clear();
            if (comboBox4.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите таблицу!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ShowTable(SQL_AllTable());

            dataGridView4.AllowUserToAddRows = false;
        }

        void validationofcorrectmatrix(KeyPressEventArgs e, string textbox)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && (ch != ' ' || textBox3.Text.Contains("")))
            {
                e.Handled = true;
            }
        }

    }
    }

    