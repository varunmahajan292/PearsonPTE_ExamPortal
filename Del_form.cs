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
    public partial class Del_form : Form
    {
        Pte_connection con = new Pte_connection();
        protected SqlConnection MyConn = new SqlConnection();/* variable declaration for make a connection*/
        protected SqlCommand MyCmd = new SqlCommand();
        DataTable DT = new DataTable();
        DataTable DT2 = new DataTable();
      
        public Del_form()
        {
            InitializeComponent();
        }

        private void Del_form_Load(object sender, EventArgs e)
        {
            MyConn.ConnectionString = Pte_connection.ConnectionS_tring;
          
        }

       
        

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //if (comboBox1.SelectedIndex == 1)
            //{


            //    DT.Rows.Clear();
            //   // dataGridView1.Rows.Clear();
            //    MyConn.Open();
            //    MyCmd = new SqlCommand("select t.WType, t.TypeDescription,q.Question,q.Corr_Answer from WritingQuestions q Inner Join WritingTypes t on q.QWritingTypeid=t.WTypeId   where q.Isactive =1", MyConn);
            //    MyCmd.CommandType = CommandType.Text;
            //    MyCmd.CommandTimeout = 120;
            //    DT.Load(MyCmd.ExecuteReader());
            //    dataGridView1.DataSource = DT;
            //    MyConn.Close();
            //    //////combo 2 fill////
            //    DT2.Rows.Clear();
            //    MyConn.Open();
            //    // DT2.Rows.Add("WType");
            //    MyCmd = new SqlCommand("select WType from WritingTypes", MyConn);
            //    MyCmd.CommandType = CommandType.Text;
            //    MyCmd.CommandTimeout = 120;
            //    DT2.Load(MyCmd.ExecuteReader());
            //    MyConn.Close();
            //    comboBox2.DisplayMember = "WType";
            //    comboBox2.ValueMember = "WType";
            //    comboBox2.DataSource = DT2;

            //    /////combo 2 fill////

            //}

            //if (comboBox1.SelectedIndex == 2)
            //{

            //    comboBox2.DataSource = null ;
            //    DT.Rows.Clear();
            //   // dataGridView1.Rows.Clear();
            //    MyConn.Open();
            //    MyCmd = new SqlCommand("select  t.LQTYPE, t.DESCP,  l.QTEXT,  l.EXPLANATION from Listening_Question l  inner join LISTENING_Qtype t on l.LQTID=T.LQTID  WHERE l.Isactive =1 ", MyConn);
            //    MyCmd.CommandType = CommandType.Text;
            //    MyCmd.CommandTimeout = 120;
            //    DT.Load(MyCmd.ExecuteReader());
            //    dataGridView1.DataSource = DT;
            //     MyConn.Close();
            //    //////combo 2 fill////
            //    DT2.Rows.Clear();
            //    MyConn.Open();
            //    // DT2.Rows.Add("WType");
            //    MyCmd = new SqlCommand("select LQTYPE from LISTENING_Qtype", MyConn);
            //    MyCmd.CommandType = CommandType.Text;
            //    MyCmd.CommandTimeout = 120;
            //    DT2.Load(MyCmd.ExecuteReader());
            //    MyConn.Close();
            //    comboBox2.DisplayMember = "LQTYPE";
            //    comboBox2.ValueMember = "LQTYPE";
            //    comboBox2.DataSource = DT2;

            //    /////combo 2 fill////

            //}
            //if (comboBox1.SelectedIndex == 3)
            //{

            //    comboBox2.DataSource = null;
            //    DT.Rows.Clear();
            //  //  dataGridView1.Rows.Clear();
            //    MyConn.Open();
            //    MyCmd = new SqlCommand("select  t.LQTYPE, t.DESCP,  l.QTEXT,  l.EXPLANATION from Listening_Question l  inner join LISTENING_Qtype t on l.LQTID=T.LQTID  WHERE l.Isactive =1 ", MyConn);
            //    MyCmd.CommandType = CommandType.Text;
            //    MyCmd.CommandTimeout = 120;
            //    DT.Load(MyCmd.ExecuteReader());
            //    dataGridView1.DataSource = DT;
            //    MyConn.Close();
            //    //////combo 2 fill////
            //    DT2.Rows.Clear();
            //    MyConn.Open();
            //    // DT2.Rows.Add("WType");
            //    MyCmd = new SqlCommand("select LQTYPE from LISTENING_Qtype", MyConn);
            //    MyCmd.CommandType = CommandType.Text;
            //    MyCmd.CommandTimeout = 120;
            //    DT2.Load(MyCmd.ExecuteReader());
            //    MyConn.Close();
            //    comboBox2.DisplayMember = "LQTYPE";
            //    comboBox2.ValueMember = "LQTYPE";
            //    comboBox2.DataSource = DT2;

            //    /////combo 2 fill////

            //}
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1 ) //writing components
            {
                DataTable DT = new DataTable();

              //  DataTable DT2 = new DataTable();
                DT.Rows.Clear();
               // dataGridView1.Rows.Clear();
                MyConn.Open();
                MyCmd = new SqlCommand("select t.WType, t.TypeDescription,q.Question,q.Corr_Answer,q.Qid from WritingQuestions q Inner Join WritingTypes t on q.QWritingTypeid=t.WTypeId   where q.Isactive =1 and t.WType=@tp", MyConn);
                MyCmd.Parameters.AddWithValue("@tp", comboBox2.SelectedValue );
                MyCmd.CommandType = CommandType.Text;
                MyCmd.CommandTimeout = 120;
                DT.Load(MyCmd.ExecuteReader());
                dataGridView1.DataSource = DT;
                MyConn.Close();
            }
            
            if (comboBox1.SelectedIndex == 2)//listening components
            {
                DataTable DT = new DataTable();

                //DataTable DT2 = new DataTable();
                DT.Rows.Clear();
                // dataGridView1.Rows.Clear();
                MyConn.Open();
                MyCmd = new SqlCommand("select  t.LQTYPE, t.DESCP,  l.QTEXT,  l.EXPLANATION, l.LQID from Listening_Question l  inner join LISTENING_Qtype t on l.LQTID=T.LQTID  WHERE l.Isactive =1 and t.LQTYPE=@tp", MyConn);
                MyCmd.Parameters.AddWithValue("@tp", comboBox2.SelectedValue);
                MyCmd.CommandType = CommandType.Text;
                MyCmd.CommandTimeout = 120;
                DT.Load(MyCmd.ExecuteReader());
                dataGridView1.DataSource = DT;
                MyConn.Close();
            }
            if (comboBox1.SelectedIndex == 3)//Reading components
            {
                DataTable DT = new DataTable();

                //DataTable DT2 = new DataTable();
                DT.Rows.Clear();
                // dataGridView1.Rows.Clear();
                MyConn.Open();
                MyCmd = new SqlCommand("select  t.QTYPE, t.QDESCRIPTION,  r.QUESTION,  r.EXPLANATION, r.RQID from ReadingQuestions r  inner join ReadingQuestionTypes t on r.RQTID=t.RQTID  WHERE r.Isactive =1 and t.QTYPE=@tp  ", MyConn);
                MyCmd.Parameters.AddWithValue("@tp", comboBox2.SelectedValue);
                MyCmd.CommandType = CommandType.Text;
                MyCmd.CommandTimeout = 120;
                DT.Load(MyCmd.ExecuteReader());
                dataGridView1.DataSource = DT;
                MyConn.Close();
            }
            if (comboBox1.SelectedIndex == 4)//speaking components
            {
                DataTable DT = new DataTable();

                //DataTable DT2 = new DataTable();
                DT.Rows.Clear();
                // dataGridView1.Rows.Clear();
                MyConn.Open();
                MyCmd = new SqlCommand("select  t.SQTYPE, t.DESCP,  s.QTEXT,  s.EXPLANATION,s.WAITINGTIME,s.RESPONSETIME,s.SQID from S_Question s  inner join S_Qtype t on s.SQTID=t.SQTID  WHERE s.Isactive =1 and t.SQTYPE=@tp ", MyConn);
                MyCmd.Parameters.AddWithValue("@tp", comboBox2.SelectedValue);
                MyCmd.CommandType = CommandType.Text;
                MyCmd.CommandTimeout = 120;
                DT.Load(MyCmd.ExecuteReader());
                dataGridView1.DataSource = DT;
                MyConn.Close();
            }
        }

        public void grd_data_call()
        {
            if (comboBox1.SelectedIndex == 1)
            {
                DataTable DT = new DataTable();

                DataTable DT2 = new DataTable();

                DT.Rows.Clear();
                // dataGridView1.Rows.Clear();
                MyConn.Open();
                MyCmd = new SqlCommand("select t.WType, t.TypeDescription,q.Question,q.Corr_Answer,q.Qid from WritingQuestions q Inner Join WritingTypes t on q.QWritingTypeid=t.WTypeId   where q.Isactive =1", MyConn);
                MyCmd.CommandType = CommandType.Text;
                MyCmd.CommandTimeout = 120;
                DT.Load(MyCmd.ExecuteReader());
                dataGridView1.DataSource = DT;
                MyConn.Close();
                //////combo 2 fill////
                DT2.Rows.Clear();
                MyConn.Open();
                // DT2.Rows.Add("WType");
                MyCmd = new SqlCommand("select WType from WritingTypes", MyConn);
                MyCmd.CommandType = CommandType.Text;
                MyCmd.CommandTimeout = 120;
                DT2.Load(MyCmd.ExecuteReader());
                MyConn.Close();
                comboBox2.DisplayMember = "WType";
                comboBox2.ValueMember = "WType";
                comboBox2.DataSource = DT2;

                /////combo 2 fill////

            }

            if (comboBox1.SelectedIndex == 2)
            {
                DataTable DT = new DataTable();
               
                DataTable DT2 = new DataTable();
                comboBox2.DataSource = null;
                DT.Rows.Clear();
                // dataGridView1.Rows.Clear();
                MyConn.Open();
                MyCmd = new SqlCommand("select  t.LQTYPE, t.DESCP,  l.QTEXT,  l.EXPLANATION,l.LQID from Listening_Question l  inner join LISTENING_Qtype t on l.LQTID=T.LQTID  WHERE l.Isactive =1 ", MyConn);
                MyCmd.CommandType = CommandType.Text;
                MyCmd.CommandTimeout = 120;
                DT.Load(MyCmd.ExecuteReader());
                dataGridView1.DataSource = DT;
                MyConn.Close();
                //////combo 2 fill////
                DT2.Rows.Clear();
                MyConn.Open();
                // DT2.Rows.Add("WType");
                MyCmd = new SqlCommand("select LQTYPE from LISTENING_Qtype", MyConn);
                MyCmd.CommandType = CommandType.Text;
                MyCmd.CommandTimeout = 120;
                DT2.Load(MyCmd.ExecuteReader());
                MyConn.Close();
                comboBox2.DisplayMember = "LQTYPE";
                comboBox2.ValueMember = "LQTYPE";
                comboBox2.DataSource = DT2;

                /////combo 2 fill////

            }
            if (comboBox1.SelectedIndex == 3)
            {
                DataTable DT = new DataTable();

                DataTable DT2 = new DataTable();
                comboBox2.DataSource = null;
                DT.Rows.Clear();
                //  dataGridView1.Rows.Clear();
                MyConn.Open();
                MyCmd = new SqlCommand("select  t.QTYPE, t.QDESCRIPTION,  r.QUESTION,  r.EXPLANATION, r.RQID from ReadingQuestions r  inner join ReadingQuestionTypes t on r.RQTID=t.RQTID  WHERE r.Isactive =1  ", MyConn);
                MyCmd.CommandType = CommandType.Text;
                MyCmd.CommandTimeout = 120;
                DT.Load(MyCmd.ExecuteReader());
                dataGridView1.DataSource = DT;
                MyConn.Close();
                //////combo 2 fill////
                DT2.Rows.Clear();
                MyConn.Open();
                // DT2.Rows.Add("WType");
                MyCmd = new SqlCommand("select QTYPE from ReadingQuestionTypes", MyConn);
                MyCmd.CommandType = CommandType.Text;
                MyCmd.CommandTimeout = 120;
                DT2.Load(MyCmd.ExecuteReader());
                MyConn.Close();
                comboBox2.DisplayMember = "QTYPE";
                comboBox2.ValueMember = "QTYPE";
                comboBox2.DataSource = DT2;

                /////combo 2 fill////

            }
            if (comboBox1.SelectedIndex == 4)
            {
                DataTable DT = new DataTable();

                DataTable DT2 = new DataTable();
                comboBox2.DataSource = null;
                DT.Rows.Clear();
                //  dataGridView1.Rows.Clear();
                MyConn.Open();
                MyCmd = new SqlCommand("select  t.SQTYPE, t.DESCP,  s.QTEXT,  s.EXPLANATION,s.WAITINGTIME,s.RESPONSETIME,s.SQID from S_Question s  inner join S_Qtype t on s.SQTID=t.SQTID  WHERE s.Isactive =1  ", MyConn);
                MyCmd.CommandType = CommandType.Text;
                MyCmd.CommandTimeout = 120;
                DT.Load(MyCmd.ExecuteReader());
                dataGridView1.DataSource = DT;
                MyConn.Close();
                //////combo 2 fill////
                DT2.Rows.Clear();
                MyConn.Open();
                // DT2.Rows.Add("WType");
                MyCmd = new SqlCommand("select SQTYPE from S_Qtype", MyConn);
                MyCmd.CommandType = CommandType.Text;
                MyCmd.CommandTimeout = 120;
                DT2.Load(MyCmd.ExecuteReader());
                MyConn.Close();
                comboBox2.DisplayMember = "SQTYPE";
                comboBox2.ValueMember = "SQTYPE";
                comboBox2.DataSource = DT2;

                /////combo 2 fill////

            }
        
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            grd_data_call();
            
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                MyConn.Open();
                MyCmd = new SqlCommand("UPDATE  WritingQuestions set Isactive =0  WHERE Qid =@qid  ", MyConn);
                MyCmd.Parameters.AddWithValue("@qid", dataGridView1.CurrentRow.Cells[4].Value);
                MyCmd.CommandType = CommandType.Text;
                MyCmd.CommandTimeout = 120;
                MyCmd.ExecuteNonQuery();
                MyConn.Close();


            }
            if (comboBox1.SelectedIndex == 2)
            {
                MyConn.Open();
                MyCmd = new SqlCommand("UPDATE   Listening_Question set Isactive =0  WHERE LQid =@qid  ", MyConn);
              MyCmd.Parameters.AddWithValue ("@qid",dataGridView1 .CurrentRow .Cells [4].Value ) ;
                MyCmd.CommandType = CommandType.Text;
                MyCmd.CommandTimeout = 120;
                MyCmd .ExecuteNonQuery ();
                MyConn.Close();


            }
            if (comboBox1.SelectedIndex == 3)
            {
                MyConn.Open();
                MyCmd = new SqlCommand("UPDATE ReadingQuestions set Isactive =0  WHERE RQid =@qid  ", MyConn);
                MyCmd.Parameters.AddWithValue ("@qid",dataGridView1 .CurrentRow .Cells [4].Value) ;
                MyCmd.CommandType = CommandType.Text;
                MyCmd.CommandTimeout = 120;
                MyCmd .ExecuteNonQuery ();
                MyConn.Close();

            }
            if (comboBox1.SelectedIndex == 4)
            {
                MyConn.Open();
                MyCmd = new SqlCommand("UPDATE   S_Question set Isactive =0  WHERE SQid =@qid  ", MyConn);
                MyCmd.Parameters.AddWithValue ("@qid",dataGridView1 .CurrentRow .Cells [6].Value) ;
                MyCmd.CommandType = CommandType.Text;
                MyCmd.CommandTimeout = 120;
                MyCmd .ExecuteNonQuery ();
                MyConn.Close();


            }
            grd_data_call();
        }

        
        
       
    }
}
