using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Pte_project
{
    public partial class Speaking_Questions : Form
    {
        Pte_connection con = new Pte_connection();

        protected SqlConnection MyConn = new SqlConnection();/* variable declaration for make a connection*/
        protected SqlCommand MyCmd = new SqlCommand();

        byte[] stream1;
        string ext1;
        byte[] stream2;
        string ext2;
        byte[] stream3;
        string ext3;
        int i = 0;
        int ht = 1;
        int ht1 = 1;
        string name;
        public Speaking_Questions()
       {
            InitializeComponent();
        }

        private void Speaking_Questions_Load(object sender, EventArgs e)
        {
            MyConn.ConnectionString = Pte_connection.ConnectionS_tring;
            
            combofill();
           
        }
        private void combofill()
        {
            MyConn.Open();/*open connection by varible*/
            MyCmd = new SqlCommand("SELECT * FROM S_Qtype", MyConn);
            MyCmd.CommandType = CommandType.Text;
            MyCmd.CommandTimeout = 120;
            DataTable vtable = new DataTable();
            vtable.Load(MyCmd.ExecuteReader());
            comboBox1.DisplayMember = "SQTYPE";
            comboBox1.ValueMember = "SQTID";
            comboBox1.DataSource = vtable;
            comboBox1.Enabled = true;
            MyConn.Close();
        }
        public void chk_type()
        {
            if (comboBox1.SelectedIndex != 2)
            {
                textBox7.Enabled = false;
                button3.Enabled = false;

            }
            else
            {
                textBox7.Enabled = true ;
                button3.Enabled = true;
            
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {  // DialogResult result = openFileDialog1.ShowDialog();
           // textBox3.Text = openFileDialog1.FileName.ToString();
            //stream1 =File . ReadAllBytes(textBox3 .Text );
           // com.Parameters.AddWithValue("@voice", stream);
            //ext1 = Path.GetExtension(textBox3 .Text );




            DialogResult result = openFileDialog1.ShowDialog();
            textBox3.Text = openFileDialog1.FileName.ToString();
            ext1 = Path.GetExtension(textBox3.Text);
            if (ext1 == ".mp3" || ext1 == ".wav")
            {
                stream1 = File.ReadAllBytes(textBox3.Text);
                // com.Parameters.AddWithValue("@voice", stream);

            }
            else
            {
                MessageBox.Show("Please upload file in mp3 or wav format");
                textBox3.Text = "";

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
           // DialogResult result = openFileDialog1.ShowDialog();
            //textBox6.Text = openFileDialog1.FileName.ToString();
            //stream2 = File.ReadAllBytes(textBox6.Text);
            // com.Parameters.AddWithValue("@voice", stream);
           // ext2 = Path.GetExtension(textBox6.Text);



            DialogResult result = openFileDialog1.ShowDialog();
            textBox6.Text = openFileDialog1.FileName.ToString();
            ext2 = Path.GetExtension(textBox6.Text);
            if (ext2 == ".mp3" || ext1 == ".wav")
            {
                stream2 = File.ReadAllBytes(textBox6.Text);
                // com.Parameters.AddWithValue("@voice", stream);

            }
            else
            {
                MessageBox.Show("Please upload file in mp3 or wav format");
                textBox6.Text = "";

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // DialogResult result = openFileDialog1.ShowDialog();
           // textBox7.Text = openFileDialog1.FileName.ToString();
            //stream3 = File.ReadAllBytes(textBox7.Text);
            // com.Parameters.AddWithValue("@voice", stream);
         //   ext3 = Path.GetExtension(textBox7.Text);



            DialogResult result = openFileDialog1.ShowDialog();
            textBox7.Text = openFileDialog1.FileName.ToString();
            ext3 = Path.GetExtension(textBox7.Text);
            if (ext3 == ".jpg" || ext1 == ".jpeg" || ext1 == ".png" || ext1 == ".pdf")
            {
                stream3 = File.ReadAllBytes(textBox6.Text);
                // com.Parameters.AddWithValue("@voice", stream);

            }
            else
            {
                MessageBox.Show("Please upload file in png or jpg or pdf format");
                textBox7.Text = "";

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            MyConn.Open();/*open connection by varible*/


            MyCmd = new SqlCommand("SP_SPEAKING_QUESTIONS", MyConn);/*fire insert query by using connection*/
            MyCmd.CommandType = CommandType.StoredProcedure;/* which type of  query you passed in above line we write text because we write direct query like */
            MyCmd.CommandTimeout = 120;/*connection time out after secs*/

           

            MyCmd.Parameters.AddWithValue("@SQID", 0);
            MyCmd.Parameters.AddWithValue("@SQTID", comboBox1.SelectedValue);
            MyCmd.Parameters.AddWithValue("@QTEXT", textBox2.Text);
            MyCmd.Parameters.AddWithValue("@QFILE ", stream1);
            MyCmd.Parameters.AddWithValue("@EXPLANATION", textBox1.Text);
            MyCmd.Parameters.AddWithValue("@QIMAGE", stream3 );
            MyCmd.Parameters.AddWithValue("@WAITINGTIME", textBox4.Text);
            MyCmd.Parameters.AddWithValue("@RESPONSETIME", textBox5.Text);
            MyCmd.Parameters.AddWithValue("@CORR_ANS ", stream2);
            MyCmd.Parameters.AddWithValue("@FextQFILE", ext1);
            MyCmd.Parameters.AddWithValue("@FextQIMAGE",ext3 );
            MyCmd.Parameters.AddWithValue("@FextCORR_ANS",ext2);
            MyCmd.Parameters.AddWithValue("@Isactive", "1");
            MyCmd.Parameters.AddWithValue("@Type", "Insert");

            MyCmd.ExecuteNonQuery();
            MyConn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            chk_type();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
            textBox6.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
        

    }
}
