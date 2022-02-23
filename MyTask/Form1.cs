using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string login;
        private void button1_Click(object sender, EventArgs e)
        {
            login = textBox1.Text;
            string password = textBox2.Text;
            string path = $"User/{login}.txt";
            FileInfo fileInf = new FileInfo(path);
            if (checkBox1.Checked)
            {
                if (fileInf.Exists)
                {
                    MessageBox.Show("Пользователь уже существует");
                }
                else
                {
                    File.AppendAllText(path, password);
                    BinaryFormatter binFormat = new BinaryFormatter();
                    using (Stream fStream = new FileStream($"Tasks/{login}.dat",
                       FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        binFormat.Serialize(fStream, new MyTask());
                    }
                    MessageBox.Show("Пользователь создан");
                }
            }
            else
            {
                if (fileInf.Exists)
                {
                    string test_password = File.ReadAllText(path);
                    if(test_password == password)
                    {
                        MessageBox.Show("Авторизация успешна");
                        Form2 frm = new Form2();
                        frm.Owner = this; //Передаём вновь созданной форме её владельца.
                        frm.Show();
                    }
                    else MessageBox.Show("Пароль не верен");
                }
                else MessageBox.Show("Пользователь не существует");
            }  
        }
    }
}
