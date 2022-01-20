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
    public partial class Form_for_dynamic_connection : Form
    {
        string[]  ary_var;
        string s;
        public Form_for_dynamic_connection()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            //file location
            string fileLoc = @"C:\Users\varun\Desktop\Pte_project\Pte_project\abc.txt";
          
            
            // create a text file on the upper location
            FileStream fs = null;
            if (!File.Exists(fileLoc))
            {
                using (fs = File.Create(fileLoc))
                {

                }
            }

            // write to a txt file 
            if (File.Exists(fileLoc))
            {
                using (StreamWriter sw = new StreamWriter(fileLoc))
                {
                    //sw.Write("Some sample text for the file");
                    sw.Write(textBox1 .Text +"#" );
                    sw.Write(textBox2.Text + "#");
                    sw.Write(textBox3.Text + "#");
                    sw.Write(textBox4.Text);
                 
                
                }
            }
            
            
            //reading from txt file
            //if (File.Exists(fileLoc))
            //{
            //    using (TextReader tr = new StreamReader(fileLoc))
            //    {
            //        //MessageBox.Show(tr.ReadLine());
                    
            //  s = tr.ReadLine ();
            //  ary_var = s.Split('#', '\n');
                
            //    }
            //}


        }

        
    }
}
