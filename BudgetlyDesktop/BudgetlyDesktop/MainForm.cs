namespace BudgetlyDesktop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            panelSideBar.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
             .SetValue(panelSideBar, true, null);

            panelSideBar.Paint += PanelSidebar_Paint;
            panelSideBar.Resize += (s, e) => panelSideBar.Invalidate();

            btnDashboard.MouseEnter += (s, e) => { btnDashboard.BackColor = Color.FromArgb(57, 62, 70); };
            btnDashboard.MouseLeave += (s, e) => { btnDashboard.BackColor = Color.Transparent; };
            btnTransactions.MouseEnter += (s, e) => { btnTransactions.BackColor = Color.FromArgb(57, 62, 70); };
            btnTransactions.MouseLeave += (s, e) => { btnTransactions.BackColor = Color.Transparent; };
        }
        private void PanelSidebar_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            using (Pen pen = new Pen(Color.FromArgb(0, 173, 181), 1))
            {
               
                int x = panelSideBar.ClientSize.Width - 1; 
                e.Graphics.DrawLine(pen, x, 0, x, panelSideBar.ClientSize.Height);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ShowWelcomeScreen();
        }
        private void ShowWelcomeScreen()
        {
            panelContent.Controls.Clear();
            lblTitle.Text = ""; 

           
            Label lblWelcome = new Label();
            lblWelcome.Text = "Welcome to Budgetly!";
            lblWelcome.Font = new Font("Bahnschrift SemiCondensed", 20F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.FromArgb(238, 238, 238);
            lblWelcome.Dock = DockStyle.Top;
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            lblWelcome.Height = 60; 

            
            Label lblDescription = new Label();
            lblDescription.Text = "Use the Dashboard to view your balance, track expenses, and manage your transactions.";
            lblDescription.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            lblDescription.ForeColor = Color.FromArgb(200, 200, 200); 
            lblDescription.Dock = DockStyle.Top;
            lblDescription.TextAlign = ContentAlignment.MiddleCenter;
            lblDescription.Padding = new Padding(20, 10, 20, 10); 
            lblDescription.AutoSize = false;
            lblDescription.Height = 60;

           
            panelContent.Controls.Add(lblDescription);
            panelContent.Controls.Add(lblWelcome);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }
        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
