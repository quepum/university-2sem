namespace TestRewriting;

/// <summary>
/// Represents the main form of "Button runs away" game.
/// </summary>
public partial class Form1 : Form
{
    public Form1()
    {
        this.InitializeComponent();
        this.StartGame();
    }

    private void StartGame()
    {
        // ReSharper disable once UnusedVariable
        var buttonController = new ButtonController(this, this.button1);
    }
}