using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace English_World
{
    public partial class Form1 : Form
    {
        //veri tabanı yoluna bağlandık. 
        OleDbConnection Connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:Data.accdb");//bağlantı noktası 
        ListViewItem Add = new ListViewItem();
        OleDbCommand command = new OleDbCommand();

        int b = 0;
        private void Data_Read()// veri okuma 
        {
            //veri tabanı yoluna açıyoruz
            Connection.Open();
            command.Connection = Connection;
            //veri tabanı yolundan Data sayfasından verileri almak istediğimizi belitliyoruz
            command.CommandText = ("Select * From Data");
            OleDbDataReader read = command.ExecuteReader();

            int a = 0;

            while (read.Read())//oku yor ise while çalışıyor
            {
                a = a + 1;

                label4.Text = Convert.ToString(a);

                Add.Text = read["İngilizce"].ToString();
                Add.SubItems.Add(read["Türkçe"].ToString());

                listView1.Items.Add(Add);
            }

            Connection.Close();//bağlantı kesiliyor
        }
   
        private void Data_write()// veri yazma
        {
            try
            {
                Connection.Open();
                OleDbCommand command = new OleDbCommand("INSERT INTO Data (Türkçe,İngilizce) Values('" + textBox1.Text + "','" + textBox2.Text + "')", Connection);
                command.ExecuteNonQuery();
                Connection.Close();
            }
            catch
            {
                MessageBox.Show(" Aynı kelimeyi ekleyemessiniz ");
                Connection.Close();
            }
        }

        private void Data_remove()//veri kaldırma 
        {
            try
            {
                Connection.Open();
                OleDbCommand command = new OleDbCommand("DELETE FROM Data where Türkçe = '" + textBox1.Text + "'", Connection);
                command.ExecuteNonQuery();
                Connection.Close();
            }
            catch
            {
                Connection.Close();
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            b = b + 1; 

            listBox1.Items.Add(textBox1.Text);
            listBox1.Items.Add(textBox2.Text);
            listView1.Items.Clear();

            Data_write();
           
            if (b != 0) { button2.Enabled = true; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            b = b + 1;

            listBox1.Items.Clear();
            listView1.Items.Clear();

            if (b == 0) { button2.Enabled = false; }
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
      
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void button3_Click(object sender, EventArgs e)//kaldırma
        {
            try
            {
                listView1.Items.Clear();
                Data_remove();
            }
            catch
            {
                Connection.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                listView1.Items.Clear();
                Data_Read();
            }
            catch
            {
                Connection.Close();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();
                String Word = textBox3.Text;
                char Letter = Convert.ToChar(Word.Substring(0, 1));

                Connection.Open();
                command.Connection = Connection;
                command.CommandText = ("SELECT * FROM DATA");

                OleDbDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    String Turkey_word = read["Türkçe"].ToString();
                    String Ingle_word = read["İngilizce"].ToString();

                    char word_one = Convert.ToChar(Turkey_word.Substring(0, 1));
                    char word_two = Convert.ToChar(Ingle_word.Substring(0,1));

                    if (word_one == Letter) { listBox1.Items.Add(Turkey_word + "      " + Ingle_word); }
                    if (word_two == Letter) { listBox1.Items.Add(Turkey_word + "     " + Ingle_word); }
                }

                Connection.Close();
            }
            catch
            {
                Connection.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add("ömer");// combox ekleme yapma 
        }
    }
}
