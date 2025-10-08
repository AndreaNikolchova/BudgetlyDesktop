namespace BudgetlyDesktop.UI.Builders
{
    using BudgetlyDesktop.Services.Transaction.Contracts;
    using System.Drawing;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Windows.Forms.DataVisualization.Charting;
    public static class DashboardBuilder
    {
        public static async void LoadDashboard(Panel panelContent, Label lblTitle, ITransactionService transactionService)
        {
            panelContent.Controls.Clear();
            lblTitle.Text = "Dashboard";

            panelContent.Controls.Add(await CreateFlowChart(transactionService));

            Chart chart = await CreateExpenseChart(transactionService);
            panelContent.Controls.Add(chart);
            chart.BringToFront();
        }

        private async static Task<FlowLayoutPanel> CreateFlowChart(ITransactionService transactionService)
        {
            FlowLayoutPanel flowCards = new FlowLayoutPanel();
            flowCards.Dock = DockStyle.Top;
            flowCards.Height = 110;
            flowCards.Padding = new Padding(10);
            flowCards.BackColor = Color.Transparent;

            flowCards.Controls.Add(await CreateCardBalance(transactionService));
            flowCards.Controls.Add(await CreateCardIncome(transactionService));
            flowCards.Controls.Add(await CreateCardExpense(transactionService));

            return flowCards;
        }
        private async static Task<Panel> CreateCardBalance(ITransactionService transactionService)
        {
            Panel cardBalance = new Panel();
            cardBalance.Size = new Size(250, 100);
          
            Label lblBalanceTitle = new Label()
            {
                Text = "Balance",
                ForeColor = Color.FromArgb(238, 238, 238),
                Font = new Font("Bahnschrift SemiCondensed", 13, FontStyle.Regular),
                Dock = DockStyle.Top,
                Height = 25,
                TextAlign = ContentAlignment.MiddleLeft
            };
            decimal balance = await transactionService.GetBalanceAsync();
            Label lblBalanceAmount = new Label()
            {
                Text = balance.ToString("f2") + " lv./" + (balance / (decimal)1.9558).ToString("f2") + "€",
                ForeColor = Color.FromArgb(108, 99, 255),
                Font = new Font("Bahnschrift SemiCondensed", 18, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };
            cardBalance.Controls.Add(lblBalanceAmount);
            cardBalance.Controls.Add(lblBalanceTitle);
            return cardBalance;
        }
        private async static Task<Panel> CreateCardIncome(ITransactionService transactionService)
        {
            Panel cardIncome = new Panel();
            cardIncome.Size = new Size(250, 100);
           
            Label lblIncomeTitle = new Label()
            {
                Text = "Total Income",
                ForeColor = Color.FromArgb(238, 238, 238),
                Font = new Font("Bahnschrift SemiCondensed", 13, FontStyle.Regular),
                Dock = DockStyle.Top,
                Height = 25,
                TextAlign = ContentAlignment.MiddleLeft
            };
            decimal income = await transactionService.GetIncomeAsync();
            Label lblIncomeAmount = new Label()
            {
                Text = income.ToString("f2") + " lv./" + (income / (decimal)1.9558).ToString("f2") + "€",
                ForeColor = Color.FromArgb(0, 173, 181),
                Font = new Font("Bahnschrift SemiCondensed", 18, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };
            cardIncome.Controls.Add(lblIncomeAmount);
            cardIncome.Controls.Add(lblIncomeTitle);
            return cardIncome;
        }
        private async static Task<Panel> CreateCardExpense(ITransactionService transactionService)
        {
            Panel cardExpense = new Panel();
            cardExpense.Size = new Size(250, 100);
            Label lblExpenseTitle = new Label()
            {
                Text = "Total Expense",
                ForeColor = Color.FromArgb(238, 238, 238),
                Font = new Font("Bahnschrift SemiCondensed", 13, FontStyle.Regular),
                Dock = DockStyle.Top,
                Height = 25,
                TextAlign = ContentAlignment.MiddleLeft
            };
            decimal expense = await transactionService.GetExpenseAsync();
            Label lblExpenseAmount = new Label()
            {
                Text = expense.ToString("f2") + " lv./" + (expense / (decimal)1.9558).ToString("f2") + "€",
                ForeColor = Color.FromArgb(255, 99, 71),
                Font = new Font("Bahnschrift SemiCondensed", 18, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };
            cardExpense.Controls.Add(lblExpenseAmount);
            cardExpense.Controls.Add(lblExpenseTitle);
            return cardExpense;
        }

        private static async Task<Chart> CreateExpenseChart(ITransactionService transactionService)
        {
            Chart chart = new Chart();
            chart.Dock = DockStyle.Fill;
            chart.BackColor = Color.FromArgb(57, 62, 70);
            chart.ForeColor = Color.FromArgb(238, 238, 238); 

            ChartArea area = new ChartArea();
            area.BackColor = Color.FromArgb(57, 62, 70);

           
            area.AxisX.LineColor = Color.FromArgb(238, 238, 238);
            area.AxisX.LabelStyle.ForeColor = Color.FromArgb(238, 238, 238);
            area.AxisX.MajorGrid.LineColor = Color.FromArgb(100, 238, 238, 238); 
            area.AxisY.LineColor = Color.FromArgb(238, 238, 238);
            area.AxisY.LabelStyle.ForeColor = Color.FromArgb(238, 238, 238);
            area.AxisY.MajorGrid.LineColor = Color.FromArgb(100, 238, 238, 238);

            chart.ChartAreas.Add(area);

            Series series = new Series();
            series.Name = "IncomeVsExpense";
            series.ChartType = SeriesChartType.Column;

            decimal income = await transactionService.GetIncomeAsync();
            decimal expense = await transactionService.GetExpenseAsync();

            series.LabelForeColor = Color.FromArgb(238, 238, 238); 
            series.Points.AddXY("Income", income);
            series.Points.AddXY("Expense", expense);

            chart.Series.Add(series);


            if (chart.Legends.Count > 0)
            {
                chart.Legends[0].ForeColor = Color.FromArgb(238, 238, 238); 
                chart.Legends[0].BackColor = Color.FromArgb(57, 62, 70);    
                chart.Legends[0].LegendStyle = LegendStyle.Row;

                
                foreach (var s in chart.Series)
                {
                    s.Color = Color.FromArgb(0, 173, 181); 
                }
            }
            return chart;
        }
       
      
    }
}
