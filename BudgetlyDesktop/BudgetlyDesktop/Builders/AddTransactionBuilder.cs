using BudgetlyDesktop.Services.Category.Contracts;
using BudgetlyDesktop.Services.Transaction.Contracts;
using BudgetlyDesktop.Services.Type.Contracts;
using BugetlyDesktop.ViewModels.Transaction;

namespace BudgetlyDesktop.UI.Builders
{
    public static class AddTransactionBuilder
    {
        public async static void ShowAddTransactionPage(Panel panelContent, Label lblTitle, ICategoryService categoryService, ITypeService typeService, ITransactionService transactionService)
        {
            panelContent.Controls.Clear();
            lblTitle.Text = "Add Transaction";

            Panel panelForm = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(50),
                BackColor = Color.FromArgb(34, 40, 49)
            };

            panelForm.Controls.Add(await CreateFormLayaout(categoryService, typeService,transactionService));
            panelContent.Controls.Add(panelForm);
        }
        private async static Task<TableLayoutPanel> CreateFormLayaout(ICategoryService categoryService, ITypeService typeService, ITransactionService transactionService)
        {

            TableLayoutPanel formLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                ColumnCount = 2,
                RowCount = 6,
                Padding = new Padding(20),
                AutoSize = true,
            };

            formLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            formLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));


            Label lblTitleField = CreateLabel("Title:");
            TextBox txtTitle = CreateTextBox();

            Label lblAmount = CreateLabel("Amount:");
            TextBox txtAmount = CreateTextBox();

            Label lblCategory = CreateLabel("Category:");

            ComboBox cmbCategory = await CreateCategoryComboBox(categoryService);

            Label lblType = CreateLabel("Type:");
            ComboBox cmbType = await CreateTypeComboBox(typeService);

            Label lblDate = CreateLabel("Date:");
            DateTimePicker dtpDate = new DateTimePicker { Format = DateTimePickerFormat.Short, Width = 200 };

            Button btnAdd = new Button
            {
                Text = "Add Transaction",
                Font = new Font("Bahnschrift SemiCondensed", 12, FontStyle.Bold),
                BackColor = Color.FromArgb(0, 173, 181),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 200,
                Height = 40,
                Anchor = AnchorStyles.Left,
                Margin = new Padding(0, 20, 0, 0)
            };

            btnAdd.Click += (s, e) => AddTransaction(txtTitle, txtAmount, cmbCategory, cmbType, dtpDate,transactionService);


            formLayout.Controls.Add(lblTitleField, 0, 0);
            formLayout.Controls.Add(txtTitle, 1, 0);
            formLayout.Controls.Add(lblAmount, 0, 1);
            formLayout.Controls.Add(txtAmount, 1, 1);
            formLayout.Controls.Add(lblCategory, 0, 2);
            formLayout.Controls.Add(cmbCategory, 1, 2);
            formLayout.Controls.Add(lblType, 0, 3);
            formLayout.Controls.Add(cmbType, 1, 3);
            formLayout.Controls.Add(lblDate, 0, 4);
            formLayout.Controls.Add(dtpDate, 1, 4);


            formLayout.Controls.Add(new Label(), 0, 5);
            formLayout.Controls.Add(btnAdd, 1, 5);
            return formLayout;
        }
        private static async void AddTransaction(TextBox txtTitle, TextBox txtAmount, ComboBox cmbCategory, ComboBox cmbType, DateTimePicker dtpDate,ITransactionService transactionService)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTitle.Text.Length <= 3) 
            {
                MessageBox.Show("Please enter a valid title.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                MessageBox.Show("Please enter a valid number for the amount.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            await transactionService.AddTransactionAsync(new AddTransactionViewModel()
            {
                Title = txtTitle.Text,
                Amount = amount,
                TypeId = cmbType.SelectedIndex,
                CategoryId = cmbCategory.SelectedIndex,
                Date = dtpDate.Value,
            });

            MessageBox.Show($"✅ Transaction Added:\n\n" +
            $"Title: {txtTitle.Text}\n" +
            $"Amount: {txtAmount.Text}\n" +
            $"Category: {cmbCategory.SelectedItem}\n" +
            $"Type: {cmbType.SelectedItem}\n" +
            $"Date: {dtpDate.Value.ToShortDateString()}",
            "Success",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);


        }

        private static Label CreateLabel(string text)
        {
            return new Label
            {
                Text = text,
                ForeColor = Color.FromArgb(238, 238, 238),
                Font = new Font("Bahnschrift SemiCondensed", 12),
                AutoSize = true,
                Anchor = AnchorStyles.Right
            };
        }

        private static TextBox CreateTextBox()
        {
            return new TextBox
            {
                Font = new Font("Bahnschrift SemiCondensed", 12),
                Width = 200
            };
        }

        private async static Task<ComboBox> CreateCategoryComboBox(ICategoryService categoryService)
        {
            var cmbCategory = new ComboBox
            {
                Font = new Font("Bahnschrift SemiCondensed", 12),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 200
            };
            var categories = await categoryService.GetAllAsync();

            var list = categories?.ToList() ?? new List<string>();
            if (list.Any())
            {
                cmbCategory.Items.AddRange(list.ToArray());
                cmbCategory.SelectedIndex = 0;
            }
            return cmbCategory;
        }
        private async static Task<ComboBox> CreateTypeComboBox(ITypeService typeService)
        {
            var cmbType = new ComboBox
            {
                Font = new Font("Bahnschrift SemiCondensed", 12),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 200
            };
            var types = await typeService.GetTypesAsync();

            var list = types?.ToList() ?? new List<string>();
            if (list.Any())
            {
                cmbType.Items.AddRange(list.ToArray());
                cmbType.SelectedIndex = 0;
            }
            return cmbType;
        }
    }
}
