namespace BudgetlyDesktop.UI.Builders
{
    using BudgetlyDesktop.Services.Category.Contracts;
    using BudgetlyDesktop.Services.Transaction.Contracts;
    using BudgetlyDesktop.Services.Type.Contracts;
    using BugetlyDesktop.ViewModels.Transaction;
    using System.ComponentModel;
    public static class TransactionsBuilder
    {
        private static BindingList<TransactionViewModel> _bindingList;

        public static async void ShowTransactionsPage(
            Panel panelContent,
            Label lblTitle,
            ITypeService typeService,
            ICategoryService categoryService,
            ITransactionService transactionService)
        {
            panelContent.Controls.Clear();
            lblTitle.Text = "Transactions";


            Panel panelFilters = await CreateFilterPanel(categoryService, typeService, transactionService, panelContent);
            panelContent.Controls.Add(panelFilters);


            Panel tablePanel = CreateTableOfTransactions();
            panelContent.Controls.Add(tablePanel);


            await LoadTransactions(transactionService, panelContent);
        }

        private static async Task LoadTransactions(ITransactionService transactionService, Panel panelContent)
        {
            var transactions = (await transactionService.GetAllTransactionsAsync())?.ToList() ?? new List<TransactionViewModel>();

            _bindingList = new BindingList<TransactionViewModel>(transactions);


            var dgv = panelContent.Controls
                .OfType<Panel>()
                .SelectMany(p => p.Controls.OfType<DataGridView>())
                .FirstOrDefault();

            if (dgv != null)
            {
                dgv.DataSource = null;
                dgv.DataSource = _bindingList;
            }
        }

        private static async Task<Panel> CreateFilterPanel(
            ICategoryService categoryService,
            ITypeService typeService,
            ITransactionService transactionService,
            Panel panelContent)
        {
            Panel panelFilters = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                Padding = new Padding(10)
            };

            DateTimePicker dtpFrom = new DateTimePicker { Format = DateTimePickerFormat.Short };
            DateTimePicker dtpTo = new DateTimePicker { Format = DateTimePickerFormat.Short, Value = DateTime.Today };
         
            Button btnApplyFilter = new Button
            {
                Text = "Apply",
                Font = new Font("Bahnschrift SemiCondensed", 10, FontStyle.Bold),
                BackColor = Color.FromArgb(0, 173, 181),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 200,
                Height = 30,
                Anchor = AnchorStyles.Left,
                
            };
            ComboBox cmbCategory = await CreateCategoryComboBox(categoryService);
            ComboBox cmbType = await CreateTypeComboBox(typeService);


            btnApplyFilter.Click += async (s, e) =>
            {
                await LoadTransactions(transactionService, panelContent);
            };

        
            panelFilters.Controls.Add(CreateFlowFilter(dtpFrom, dtpTo, cmbCategory, cmbType, btnApplyFilter));
            return panelFilters;
        }

        private static async Task<ComboBox> CreateCategoryComboBox(ICategoryService categoryService)
        {
            ComboBox cmbCategory = new ComboBox { Width = 120 };
            var categories = await categoryService.GetAllAsync();

            var list = categories?.ToList() ?? new List<string>();
            if (list.Any())
            {
                cmbCategory.Items.AddRange(list.ToArray());
                cmbCategory.SelectedIndex = 0;
            }

            return cmbCategory;
        }

        private static async Task<ComboBox> CreateTypeComboBox(ITypeService typeService)
        {
            ComboBox cmbType = new ComboBox { Width = 100 };
            var types = await typeService.GetTypesAsync();

            var list = types?.ToList() ?? new List<string>();
            if (list.Any())
            {
                cmbType.Items.AddRange(list.ToArray());
                cmbType.SelectedIndex = 0;
            }

            return cmbType;
        }

        private static FlowLayoutPanel CreateFlowFilter(
            DateTimePicker dtpFrom,
            DateTimePicker dtpTo,
            ComboBox categoryComboBox,
            ComboBox typeComboBox,
            Button btnApplyFilter)
        {
            FlowLayoutPanel flowFilters = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
                WrapContents = false
            };

            flowFilters.Controls.AddRange(new Control[]
            {
                dtpFrom,
                dtpTo,
                categoryComboBox,
                typeComboBox,
                btnApplyFilter,
                 });

            return flowFilters;
        }

        private static Panel CreateTableOfTransactions()
        {
            Panel dgvWrapper = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10, 30, 10, 10),
                BackColor = Color.Transparent
            };

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
            return dgvWrapper;
        }
    }
}
