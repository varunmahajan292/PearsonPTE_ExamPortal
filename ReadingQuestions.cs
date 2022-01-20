using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Pte_project
{
    public partial class ReadingQuestions : Form
    {
        Pte_connection con = new Pte_connection();

        protected SqlConnection MyConn = new SqlConnection();/* variable declaration for make a connection*/
        protected SqlCommand MyCmd = new SqlCommand();
        int i = 0;
        int y = 0;
        int x = 0;
        int ht1 = 1;
        int ht2 = 1;
        int x1 = 0;
        int y1 = 0;
        int ht = 1;
        string storage_text, storage_acc_name, a, b, c, d;
        int storage_tab_index;

        string name;
        string id;
        public ReadingQuestions()
        {
            InitializeComponent();
        }

        private void ReadingQuestions_Load(object sender, EventArgs e)
        {
            MyConn.ConnectionString = Pte_connection.ConnectionS_tring;
            panel4.Visible = false;
            panel2.Visible = false;
            combofill();

            button4.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            //  listBox1.Enabled = false;
            //listBox2.Enabled = false;
            PN1.Visible = false;
            PN2.Visible = false;
        }

        private void combofill()
        {
            MyConn.Open();/*open connection by varible*/

            MyCmd = new SqlCommand("SELECT * FROM ReadingQuestionTypes", MyConn);
            MyCmd.CommandType = CommandType.Text;
            MyCmd.CommandTimeout = 120;

            DataTable vtable = new DataTable();

            vtable.Load(MyCmd.ExecuteReader());


            comboBox1.DisplayMember = "QTYPE";
            comboBox1.ValueMember = "RQTID";
            comboBox1.DataSource = vtable;

            comboBox1.Enabled = true;
            MyConn.Close();
        }


        public class Item
        {
            public string strText;
            public string strValue;
            public override string ToString()
            {
                return strText;

            }


        }

        private void LB_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;
            if (PN1.HasChildren)
            {
                // Recursively call this method for each child control.
                foreach (Control childControl in PN1.Controls)
                {
                    //  ResetAllControlsBackColor(childControl);
                    childControl.BackColor = Color.White;
                }
                clickedLabel.BackColor = Color.Blue;
            }



            if (PN2.HasChildren)
            {
                // Recursively call this method for each child control.
                foreach (Control childControl in PN2.Controls)
                {
                    //  ResetAllControlsBackColor(childControl);
                    childControl.BackColor = Color.White;
                }
                clickedLabel.BackColor = Color.Blue;
            }




            //if (clickedLabel != null)
            //{

            //    if (clickedLabel.ForeColor == Color.Black)
            //        return;

            //    clickedLabel.ForeColor = Color.Black;

            //    //Dynamic Lables Click Function
            //}




        }
        private void button5_Click(object sender, EventArgs e)
        {
            MyConn.Open();/*open connection by varible*/

            for (i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                MyCmd = new SqlCommand("SP_ReadingAnswerOptions", MyConn);/*fire insert query by using connection*/
                MyCmd.CommandType = CommandType.StoredProcedure;/* which type of  query you passed in above line we write text because we write direct query like */
                MyCmd.CommandTimeout = 120;/*connection time out after secs*/


                MyCmd.Parameters.AddWithValue("@RAQID", 0);
                MyCmd.Parameters.AddWithValue("@RQTID", comboBox1.SelectedValue);
                MyCmd.Parameters.AddWithValue("@RQID", label2.Text);
                MyCmd.Parameters.AddWithValue("@OPTIONNO", "");
                MyCmd.Parameters.AddWithValue("@ANSWEROPTION", dataGridView1.Rows[i].Cells[0].Value);
                MyCmd.Parameters.AddWithValue("@ISACTIVE", "1");
                MyCmd.Parameters.AddWithValue("@Type", "Insert");
                DataTable dt1 = new DataTable();
                dt1.Load(MyCmd.ExecuteReader());/*what you expect in return*/
                foreach (DataRow read in dt1.Rows)
                {


                    dataGridView1.Rows[i].Cells[1].Value = read["RAQID"].ToString();


                }
            }
            MyConn.Close();
            panel4.Visible = false;
            panel2.Visible = true;
            panel2.BringToFront();
            panel2.Location = new Point(12, 12);
            panel2.Size = new Size(1139, 603);
            add_radio_ckbox();

        }

        private void add_radio_ckbox()
        {
            if (comboBox1.SelectedIndex == 0)
            {
                for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                {
                    RadioButton RB = new RadioButton();
                    RB.Name = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    RB.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    RB.Location = new Point(200, 50 * i);
                    groupBox1.Controls.Add(RB);
                }
            }

            if (comboBox1.SelectedIndex == 1)
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
            if (comboBox1.SelectedIndex == 2)
            {
                groupBox1.Visible = false;
                //listBox1.Visible = true;
                //listBox1 .Location =new Point (12,6);
                //listBox1 .Size =new Size(205,316);
                //listBox2.Visible = true;
                //listBox2.Location = new Point(498, 0);
                //listBox2.Size = new Size(205, 316);
                PN1.Visible = true;
                PN1.Location = new Point(12, 6);
                PN1.Size = new Size(395, 463);
                PN2.Visible = true;
                PN2.Location = new Point(498, 0);
                PN2.Size = new Size(395, 463);
                PN1.Enabled = true;
                PN1.BringToFront();
                PN2.Enabled = true;
                PN2.BringToFront();

                button4.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                P_btn1.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
                P_btn2.Text = dataGridView1.Rows[1].Cells[0].Value.ToString();
                P_btn3.Text = dataGridView1.Rows[2].Cells[0].Value.ToString();
                P_btn4.Text = dataGridView1.Rows[3].Cells[0].Value.ToString();
                P_btn5.Text = dataGridView1.Rows[4].Cells[0].Value.ToString();
                P_btn1.AccessibleName  = dataGridView1.Rows[0].Cells[1].Value.ToString();
                P_btn2.AccessibleName = dataGridView1.Rows[1].Cells[1].Value.ToString();
                P_btn3.AccessibleName = dataGridView1.Rows[2].Cells[1].Value.ToString();
                P_btn4.AccessibleName = dataGridView1.Rows[3].Cells[1].Value.ToString();
                P_btn5.AccessibleName = dataGridView1.Rows[4].Cells[1].Value.ToString();
               

                //for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                //{

                //        // Label LB = new Label();
                //   // LB.Name = dataGridView1.Rows[i].Cells[1].Value.ToString();
                //   // LB.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                //   // LB.Location = new Point(0, ht+10);
                //   // //LB.MaximumSize = new Size(800,500);
                //   // //LB.CanSelect = true;
                //   // LB.Width= 200;
                //   // LB.AutoSize =true;

                //   // LB.MaximumSize =new Size  (200,0);

                //   // LB.Click += new System.EventHandler(this.LB_Click);



                //   // LB.BorderStyle = BorderStyle.FixedSingle;
                //   // LB.Visible = true;
                //   //// LB.BackColor = Color.Yellow ;
                //   // LB.Show();
                //   // LB.Enabled = true;
                //   // LB.BringToFront();

                //   // PN1 .Controls.Add(LB);
                //   // ht=ht+LB.Height;

                //   // //Item obj = new Item();
                //   // //obj.strText = dataGridView1.Rows[i].Cells[0].Value.ToString(); ;
                //   // //obj.strValue = dataGridView1.Rows[i].Cells[1].Value.ToString(); ;
                //   // //listBox1.Items.Add(obj);
                //   // //listBox1.Enabled = true;
                //   // //listBox1.BringToFront();
                //   // //listBox2.Enabled = true;
                //   // //listBox2.BringToFront();

                //}

            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel4.BringToFront();
            panel4.Location = new Point(12, 12);
            panel4.Size = new Size(1267, 603);
            label6.Text = comboBox1.Text;
            label4.Text = tb_ques.Text;
            MyConn.Open();/*open connection by varible*/


            MyCmd = new SqlCommand("SP_READINGQUESTIONS", MyConn);/*fire insert query by using connection*/
            MyCmd.CommandType = CommandType.StoredProcedure;/* which type of  query you passed in above line we write text because we write direct query like */
            MyCmd.CommandTimeout = 120;/*connection time out after secs*/


            MyCmd.Parameters.AddWithValue("@RQID", 0);
            MyCmd.Parameters.AddWithValue("@RQTID", comboBox1.SelectedValue);
            MyCmd.Parameters.AddWithValue("@QUESTION", tb_ques.Text);
            MyCmd.Parameters.AddWithValue("@CORRANSIDS", "");
            MyCmd.Parameters.AddWithValue("@EXPLANATION", tb_expla.Text);
            MyCmd.Parameters.AddWithValue("@ISACTIVE", "1");
            MyCmd.Parameters.AddWithValue("@Type", "Insert");
            DataTable dt = new DataTable();
            dt.Load(MyCmd.ExecuteReader());/*what you expect in return*/
            foreach (DataRow read in dt.Rows)
            {


                label2.Text = read["RQID"].ToString();


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

        public void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
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

                var Buttons = PN2.Controls.OfType<Button >();
                foreach (Button B in Buttons )
                {


                    name = name + ',' + B.AccessibleName ;


                }


                name = name.Remove(0, 1);

            }
            MyConn.Open();/*open connection by varible*/

            MyCmd = new SqlCommand("SP_READINGQUESTIONS", MyConn);/*fire insert query by using connection*/
            MyCmd.CommandType = CommandType.StoredProcedure;/* which type of  query you passed in above line we write text because we write direct query like */
            MyCmd.CommandTimeout = 120;/*connection time out after secs*/
            MyCmd.Parameters.AddWithValue("@RQID", label2.Text);
            MyCmd.Parameters.AddWithValue("@RQTID", comboBox1.SelectedValue);
            MyCmd.Parameters.AddWithValue("@QUESTION", tb_ques.Text);
            MyCmd.Parameters.AddWithValue("@CORRANSIDS", name);
            MyCmd.Parameters.AddWithValue("@EXPLANATION", tb_expla.Text);
            MyCmd.Parameters.AddWithValue("@ISACTIVE", "1");
            MyCmd.Parameters.AddWithValue("@Type", "Update");
            MyCmd.ExecuteNonQuery();
            MyConn.Close();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            dataGridView1.Rows.Remove(row);
            i = i - 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ////if (listBox1.SelectedItem != null)
            ////{


            ////    Item obj1 = new Item();
            ////    obj1.strText = listBox1.SelectedItem.ToString();
            ////    obj1.strValue = listBox1.SelectedValue.ToString();
            ////    listBox2.Items.Add(obj1);
            ////    //listBox2.Items.Add(listBox1.SelectedItem);
            ////    //listBox1.Items.Remove(listBox1.SelectedItem);
            ////}
            ////else
            ////{
            ////    MessageBox.Show("No item selected");
            ////}
            ////foreach (Control p in PN2.Controls)
            ////    if (p.GetType() != typeof(Label))
            ////    {
            ////        ht1 = 1;
            ////    }
            //if (PN2.HasChildren ==false)
            //{
            //    ht1 = 1;
            //}


            //if (PN1.HasChildren)
            //{

            //    foreach (Control childControl in PN1.Controls)
            //    { 

            //       if( childControl.BackColor == Color.Blue)
            //       {



            //          // childControl.Parent = PN2;
            //           childControl.BackColor = Color.White;
            //         //  childControl.Location = new Point(x, y);
            //          // LB.Name = dataGridView1.Rows[i].Cells[1].Value.ToString();
            //          // LB.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            //           childControl.Location = new Point(0, ht1 + 10);
            //           //LB.MaximumSize = new Size(800,500);
            //           //LB.CanSelect = true;
            //           childControl.Width = 200;
            //           childControl.AutoSize = true;

            //           childControl.MaximumSize = new Size(200, 0);

            //           childControl.Click += new System.EventHandler(this.LB_Click);



            //          // childControl.BorderStyle = BorderStyle.FixedSingle;
            //           childControl.Visible = true;
            //           // LB.BackColor = Color.Yellow ;
            //           childControl.Show();
            //           childControl.Enabled = true;
            //           childControl.BringToFront();

            //           PN2.Controls.Add(childControl);
            //           ht1 = ht1 + childControl.Height;



            //             //g = (childControl .Name );
            //       }
            //    }
            //}





        }

        private void button6_Click(object sender, EventArgs e)
        {
            ////foreach (Control p in PN1.Controls)
            ////    if (p.GetType() != typeof(Label ))
            ////    {
            ////        ht2 = 1;
            ////    }
            //if (PN1.HasChildren == false)
            //{
            //    ht2 = 1;
            //}
            //if (PN2.HasChildren)
            //{

            //    foreach (Control childControl in PN2.Controls)
            //    {

            //        if (childControl.BackColor == Color.Blue)
            //        {

            //            // childControl.Parent = PN2;
            //            childControl.BackColor = Color.White;
            //            //  childControl.Location = new Point(x, y);
            //            // LB.Name = dataGridView1.Rows[i].Cells[1].Value.ToString();
            //            // LB.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            //            childControl.Location = new Point(0, ht2 + 10);
            //            //LB.MaximumSize = new Size(800,500);
            //            //LB.CanSelect = true;
            //            childControl.Width = 200;
            //            childControl.AutoSize = true;

            //            childControl.MaximumSize = new Size(200, 0);

            //            childControl.Click += new System.EventHandler(this.LB_Click);



            //            // childControl.BorderStyle = BorderStyle.FixedSingle;
            //            childControl.Visible = true;
            //            // LB.BackColor = Color.Yellow ;
            //            childControl.Show();
            //            childControl.Enabled = true;
            //            childControl.BringToFront();

            //            PN1.Controls.Add(childControl);
            //            ht2 = ht2 + childControl.Height;

            //        }
            //    }
            //}



            ////if (listBox2.SelectedItem != null)
            ////{
            ////    listBox1.Items.Add(listBox2.SelectedItem);
            ////    listBox2.Items.Remove(listBox2.SelectedItem);
            ////}
            ////else
            ////{
            ////    MessageBox.Show("No item selected");
            ////}






        }

        private void button8_Click(object sender, EventArgs e)
        {

            //if (PN2.HasChildren)
            //{

            //    foreach (Control childControl in PN2.Controls)
            //    {

            //        if (childControl.BackColor == Color.Blue)
            //        {
            //            x = childControl.Left;
            //            y = childControl.Top;
            //            childControl .
            //            // childControl.Parent = PN2;
            //            childControl.BackColor = Color.White;
            //            //  childControl.Location = new Point(x, y);
            //            // LB.Name = dataGridView1.Rows[i].Cells[1].Value.ToString();
            //            // LB.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            //            childControl.Location = new Point(0, ht2 + 10);
            //            //LB.MaximumSize = new Size(800,500);
            //            //LB.CanSelect = true;
            //            childControl.Width = 200;
            //            childControl.AutoSize = true;

            //            childControl.MaximumSize = new Size(200, 0);

            //            childControl.Click += new System.EventHandler(this.LB_Click);



            //            // childControl.BorderStyle = BorderStyle.FixedSingle;
            //            childControl.Visible = true;
            //            // LB.BackColor = Color.Yellow ;
            //            childControl.Show();
            //            childControl.Enabled = true;
            //            childControl.BringToFront();

            //            PN1.Controls.Add(childControl);
            //            ht2 = ht2 + childControl.Height;

            //        }
            //    }
            //  }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tb_ques.Text = "";
            tb_expla.Text = "";
        }






        //################################
        private void button_selection_in_both_panels(object sender, EventArgs e)
        {
            Button Btn = (Button)sender;

            selected_button();
            selected_button_in_panel2();
            Btn.BackColor = Color.Blue;


        }
        private void selected_button_in_panel2()
        {

            foreach (Button Btn in PN2.Controls)
            {

                Btn.BackColor = Color.White;
            }

        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    foreach (Button bt in panel1.Controls)
        //    {
        //        if (bt.BackColor == Color.Blue)
        //        {
        //            storage_text = bt.Text;
        //            storage_acc_name = bt.AccessibleName;

        //            bt.Text = "";
        //            bt.AccessibleName = "";
        //            if (P_btn6.Text == "")
        //            {

        //                P_btn6.Text = storage_text;
        //                P_btn6.AccessibleName = storage_acc_name;
        //            }
        //            else if (P_btn7.Text == "")
        //            {
        //                P_btn7.Text = storage_text;
        //                P_btn7.AccessibleName = storage_acc_name;

        //            }
        //            else if (P_btn8.Text == "")
        //            {
        //                P_btn8.Text = storage_text;
        //                P_btn8.AccessibleName = storage_acc_name;

        //            }
        //            else if (P_btn9.Text == "")
        //            {
        //                P_btn9.Text = storage_text;
        //                P_btn9.AccessibleName = storage_acc_name;
        //            }
        //            else if (P_btn10.Text == "")
        //            {

        //                P_btn10.Text = storage_text;
        //                P_btn10.AccessibleName = storage_acc_name;
        //            }
        //            else
        //            {
        //            }
        //            selected_button();
        //        }
        //        //foreach (Button bt in panel2.Controls)
        //        //{
        //        //    if (bt.Text == "")
        //        //    {
        //        //         bt.Text = storage_text;

        //        //         bt.AccessibleName = storage_acc_name;

        //        //        break;

        //        //    }
        //    }




        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    foreach (Button btn in panel2.Controls)
        //    {
        //        if (btn.BackColor == Color.Blue)
        //        {
        //            storage_text = btn.Text;
        //            storage_acc_name = btn.AccessibleName;
        //            //btn.Text = storage_text;
        //            //btn.AccessibleName = storage_acc_name;
        //            btn.Text = "";
        //            btn.AccessibleName = "";
        //            break;

        //        }
        //    }
        //    if (P_btn1.Text == "")
        //    {

        //        P_btn1.Text = storage_text;
        //        P_btn1.AccessibleName = storage_acc_name;
        //    }
        //    else if (P_btn2.Text == "")
        //    {
        //        P_btn2.Text = storage_text;
        //        P_btn2.AccessibleName = storage_acc_name;

        //    }
        //    else if (P_btn3.Text == "")
        //    {
        //        P_btn3.Text = storage_text;
        //        P_btn3.AccessibleName = storage_acc_name;

        //    }
        //    else if (P_btn4.Text == "")
        //    {
        //        P_btn4.Text = storage_text;
        //        P_btn4.AccessibleName = storage_acc_name;
        //    }
        //    else if (P_btn5.Text == "")
        //    {

        //        P_btn5.Text = storage_text;
        //        P_btn5.AccessibleName = storage_acc_name;
        //    }
        //    else
        //    {
        //    }
        //    selected_button_in_panel2();
        //}



        private void upper()
        {

            foreach (Button bt in PN2.Controls)
            {
                if (bt.BackColor == Color.Blue)
                {
                    storage_text = bt.Text;
                    storage_acc_name = bt.AccessibleName;
                    storage_tab_index = bt.TabIndex;
                    bt.Text = "";
                    bt.AccessibleName = "";
                    break;
                }


            }
            foreach (Button bt in PN2.Controls)
            {
                if (bt.TabIndex == storage_tab_index - 1)
                {

                    a = bt.Text;
                    b = bt.AccessibleName;
                    bt.Text = "";
                    bt.AccessibleName = "";
                    bt.Text = storage_text;
                    bt.AccessibleName = storage_acc_name;
                    break;

                }

            }

            foreach (Button bt in PN2.Controls)
            {
                if (bt.TabIndex == storage_tab_index)
                {

                    bt.Text = a;
                    bt.AccessibleName = b;
                    break;
                }

            }




        }
        private void lower()
        {
            storage_text = "";
            storage_acc_name = "";
            storage_tab_index = 0;
            foreach (Button bt in PN2.Controls)
            {
                if (bt.BackColor == Color.Blue)
                {
                    storage_text = bt.Text;
                    storage_acc_name = bt.AccessibleName;
                    storage_tab_index = bt.TabIndex;
                    bt.Text = "";
                    bt.AccessibleName = "";
                    break;
                }


            }
            foreach (Button bt in PN2.Controls)
            {
                if (bt.TabIndex == storage_tab_index + 1)
                {

                    a = bt.Text;
                    b = bt.AccessibleName;
                    bt.Text = "";
                    bt.AccessibleName = "";
                    bt.Text = storage_text;
                    bt.AccessibleName = storage_acc_name;
                    break;

                }

            }

            foreach (Button bt in PN2.Controls)
            {
                if (bt.TabIndex == storage_tab_index)
                {

                    bt.Text = a;
                    bt.AccessibleName = b;
                    break;
                }

            }




        }

        //private void button14_Click(object sender, EventArgs e)
        //{
        //    //upper();
        //    ////foreach (Button bt in panel2.Controls)
        //    ////    {
        //    ////        if (bt.BackColor == Color.Blue)
        //    ////        {
        //    ////            storage_text = bt.Text;
        //    ////            storage_acc_name = bt.AccessibleName;

        //    ////            bt.Text = "";
        //    ////            bt.AccessibleName = "";
        //    ////        } 

        //}

        //private void button13_Click(object sender, EventArgs e)
        //{
        //    lower();
        //}

        private void T_PN2_Click(object sender, EventArgs e)
        {
            foreach (Button bt in PN1.Controls)
            {
                if (bt.BackColor == Color.Blue)
                {
                    storage_text = bt.Text;
                    storage_acc_name = bt.AccessibleName;

                    bt.Text = "";
                    bt.AccessibleName = "";
                    if (P_btn6.Text == "")
                    {

                        P_btn6.Text = storage_text;
                        P_btn6.AccessibleName = storage_acc_name;
                    }
                    else if (P_btn7.Text == "")
                    {
                        P_btn7.Text = storage_text;
                        P_btn7.AccessibleName = storage_acc_name;

                    }
                    else if (P_btn8.Text == "")
                    {
                        P_btn8.Text = storage_text;
                        P_btn8.AccessibleName = storage_acc_name;

                    }
                    else if (P_btn9.Text == "")
                    {
                        P_btn9.Text = storage_text;
                        P_btn9.AccessibleName = storage_acc_name;
                    }
                    else if (P_btn10.Text == "")
                    {

                        P_btn10.Text = storage_text;
                        P_btn10.AccessibleName = storage_acc_name;
                    }
                    else
                    {
                    }
                    selected_button();
                }
                //foreach (Button bt in panel2.Controls)
                //{
                //    if (bt.Text == "")
                //    {
                //         bt.Text = storage_text;

                //         bt.AccessibleName = storage_acc_name;

                //        break;

                //    }
            }


        }

        //private void T_PN1_Click(object sender, EventArgs e)
        //{
        //    foreach (Button btn in PN2.Controls)
        //    {
        //        if (btn.BackColor == Color.Blue)
        //        {
        //            storage_text = btn.Text;
        //            storage_acc_name = btn.AccessibleName;
        //            //btn.Text = storage_text;
        //            //btn.AccessibleName = storage_acc_name;
        //            btn.Text = "";
        //            btn.AccessibleName = "";
        //            break;

        //        }
        //    }
        //    if (P_btn1.Text == "")
        //    {

        //        P_btn1.Text = storage_text;
        //        P_btn1.AccessibleName = storage_acc_name;
        //    }
        //    else if (P_btn2.Text == "")
        //    {
        //        P_btn2.Text = storage_text;
        //        P_btn2.AccessibleName = storage_acc_name;

        //    }
        //    else if (P_btn3.Text == "")
        //    {
        //        P_btn3.Text = storage_text;
        //        P_btn3.AccessibleName = storage_acc_name;

        //    }
        //    else if (P_btn4.Text == "")
        //    {
        //        P_btn4.Text = storage_text;
        //        P_btn4.AccessibleName = storage_acc_name;
        //    }
        //    else if (P_btn5.Text == "")
        //    {

        //        P_btn5.Text = storage_text;
        //        P_btn5.AccessibleName = storage_acc_name;
        //    }
        //    else
        //    {
        //    }
        //    selected_button_in_panel2();
        //}

        private void Btn_UP_Click(object sender, EventArgs e)
        {
            upper();
            //foreach (Button bt in panel2.Controls)
            //    {
            //        if (bt.BackColor == Color.Blue)
            //        {
            //            storage_text = bt.Text;
            //            storage_acc_name = bt.AccessibleName;

            //            bt.Text = "";
            //            bt.AccessibleName = "";
            //        }
        }

        private void Btn_lower_Click(object sender, EventArgs e)
        {
            lower();
        }

        private void T_PN2_Click_1(object sender, EventArgs e)
        {

        }

        private void P_btn6_Click(object sender, EventArgs e)
        {

        }

        private void P_btn7_Click(object sender, EventArgs e)
        {

        }

        private void P_btn8_Click(object sender, EventArgs e)
        {

        }

        private void P_btn5_Click(object sender, EventArgs e)
        {

        }

        private void P_btn4_Click(object sender, EventArgs e)
        {

        }

        private void P_btn3_Click(object sender, EventArgs e)
        {

        }

        private void selected_button()
        {
            foreach (Button Btn in PN1.Controls)
            {

                Btn.BackColor = Color.White;
            }

        }

        private void T_PN1_Click(object sender, EventArgs e)
        {
            //foreach (Button btn in PN2.Controls)
            //{
            //    if (btn.BackColor == Color.Blue)
            //    {
            //        storage_text = btn.Text;
            //        storage_acc_name = btn.AccessibleName;
            //        //btn.Text = storage_text;
            //        //btn.AccessibleName = storage_acc_name;
            //        btn.Text = "";
            //        btn.AccessibleName = "";
            //        break;

            //    }
            //}
            //if (P_btn1.Text == "")
            //{

            //    P_btn1.Text = storage_text;
            //    P_btn1.AccessibleName = storage_acc_name;
            //}
            //else if (P_btn2.Text == "")
            //{
            //    P_btn2.Text = storage_text;
            //    P_btn2.AccessibleName = storage_acc_name;

            //}
            //else if (P_btn3.Text == "")
            //{
            //    P_btn3.Text = storage_text;
            //    P_btn3.AccessibleName = storage_acc_name;

            //}
            //else if (P_btn4.Text == "")
            //{
            //    P_btn4.Text = storage_text;
            //    P_btn4.AccessibleName = storage_acc_name;
            //}
            //else if (P_btn5.Text == "")
            //{

            //    P_btn5.Text = storage_text;
            //    P_btn5.AccessibleName = storage_acc_name;
            //}
            //else
            //{
            //}
            //selected_button_in_panel2();
            foreach (Button btn in PN2.Controls)
            {
                if (btn.BackColor == Color.Blue)
                {
                    storage_text = btn.Text;
                    storage_acc_name = btn.AccessibleName;
                    //btn.Text = storage_text;
                    //btn.AccessibleName = storage_acc_name;
                    btn.Text = "";
                    btn.AccessibleName = "";
                    break;

                }
            }
            if (P_btn1.Text == "")
            {

                P_btn1.Text = storage_text;
                P_btn1.AccessibleName = storage_acc_name;
            }
            else if (P_btn2.Text == "")
            {
                P_btn2.Text = storage_text;
                P_btn2.AccessibleName = storage_acc_name;

            }
            else if (P_btn3.Text == "")
            {
                P_btn3.Text = storage_text;
                P_btn3.AccessibleName = storage_acc_name;

            }
            else if (P_btn4.Text == "")
            {
                P_btn4.Text = storage_text;
                P_btn4.AccessibleName = storage_acc_name;
            }
            else if (P_btn5.Text == "")
            {

                P_btn5.Text = storage_text;
                P_btn5.AccessibleName = storage_acc_name;
            }
            else
            {
            }
            selected_button_in_panel2();
                }

        







                //private void button_Click(object sender, EventArgs e)
                //{
                //    foreach (Button bt in panel1.Controls)
                //        {
                //            if (bt.BackColor == Color.Blue)
                //            {
                //                storage_text = bt.Text;
                //                storage_acc_name = bt.AccessibleName;

                //                bt.Text = "";
                //                bt.AccessibleName = "";
                //                if (button12.Text == "")
                //                {

                //                    button12.Text = storage_text;
                //                    button12.AccessibleName = storage_acc_name;
                //                }
                //                else if (button11.Text == "")
                //                {
                //                    button11.Text = storage_text;
                //                    button11.AccessibleName = storage_acc_name;

                //                }
                //                else if (button10.Text == "")
                //                {
                //                    button10.Text = storage_text;
                //                    button10.AccessibleName = storage_acc_name;

                //                }
                //                else if (button9.Text == "")
                //                {
                //                    button9.Text = storage_text;
                //                    button9.AccessibleName = storage_acc_name;
                //                }
                //                else if (button8.Text == "")
                //                {

                //                    button8.Text = storage_text;
                //                    button8.AccessibleName = storage_acc_name;
                //                }
                //                else
                //                {
                //                }

                //            }

                ////foreach (Button bt in panel1.Controls)
                ////{
                ////    if (bt.Text == "")
                ////    {
                ////        bt.Text = storage_text;
                ////        // storage_text = btn.Text;
                ////        //storage_acc_name = btn.AccessibleName;
                ////        bt.AccessibleName = storage_acc_name;
                ////        // btn.Text = "";
                ////        //btn.AccessibleName = "";
                ////        break;

                ////    }
            }
        }
    


       
        
        
        
        
        
        //    private void button3_Click(object sender, EventArgs e)
        //    {

        //        Button Btn = (Button)sender;

        //        selected_button();
        //        Btn.BackColor = Color.Blue;

        //    }


        //    private void button1_Click(object sender, EventArgs e)
        //    {
        //        //foreach (Button bt in panel1.Controls)
        //        //{
        //        //    if (bt.BackColor == Color.Blue)
        //        //    {
        //        //        storage_text = bt.Text;
        //        //        storage_acc_name = bt.AccessibleName;

        //        //        bt.Text = "";
        //        //        bt.AccessibleName = "";
        //        //        if (button12.Text == "")
        //        //        {

        //        //            button12.Text = storage_text;
        //        //            button12.AccessibleName = storage_acc_name;
        //        //        }
        //        //        else if (button11.Text == "")
        //        //        {
        //        //            button11.Text = storage_text;
        //        //            button11.AccessibleName = storage_acc_name;

        //        //        }
        //        //        else if (button10.Text == "")
        //        //        {
        //        //            button10.Text = storage_text;
        //        //            button10.AccessibleName = storage_acc_name;

        //        //        }
        //        //        else if (button9.Text == "")
        //        //        {
        //        //            button9.Text = storage_text;
        //        //            button9.AccessibleName = storage_acc_name;
        //        //        }
        //        //        else if (button8.Text == "")
        //        //        {

        //        //            button8.Text = storage_text;
        //        //            button8.AccessibleName = storage_acc_name;
        //        //        }
        //        //        else
        //        //        {
        //        //        }

        //        //    }

        //        //}

        //        foreach (Button btn in panel1.Controls)
        //        {
        //            if (btn.BackColor == Color.Blue)
        //            {
        //                btn.Text = storage_text;
        //                btn.AccessibleName = storage_acc_name;

        //                break;

        //            }
        //        }
        //      }




        //    private void button2_Click(object sender, EventArgs e)
        //    {
        //        foreach (Button btn in panel2.Controls)
        //        {
        //            if (btn.BackColor == Color.Blue)
        //            {
        //                storage_text = btn.Text;
        //                storage_acc_name = btn.AccessibleName;

        //                btn.Text = "";
        //                btn.AccessibleName = "";

        //            }
        //        }


        //        //foreach (Button btn in panel1.Controls)
        //        //{
        //        //    if (btn.BackColor == Color.Blue)
        //        //    {
        //        //        btn.Text = storage_text;
        //        //        btn.AccessibleName = storage_acc_name;

        //        //        break;

        //        //    }
        //        //}
        //                //if (button3.Text == "")
        //                //{

        //                //    button3.Text = storage_text;
        //                //    button3.AccessibleName = storage_acc_name;
        //                //}
        //                //else if (button4.Text == "")
        //                //{
        //                //    button4.Text = storage_text;
        //                //    button4.AccessibleName = storage_acc_name;

        //                //}
        //                //else if (button5.Text == "")
        //                //{
        //                //    button5.Text = storage_text;
        //                //    button5.AccessibleName = storage_acc_name;

        //                //}
        //                //else if (button6.Text == "")
        //                //{
        //                //    button6.Text = storage_text;
        //                //    button6.AccessibleName = storage_acc_name;
        //                //}
        //                //else if (button7.Text == "")
        //                //{

        //                //    button7.Text = storage_text;
        //                //    button7.AccessibleName = storage_acc_name;
        //                //}
        //                //else
        //                //{
        //                //}

        //            //}
        //        //}

        //    }


        //    public void button_selection(object sndr, EventArgs arg)
        //    {

        //        Button Btn = (Button)sndr;
        //        selected_button_in_panel2();
        //        Btn.BackColor = Color.Blue;

        //    }
        //    private void button12_Click(object sender, EventArgs e)
        //    {

        //        Button Btn = (Button)sender;
        //        selected_button_in_panel2();
        //        Btn.BackColor = Color.Blue;
        //    }

        //    private void Lst_box_Load(object sender, EventArgs e)
        //    {
        //        selected_button_in_panel2();
        //        selected_button();
        //    }


        //}
    




      
       
    