namespace ARTGC
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            button4 = new Button();
            button6 = new Button();
            button7 = new Button();
            btnTestGI = new Button();
            button3 = new Button();
            btnMsg_accept = new Button();
            btnMsg_aycConnection = new Button();
            btnMsg_pickupDone = new Button();
            btnMsg_jobDone = new Button();
            btnMsg_abortStatus = new Button();
            btnMsg_detectVehicle = new Button();
            btnMsg_aycPosition = new Button();
            btnMsg_aycSpreader = new Button();
            btnMsg_reject = new Button();
            btnMsg_aycStatus = new Button();
            TB_AutoStatus = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(17, 20);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(271, 38);
            button1.TabIndex = 0;
            button1.Text = "MV TEST(viewjobtracking)";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.Control;
            dataGridViewCellStyle7.Font = new Font("Malgun Gothic", 9F);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Malgun Gothic", 9F);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(40, 40, 40);
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle8;
            dataGridView1.Location = new Point(17, 120);
            dataGridView1.Margin = new Padding(4, 5, 4, 5);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = SystemColors.Control;
            dataGridViewCellStyle9.Font = new Font("Malgun Gothic", 9F);
            dataGridViewCellStyle9.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1539, 611);
            dataGridView1.TabIndex = 1;
            // 
            // button2
            // 
            button2.Location = new Point(297, 20);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(199, 38);
            button2.TabIndex = 2;
            button2.Text = "JobOrder Serach";
            button2.UseVisualStyleBackColor = true;
            button2.Click += OnJobOrderSearch;
            // 
            // button4
            // 
            button4.Location = new Point(17, 68);
            button4.Margin = new Padding(4, 5, 4, 5);
            button4.Name = "button4";
            button4.Size = new Size(271, 38);
            button4.TabIndex = 4;
            button4.Text = "MV TEST(viewjobparameter)";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button6
            // 
            button6.Location = new Point(511, 20);
            button6.Margin = new Padding(4, 5, 4, 5);
            button6.Name = "button6";
            button6.Size = new Size(157, 38);
            button6.TabIndex = 6;
            button6.Text = "StepJobStart";
            button6.UseVisualStyleBackColor = true;
            button6.Click += StepJobStart_Click;
            // 
            // button7
            // 
            button7.Location = new Point(516, 71);
            button7.Margin = new Padding(4, 5, 4, 5);
            button7.Name = "button7";
            button7.Size = new Size(153, 38);
            button7.TabIndex = 7;
            button7.Text = "StepJobEnd";
            button7.UseVisualStyleBackColor = true;
            button7.Click += StepJobEnd_Click;
            // 
            // btnTestGI
            // 
            btnTestGI.Location = new Point(694, 20);
            btnTestGI.Margin = new Padding(4, 5, 4, 5);
            btnTestGI.Name = "btnTestGI";
            btnTestGI.Size = new Size(271, 38);
            btnTestGI.TabIndex = 8;
            btnTestGI.Text = "GI Test Start";
            btnTestGI.UseVisualStyleBackColor = true;
            btnTestGI.Click += btnTestGI_Click;
            // 
            // button3
            // 
            button3.Location = new Point(694, 68);
            button3.Margin = new Padding(4, 5, 4, 5);
            button3.Name = "button3";
            button3.Size = new Size(271, 38);
            button3.TabIndex = 9;
            button3.Text = "Get Inventory Data Test (RCS)";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // btnMsg_accept
            // 
            btnMsg_accept.Location = new Point(1564, 245);
            btnMsg_accept.Margin = new Padding(4, 5, 4, 5);
            btnMsg_accept.Name = "btnMsg_accept";
            btnMsg_accept.Size = new Size(175, 38);
            btnMsg_accept.TabIndex = 10;
            btnMsg_accept.Text = "Msg accept";
            btnMsg_accept.UseVisualStyleBackColor = true;
            btnMsg_accept.Click += btnMsg_Accept_Click;
            // 
            // btnMsg_aycConnection
            // 
            btnMsg_aycConnection.Location = new Point(1564, 181);
            btnMsg_aycConnection.Margin = new Padding(4, 5, 4, 5);
            btnMsg_aycConnection.Name = "btnMsg_aycConnection";
            btnMsg_aycConnection.Size = new Size(175, 38);
            btnMsg_aycConnection.TabIndex = 11;
            btnMsg_aycConnection.Text = "Msg Connect";
            btnMsg_aycConnection.UseVisualStyleBackColor = true;
            btnMsg_aycConnection.Click += btnMsg_aycConnection_Click;
            // 
            // btnMsg_pickupDone
            // 
            btnMsg_pickupDone.Location = new Point(1747, 245);
            btnMsg_pickupDone.Margin = new Padding(4, 5, 4, 5);
            btnMsg_pickupDone.Name = "btnMsg_pickupDone";
            btnMsg_pickupDone.Size = new Size(175, 38);
            btnMsg_pickupDone.TabIndex = 13;
            btnMsg_pickupDone.Text = "Msg pickupDone";
            btnMsg_pickupDone.UseVisualStyleBackColor = true;
            btnMsg_pickupDone.Click += btnMsg_pickupDone_Click;
            // 
            // btnMsg_jobDone
            // 
            btnMsg_jobDone.Location = new Point(1930, 245);
            btnMsg_jobDone.Margin = new Padding(4, 5, 4, 5);
            btnMsg_jobDone.Name = "btnMsg_jobDone";
            btnMsg_jobDone.Size = new Size(175, 38);
            btnMsg_jobDone.TabIndex = 14;
            btnMsg_jobDone.Text = "Msg jobDone";
            btnMsg_jobDone.UseVisualStyleBackColor = true;
            btnMsg_jobDone.Click += btnMsg_jobDone_Click;
            // 
            // btnMsg_abortStatus
            // 
            btnMsg_abortStatus.Location = new Point(1564, 293);
            btnMsg_abortStatus.Margin = new Padding(4, 5, 4, 5);
            btnMsg_abortStatus.Name = "btnMsg_abortStatus";
            btnMsg_abortStatus.Size = new Size(175, 38);
            btnMsg_abortStatus.TabIndex = 15;
            btnMsg_abortStatus.Text = "Msg abortStatus";
            btnMsg_abortStatus.UseVisualStyleBackColor = true;
            btnMsg_abortStatus.Click += btnMsg_abortStatus_Click;
            // 
            // btnMsg_detectVehicle
            // 
            btnMsg_detectVehicle.Location = new Point(1564, 341);
            btnMsg_detectVehicle.Margin = new Padding(4, 5, 4, 5);
            btnMsg_detectVehicle.Name = "btnMsg_detectVehicle";
            btnMsg_detectVehicle.Size = new Size(175, 38);
            btnMsg_detectVehicle.TabIndex = 16;
            btnMsg_detectVehicle.Text = "Msg detectVehicle";
            btnMsg_detectVehicle.UseVisualStyleBackColor = true;
            btnMsg_detectVehicle.Click += btnMsg_detectVehicle_Click;
            // 
            // btnMsg_aycPosition
            // 
            btnMsg_aycPosition.Location = new Point(1747, 455);
            btnMsg_aycPosition.Margin = new Padding(4, 5, 4, 5);
            btnMsg_aycPosition.Name = "btnMsg_aycPosition";
            btnMsg_aycPosition.Size = new Size(175, 38);
            btnMsg_aycPosition.TabIndex = 18;
            btnMsg_aycPosition.Text = "Msg aycPosition";
            btnMsg_aycPosition.UseVisualStyleBackColor = true;
            btnMsg_aycPosition.Click += btnMsg_aycPosition_Click;
            // 
            // btnMsg_aycSpreader
            // 
            btnMsg_aycSpreader.Location = new Point(1925, 455);
            btnMsg_aycSpreader.Margin = new Padding(4, 5, 4, 5);
            btnMsg_aycSpreader.Name = "btnMsg_aycSpreader";
            btnMsg_aycSpreader.Size = new Size(175, 38);
            btnMsg_aycSpreader.TabIndex = 19;
            btnMsg_aycSpreader.Text = "Msg aycSpreader";
            btnMsg_aycSpreader.UseVisualStyleBackColor = true;
            btnMsg_aycSpreader.Click += btnMsg_aycSpreader_Click;
            // 
            // btnMsg_reject
            // 
            btnMsg_reject.Location = new Point(1564, 524);
            btnMsg_reject.Margin = new Padding(4, 5, 4, 5);
            btnMsg_reject.Name = "btnMsg_reject";
            btnMsg_reject.Size = new Size(175, 38);
            btnMsg_reject.TabIndex = 20;
            btnMsg_reject.Text = "Msg reject";
            btnMsg_reject.UseVisualStyleBackColor = true;
            btnMsg_reject.Click += btnMsg_reject_Click;
            // 
            // btnMsg_aycStatus
            // 
            btnMsg_aycStatus.Location = new Point(1564, 455);
            btnMsg_aycStatus.Margin = new Padding(4, 5, 4, 5);
            btnMsg_aycStatus.Name = "btnMsg_aycStatus";
            btnMsg_aycStatus.Size = new Size(175, 38);
            btnMsg_aycStatus.TabIndex = 21;
            btnMsg_aycStatus.Text = "Msg aycStatus";
            btnMsg_aycStatus.UseVisualStyleBackColor = true;
            btnMsg_aycStatus.Click += btnMsg_aycStatus_Click;
            // 
            // TB_AutoStatus
            // 
            TB_AutoStatus.Location = new Point(1747, 407);
            TB_AutoStatus.Name = "TB_AutoStatus";
            TB_AutoStatus.Size = new Size(150, 31);
            TB_AutoStatus.TabIndex = 22;
            TB_AutoStatus.Text = "1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1564, 407);
            label1.Name = "label1";
            label1.Size = new Size(88, 25);
            label1.TabIndex = 23;
            label1.Text = "autoSts : ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2133, 750);
            Controls.Add(label1);
            Controls.Add(TB_AutoStatus);
            Controls.Add(btnMsg_aycStatus);
            Controls.Add(btnMsg_reject);
            Controls.Add(btnMsg_aycSpreader);
            Controls.Add(btnMsg_aycPosition);
            Controls.Add(btnMsg_detectVehicle);
            Controls.Add(btnMsg_abortStatus);
            Controls.Add(btnMsg_jobDone);
            Controls.Add(btnMsg_pickupDone);
            Controls.Add(btnMsg_aycConnection);
            Controls.Add(btnMsg_accept);
            Controls.Add(button3);
            Controls.Add(btnTestGI);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private DataGridView dataGridView1;
        private Button button2;
        private Button button4;
        private Button button6;
        private Button button7;
        private Button btnTestGI;
        private Button button3;
        private Button btnMsg_accept;
        private Button btnMsg_aycConnection;
        private Button btnMsg_pickupDone;
        private Button btnMsg_jobDone;
        private Button btnMsg_abortStatus;
        private Button btnMsg_detectVehicle;
        private Button btnMsg_aycPosition;
        private Button btnMsg_aycSpreader;
        private Button btnMsg_reject;
        private Button btnMsg_aycStatus;
        private TextBox TB_AutoStatus;
        private Label label1;
    }
}
