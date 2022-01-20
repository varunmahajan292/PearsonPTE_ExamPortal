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
    public partial class Answer_form : Form
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
       
        double     a;
        double  time_fr_work;   

        public Answer_form()
        {
            InitializeComponent();
        }

        private void Answer_form_Load(object sender, EventArgs e)
        {
            MyConn.ConnectionString = Pte_connection.ConnectionS_tring;
            cmb_fill_choose_ps();
            panel2.Visible = true;
            panel2.BringToFront();
            panel2.Size = new Size(1326, 551);
            panel2.Location = new Point(12, 12);
            label11.Text = (ques_no).ToString();
            panel3.Visible = false;
           
            
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
                    a = Convert.ToDouble(cols[2]);
                    label3.Text = cols[3].ToString();
                    label4.Text = cols[4].ToString();
                    Quesid = Convert.ToInt32(cols[5]);
                    Corr_ans= cols[6].ToString ();
                    
                    num++;
                    ques_no++;
                    label11.Text = (ques_no).ToString();

                }
              max_ques = d2.Rows.Count;
             // int chk_last = max_ques;
              label12.Text = (max_ques).ToString ();
               MyConn.Close();
               

        }

        
       
        private void bTN_NEXT_Click(object sender, EventArgs e)
        {
            insert_update_answer_key();
            if (num >= 1)
            {
                btn_prev.Enabled = true;
            }

            if (num == max_ques - 1)
            {
                bTN_NEXT.Enabled = false;
            }
            else if(num == max_ques-1)
            {
                bTN_NEXT.Enabled = true ;
            }


            show_questions();
            MyConn.Open();
            MyCmd = new SqlCommand("SELECT *  FROM Answer_key WHERE Quesid = @present and Studentid=@stuid", MyConn);
            MyCmd.Parameters.AddWithValue("@present", Quesid);
            MyCmd.Parameters.AddWithValue("@stuid", 18);
            DataTable qexist = new DataTable();
            qexist.Load(MyCmd.ExecuteReader());
            MyConn.Close();
            foreach (DataRow rdr in qexist.Rows)
            {
                tb_ans.Text = rdr["Answer"].ToString();

            }
            
            fn_TIMERSTART();
            
           
        }
