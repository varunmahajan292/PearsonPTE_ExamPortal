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
    public partial class WritingQuestions : Form
    {
        Pte_connection con = new Pte_connection();

        protected SqlConnection MyConn = new SqlConnection();/* variable declaration for make a connection*/
        protected SqlCommand MyCmd = new SqlCommand();
        string store_id_of_wq;
        
    
        public WritingQuestions()
        {
            InitializeComponent();
        }

       

        private void WritingQuestions_Load(object sender, EventArgs e)
        {
            MyConn.ConnectionString = Pte_connection.ConnectionS_tring;
            
            
            label5.Text = "";
            label6.Text = "";
            panel1.Visible = false;
            fn_fr_first_combo();
            fn_fr_second_combo();

             grd_fill_on_pgload();
            fn_for_second_combo_PANEL();//combos in panel1
            fn_for_first_comboPANEL();//combos in panel1
            btn_update_ques.Hide() ;
            btn_add_question.Show();
            
          
             
        }

        private void btn_add_question_Click(object sender, EventArgs e)
        {
            MyConn.Open();/*open connection by varible*/


            MyCmd = new SqlCommand("SP_WritingQuestions", MyConn);/*fire insert query by using connection*/
            MyCmd.CommandType = CommandType.StoredProcedure;/* which type of  query you passed in above line we write text because we write direct query like */
            MyCmd.CommandTimeout = 120;/*connection time out after secs*/




            MyCmd.Parameters.AddWithValue("@OID", 0);
            MyCmd.Parameters.AddWithValue("@DPLANID", Cb_dayplan .SelectedValue );
            MyCmd.Parameters.AddWithValue("@QWRITINGTYPEID", cb_question_type .SelectedValue);
            MyCmd.Parameters.AddWithValue("@QUESTION", tb_ques .Text);
            MyCmd.Parameters.AddWithValue("@CORRANSWER", tb_corr_ans .Text);
            MyCmd.Parameters.AddWithValue("@ISACTIVE", "1");
            MyCmd.Parameters.AddWithValue("@EXPLANATION", tb_explanation .Text);

            MyCmd.Parameters.AddWithValue("@Type", "Insert");
            MyCmd.ExecuteNonQuery();/*what you expect in return*/


            MyConn.Close();

            MessageBox.Show("Record Inserted Successfully");
            
        }

        private void btn_clr_txtboxes_Click(object sender, EventArgs e)
        {
            tb_ques.Text = "";
            tb_corr_ans.Text = "";
            tb_explanation.Text = "";
        }
        public void fn_fr_first_combo()
        { 
           
            MyConn.Open();/*open connection by varible*/

            MyCmd = new SqlCommand("SELECT * FROM DayPlan", MyConn);
            MyCmd.CommandType = CommandType.Text;
            MyCmd.CommandTimeout = 120;

            DataTable vtable = new DataTable();

            vtable.Load(  MyCmd.ExecuteReader());

                     
            Cb_dayplan.DisplayMember = "PlanNo";
            Cb_dayplan.ValueMember = "DPlan";
            Cb_dayplan.DataSource = vtable;
            
            Cb_dayplan.Enabled = true;
            MyConn.Close();

        }
       
        public void fn_fr_second_combo()
        {

            MyConn.Open();/*open connection by varible*/

            MyCmd = new SqlCommand("SELECT * FROM WritingTypes", MyConn);
            MyCmd.CommandType = CommandType.Text;
            MyCmd.CommandTimeout = 120;

            DataTable vtable1 = new DataTable();

            vtable1.Load(MyCmd.ExecuteReader());
            

            cb_question_type.DisplayMember = "WType";
            cb_question_type.ValueMember = "WTypeId";
            cb_question_type.DataSource = vtable1;

            cb_question_type.Enabled = true;
            MyConn.Close();

        }

        private void Cb_dayplan_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyConn.Close();
            MyConn.Open();

            MyCmd = new SqlCommand("select * from DayPlan where DPlan=@DPLAN ", MyConn);
            MyCmd.Parameters.AddWithValue("@DPLAN", Cb_dayplan .SelectedValue );
            DataTable d2 = new DataTable();
            d2.Load( MyCmd.ExecuteReader());

            foreach (DataRow rdr in d2.Rows)
            {
                //dataGridView1.Rows.Add();
                //dataGridView1.Rows[i].Cells[0].Value = rdr["PlanNo"].ToString();
                //dataGridView1.Rows[i].Cells[1].Value = rdr["PType"].ToString();
                //dataGridView1.Rows[i].Cells[2].Value = rdr["DPlan"].ToString();

                //i = i + 1;
                label5 .Text = rdr["PType"].ToString();

               
            }
            
            MyConn.Close();
        }

        private void cb_question_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyConn.Close();
            MyConn.Open();

            MyCmd = new SqlCommand("select * from WritingTypes where WTypeId=@WTI ", MyConn);
            MyCmd.Parameters.AddWithValue("@WTI", cb_question_type .SelectedValue);

            DataTable d2 = new DataTable();
            d2.Load(MyCmd.ExecuteReader());

            foreach (DataRow rdr in d2.Rows)
            {
                //dataGridView1.Rows.Add();
                //dataGridView1.Rows[i].Cells[0].Value = rdr["PlanNo"].ToString();
                //dataGridView1.Rows[i].Cells[1].Value = rdr["PType"].ToString();
                //dataGridView1.Rows[i].Cells[2].Value = rdr["DPlan"].ToString();

                //i = i + 1;
                label6.Text = rdr["TypeDescription"].ToString();


            }
            
            MyConn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.BringToFront();
            panel1.Size = new Size(968, 608);
            panel1.Location = new Point(12, 12);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

       



