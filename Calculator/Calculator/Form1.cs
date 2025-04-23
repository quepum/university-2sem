namespace Calculator;

public partial class Form1 : Form
{
    public Form1()
    {
        this.InitializeComponent();
    }

    private void ButtonZero_Click(object sender, EventArgs e)
    {
        if (this.textBox1.Text is "0")
        {
            this.textBox1.Text = @"0";
        }
        else
        {
            this.textBox1.Text += @"0";
        }
    }

    private void Button1_Click(object sender, EventArgs e)
    {
        if (this.textBox1.Text is "0")
        {
            this.textBox1.Text = @"1";
        }
        else
        {
            this.textBox1.Text += @"1";
        }
    }
}