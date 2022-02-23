using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace MyTask
{
    public partial class Form2 : Form
    {
        public Form2()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            main.to_make.Add(new Task(login, textBox1.Text));
            refresh();
        }

        MyTask main;
        string login;

        public void refresh()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            foreach (var item in main.to_make)
            {
                listBox1.Items.Add(item);
            }
            foreach (var item in main.in_process)
            {
                listBox2.Items.Add(item);
            }

            foreach (var item in main.finished)
            {
                listBox3.Items.Add(item);
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form1 frm = (Form1)this.Owner;
            login = frm.login;
            this.Text = login;
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream stream = new FileStream($"Tasks/{login}.dat", FileMode.Open))
            {
                main = (MyTask)binFormat.Deserialize(stream);
            }
            refresh();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream($"Tasks/{login}.dat",
                       FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, main);
            }
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                main.goIn_Process(listBox1.SelectedIndex);
                refresh();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0)
            {
                main.goFinished(listBox2.SelectedIndex);
                refresh();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0)
            {
                main.backTo_make(listBox2.SelectedIndex);
                refresh();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex >= 0)
            {
                main.backIn_process(listBox3.SelectedIndex);
                refresh();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex >= 0)
            {
                main.Done(listBox3.SelectedIndex);
                refresh();
            }
        }
    }
}
