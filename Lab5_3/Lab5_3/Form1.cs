namespace Lab5_3
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
            int step = int.Parse(textBox3.Text);

            for (int i = start; i <= end; i += step)
            {
                listBox1.Items.Add(i);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();

            foreach (var item in listBox1.Items)
            {
                int number = Convert.ToInt32(item);

                if (number > 0)
                {
                    listBox2.Items.Add(number);
                }
            }
        }
    }
}
