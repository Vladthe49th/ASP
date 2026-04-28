namespace Lab5_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            int start = int.Parse(textBox1.Text);
            int end = int.Parse(textBox2.Text);

            for (int i = start; i <= end; i++)
            {
                listBox1.Items.Add(i);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double product = 1;
            int count = listBox1.Items.Count;

            foreach (var item in listBox1.Items)
            {
                product *= Convert.ToDouble(item);
            }

            double result = Math.Pow(product, 1.0 / count);
            textBox3.Text = result.ToString();
        }
    }
}
