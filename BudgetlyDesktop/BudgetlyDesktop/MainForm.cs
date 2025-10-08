
namespace BudgetlyDesktop
{
    using BudgetlyDesktop.UI.Builders;
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
            WelcomeBuilder.ShowWelcomeScreen(panelContent, lblTitle);
        }
        
        private void btnExit_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }
        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            DashboardBuilder.LoadDashboard(panelContent,lblTitle);
        }
       
    }
}
