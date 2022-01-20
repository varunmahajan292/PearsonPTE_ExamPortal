using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Forms;
using System.IO;


namespace Pte_project
{
    
    class Pte_connection
    {
        string fileLoc = @"C:\Users\s2\Desktop\Pte_project\abc.txt";
        private static string Conn;
        //private static string [] dyn_conn;

        public static string ConnectionS_tring
        {
            
            get { return Conn; }
            set { Conn = value; }
        }

        public Pte_connection()
        {
            string[] ary_var;
            string s;
            
            if (File.Exists(fileLoc))
            {
                using (TextReader tr = new StreamReader(fileLoc))
                {
                    //MessageBox.Show(tr.ReadLine());

                    s = tr.ReadLine();
                    ary_var = s.Split('#', '\n');

                }
            }
           
            
            // MyConn.ConnectionString = @"Data Source=STYLE;Initial Catalog=SalonDB;Integrated Security=True";
            Conn = @"Data Source=VARUN-PC;Initial Catalog=PTE_DB;Integrated Security=True";
            // MyConn.ConnectionString = @"Data Source=.\sqlexpress;AttachDbFilename=C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\DBGMark.mdf;Initial Catalog=DBGmark;Integrated Security=True";
            // MyConn.ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\DBGMark.mdf;Integrated Security=True;User Instance=True";

        }
//----------------------------------------------------//////////////////////--------------------------//////////////////////-----------------/
        //public get_db_info()
        //{
        //if (File.Exists(fileLoc))
        //    {
        //        using (TextReader tr = new StreamReader(fileLoc))
        //        {
        //            MessageBox.Show(tr.ReadLine());
        //        }
        //    }
        
        //}


    }
}
