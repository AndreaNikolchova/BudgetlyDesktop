using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace BudgetlyDesktop.UI.Builders
{
    public static class TransactionsBuilder
    {
        public static void ShowTransactionsPage(Panel panelContent, Label lblTitle)
        {
            panelContent.Controls.Clear();
            lblTitle.Text = "Transactions";

            // --- Filters Panel ---
            Panel panelFilters = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                Padding = new Padding(10)
            };

            DateTimePicker dtpFrom = new DateTimePicker { Format = DateTimePickerFormat.Short };
            DateTimePicker dtpTo = new DateTimePicker { Format = DateTimePickerFormat.Short, Value = DateTime.Today };

            ComboBox cmbCategory = new ComboBox { Width = 120 };
            cmbCategory.Items.AddRange(new string[] { "All", "Food", "Transport", "Salary" });
            cmbCategory.SelectedIndex = 0;

            ComboBox cmbType = new ComboBox { Width = 100 };
            cmbType.Items.AddRange(new string[] { "All", "Income", "Expense" });
            cmbType.SelectedIndex = 0;

            Button btnApplyFilter = new Button { Text = "Apply" };
        
            Button btnAdd = new Button { Text = "+ Add Transaction" };

            FlowLayoutPanel flowFilters = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
                WrapContents = false
            };
            flowFilters.Controls.AddRange(new Control[] { dtpFrom, dtpTo, cmbCategory, cmbType, btnApplyFilter, btnAdd });
            panelFilters.Controls.Add(flowFilters);

            panelContent.Controls.Add(panelFilters);

         
            Panel dgvWrapper = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10, 30, 10, 10), 
                BackColor = Color.Transparent
            };

            // --- DataGridView ---
            DataGridView dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                BackgroundColor = Color.FromArgb(34, 40, 49),
                ForeColor = Color.FromArgb(34, 40, 49), 
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                AllowUserToAddRows = false,
                Font = new Font("Bahnschrift SemiCondensed", 11),
                RowTemplate = { Height = 30 },
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(39, 41, 61),
                    ForeColor = Color.FromArgb(238, 238, 238),
                    Font = new Font("Bahnschrift SemiCondensed", 11, FontStyle.Bold)
                },
                
            };
         

            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Date", DataPropertyName = "Date", Width = 100 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Title", DataPropertyName = "Title", Width = 150 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Category", DataPropertyName = "Category", Width = 120 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Type", DataPropertyName = "Type", Width = 80 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Amount", DataPropertyName = "Amount", Width = 100 });

            dgvWrapper.Controls.Add(dgv);
            panelContent.Controls.Add(dgvWrapper);

            // --- Load initial dummy data ---
            LoadDummyTransactions(panelContent, DateTime.Today.AddDays(-30), DateTime.Today, "All", "All");
        }

        private static void LoadDummyTransactions(Panel panelContent, DateTime from, DateTime to, string category, string type)
        {
            var dummy = new List<dynamic>
            {
                new { Date = DateTime.Today.AddDays(-5).ToShortDateString(), Title = "Grocery", Category = "Food", Type = "Expense", Amount = 45.50m },
                new { Date = DateTime.Today.AddDays(-3).ToShortDateString(), Title = "Salary", Category = "Salary", Type = "Income", Amount = 2000.00m },
                new { Date = DateTime.Today.AddDays(-2).ToShortDateString(), Title = "Bus Ticket", Category = "Transport", Type = "Expense", Amount = 2.50m },
                new { Date = DateTime.Today.AddDays(-1).ToShortDateString(), Title = "Movie", Category = "Entertainment", Type = "Expense", Amount = 15.00m }
            };

            if (category != "All") dummy = dummy.Where(t => t.Category == category).ToList();
            if (type != "All") dummy = dummy.Where(t => t.Type == type).ToList();
            dummy = dummy.Where(t => DateTime.Parse(t.Date) >= from && DateTime.Parse(t.Date) <= to).ToList();

            var dgv = panelContent.Controls.OfType<Panel>()
                          .FirstOrDefault(p => p.Controls.OfType<DataGridView>().Any())
                          ?.Controls.OfType<DataGridView>().FirstOrDefault();

            if (dgv != null)
                dgv.DataSource = dummy;
        }
    }
}
