using System;
using System.Drawing;
using System.Windows.Forms;

namespace EmailAttachmentScanner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetupFormStyle();
        }

        private void SetupFormStyle()
        {
            this.Text = "Email Attachment Scanner - Аналізатор небезпечних вкладень";
            this.Size = new Size(720, 580);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFileName.Text))
            {
                MessageBox.Show("Будь ласка, введіть назву вкладення!",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fileName = txtFileName.Text.Trim();
            var analyzer = new AttachmentAnalyzer(fileName);

            // Отримуємо аналіз
            string report = analyzer.GetAnalysisReport();
            int riskLevel = analyzer.CalculateRiskLevel();

            // Виводимо результат
            rtbResult.Text = report;
            rtbResult.ForeColor = Color.Black;

            // Налаштовуємо ProgressBar
            progressRisk.Value = riskLevel;

            // Колір прогрес-бару залежно від ризику
            if (riskLevel >= 75)
                progressRisk.ForeColor = Color.Red;
            else if (riskLevel >= 50)
                progressRisk.ForeColor = Color.Orange;
            else
                progressRisk.ForeColor = Color.Green;

            lblRiskLevel.Text = $"Рівень ризику: {riskLevel}%";
            lblRiskLevel.ForeColor = progressRisk.ForeColor;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFileName.Clear();
            rtbResult.Clear();
            progressRisk.Value = 0;
            lblRiskLevel.Text = "Рівень ризику: 0%";
            lblRiskLevel.ForeColor = Color.Black;
            txtFileName.Focus();
        }

        private void btnGemini_Click(object sender, EventArgs e)
        {
            // Поки що заглушка. Реалізуємо пізніше
            if (string.IsNullOrWhiteSpace(rtbResult.Text))
            {
                MessageBox.Show("Спочатку виконайте локальну перевірку!",
                    "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show("Інтеграція з Gemini буде реалізована на наступному етапі.",
                "Gemini AI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Додаткові зручності
        private void txtFileName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCheck.PerformClick();
            }
        }

        private void InitializeComponent()
        {

        }
    }
}