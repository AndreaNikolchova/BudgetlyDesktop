
namespace BudgetlyDesktop
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelSideBar = new Panel();
            panelSideButtons = new FlowLayoutPanel();
            btnDashboard = new Button();
            btnTransactions = new Button();
            btnAdd = new Button();
            pbLogo = new PictureBox();
            panelTopBar = new Panel();
            btnMin = new Button();
            btnExit = new Button();
            lblTitle = new Label();
            panelContent = new Panel();
            panelSideBar.SuspendLayout();
            panelSideButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            panelTopBar.SuspendLayout();
            SuspendLayout();
            // 
            // panelSideBar
            // 
            panelSideBar.BackColor = Color.Transparent;
            panelSideBar.Controls.Add(panelSideButtons);
            panelSideBar.Controls.Add(pbLogo);
            panelSideBar.Dock = DockStyle.Left;
            panelSideBar.Location = new Point(0, 0);
            panelSideBar.MaximumSize = new Size(222, 0);
            panelSideBar.Name = "panelSideBar";
            panelSideBar.Size = new Size(220, 650);
            panelSideBar.TabIndex = 0;
            // 
            // panelSideButtons
            // 
            panelSideButtons.Controls.Add(btnDashboard);
            panelSideButtons.Controls.Add(btnTransactions);
            panelSideButtons.Controls.Add(btnAdd);
            panelSideButtons.Dock = DockStyle.Top;
            panelSideButtons.FlowDirection = FlowDirection.TopDown;
            panelSideButtons.Location = new Point(0, 110);
            panelSideButtons.Name = "panelSideButtons";
            panelSideButtons.Size = new Size(220, 212);
            panelSideButtons.TabIndex = 1;
            panelSideButtons.WrapContents = false;
            // 
            // btnDashboard
            // 
            btnDashboard.Cursor = Cursors.Hand;
            btnDashboard.Dock = DockStyle.Left;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Bahnschrift SemiCondensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDashboard.ForeColor = Color.FromArgb(238, 238, 238);
            btnDashboard.Location = new Point(0, 0);
            btnDashboard.Margin = new Padding(0);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(10, 0, 0, 0);
            btnDashboard.RightToLeft = RightToLeft.No;
            btnDashboard.Size = new Size(219, 40);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "Dashboard";
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // btnTransactions
            // 
            btnTransactions.Cursor = Cursors.Hand;
            btnTransactions.Dock = DockStyle.Left;
            btnTransactions.FlatAppearance.BorderSize = 0;
            btnTransactions.FlatStyle = FlatStyle.Flat;
            btnTransactions.Font = new Font("Bahnschrift SemiCondensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTransactions.ForeColor = Color.FromArgb(238, 238, 238);
            btnTransactions.Location = new Point(0, 40);
            btnTransactions.Margin = new Padding(0);
            btnTransactions.Name = "btnTransactions";
            btnTransactions.Padding = new Padding(10, 0, 0, 0);
            btnTransactions.RightToLeft = RightToLeft.No;
            btnTransactions.Size = new Size(219, 40);
            btnTransactions.TabIndex = 1;
            btnTransactions.Text = "Transactions";
            btnTransactions.UseVisualStyleBackColor = false;
            btnTransactions.Click += btnTransactions_Click;
            // 
            // btnAdd
            // 
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.Dock = DockStyle.Left;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Bahnschrift SemiCondensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.FromArgb(238, 238, 238);
            btnAdd.Location = new Point(0, 80);
            btnAdd.Margin = new Padding(0);
            btnAdd.Name = "btnAdd";
            btnAdd.Padding = new Padding(10, 0, 0, 0);
            btnAdd.RightToLeft = RightToLeft.No;
            btnAdd.Size = new Size(219, 40);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add transaction";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // pbLogo
            // 
            pbLogo.Dock = DockStyle.Top;
            pbLogo.Image = UI.Properties.Resources.BudgetlyLogo1;
            pbLogo.Location = new Point(0, 0);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(220, 110);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 0;
            pbLogo.TabStop = false;
            // 
            // panelTopBar
            // 
            panelTopBar.Controls.Add(btnMin);
            panelTopBar.Controls.Add(btnExit);
            panelTopBar.Controls.Add(lblTitle);
            panelTopBar.Dock = DockStyle.Top;
            panelTopBar.Location = new Point(220, 0);
            panelTopBar.MaximumSize = new Size(0, 60);
            panelTopBar.Name = "panelTopBar";
            panelTopBar.Size = new Size(880, 60);
            panelTopBar.TabIndex = 1;
            // 
            // btnMin
            // 
            btnMin.BackColor = Color.FromArgb(57, 62, 70);
            btnMin.FlatAppearance.BorderSize = 0;
            btnMin.FlatStyle = FlatStyle.Flat;
            btnMin.ForeColor = Color.FromArgb(238, 238, 238);
            btnMin.Location = new Point(806, 0);
            btnMin.Name = "btnMin";
            btnMin.Size = new Size(37, 29);
            btnMin.TabIndex = 1;
            btnMin.Text = "__";
            btnMin.UseVisualStyleBackColor = false;
            btnMin.Click += btnMin_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(57, 62, 70);
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.ForeColor = Color.FromArgb(238, 238, 238);
            btnExit.Location = new Point(843, 0);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(37, 29);
            btnExit.TabIndex = 0;
            btnExit.Text = "X";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Dock = DockStyle.Left;
            lblTitle.FlatStyle = FlatStyle.Flat;
            lblTitle.Font = new Font("Bahnschrift SemiCondensed", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(238, 238, 238);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(5, 15, 0, 0);
            lblTitle.Size = new Size(90, 56);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Tittle";
            // 
            // panelContent
            // 
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(220, 60);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(880, 590);
            panelContent.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 40, 49);
            ClientSize = new Size(1100, 650);
            Controls.Add(panelContent);
            Controls.Add(panelTopBar);
            Controls.Add(panelSideBar);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(1100, 650);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            panelSideBar.ResumeLayout(false);
            panelSideButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            panelTopBar.ResumeLayout(false);
            panelTopBar.PerformLayout();
            ResumeLayout(false);
        }



        #endregion

        private Panel panelSideBar;
        private Panel panelTopBar;
        private PictureBox pbLogo;
        private FlowLayoutPanel panelSideButtons;
        private Button btnDashboard;
        private Button btnTransactions;
        private Label lblTitle;
        private Panel panelContent;
        private Button btnExit;
        private Button btnMin;
        private Button btnAdd;
    }
}
