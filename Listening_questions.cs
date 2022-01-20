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
    public partial class Listening_questions : Form
    {

        Pte_connection con = new Pte_connection();

        protected SqlConnection MyConn = new SqlConnection();/* variable declaration for make a connection*/
        protected SqlCommand MyCmd = new SqlCommand();
        byte[] stream;
        string ext;
        string ext1;
        int i = 0;
        int ht = 1;
        int ht1 =1;
        string name;

        public Listening_questions()
        {           
            InitializeComponent();
        }
        private void Listening_questions_Load(object sender, EventArgs e)
        {
            MyConn.ConnectionString = Pte_connection.ConnectionS_tring;
          
           // comboBox2.Text ="Choose File Type";
            combofill();
            panel4.Visible = false;
            panel2.Visible = false;
           // panel3.Visible = false;
            
        }
        private void combofill()
        {
            MyConn.Open();/*open connection by varible*/

            MyCmd = new SqlCommand("SELECT * FROM LISTENING_Qtype", MyConn);
            MyCmd.CommandType = CommandType.Text;
            MyCmd.CommandTimeout = 120;

            DataTable vtable = new DataTable();

            vtable.Load(MyCmd.ExecuteReader());


            comboBox1.DisplayMember = "LQTYPE";
            comboBox1.ValueMember = "LQTID";
            comboBox1.DataSource = vtable;

            comboBox1.Enabled = true;
            MyConn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName.ToString();
            ext = Path.GetExtension(textBox1.Text);
            if (ext == ".mp3" || ext == ".wav")
            {
                stream = File.ReadAllBytes(textBox1.Text);
                // com.Parameters.AddWithValue("@voice", stream);
               
            }
            else
            {
                MessageBox.Show("Please upload file in mp3 or wav format");
                textBox1.Text = "";
               
            }

          
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 7) // for summarize spoken test// for dictation 
            {
                MessageBox.Show("Thank You Your question saved successfully");
            }
            else
            {
                panel4.Visible = true;
                panel4.BringToFront();
                panel4.Location = new Point(12, 12);
                panel4.Size = new Size(1177, 570);
                label8.Text = comboBox1.Text;
                label9.Text = tb_que.Text;

            }

            MyConn.Open();/*open connection by varible*/


            MyCmd = new SqlCommand("SP_LISTENING_QUESTIONS", MyConn);/*fire insert query by using connection*/
            MyCmd.CommandType = CommandType.StoredProcedure;/* which type of  query you passed in above line we write text because we write direct query like */
            MyCmd.CommandTimeout = 120;/*connection time out after secs*/


            MyCmd.Parameters.AddWithValue("@LQID", 0);
            MyCmd.Parameters.AddWithValue("@LQTID", comboBox1.SelectedValue);
            MyCmd.Parameters.AddWithValue("@QTEXT", tb_que.Text);
            MyCmd.Parameters.AddWithValue("@QFILE ", stream);
            MyCmd.Parameters.AddWithValue("@QFTYPE", ext);
            MyCmd.Parameters.AddWithValue("@EXPLANATION", textBox3.Text);
            MyCmd.Parameters.AddWithValue("@CORRANS", "");
            MyCmd.Parameters.AddWithValue("@ISACTIVE", "1");
            MyCmd.Parameters.AddWithValue("@Type", "Insert");
            DataTable dt = new DataTable();
            dt.Load(MyCmd.ExecuteReader());/*what you expect in return*/
            foreach (DataRow read in dt.Rows)
            {


                label6.Text = read["LQID"].ToString();


            }



            MyConn.Close();

            MessageBox.Show("Record Added Successfully, Now you Have to write answer options for the question");

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
            dataGridView1.Rows[i].Cells[0].Value = tb_answer_options.Text;
            tb_answer_options.Text = "";
            i++;
          
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            dataGridView1.Rows.Remove(row);
            i = i - 1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
        private void button5_Click(object sender, EventArgs e)
        {
            MyConn.Open();/*open connection by varible*/

            for (i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                MyCmd = new SqlCommand("SP_L_ANS_OPTIONS", MyConn);/*fire insert query by using connection*/
                MyCmd.CommandType = CommandType.StoredProcedure;/* which type of  query you passed in above line we write text because we write direct query like */
                MyCmd.CommandTimeout = 120;/*connection time out after secs*/


                MyCmd.Parameters.AddWithValue("@LANSOPID", 0);
                MyCmd.Parameters.AddWithValue("@LQID", label6.Text);
                MyCmd.Parameters.AddWithValue("@ANSOPTIONS", dataGridView1.Rows[i].Cells[0].Value);
                MyCmd.Parameters.AddWithValue("@EXPLANATION", "");
                MyCmd.Parameters.AddWithValue("@ISACTIVE", 1);
                MyCmd.Parameters.AddWithValue("@Type", "Insert");
                DataTable dt1 = new DataTable();
                dt1.Load(MyCmd.ExecuteReader());/*what you expect in return*/
                foreach (DataRow read in dt1.Rows)
                {


                    dataGridView1.Rows[i].Cells[1].Value = read["LANSOPID"].ToString();


                }
            }
            MyConn.Close();
           
                panel4.Visible = false;
                panel2.Visible = true;
                panel2.BringToFront();
                panel2.Location = new Point(12, 12);
                panel2.Size = new Size(1177, 570);
                add_radio_ckbox();
          

        }

         private void LB_Click(object sender, EventArgs e)
        {
           Label clickedLabel = sender as Label;

           clickedLabel.BackColor = Color.Yellow;
           }

         public void add_radio_ckbox()
         {
             if (comboBox1.SelectedIndex == 1)//for multi choice multi answer
             {
                 for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                 {
                     CheckBox CB = new CheckBox();
                     CB.Name = dataGridView1.Rows[i].Cells[1].Value.ToString();
                     CB.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                     CB.Location = new Point(200, 10 * i);
                     groupBox1.Controls.Add(CB);
                 }

             }

             if (comboBox1.SelectedIndex == 3)//highlight correct summary
             {

                 for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                 {
                     RadioButton RB = new RadioButton();
                     RB.Name = dataGridView1.Rows[i].Cells[1].Value.ToString();
                     RB.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                     RB.Location = new Point(200, 10 * i);
                     groupBox1.Controls.Add(RB);
                 }

             }
             if (comboBox1.SelectedIndex == 2) //for text boxes
             {

                 for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                 {
                     Label LB = new Label();
                     LB.Name = dataGridView1.Rows[i].Cells[1].Value.ToString();
                     LB.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                     LB.Location = new Point(0, ht1 + 10);
                     //LB.MaximumSize = new Size(800,500);
                     //LB.CanSelect = true;
                     LB.Width = 200;
                     LB.AutoSize = true;

                     LB.MaximumSize = new Size(200, 0);

                     LB.Click += new System.EventHandler(this.LB_Click);



                     // LB.BorderStyle = BorderStyle.FixedSingle;
                     LB.Visible = true;
                     // LB.BackColor = Color.Yellow ;
                     LB.Show();
                     LB.Enabled = true;
                     LB.BringToFront();

                     groupBox1.Controls.Add(LB);
                     ht1 = ht1 + LB.Height;

                     //Item obj = new Item();
                     //obj.strText = dataGridView1.Rows[i].Cells[0].Value.ToString(); ;
                     //obj.strValue = dataGridView1.Rows[i].Cells[1].Value.ToString(); ;
                     //listBox1.Items.Add(obj);
                     //listBox1.Enabled = true;
                     //listBox1.BringToFront();
                     //listBox2.Enabled = true;
                     //listBox2.BringToFront();

                 }
             }
             if (comboBox1.SelectedIndex == 4) // for multichoice single answer
             {
                 for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                 {
                     RadioButton RB = new RadioButton();
                     RB.Name = dataGridView1.Rows[i].Cells[1].Value.ToString();
                     RB.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                     RB.Location = new Point(200, 10 * i);
                     groupBox1.Controls.Add(RB);
                 }

             }
             if (comboBox1.SelectedIndex == 5) // for select missing word
             {
                 for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                 {
                     RadioButton RB = new RadioButton();
                     RB.Name = dataGridView1.Rows[i].Cells[1].Value.ToString();
                     RB.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                     RB.Location = new Point(200, 10 * i);
                     groupBox1.Controls.Add(RB);
                 }

             }
             if (comboBox1.SelectedIndex == 6) //for highlight incorrect words
             {

                 for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                 {
                     Label LB = new Label();
                     LB.Name = dataGridView1.Rows[i].Cells[1].Value.ToString();
                     LB.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                     LB.Location = new Point(0, ht1 + 10);
                     //LB.MaximumSize = new Size(800,500);
                     //LB.CanSelect = true;
                     LB.Width = 200;
                     LB.AutoSize = true;

                     LB.MaximumSize = new Size(200, 0);

                     LB.Click += new System.EventHandler(this.LB_Click);



                     // LB.BorderStyle = BorderStyle.FixedSingle;
                     LB.Visible = true;
                     // LB.BackColor = Color.Yellow ;
                     LB.Show();
                     LB.Enabled = true;
                     LB.BringToFront();

                     groupBox1.Controls.Add(LB);
                     ht1 = ht1 + LB.Height;

                     //Item obj = new Item();
                     //obj.strText = dataGridView1.Rows[i].Cells[0].Value.ToString(); ;
                     //obj.strValue = dataGridView1.Rows[i].Cells[1].Value.ToString(); ;
                     //listBox1.Items.Add(obj);
                     //listBox1.Enabled = true;
                     //listBox1.BringToFront();
                     //listBox2.Enabled = true;
                     //listBox2.BringToFront();

                 }



             }
         }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.ScrollBars = ScrollBars.Both;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 3)
            {
                var radioButtons = groupBox1.Controls.OfType<RadioButton>();
                foreach (RadioButton RB in radioButtons)
                {
                    if (RB.Checked == true)
                    {
                        name = RB.Name;
                    }
                }
            }
            if (comboBox1.SelectedIndex == 1)
            {
                var checkboxes = groupBox1.Controls.OfType<CheckBox>();
                foreach (CheckBox CB in checkboxes)
                {

                    if (CB.Checked == true)
                    {
                        name = name + ',' + CB.Name;

                    }
                }


                name = name.Remove(0, 1);

            }
            if (comboBox1.SelectedIndex == 2)
            {
                //foreach (Item  drv in listBox2.Items)
                //{
                //    name  = drv.[listBox2.ValueMember].ToString();
                //    //if you want to store all the idexes from your listbox, put them into an array 

                //}

                //for (int i = 0; i < listBox2.Items.Count; i++)
                //{
                //    listBox2.SetSelected(i, true);
                //    id = listBox2.SelectedValue.ToString();
                //}
                //name = Convert.ToString(id); 




                //listBox2.SelectionMode = SelectionMode.MultiExtended; 
                //for (int i = 1; i < listBox2.Items.Count; i++)
                //{
                //      listBox1.SetSelected(i, true);
                //      name = listBox1.SelectedItem.ToString();

                //}

                var Labels = groupBox1 .Controls.OfType<Label>();
                foreach (Label LB in Labels)
                {


                    name = name + ',' + LB.Name;


                }


                name = name.Remove(0, 1);

            }
            if (comboBox1.SelectedIndex == 4)
            {
                var radioButtons = groupBox1.Controls.OfType<RadioButton>();
                foreach (RadioButton RB in radioButtons)
                {
                    if (RB.Checked == true)
                    {
                        name = RB.Name;
                    }
                }
            }
            if (comboBox1.SelectedIndex == 5)
            {
                var radioButtons = groupBox1.Controls.OfType<RadioButton>();
                foreach (RadioButton RB in radioButtons)
                {
                    if (RB.Checked == true)
                    {
                        name = RB.Name;
                    }
                }
            }
            if (comboBox1.SelectedIndex == 6)//for highlight incorrct words
            {
              
                var Labels = groupBox1.Controls.OfType<Label>();
                foreach (Label LB in Labels)
                {


                    name = name + ',' + LB.Name;


                }


                name = name.Remove(0, 1);

            }
            MyConn.Open();/*open connection by varible*/

            MyCmd = new SqlCommand("SP_LISTENING_QUESTIONS", MyConn);/*fire insert query by using connection*/
            MyCmd.CommandType = CommandType.StoredProcedure;/* which type of  query you passed in above line we write text because we write direct query like */
            MyCmd.CommandTimeout = 120;/*connection time out after secs*/

            MyCmd.Parameters.AddWithValue("@LQID", label6.Text);
            MyCmd.Parameters.AddWithValue("@LQTID", comboBox1.SelectedValue);
            MyCmd.Parameters.AddWithValue("@QTEXT", tb_que.Text);
            MyCmd.Parameters.AddWithValue("@QFILE ", stream);
            MyCmd.Parameters.AddWithValue("@QFTYPE", ext);
            MyCmd.Parameters.AddWithValue("@EXPLANATION", textBox3.Text);
            MyCmd.Parameters.AddWithValue("@CORRANS", name);
            MyCmd.Parameters.AddWithValue("@ISACTIVE", "1");
            MyCmd.Parameters.AddWithValue("@Type", "Update");
            MyCmd.ExecuteNonQuery();
             MyConn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tb_que.Text = "";
            textBox3.Text = "";
            textBox1.Text = "";
        }

      

        

        

        
      


        
        
       

    }
}
