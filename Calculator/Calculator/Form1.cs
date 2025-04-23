namespace Calculator;

/// <summary>
/// eds.
/// </summary>
public partial class Form1 : Form
{
    public Form1()
    {
        this.InitializeComponent();
    }

    private void NumberButton_Click(object sender, EventArgs e)
    {
        if (sender is Button button && int.TryParse(button.Text, out int number))
        {
            if (this.textBox1.Text is "0")
            {
                this.textBox1.Text = number.ToString();
            }
            else
            {
                this.textBox1.Text += number.ToString();
            }
        }
    }
}