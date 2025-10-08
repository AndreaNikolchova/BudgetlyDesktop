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
            pbLogo = new PictureBox();
            panelTopBar = new Panel();
            label1 = new Label();
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
            panelSideBar.MaximumSize = new Size(220, 0);
            panelSideBar.Name = "panelSideBar";
            panelSideBar.Size = new Size(220, 650);
            panelSideBar.TabIndex = 0;
            // 
            // panelSideButtons
            // 
            panelSideButtons.Controls.Add(btnDashboard);
            panelSideButtons.Controls.Add(btnTransactions);
            panelSideButtons.Dock = DockStyle.Top;
            panelSideButtons.FlowDirection = FlowDirection.TopDown;
            panelSideButtons.Location = new Point(0, 110);
            panelSideButtons.Name = "panelSideButtons";
            panelSideButtons.Size = new Size(220, 195);
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
            panelTopBar.Controls.Add(label1);
            panelTopBar.Dock = DockStyle.Top;
            panelTopBar.Location = new Point(220, 0);
            panelTopBar.MaximumSize = new Size(0, 60);
            panelTopBar.Name = "panelTopBar";
            panelTopBar.Size = new Size(880, 60);
            panelTopBar.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Dock = DockStyle.Left;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Bahnschrift SemiCondensed", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(238, 238, 238);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(5, 15, 0, 0);
            label1.Size = new Size(166, 56);
            label1.TabIndex = 0;
            label1.Text = "Dashboard";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 40, 49);
            ClientSize = new Size(1100, 650);
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
        private Label label1;
    }
}
