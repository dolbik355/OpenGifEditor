namespace OpenGifImage
{
    partial class PreviewForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnPlayPause = new System.Windows.Forms.Button();
            this.lblFrameInfo = new System.Windows.Forms.Label();
            this.trackBarPreview = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPreview)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxPreview.BackColor = System.Drawing.Color.FromArgb(28, 28, 28);
            this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.TabIndex = 0;
            this.pictureBoxPreview.TabStop = false;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(63, 63, 70);
            this.panelBottom.Controls.Add(this.lblFrameInfo); // Текст теперь первый
            this.panelBottom.Controls.Add(this.btnPlayPause);
            this.panelBottom.Controls.Add(this.trackBarPreview);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Height = 100; // Немного увеличим высоту для стабильности
            this.panelBottom.Name = "panelBottom";
            // 
            // lblFrameInfo
            // 
            this.lblFrameInfo.Dock = System.Windows.Forms.DockStyle.Top; // Прибиваем к верху панели
            this.lblFrameInfo.Height = 30;
            this.lblFrameInfo.AutoSize = false; // ЗАПРЕЩАЕМ менять размер под текст
            this.lblFrameInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter; // Текст строго в центре
            this.lblFrameInfo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblFrameInfo.ForeColor = System.Drawing.Color.White;
            this.lblFrameInfo.Text = "Загрузка...";
            // 
            // btnPlayPause
            // 
            this.btnPlayPause.Location = new System.Drawing.Point(15, 45);
            this.btnPlayPause.Size = new System.Drawing.Size(130, 35);
            this.btnPlayPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayPause.ForeColor = System.Drawing.Color.White;
            this.btnPlayPause.BackColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.btnPlayPause.Text = "Пауза";
            // 
            // trackBarPreview
            // 
            this.trackBarPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarPreview.AutoSize = false;
            this.trackBarPreview.Location = new System.Drawing.Point(155, 45);
            this.trackBarPreview.Name = "trackBarPreview";
            this.trackBarPreview.Size = new System.Drawing.Size(620, 45);
            this.trackBarPreview.TabIndex = 5;
            this.trackBarPreview.TickStyle = System.Windows.Forms.TickStyle.BottomRight;
            this.trackBarPreview.Scroll += new System.EventHandler(this.trackBarPreview_Scroll);
            // 
            // PreviewForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.pictureBoxPreview);
            this.Controls.Add(this.panelBottom);
            this.MinimumSize = new System.Drawing.Size(600, 450);
            this.Name = "PreviewForm";
            this.Text = "Просмотр";
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPreview)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnPlayPause;
        private System.Windows.Forms.Label lblFrameInfo;
        private System.Windows.Forms.TrackBar trackBarPreview;
    }
}