namespace GeminiWork
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


        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtFileName = new TextBox();
            btnCheck = new Button();
            btnGemini = new Button();
            btnClear = new Button();
            label1 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            rtbResult = new RichTextBox();
            lblRiskLevel = new Label();
            progressRisk = new ProgressBar();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            // 
            // txtFileName
            // 
            txtFileName.Location = new Point(10, 62);
            txtFileName.Name = "txtFileName";
            txtFileName.Size = new Size(100, 27);
            txtFileName.TabIndex = 0;
            // 
            // btnCheck
            // 
            btnCheck.Location = new Point(6, 113);
            btnCheck.Name = "btnCheck";
            btnCheck.Size = new Size(104, 29);
            btnCheck.TabIndex = 2;
            btnCheck.Text = "Перевірити";
            btnCheck.UseVisualStyleBackColor = true;
            // 
            // btnGemini
            // 
            btnGemini.Location = new Point(179, 113);
            btnGemini.Name = "btnGemini";
            btnGemini.Size = new Size(134, 29);
            btnGemini.TabIndex = 3;
            btnGemini.Text = "Аналіз Gemini";
            btnGemini.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(95, 164);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 4;
            btnClear.Text = "Очистити";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 23);
            label1.Name = "label1";
            label1.Size = new Size(183, 20);
            label1.TabIndex = 0;
            label1.Text = "Введіть назву вкладення:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtFileName);
            groupBox1.Controls.Add(btnGemini);
            groupBox1.Controls.Add(btnClear);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnCheck);
            groupBox1.Location = new Point(28, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(319, 226);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Введення даних";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rtbResult);
            groupBox2.Controls.Add(lblRiskLevel);
            groupBox2.Controls.Add(progressRisk);
            groupBox2.Location = new Point(437, 23);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(250, 215);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Результати аналізу";
            // 
            // rtbResult
            // 
            rtbResult.Location = new Point(125, 95);
            rtbResult.Name = "rtbResult";
            rtbResult.Size = new Size(125, 120);
            rtbResult.TabIndex = 2;
            rtbResult.Text = "";
            // 
            // lblRiskLevel
            // 
            lblRiskLevel.AutoSize = true;
            lblRiskLevel.Location = new Point(17, 105);
            lblRiskLevel.Name = "lblRiskLevel";
            lblRiskLevel.Size = new Size(50, 20);
            lblRiskLevel.TabIndex = 1;
            lblRiskLevel.Text = "label2";
            // 
            // progressRisk
            // 
            progressRisk.Location = new Point(9, 38);
            progressRisk.Name = "progressRisk";
            progressRisk.Size = new Size(125, 29);
            progressRisk.TabIndex = 0;
            // 
            // Form1
            // 
        }

        #endregion
        private TextBox txtFileName;
        private Button btnCheck;
        private Button btnGemini;
        private Button btnClear;
        private Label label1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label lblRiskLevel;
        private ProgressBar progressRisk;
        private RichTextBox rtbResult;
    }
}
