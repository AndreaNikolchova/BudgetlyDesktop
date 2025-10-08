namespace BudgetlyDesktop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            panelSideBar.Paint += PanelSidebar_Paint;
            btnDashboard.MouseEnter += (s, e) => { btnDashboard.BackColor = Color.FromArgb(57, 62, 70); };
            btnDashboard.MouseLeave += (s, e) => { btnDashboard.BackColor = Color.Transparent; };
            btnTransactions.MouseEnter += (s, e) => { btnTransactions.BackColor = Color.FromArgb(57, 62, 70); };
            btnTransactions.MouseLeave += (s, e) => { btnTransactions.BackColor = Color.Transparent; };
        }
        private void PanelSidebar_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.FromArgb(0, 173, 181), 1)) 
            {
                e.Graphics.DrawLine(pen, panelSideBar.Width - 1, 0, panelSideBar.Width - 1, panelSideBar.Height);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
