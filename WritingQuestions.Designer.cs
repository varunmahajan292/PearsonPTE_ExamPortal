namespace Pte_project
{
    partial class WritingQuestions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WritingQuestions));
            this.label1 = new System.Windows.Forms.Label();
            this.Cb_dayplan = new System.Windows.Forms.ComboBox();
            this.cb_question_type = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_ques = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_corr_ans = new System.Windows.Forms.TextBox();
            this.btn_clr_txtboxes = new System.Windows.Forms.Button();
            this.btn_update_ques = new System.Windows.Forms.Button();
            this.btn_add_question = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comb1 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_explanation = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(160, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Day Plan";
            // 
            // Cb_dayplan
            // 
            this.Cb_dayplan.FormattingEnabled = true;
            this.Cb_dayplan.Location = new System.Drawing.Point(269, 49);
            this.Cb_dayplan.Name = "Cb_dayplan";
            this.Cb_dayplan.Size = new System.Drawing.Size(258, 21);
            this.Cb_dayplan.TabIndex = 2;
            this.Cb_dayplan.SelectedIndexChanged += new System.EventHandler(this.Cb_dayplan_SelectedIndexChanged);
            // 
            // cb_question_type
            // 
            this.cb_question_type.FormattingEnabled = true;
            this.cb_question_type.Location = new System.Drawing.Point(269, 76);
            this.cb_question_type.Name = "cb_question_type";
            this.cb_question_type.Size = new System.Drawing.Size(258, 21);
            this.cb_question_type.TabIndex = 4;
            this.cb_question_type.SelectedIndexChanged += new System.EventHandler(this.cb_question_type_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(76, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select Question Type (Writing)";
            // 
            // tb_ques
            // 
            this.tb_ques.Location = new System.Drawing.Point(269, 151);
            this.tb_ques.Multiline = true;
            this.tb_ques.Name = "tb_ques";
            this.tb_ques.Size = new System.Drawing.Size(865, 100);
            this.tb_ques.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(118, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Write Your QUESTION";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(59, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Write Your CORRECT ANSWER";
            // 
            // tb_corr_ans
            // 
            this.tb_corr_ans.Location = new System.Drawing.Point(269, 257);
            this.tb_corr_ans.Multiline = true;
            this.tb_corr_ans.Name = "tb_corr_ans";
            this.tb_corr_ans.Size = new System.Drawing.Size(474, 126);
            this.tb_corr_ans.TabIndex = 7;
            // 
            // btn_clr_txtboxes
            // 
            this.btn_clr_txtboxes.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_clr_txtboxes.Location = new System.Drawing.Point(452, 398);
            this.btn_clr_txtboxes.Name = "btn_clr_txtboxes";
            this.btn_clr_txtboxes.Size = new System.Drawing.Size(75, 52);
            this.btn_clr_txtboxes.TabIndex = 11;
            this.btn_clr_txtboxes.Text = "Clear ";
            this.btn_clr_txtboxes.UseVisualStyleBackColor = false;
            this.btn_clr_txtboxes.Click += new System.EventHandler(this.btn_clr_txtboxes_Click);
            // 
            // btn_update_ques
            // 
            this.btn_update_ques.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_update_ques.Location = new System.Drawing.Point(359, 398);
            this.btn_update_ques.Name = "btn_update_ques";
            this.btn_update_ques.Size = new System.Drawing.Size(75, 52);
            this.btn_update_ques.TabIndex = 10;
            this.btn_update_ques.Text = "Update";
            this.btn_update_ques.UseVisualStyleBackColor = false;
            this.btn_update_ques.Click += new System.EventHandler(this.btn_update_ques_Click);
            // 
            // btn_add_question
            // 
            this.btn_add_question.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_add_question.Location = new System.Drawing.Point(269, 403);
            this.btn_add_question.Name = "btn_add_question";
            this.btn_add_question.Size = new System.Drawing.Size(75, 52);
            this.btn_add_question.TabIndex = 9;
            this.btn_add_question.Text = "Add";
            this.btn_add_question.UseVisualStyleBackColor = false;
            this.btn_add_question.Click += new System.EventHandler(this.btn_add_question_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(546, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(269, 106);
            this.label6.MaximumSize = new System.Drawing.Size(900, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(863, 32);
            this.label6.TabIndex = 14;
            this.label6.Text = resources.GetString("label6.Text");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(692, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 37);
            this.button1.TabIndex = 15;
            this.button1.Text = "Search ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.comb1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(62, 430);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(179, 41);
            this.panel1.TabIndex = 16;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(269, 352);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(192, 33);
            this.button2.TabIndex = 21;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(192, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Select Day Plan No";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(180, 60);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(176, 21);
            this.comboBox1.TabIndex = 19;
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(416, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Select Writing Type";
            // 
            // comb1
            // 
            this.comb1.FormattingEnabled = true;
            this.comb1.Location = new System.Drawing.Point(405, 59);
            this.comb1.Name = "comb1";
            this.comb1.Size = new System.Drawing.Size(180, 21);
            this.comb1.TabIndex = 17;
            this.comb1.SelectionChangeCommitted += new System.EventHandler(this.comb1_SelectionChangeCommitted);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column6,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column2,
            this.Column7,
            this.Column8});
            this.dataGridView1.Location = new System.Drawing.Point(141, 168);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(577, 128);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Selected Day Plan";
            this.Column1.Name = "Column1";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Selected Question Type";
            this.Column6.Name = "Column6";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Question";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Correct Answer";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "ID";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "id of dayplan";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Id if writing types";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Explanation";
            this.Column8.Name = "Column8";
            // 
            // tb_explanation
            // 
            this.tb_explanation.Location = new System.Drawing.Point(749, 280);
            this.tb_explanation.Multiline = true;
            this.tb_explanation.Name = "tb_explanation";
            this.tb_explanation.Size = new System.Drawing.Size(392, 103);
            this.tb_explanation.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(793, 261);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 16);
            this.label9.TabIndex = 18;
            this.label9.Text = "EXPLANATION";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(421, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(123, 24);
            this.label10.TabIndex = 25;
            this.label10.Text = "Writing Section";
            // 
            // WritingQuestions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.MediumPurple;
            this.ClientSize = new System.Drawing.Size(1157, 485);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tb_explanation);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_clr_txtboxes);
            this.Controls.Add(this.btn_update_ques);
            this.Controls.Add(this.btn_add_question);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_corr_ans);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_ques);
            this.Controls.Add(this.cb_question_type);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Cb_dayplan);
            this.Controls.Add(this.label1);
            this.Name = "WritingQuestions";
            this.Text = "WritingQuestions";
            this.Load += new System.EventHandler(this.WritingQuestions_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Cb_dayplan;
        private System.Windows.Forms.ComboBox cb_question_type;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_ques;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_corr_ans;
        private System.Windows.Forms.Button btn_clr_txtboxes;
        private System.Windows.Forms.Button btn_update_ques;
        private System.Windows.Forms.Button btn_add_question;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comb1;
        private System.Windows.Forms.TextBox tb_explanation;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Label label10;

    }
}