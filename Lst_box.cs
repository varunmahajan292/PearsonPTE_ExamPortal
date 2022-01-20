using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pte_project
{
    public partial class Lst_box : Form
    {
        string storage_text, storage_acc_name, a, b, c, d;
        int storage_tab_index;
        public Lst_box()
        {
            InitializeComponent();
        }

        private void Lst_box_Load(object sender, EventArgs e)
        {

        }
        private void button_selection_in_both_panels(object sender, EventArgs e)
        {
            Button Btn = (Button)sender;

            selected_button();
            selected_button_in_panel2();
            Btn.BackColor = Color.Blue;


        }



        private void selected_button()
        {
            foreach (Button Btn in PN1.Controls)
            {

                Btn.BackColor = Color.White;
            }


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
                storage_tab_index=0;
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

        private void T_PN1_Click(object sender, EventArgs e)
        {
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
    

