using System;
using System.Drawing;
using System.Windows.Forms;

namespace OpenGifImage
{
    public partial class FrameDelayForm : Form
    {
        public int[] NewDelays { get; private set; }
        private DataGridView grid;
        private Button btnApply;
        private Button btnCancel;
        private Label lblInfo;

        public FrameDelayForm(int[] currentDelays)
        {
            InitializeComponent();

            NewDelays = new int[currentDelays.Length];
            Array.Copy(currentDelays, NewDelays, currentDelays.Length);

            grid.RowCount = currentDelays.Length;
            for (int i = 0; i < currentDelays.Length; i++)
            {
                grid[0, i].Value = (i + 1).ToString();
                grid[1, i].Value = currentDelays[i].ToString();
            }
        }

        private void InitializeComponent()
        {
            this.BackColor = Color.FromArgb(45, 45, 48);
            this.ForeColor = Color.White;
            this.Size = new Size(600, 400);
            this.Text = "Настройка времени кадров";
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowIcon = false;

            lblInfo = new Label();
            lblInfo.Text = "Установите задержку для каждого кадра в миллисекундах (1/1000 секунды).";
            lblInfo.Location = new Point(10, 10);
            lblInfo.AutoSize = true;
            lblInfo.ForeColor = Color.White;

            grid = new DataGridView();
            grid.Location = new Point(10, 40);
            grid.Size = new Size(560, 260);
            grid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.RowHeadersVisible = false; 
            grid.BackgroundColor = Color.FromArgb(45, 45, 48);
            grid.GridColor = Color.Gray;
            grid.BorderStyle = BorderStyle.None;
            grid.ColumnCount = 2;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            grid.DefaultCellStyle.BackColor = Color.FromArgb(63, 63, 70);
            grid.DefaultCellStyle.ForeColor = Color.White;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204); 

            grid.Columns[0].Name = "Номер кадра";
            grid.Columns[0].ReadOnly = true; 
            grid.Columns[0].Width = 150;

            grid.Columns[1].Name = "Задержка (мс)";
            grid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            btnApply = new Button();
            btnApply.Text = "Применить";
            btnApply.Location = new Point(360, 315);
            btnApply.Size = new Size(100, 30);
            btnApply.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnApply.FlatStyle = FlatStyle.Flat;
            btnApply.BackColor = Color.FromArgb(63, 63, 70);
            btnApply.FlatAppearance.BorderColor = Color.Gray;
            btnApply.Click += new EventHandler(this.BtnApply_Click);

            btnCancel = new Button();
            btnCancel.Text = "Отмена";
            btnCancel.Location = new Point(470, 315);
            btnCancel.Size = new Size(100, 30);
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.BackColor = Color.FromArgb(63, 63, 70);
            btnCancel.FlatAppearance.BorderColor = Color.Gray;
            btnCancel.Click += new EventHandler(this.BtnCancel_Click);

            this.Controls.Add(lblInfo);
            this.Controls.Add(grid);
            this.Controls.Add(btnApply);
            this.Controls.Add(btnCancel);
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grid.RowCount; i++)
            {
                var cellValue = grid[1, i].Value?.ToString()?.Trim();

                if (!string.IsNullOrEmpty(cellValue) && int.TryParse(cellValue, out int delay) && delay > 0)
                {
                    NewDelays[i] = delay;
                }
                else
                {
                    MessageBox.Show($"Некорректное значение в строке {i + 1}. Введите целое положительное число (например: 100).", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}