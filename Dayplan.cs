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
    public partial class Dayplan : Form
    {
        Pte_connection con = new Pte_connection();

        protected SqlConnection MyConn =new SqlConnection ();/* variable declaration for make a connection*/
        protected SqlCommand MyCmd=new SqlCommand ();

   
        public Dayplan()
        {
            InitializeComponent();
        }

        private void Dayplan_Load(object sender, EventArgs e)
        {

            MyConn.ConnectionString = Pte_connection.ConnectionS_tring;

            radioButton1.Checked = false;
            radioButton2.Checked = false;

            grid_data_receive();
           
        }

        private void btn_add_day_pln_Click(object sender, EventArgs e)
        {
            MyConn.Open();/*open connection by varible*/


            MyCmd = new SqlCommand("SP_Dayplan", MyConn);/*fire insert query by using connection*/
            MyCmd.CommandType = CommandType.StoredProcedure;/* which type of  query you passed in above line we write text because we write direct query like */
            MyCmd.CommandTimeout = 120;/*connection time out after secs*/

            MyCmd.Parameters.AddWithValue("@DPLAN", 0);
            MyCmd.Parameters.AddWithValue("@PLAN_NO",tb_p_no .Text );
           if (radioButton1.Checked==true )
            {
               MyCmd.Parameters.AddWithValue("@PTYPE", radioButton1 .Text );
           } 
          
           else
            {
                if(radioButton2.Checked==true )
                {
                    MyCmd.Parameters.AddWithValue("@PTYPE", radioButton2 .Text );
                }
           }
           
            MyCmd.Parameters.AddWithValue("@ISACTIVE", "1");
            MyCmd.Parameters.AddWithValue("@Type", "Insert");
            MyCmd.ExecuteNonQuery();/*what you expect in return*/

            MyConn.Close();

            MessageBox.Show ("Record Inserted Successfully");
            tb_p_no.Text = "";
           



            grid_data_receive();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tb_p_no.Text = "";
            radioButton2.Checked = false ;
            radioButton1.Checked = false;
            
        }

        public void grid_data_receive()
        {
            int i = 0;
            dataGridView1.Rows.Clear();

            MyConn.Open();

            SqlCommand MyCmd = new SqlCommand("select * from DayPlan ", MyConn);

            SqlDataReader rdr = MyCmd.ExecuteReader();

            while (rdr.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = rdr["PlanNo"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = rdr["PType"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = rdr["DPlan"].ToString();

                i = i + 1;
            }
            rdr.Close();
            MyConn.Close();
        }

       
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           // int ii = 0;
            

            MyConn.Open();
            
            SqlCommand MyCmd = new SqlCommand("select * from DayPlan where DPlan=@DPLAN ", MyConn);
            MyCmd.Parameters.AddWithValue("@DPLAN",dataGridView1 .CurrentRow .Cells [2].Value  );
            SqlDataReader rdr = MyCmd.ExecuteReader();

            while (rdr.Read())
            {
                //dataGridView1.Rows.Add();
                //dataGridView1.Rows[i].Cells[0].Value = rdr["PlanNo"].ToString();
                //dataGridView1.Rows[i].Cells[1].Value = rdr["PType"].ToString();
                //dataGridView1.Rows[i].Cells[2].Value = rdr["DPlan"].ToString();

                //i = i + 1;
                tb_p_no.Text = rdr["PlanNo"].ToString();

                string s = rdr["PType"].ToString();

                if (s == "Practice Session")
                {
                    radioButton1.Checked = true;
                    radioButton2.Checked = false ;

                }
                else
                {
                    if (s == "Mock Test")
                    {
                        radioButton2.Checked = true;
                        radioButton1.Checked = false;

                    }
                    else
                    {
                        radioButton2.Checked = false;
                        radioButton1.Checked = false;
                    }

                }
            }
            rdr.Close();
            MyConn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyConn.Open();/*open connection by varible*/


            MyCmd = new SqlCommand("SP_Dayplan", MyConn);/*fire insert query by using connection*/
            MyCmd.CommandType = CommandType.StoredProcedure;/* which type of  query you passed in above line we write text because we write direct query like */
            MyCmd.CommandTimeout = 120;/*connection time out after secs*/

            MyCmd.Parameters.AddWithValue("@DPLAN", dataGridView1.CurrentRow.Cells[2].Value);
            MyCmd.Parameters.AddWithValue("@PLAN_NO", tb_p_no.Text);
            if (radioButton1.Checked == true)
            {
                MyCmd.Parameters.AddWithValue("@PTYPE", radioButton1.Text);
            }

            else
            {
                if (radioButton2.Checked == true)
                {
                    MyCmd.Parameters.AddWithValue("@PTYPE", radioButton2.Text);
                }
            }

            MyCmd.Parameters.AddWithValue("@ISACTIVE", "1");
            MyCmd.Parameters.AddWithValue("@Type", "Update");
            MyCmd.ExecuteNonQuery();/*what you expect in return*/

            MyConn.Close();

            MessageBox.Show("Record Updated Successfully");
            tb_p_no.Text = "";




            grid_data_receive();
        }

       

       
        }
       
        
        }

        
    

