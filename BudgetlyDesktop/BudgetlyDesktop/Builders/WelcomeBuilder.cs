namespace BudgetlyDesktop.UI.Builders
{
    public static class WelcomeBuilder
    {
        public static void ShowWelcomeScreen(Panel panelContent,Label lblTitle)
        {
            panelContent.Controls.Clear();
            lblTitle.Text = "";

            Label lblWelcome = CreateWelcomeLabel();
            Label lblDescription = CreateDescriptionLabel();

            panelContent.Controls.Add(lblDescription);
            panelContent.Controls.Add(lblWelcome);
        }
        private static Label CreateWelcomeLabel()
        {
            Label lblWelcome = new Label();
            lblWelcome.Text = "Welcome to Budgetly!";
            lblWelcome.Font = new Font("Bahnschrift SemiCondensed", 20F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.FromArgb(238, 238, 238);
            lblWelcome.Dock = DockStyle.Top;
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            lblWelcome.Height = 60;
            return lblWelcome;

        }
        private static Label CreateDescriptionLabel()
        {
            Label lblDescription = new Label();
            lblDescription.Text = "Use the Dashboard to view your balance, track expenses, and manage your transactions.";
            lblDescription.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            lblDescription.ForeColor = Color.FromArgb(200, 200, 200);
            lblDescription.Dock = DockStyle.Top;
            lblDescription.TextAlign = ContentAlignment.MiddleCenter;
            lblDescription.Padding = new Padding(20, 10, 20, 10);
            lblDescription.AutoSize = false;
            lblDescription.Height = 60;
            return lblDescription;
        }
    }
}