//########################################33


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
            

            
                MyConn.Open();

                MyCmd = new SqlCommand("select * from DayPlan where DPlan=@DPN ", MyConn);
                MyCmd.Parameters.AddWithValue("@DPN", dataGridView1.CurrentRow.Cells[5].Value);
                DataTable d2 = new DataTable();
                d2.Load(MyCmd.ExecuteReader());

                foreach (DataRow rdr in d2.Rows)
                {
                    //dataGridView1.Rows.Add();
                    //dataGridView1.Rows[i].Cells[0].Value = rdr["PlanNo"].ToString();
                    //dataGridView1.Rows[i].Cells[1].Value = rdr["PType"].ToString();
                    //dataGridView1.Rows[i].Cells[2].Value = rdr["DPlan"].ToString();

                    //i = i + 1;



                    Cb_dayplan.Text = rdr["PlanNo"].ToString();



                }
                
                MyConn.Close();

            
           ////////////
         
            
                MyConn.Open();

                MyCmd = new SqlCommand("select * from WritingTypes where WTypeId=@wt ", MyConn);
                MyCmd.Parameters.AddWithValue("@wt", dataGridView1.CurrentRow.Cells[6].Value);
                DataTable d3 = new DataTable();
                d3.Load(MyCmd.ExecuteReader());

                foreach (DataRow rdr in d3.Rows)
                {
                    //dataGridView1.Rows.Add();
                    //dataGridView1.Rows[i].Cells[0].Value = rdr["PlanNo"].ToString();
                    //dataGridView1.Rows[i].Cells[1].Value = rdr["PType"].ToString();
                    //dataGridView1.Rows[i].Cells[2].Value = rdr["DPlan"].ToString();

                    //i = i + 1;



                    cb_question_type.Text = rdr["WType"].ToString();



                }
                
                MyConn.Close();
               

            

            ////////////

            
                MyConn.Open();

                MyCmd = new SqlCommand("select * from WritingQuestions where Qid=@q ", MyConn);
                MyCmd.Parameters.AddWithValue("@q", dataGridView1.CurrentRow.Cells[4].Value);
                DataTable d1 = new DataTable();
                d1.Load (MyCmd.ExecuteReader());

                foreach (DataRow rdr in d1.Rows )
                {
                    //dataGridView1.Rows.Add();
                    //dataGridView1.Rows[i].Cells[0].Value = rdr["PlanNo"].ToString();
                    //dataGridView1.Rows[i].Cells[1].Value = rdr["PType"].ToString();
                    //dataGridView1.Rows[i].Cells[2].Value = rdr["DPlan"].ToString();

                    //i = i + 1;
                    store_id_of_wq = rdr["Qid"].ToString();


                    tb_ques.Text = rdr["Question"].ToString();
                    tb_corr_ans.Text = rdr["Corr_Answer"].ToString();
                    tb_explanation.Text = rdr["explanation"].ToString();

                }
               
                MyConn.Close();
                
           



           // btn_update_ques.Enabled = true;
            panel1.Visible = false;

            btn_update_ques.Show();
            btn_add_question.Hide();

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            grid_data_receive();
        }

        private void comb1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            grid_data_receive();
        }

        public void grid_data_receive()
        {
            //int i = 0;

            //dataGridView1.Rows.Clear();
            //MyConn.Close();
            //MyConn.Open();

            //SqlCommand MyCmd = new SqlCommand("select * from WritingQuestions where DayPlanid=@dpi and QWritingTypeid=@WTI", MyConn);

            //MyCmd.Parameters.AddWithValue("@dpi", comboBox1.SelectedValue);
            //MyCmd.Parameters.AddWithValue("@WTI", comb1.SelectedValue);

            //SqlDataReader rdr = MyCmd.ExecuteReader();

            //while (rdr.Read())
            //{
            //    dataGridView1.Rows.Add();
            //    dataGridView1.Rows[i].Cells[0].Value = rdr["DayPlanid"].ToString();
            //    dataGridView1.Rows[i].Cells[1].Value = rdr["QWritingTypeid"].ToString();
            //    dataGridView1.Rows[i].Cells[2].Value = rdr["Question"].ToString();
            //    dataGridView1.Rows[i].Cells[3].Value = rdr["Corr_Answer"].ToString();
            //    dataGridView1.Rows[i].Cells[4].Value = rdr["Qid"].ToString();

            //    i = i + 1;
            //}
            //
            //MyConn.Close();

            int i = 0;

            dataGridView1.Rows.Clear();
            MyConn.Open();

            MyCmd = new SqlCommand("select DayPlan.PlanNo, WritingTypes.WType, WritingQuestions.Question, WritingQuestions.Corr_Answer, WritingQuestions.Qid, WritingQuestions.DayPlanid, WritingQuestions.QWritingTypeid, WritingQuestions.explantion From WritingQuestions INNER JOIN DayPlan ON WritingQuestions.DayPlanid =DayPlan.DPlan INNER JOIN WritingTypes ON WritingQuestions.QWritingTypeid = WritingTypes.WTypeId where WritingQuestions.DayPlanid=@dpi and WritingQuestions.QWritingTypeid=@WTI", MyConn);
            MyCmd.Parameters.AddWithValue("@dpi", comboBox1.SelectedValue);
            MyCmd.Parameters.AddWithValue("@WTI", comb1.SelectedValue);
            DataTable DT = new DataTable();
            DT.Load(MyCmd.ExecuteReader());

           
            foreach(DataRow rdr in DT.Rows)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = rdr["PlanNo"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = rdr["WType"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = rdr["Question"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = rdr["Corr_Answer"].ToString();
                dataGridView1.Rows[i].Cells[4].Value = rdr["Qid"].ToString();
                dataGridView1.Rows[i].Cells[5].Value = rdr["DayPlanid"].ToString();
                dataGridView1.Rows[i].Cells[6].Value = rdr["QWritingTypeid"].ToString();
                dataGridView1.Rows[i].Cells[7].Value = rdr["explanation"].ToString();

                i = i + 1;
            }
           
            MyConn.Close();

           



        }

        public void fn_for_second_combo_PANEL()
        {

            MyConn.Open();/*open connection by varible*/

            MyCmd = new SqlCommand("SELECT * FROM WritingTypes", MyConn);
            MyCmd.CommandType = CommandType.Text;
            MyCmd.CommandTimeout = 120;

            DataTable vtable1 = new DataTable();

            vtable1.Load(MyCmd.ExecuteReader());


            comb1.DisplayMember = "WType";
            comb1.ValueMember = "WTypeId";
            comb1.DataSource = vtable1;

            comb1.Enabled = true;
            MyConn.Close();

        }

        public void fn_for_first_comboPANEL()
        {

            MyConn.Open();/*open connection by varible*/

            MyCmd = new SqlCommand("SELECT * FROM DayPlan", MyConn);
            MyCmd.CommandType = CommandType.Text;
            MyCmd.CommandTimeout = 120;

            DataTable vtable1 = new DataTable();

            vtable1.Load(MyCmd.ExecuteReader());


            comboBox1.DisplayMember = "PlanNo";
            comboBox1.ValueMember = "DPlan";
            comboBox1.DataSource = vtable1;

            comboBox1.Enabled = true;
            MyConn.Close();

        }

        public void grd_fill_on_pgload()
        {

            int i = 0;

            dataGridView1.Rows.Clear();
            MyConn.Open();

            MyCmd = new SqlCommand("select DayPlan.PlanNo, WritingTypes.WType, WritingQuestions.Question, WritingQuestions.Corr_Answer, WritingQuestions.Qid, WritingQuestions.DayPlanid, WritingQuestions.QWritingTypeid, WritingQuestions.explanation  From WritingQuestions INNER JOIN DayPlan ON WritingQuestions.DayPlanid =DayPlan.DPlan INNER JOIN WritingTypes ON WritingQuestions.QWritingTypeid = WritingTypes.WTypeId", MyConn);
            DataTable DTABLE = new DataTable();
             DTABLE.Load(MyCmd.ExecuteReader());

            foreach (DataRow rdr in DTABLE .Rows )
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = rdr["PlanNo"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = rdr["WType"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = rdr["Question"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = rdr["Corr_Answer"].ToString();
                dataGridView1.Rows[i].Cells[4].Value = rdr["Qid"].ToString();
                dataGridView1.Rows[i].Cells[5].Value = rdr["DayPlanid"].ToString();
                dataGridView1.Rows[i].Cells[6].Value = rdr["QWritingTypeid"].ToString();
                dataGridView1.Rows[i].Cells[7].Value = rdr["explanation"].ToString();
                i = i + 1;
            }
           
            MyConn.Close();

        }

        private void btn_update_ques_Click(object sender, EventArgs e)
        {
           
            
            
            
            MyConn.Open();/*open connection by varible*/


            MyCmd = new SqlCommand("SP_WritingQuestions", MyConn);/*fire insert query by using connection*/
            MyCmd.CommandType = CommandType.StoredProcedure;/* which type of  query you passed in above line we write text because we write direct query like */
            MyCmd.CommandTimeout = 120;/*connection time out after secs*/




            MyCmd.Parameters.AddWithValue("@OID", dataGridView1.CurrentRow .Cells [4].Value );
            MyCmd.Parameters.AddWithValue("@DPLANID", Cb_dayplan.SelectedValue);
            MyCmd.Parameters.AddWithValue("@QWRITINGTYPEID", cb_question_type.SelectedValue);
            MyCmd.Parameters.AddWithValue("@QUESTION", tb_ques.Text);
            MyCmd.Parameters.AddWithValue("@CORRANSWER", tb_corr_ans.Text);
            MyCmd.Parameters.AddWithValue("@ISACTIVE", "1");
            MyCmd.Parameters.AddWithValue("@EXPLANATION", tb_explanation.Text);
            MyCmd.Parameters.AddWithValue("@Type", "Update");
            MyCmd.ExecuteNonQuery();/*what you expect in return*/


            MyConn.Close();

            MessageBox.Show("Record Updated Successfully");
            btn_update_ques.Hide();
            btn_add_question.Show();
            


        }

       
       


    }
}
