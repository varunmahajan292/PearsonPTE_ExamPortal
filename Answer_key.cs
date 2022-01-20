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
    public partial class Answer_key : Form
    {
        Pte_connection con = new Pte_connection();

        protected SqlConnection MyConn = new SqlConnection();/* variable declaration for make a connection*/
        protected SqlCommand MyCmd = new SqlCommand();
        DataRow cols;
        int num = 0;
        int ques_no = 0;
        int max_ques = 0;
        int chk_last = 0;
        int numprev = 0;
        int Quesid;
        string Corr_ans;
        DataTable d2 = new DataTable();
       
        public Answer_key()
        {
            InitializeComponent();
        }

        private void Answer_key_Load(object sender, EventArgs e)
        {
            MyConn.ConnectionString = Pte_connection.ConnectionS_tring;
            panel3.Visible = false;
            cmb_fill_choose_ps();
            panel2.Visible = true;
            panel2.BringToFront();
            panel2.Size = new Size(1326, 551);
            panel2.Location = new Point(12, 12);
            panel4.Visible = false;
        }
        private void cmb_fill_choose_ps()
        {
            MyConn.Open();/*open connection by varible*/

            MyCmd = new SqlCommand("SELECT * FROM DayPlan", MyConn);
            MyCmd.CommandType = CommandType.Text;
            MyCmd.CommandTimeout = 120;

            DataTable vtable = new DataTable();

            vtable.Load(MyCmd.ExecuteReader());


            CB_SELECT_PRACSET.DisplayMember = "PlanNo";
            CB_SELECT_PRACSET.ValueMember = "DPlan";
            CB_SELECT_PRACSET.DataSource = vtable;

            CB_SELECT_PRACSET.Enabled = true;
            MyConn.Close();

        }

        private void btn_shwans_Click(object sender, EventArgs e)
        {
            MyConn.Open();

            MyCmd = new SqlCommand("select DayPlan.PlanNo, WritingTypes.WType, WritingTypes.ATime, WritingTypes.TypeDescription, WritingQuestions.Question, WritingQuestions.Qid, WritingQuestions.Corr_Answer, WritingTypes.explanation From WritingQuestions INNER JOIN DayPlan ON WritingQuestions.DayPlanid = DayPlan.DPlan INNER JOIN WritingTypes ON WritingQuestions.QWritingTypeid = WritingTypes.WTypeId WHERE WritingQuestions.DayPlanid=@DPI", MyConn);
            MyCmd.Parameters.AddWithValue("@DPI", CB_SELECT_PRACSET.SelectedValue);
            // MyCmd.Parameters.AddWithValue("@DPLAN", Cb_dayplan.SelectedValue);

            d2.Load(MyCmd.ExecuteReader());
            if (num == (d2.Rows.Count))
            { }
            else
            {
                cols = d2.Rows[num];

                label10.Text = cols[0].ToString();


                label2.Text = cols[1].ToString();
                label7.Text = cols[2].ToString();
               // a = Convert.ToDouble(cols[2]);
                label3.Text = cols[3].ToString();
                label4.Text = cols[4].ToString();
                Quesid = Convert.ToInt32(cols[5]);
                tb_ans.Text = cols[6].ToString();
                label14.Text = cols[7].ToString();

                num++;
                ques_no++;
                label11.Text = (ques_no).ToString();

            }
            max_ques = d2.Rows.Count;
            // int chk_last = max_ques;
            label12.Text = (max_ques).ToString();
            MyConn.Close();




            MyConn.Close();

            panel2.Visible = false;
           // fn_TIMERSTART();
            if (num == 1)
            {
                btn_prev.Enabled = false;
                bTN_NEXT.Enabled = true;
            }
        }

        private void btn_prev_Click(object sender, EventArgs e)
        {
           //  insert_update_answer_key();
            if (num == max_ques)
            {
                //btn_prev.Enabled = true;
                bTN_NEXT.Enabled = true;
            }
            else if (num == 2)
            {
                btn_prev.Enabled = false;
            }
            //bTN_NEXT.Enabled = true;
            // MyConn.Close();
            //    MyConn.Open();

            //    MyCmd = new SqlCommand("select DayPlan.PlanNo, WritingTypes.WType, WritingTypes.ATime, WritingTypes.TypeDescription, WritingQuestions.Question, WritingQuestions.Qid, WritingQuestions.Corr_Answer From WritingQuestions INNER JOIN DayPlan ON WritingQuestions.DayPlanid = DayPlan.DPlan INNER JOIN WritingTypes ON WritingQuestions.QWritingTypeid = WritingTypes.WTypeId WHERE WritingQuestions.DayPlanid=@DP", MyConn);
            //    MyCmd.Parameters.AddWithValue("@DP", CB_SELECT_PRACSET.SelectedValue);
            //    // MyCmd.Parameters.AddWithValue("@DPLAN", Cb_dayplan.SelectedValue);
            //    DataTable d3 = new DataTable();
            //    d3.Load(MyCmd.ExecuteReader());
            num -= 2;



            cols = d2.Rows[num];

            label10.Text = cols[0].ToString();

            label2.Text = cols[1].ToString();
            label7.Text = cols[2].ToString();
          //  a = Convert.ToDouble(cols[2]);
            label3.Text = cols[3].ToString();
            label4.Text = cols[4].ToString();
            Quesid = Convert.ToInt32(cols[5]);
            tb_ans.Text = cols[6].ToString();
            label14.Text = cols[7].ToString();

            num++;
            ques_no--;
            label11.Text = (ques_no).ToString();

            //}
            max_ques = d2.Rows.Count;
            // int chk_last = max_ques;
            label12.Text = (max_ques).ToString();
            MyConn.Close();
            //MyConn.Open();/*open connection by varible*
        }

        private void bTN_NEXT_Click(object sender, EventArgs e)
        {
           // insert_update_answer_key();
            if (num >= 1)
            {
                btn_prev.Enabled = true;
            }

            if (num == max_ques - 1)
            {
                bTN_NEXT.Enabled = false;
            }
            else if (num == max_ques - 1)
            {
                bTN_NEXT.Enabled = true;
            }


            show_questions();

          //  MyCmd = new SqlCommand("SELECT *  FROM Answer_key WHERE Quesid = @present and Studentid=@stuid", MyConn);
          //  MyCmd.Parameters.AddWithValue("@present", Quesid);
          //  MyCmd.Parameters.AddWithValue("@stuid", 11);
          //  DataTable qexist = new DataTable();
          //  qexist.Load(MyCmd.ExecuteReader());
          //  MyConn.Close();
          //  foreach (DataRow rdr in qexist.Rows)
          //  {
          //      tb_ans.Text = rdr["Answer"].ToString();

          //  }
          ////  fn_TIMERSTART();
            
        }
        public void show_questions()
        {


            //MyConn.Close();
            //MyConn.Open();

            //MyCmd = new SqlCommand("select DayPlan.PlanNo, WritingTypes.WType, WritingTypes.ATime, WritingTypes.TypeDescription, WritingQuestions.Question, WritingQuestions.Qid, WritingQuestions.Corr_Answer From WritingQuestions INNER JOIN DayPlan ON WritingQuestions.DayPlanid = DayPlan.DPlan INNER JOIN WritingTypes ON WritingQuestions.QWritingTypeid = WritingTypes.WTypeId WHERE WritingQuestions.DayPlanid=@DPI", MyConn);
            //MyCmd.Parameters.AddWithValue("@DPI", CB_SELECT_PRACSET.SelectedValue);
            //// MyCmd.Parameters.AddWithValue("@DPLAN", Cb_dayplan.SelectedValue);

            //d2.Load(MyCmd.ExecuteReader());



            if (num == (d2.Rows.Count))
            { }
            else
            {
                cols = d2.Rows[num];

                label10.Text = cols[0].ToString();


                label2.Text = cols[1].ToString();
                label7.Text = cols[2].ToString();
               // a = Convert.ToDouble(cols[2]);
                label3.Text = cols[3].ToString();
                label4.Text = cols[4].ToString();
                Quesid = Convert.ToInt32(cols[5]);
                tb_ans.Text  = cols[6].ToString();

                num++;
                ques_no++;
                label11.Text = (ques_no).ToString();

            }
            max_ques = d2.Rows.Count;
            // int chk_last = max_ques;
            label12.Text = (max_ques).ToString();
            MyConn.Close();


        }

        private void BTN_my_responce_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel3.BringToFront();
            panel3.Size = new Size(940, 416);
            panel3.Location = new Point(151, 12);
            MyConn.Open();
            MyCmd = new SqlCommand("SELECT *  FROM Answer_key WHERE Quesid = @present and Studentid=@stuid", MyConn);
            MyCmd.Parameters.AddWithValue("@present", Quesid);
            MyCmd.Parameters.AddWithValue("@stuid", 18);
            DataTable qexist = new DataTable();
            qexist.Load(MyCmd.ExecuteReader());
            MyConn.Close();
            foreach (DataRow rdr in qexist.Rows)
            {
                label13.Text = rdr["Answer"].ToString();

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;

        }

        private void btn_explanation_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel4.BringToFront();
            panel4.Size = new Size(940, 416);
            panel4.Location = new Point(151, 12);
        }

       
       
    }
}
