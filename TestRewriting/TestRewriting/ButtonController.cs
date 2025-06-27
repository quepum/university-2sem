// <copyright file="ButtonController.cs" author="Alina Letyagina">
// under MIT License.
// </copyright>

namespace TestRewriting
{
    public class ButtonController
    {
        private readonly Form parentForm;
        private readonly Button button;
        private readonly Random random;

        public ButtonController(Form parentForm, Button button)
        {
            this.parentForm = parentForm;
            this.button = button;
            this.random = new Random();

            parentForm.MouseMove += this.ParentForm_MouseMove;
            button.Click += Button_Click;
        }

        private static void Button_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }

        private static double CalculateDistance(Point a, Point b)
        {
            return Math.Sqrt(
                Math.Pow(a.X - b.X, 2) +
                Math.Pow(a.Y - b.Y, 2));
        }

        private void ParentForm_MouseMove(object? sender, MouseEventArgs e)
        {
            var cursorPosition = e.Location;
            var buttonCenter = this.GetButtonCenterPosition();

            double distance = CalculateDistance(cursorPosition, buttonCenter);

            if (distance < 100)
            {
                this.MoveButtonToRandomPosition();
            }
        }

        private Point GetButtonCenterPosition()
        {
            return new Point(
                this.button.Left + (this.button.Width / 2),
                this.button.Top + (this.button.Height / 2));
        }

        private void MoveButtonToRandomPosition()
        {
            const int maxAttempts = 20;
            var cursorPosition = this.parentForm.PointToClient(Cursor.Position);

            for (int i = 0; i < maxAttempts; i++)
            {
                int newX = this.random.Next(0, this.parentForm.ClientSize.Width - this.button.Width);
                int newY = this.random.Next(0, this.parentForm.ClientSize.Height - this.button.Height);

                var newButtonCenter = new Point(
                    newX + (this.button.Width / 2),
                    newY + (this.button.Height / 2));

                double distance = CalculateDistance(newButtonCenter, cursorPosition);

                if (distance > 100)
                {
                    this.button.Location = new Point(newX, newY);
                    return;
                }
            }

            this.button.Location = new Point(
                this.random.Next(0, this.parentForm.ClientSize.Width - this.button.Width),
                this.random.Next(0, this.parentForm.ClientSize.Height - this.button.Height));
        }
    }
}