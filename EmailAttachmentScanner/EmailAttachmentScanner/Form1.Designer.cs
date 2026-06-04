namespace EmailAttachmentScanner
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
            groupBox1 = new GroupBox();
            btnClear = new Button();
            btnGemini = new Button();
            btnCheck = new Button();
            txtFileName = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            rtbResult = new RichTextBox();
            lblRiskLevel = new Label();
            progressRisk = new ProgressBar();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnClear);
            groupBox1.Controls.Add(btnGemini);
            groupBox1.Controls.Add(btnCheck);
            groupBox1.Controls.Add(txtFileName);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(23, 34);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(323, 208);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Введення даних";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(101, 162);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 4;
            btnClear.Text = "Очистити";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnGemini
            // 
            btnGemini.Location = new Point(172, 104);
            btnGemini.Name = "btnGemini";
            btnGemini.Size = new Size(136, 29);
            btnGemini.TabIndex = 3;
            btnGemini.Text = "Аналіз Gemini";
            btnGemini.UseVisualStyleBackColor = true;
            btnGemini.Click += btnGemini_Click;
            // 
            // btnCheck
            // 
            btnCheck.Location = new Point(11, 104);
            btnCheck.Name = "btnCheck";
            btnCheck.Size = new Size(118, 29);
            btnCheck.TabIndex = 2;
            btnCheck.Text = "Перевірити";
            btnCheck.UseVisualStyleBackColor = true;
            btnCheck.Click += btnCheck_Click;
            // 
            // txtFileName
            // 
            txtFileName.Location = new Point(4, 51);
            txtFileName.Name = "txtFileName";
            txtFileName.Size = new Size(125, 27);
            txtFileName.TabIndex = 1;
            txtFileName.KeyDown += txtFileName_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 23);
            label1.Name = "label1";
            label1.Size = new Size(183, 20);
            label1.TabIndex = 0;
            label1.Text = "Введіть назву вкладення:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rtbResult);
            groupBox2.Controls.Add(lblRiskLevel);
            groupBox2.Controls.Add(progressRisk);
            groupBox2.Location = new Point(428, 78);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(331, 222);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Результат аналізу";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // rtbResult
            // 
            rtbResult.Location = new Point(206, 102);
            rtbResult.Name = "rtbResult";
            rtbResult.Size = new Size(125, 120);
            rtbResult.TabIndex = 2;
            rtbResult.Text = "";
            // 
            // lblRiskLevel
            // 
            lblRiskLevel.AutoSize = true;
            lblRiskLevel.Location = new Point(10, 82);
            lblRiskLevel.Name = "lblRiskLevel";
            lblRiskLevel.Size = new Size(50, 20);
            lblRiskLevel.TabIndex = 1;
            lblRiskLevel.Text = "label2";
            lblRiskLevel.Click += label2_Click;
            // 
            // progressRisk
            // 
            progressRisk.Location = new Point(106, 39);
            progressRisk.Name = "progressRisk";
            progressRisk.Size = new Size(125, 29);
            progressRisk.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtFileName;
        private Label label1;
        private GroupBox groupBox2;
        private Button btnClear;
        private Button btnGemini;
        private Button btnCheck;
        private RichTextBox rtbResult;
        private Label lblRiskLevel;
        private ProgressBar progressRisk;
    }
}
