// <copyright file="Program.cs" author="Alina Letyagina">
// under MIT License.
// </copyright>

namespace Calculator;

/// <summary>
/// The Program class contains the entry point for the Windows Forms application.
/// </summary>
internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new CalculatorForm());
    }
}