//################################33Panel START WORKING ON CHOOSE AND START BUTTON#################################################33
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

        private void btn_start_Click(object sender, EventArgs e)
        {
            MyConn.Open();

            MyCmd = new SqlCommand("select DayPlan.PlanNo, WritingTypes.WType, WritingTypes.ATime, WritingTypes.TypeDescription, WritingQuestions.Question, WritingQuestions.Qid, WritingQuestions.Corr_Answer From WritingQuestions INNER JOIN DayPlan ON WritingQuestions.DayPlanid = DayPlan.DPlan INNER JOIN WritingTypes ON WritingQuestions.QWritingTypeid = WritingTypes.WTypeId WHERE WritingQuestions.DayPlanid=@DPI", MyConn);
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
                a = Convert.ToDouble(cols[2]);
                label3.Text = cols[3].ToString();
                label4.Text = cols[4].ToString();
                Quesid = Convert.ToInt32(cols[5]);
                Corr_ans = cols[6].ToString();

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
            fn_TIMERSTART();
            if (num == 1)
            {
                btn_prev.Enabled = false;
                bTN_NEXT.Enabled = true;
            }
            

        }

        //################################33---STOP WORKING ON CHOOSE AND START BUTTON#################################################33
        public void fn_TIMERSTART() 
        {
           
            
                tmr1.Start();
                tmr1.Interval = 1000;
                time_fr_work = a * 60;
           
          
        }

        private void tmr1_Tick(object sender, EventArgs e)
        {
            TimeSpan t = TimeSpan.FromSeconds(time_fr_work);

            string answer = string.Format("{1:D2}m:{2:D2}s",
                            t.Hours,
                            t.Minutes,
                            t.Seconds,
                            t.Milliseconds);
            label7.Text = Convert.ToString(answer);
            time_fr_work -= 1;
                
            if (num == max_ques && time_fr_work == 0)
            {
                
                tmr1.Stop();
                MessageBox.Show("Your Time Has Expired And Please Check Your Answer Key ");
                panel3.Visible = true;
                panel3.Size = new Size(1326, 551);
                panel3.Location = new Point(12, 12);
                panel3.BringToFront(); 


            }
            
            else if (time_fr_work == 0)
            {
                insert_update_answer_key();
                    show_questions();
                    fn_TIMERSTART();
                   
                   
                }
                
            }
    //   public void fn_stp_last_ques()
    //{
    //       if 
    
    //}


        //##########################--------------functions for cut copy paste& scroll---###############################333##########33

        private void button1_Click(object sender, EventArgs e)
        {
            if (tb_ans.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                tb_ans.Cut();

        }

        private void button3_Click(object sender, EventArgs e)
        {// Ensure that text is selected in the text box.   
            if (tb_ans.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                tb_ans.Copy();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Determine if there is any text in the Clipboard to paste into the text box.
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (tb_ans.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        tb_ans.SelectionStart = tb_ans.SelectionStart + tb_ans.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                tb_ans.Paste();
            }
        }

        private void tb_ans_TextChanged(object sender, EventArgs e)
        {
            tb_ans.ScrollBars = ScrollBars.Both;
        }

        private void btn_prev_Click(object sender, EventArgs e)
        {

            insert_update_answer_key();
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
            a = Convert.ToDouble(cols[2]);
            label3.Text = cols[3].ToString();
            label4.Text = cols[4].ToString();
            Quesid = Convert.ToInt32(cols[5]);
            Corr_ans = cols[6].ToString();

            num++;
            ques_no--;
            label11.Text = (ques_no).ToString();

            //}
            max_ques = d2.Rows.Count;
            // int chk_last = max_ques;
            label12.Text = (max_ques).ToString();
            MyConn.Close();
            MyConn.Open();/*open connection by varible*/


            MyCmd = new SqlCommand("SELECT *  FROM Answer_key WHERE Quesid = @present and Studentid=@stuid", MyConn);
            MyCmd.Parameters.AddWithValue("@present", Quesid);
            MyCmd.Parameters.AddWithValue("@stuid", 18);
            DataTable qexists = new DataTable();
            qexists.Load(MyCmd.ExecuteReader());
            MyConn.Close();
            foreach (DataRow rdr in qexists.Rows)
            {
                tb_ans.Text = rdr["Answer"].ToString();

            }





            //// if (num == max_ques - 1)
            // {
            //     bTN_NEXT.Enabled = false;
            // }
            // show_questions();
            fn_TIMERSTART();
        }
        
        ///##########################-----------end functions for cut copy paste& scroll---###############################333##########33
        ///
        //############################################################---CODE FOR ANSWER KEY----------###########################################3333333
        public void insert_update_answer_key()
        {
            MyConn.Open();/*open connection by varible*/


            MyCmd = new SqlCommand("SELECT *  FROM Answer_key WHERE Quesid = @present and Studentid=@stuid", MyConn);
            MyCmd.Parameters.AddWithValue("@present", Quesid);
            MyCmd.Parameters.AddWithValue("@stuid", 87);
            DataTable qexist = new DataTable();
            qexist.Load(MyCmd.ExecuteReader());
            MyConn.Close();
            
            if(qexist.Rows.Count!=0)
            {
                 MyConn.Open();/*open connection by varible*/
               

             MyCmd = new SqlCommand("SP_AnswerKey", MyConn);/*fire insert query by using connection*/
             MyCmd.CommandType = CommandType.StoredProcedure;/* which type of  query you passed in above line we write text because we write direct query like */
             MyCmd.CommandTimeout = 120;/*connection time out after secs*/


             MyCmd.Parameters.AddWithValue("@ANSID", 0);
             MyCmd.Parameters.AddWithValue("@QID", Quesid);
             MyCmd.Parameters.AddWithValue("@STUDENTID", 19);
             MyCmd.Parameters.AddWithValue("@ANSWER", tb_ans.Text);
             MyCmd.Parameters.AddWithValue("@TIMESAVE", 0);
             MyCmd.Parameters.AddWithValue("@Marks", 0);
            
             MyCmd.Parameters.AddWithValue("@Type", "Update");
             MyCmd.ExecuteNonQuery();/*what you expect in return*/
            

             MyConn.Close();
             tb_ans.Text = "";
            }
            else
            {
                  MyConn.Open();/*open connection by varible*/


            MyCmd = new SqlCommand("SP_AnswerKey", MyConn);/*fire insert query by using connection*/
            MyCmd.CommandType = CommandType.StoredProcedure;/* which type of  query you passed in above line we write text because we write direct query like */
            MyCmd.CommandTimeout = 120;/*connection time out after secs*/


          
             MyCmd.Parameters.AddWithValue("@ANSID",0 );
            MyCmd.Parameters.AddWithValue("@QID",Quesid);
            MyCmd.Parameters.AddWithValue("@STUDENTID", 19);
            MyCmd.Parameters.AddWithValue("@ANSWER", tb_ans.Text );
            MyCmd.Parameters.AddWithValue("@TIMESAVE", 0);
            MyCmd.Parameters.AddWithValue("@Marks", 0);
            MyCmd.Parameters.AddWithValue("@Type", "Insert");
            MyCmd.ExecuteNonQuery();/*what you expect in return*/


            MyConn.Close();
            tb_ans.Text = "";
          

            }
            
             
          

         

        
        
        }

        private void BTN_SUBMIT_EXIT_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You Have Submit Your Test SuccessFully");
            tmr1.Stop();
            panel3.Visible = true;
            panel3.BringToFront();
            panel3.Size = new Size(1326, 551);
            panel3.Location = new Point(12, 12);
            

        }

        private void label13_Click(object sender, EventArgs e)
        {
            Answer_key ak = new Answer_key();
            ak.Show();
        }

       
           
        
    
    }
           
    }

