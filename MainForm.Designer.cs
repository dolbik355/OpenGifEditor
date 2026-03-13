namespace OpenGifImage
{
    public static class AppColors
    {
        public static readonly System.Drawing.Color FormBackground = System.Drawing.Color.FromArgb(45, 45, 48);
        public static readonly System.Drawing.Color PanelBackground = System.Drawing.Color.FromArgb(45, 45, 48);
        public static readonly System.Drawing.Color ButtonBackground = System.Drawing.Color.FromArgb(63, 63, 70);
        public static readonly System.Drawing.Color ButtonBackgroundSecondary = System.Drawing.Color.FromArgb(80, 80, 80);
        public static readonly System.Drawing.Color PictureBoxBackground = System.Drawing.Color.FromArgb(28, 28, 28);
        public static readonly System.Drawing.Color TextColor = System.Drawing.Color.White;
        public static readonly System.Drawing.Color TextBoxBackground = System.Drawing.Color.FromArgb(63, 63, 70);
    }

    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows
        private void InitializeComponent()
        {
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonUndo = new System.Windows.Forms.Button();
            this.buttonRedo = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.trackBarFrames = new System.Windows.Forms.TrackBar();
            this.labelCurrentFrame = new System.Windows.Forms.Label();
            this.labelTotalFrames = new System.Windows.Forms.Label();
            this.buttonPreview = new System.Windows.Forms.Button();
            this.tabMethods = new System.Windows.Forms.TabControl();
            this.tabPageCrop = new System.Windows.Forms.TabPage();
            this.panelCropBorder = new System.Windows.Forms.Panel();
            this.lblPx4 = new System.Windows.Forms.Label();
            this.lblPx3 = new System.Windows.Forms.Label();
            this.lblPx2 = new System.Windows.Forms.Label();
            this.lblPx1 = new System.Windows.Forms.Label();
            this.buttonCrop = new System.Windows.Forms.Button();
            this.textBoxCropBottom = new System.Windows.Forms.TextBox();
            this.textBoxCropRight = new System.Windows.Forms.TextBox();
            this.textBoxCropLeft = new System.Windows.Forms.TextBox();
            this.textBoxCropTop = new System.Windows.Forms.TextBox();
            this.lblB = new System.Windows.Forms.Label();
            this.lblR = new System.Windows.Forms.Label();
            this.lblL = new System.Windows.Forms.Label();
            this.lblT = new System.Windows.Forms.Label();
            this.tabPageLength = new System.Windows.Forms.TabPage();
            this.buttonCropLength = new System.Windows.Forms.Button();
            this.textBoxCropEnd = new System.Windows.Forms.TextBox();
            this.lblEnd = new System.Windows.Forms.Label();
            this.textBoxCropStart = new System.Windows.Forms.TextBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.tabPageAdd = new System.Windows.Forms.TabPage();
            this.buttonAddFrame = new System.Windows.Forms.Button();
            this.numericUpDownFrameToAddAfter = new System.Windows.Forms.NumericUpDown();
            this.lblAddPos = new System.Windows.Forms.Label();
            this.buttonSetDelay = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.addFrameFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFrames)).BeginInit();
            this.tabMethods.SuspendLayout();
            this.tabPageCrop.SuspendLayout();
            this.panelCropBorder.SuspendLayout();
            this.tabPageLength.SuspendLayout();
            this.tabPageAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrameToAddAfter)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOpen
            // 
            this.buttonOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.buttonOpen.FlatAppearance.BorderSize = 0;
            this.buttonOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpen.ForeColor = System.Drawing.Color.White;
            this.buttonOpen.Location = new System.Drawing.Point(839, 20);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(100, 35);
            this.buttonOpen.TabIndex = 0;
            this.buttonOpen.Text = "Открыть";
            this.buttonOpen.UseVisualStyleBackColor = false;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(945, 20);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 35);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonUndo
            // 
            this.buttonUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUndo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.buttonUndo.FlatAppearance.BorderSize = 0;
            this.buttonUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUndo.ForeColor = System.Drawing.Color.White;
            this.buttonUndo.Location = new System.Drawing.Point(1051, 20);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(100, 35);
            this.buttonUndo.TabIndex = 2;
            this.buttonUndo.Text = "Отменить";
            this.buttonUndo.UseVisualStyleBackColor = false;
            this.buttonUndo.Click += new System.EventHandler(this.buttonUndo_Click);
            // 
            // buttonRedo
            // 
            this.buttonRedo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRedo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.buttonRedo.FlatAppearance.BorderSize = 0;
            this.buttonRedo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRedo.ForeColor = System.Drawing.Color.White;
            this.buttonRedo.Location = new System.Drawing.Point(839, 70);
            this.buttonRedo.Name = "buttonRedo";
            this.buttonRedo.Size = new System.Drawing.Size(100, 35);
            this.buttonRedo.TabIndex = 3;
            this.buttonRedo.Text = "Вернуть";
            this.buttonRedo.UseVisualStyleBackColor = false;
            this.buttonRedo.Click += new System.EventHandler(this.buttonRedo_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.pictureBox1.Location = new System.Drawing.Point(20, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(799, 600);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // trackBarFrames
            // 
            this.trackBarFrames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarFrames.AutoSize = false;
            this.trackBarFrames.Location = new System.Drawing.Point(20, 630);
            this.trackBarFrames.Name = "trackBarFrames";
            this.trackBarFrames.Size = new System.Drawing.Size(808, 30);
            this.trackBarFrames.TabIndex = 5;
            this.trackBarFrames.Scroll += new System.EventHandler(this.trackBarFrames_Scroll);
            // 
            // labelCurrentFrame
            // 
            this.labelCurrentFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCurrentFrame.AutoSize = true;
            this.labelCurrentFrame.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelCurrentFrame.ForeColor = System.Drawing.Color.White;
            this.labelCurrentFrame.Location = new System.Drawing.Point(20, 670);
            this.labelCurrentFrame.Name = "labelCurrentFrame";
            this.labelCurrentFrame.Size = new System.Drawing.Size(174, 28);
            this.labelCurrentFrame.TabIndex = 6;
            this.labelCurrentFrame.Text = "Текущий кадр: 1";
            // 
            // labelTotalFrames
            // 
            this.labelTotalFrames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTotalFrames.AutoSize = true;
            this.labelTotalFrames.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelTotalFrames.ForeColor = System.Drawing.Color.White;
            this.labelTotalFrames.Location = new System.Drawing.Point(20, 695);
            this.labelTotalFrames.Name = "labelTotalFrames";
            this.labelTotalFrames.Size = new System.Drawing.Size(165, 28);
            this.labelTotalFrames.TabIndex = 7;
            this.labelTotalFrames.Text = "Всего кадров: 0";
            // 
            // buttonPreview
            // 
            this.buttonPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.buttonPreview.FlatAppearance.BorderSize = 0;
            this.buttonPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPreview.ForeColor = System.Drawing.Color.White;
            this.buttonPreview.Location = new System.Drawing.Point(1049, 675);
            this.buttonPreview.Name = "buttonPreview";
            this.buttonPreview.Size = new System.Drawing.Size(110, 35);
            this.buttonPreview.TabIndex = 10;
            this.buttonPreview.Text = "Просмотр";
            this.buttonPreview.UseVisualStyleBackColor = false;
            this.buttonPreview.Click += new System.EventHandler(this.buttonPreview_Click);
            // 
            // tabMethods
            // 
            this.tabMethods.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMethods.Controls.Add(this.tabPageCrop);
            this.tabMethods.Controls.Add(this.tabPageLength);
            this.tabMethods.Controls.Add(this.tabPageAdd);
            this.tabMethods.Location = new System.Drawing.Point(839, 120);
            this.tabMethods.Name = "tabMethods";
            this.tabMethods.SelectedIndex = 0;
            this.tabMethods.Size = new System.Drawing.Size(320, 251);
            this.tabMethods.TabIndex = 8;
            // 
            // tabPageCrop
            // 
            this.tabPageCrop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabPageCrop.Controls.Add(this.panelCropBorder);
            this.tabPageCrop.Location = new System.Drawing.Point(4, 34);
            this.tabPageCrop.Name = "tabPageCrop";
            this.tabPageCrop.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCrop.Size = new System.Drawing.Size(312, 213);
            this.tabPageCrop.TabIndex = 0;
            this.tabPageCrop.Text = "Обрезка";
            // 
            // panelCropBorder
            // 
            this.panelCropBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCropBorder.Controls.Add(this.lblPx4);
            this.panelCropBorder.Controls.Add(this.lblPx3);
            this.panelCropBorder.Controls.Add(this.lblPx2);
            this.panelCropBorder.Controls.Add(this.lblPx1);
            this.panelCropBorder.Controls.Add(this.buttonCrop);
            this.panelCropBorder.Controls.Add(this.textBoxCropBottom);
            this.panelCropBorder.Controls.Add(this.textBoxCropRight);
            this.panelCropBorder.Controls.Add(this.textBoxCropLeft);
            this.panelCropBorder.Controls.Add(this.textBoxCropTop);
            this.panelCropBorder.Controls.Add(this.lblB);
            this.panelCropBorder.Controls.Add(this.lblR);
            this.panelCropBorder.Controls.Add(this.lblL);
            this.panelCropBorder.Controls.Add(this.lblT);
            this.panelCropBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCropBorder.ForeColor = System.Drawing.Color.White;
            this.panelCropBorder.Location = new System.Drawing.Point(3, 3);
            this.panelCropBorder.Name = "panelCropBorder";
            this.panelCropBorder.Size = new System.Drawing.Size(306, 207);
            this.panelCropBorder.TabIndex = 9;
            // 
            // lblPx4
            // 
            this.lblPx4.AutoSize = true;
            this.lblPx4.Location = new System.Drawing.Point(260, 110);
            this.lblPx4.Name = "lblPx4";
            this.lblPx4.Size = new System.Drawing.Size(31, 25);
            this.lblPx4.TabIndex = 12;
            this.lblPx4.Text = "px";
            // 
            // lblPx3
            // 
            this.lblPx3.AutoSize = true;
            this.lblPx3.Location = new System.Drawing.Point(260, 60);
            this.lblPx3.Name = "lblPx3";
            this.lblPx3.Size = new System.Drawing.Size(31, 25);
            this.lblPx3.TabIndex = 11;
            this.lblPx3.Text = "px";
            // 
            // lblPx2
            // 
            this.lblPx2.AutoSize = true;
            this.lblPx2.Location = new System.Drawing.Point(125, 110);
            this.lblPx2.Name = "lblPx2";
            this.lblPx2.Size = new System.Drawing.Size(31, 25);
            this.lblPx2.TabIndex = 10;
            this.lblPx2.Text = "px";
            // 
            // lblPx1
            // 
            this.lblPx1.AutoSize = true;
            this.lblPx1.Location = new System.Drawing.Point(125, 60);
            this.lblPx1.Name = "lblPx1";
            this.lblPx1.Size = new System.Drawing.Size(31, 25);
            this.lblPx1.TabIndex = 9;
            this.lblPx1.Text = "px";
            // 
            // buttonCrop
            // 
            this.buttonCrop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.buttonCrop.FlatAppearance.BorderSize = 0;
            this.buttonCrop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCrop.Location = new System.Drawing.Point(50, 160);
            this.buttonCrop.Name = "buttonCrop";
            this.buttonCrop.Size = new System.Drawing.Size(200, 35);
            this.buttonCrop.TabIndex = 8;
            this.buttonCrop.Text = "Обрезать";
            this.buttonCrop.UseVisualStyleBackColor = false;
            this.buttonCrop.Click += new System.EventHandler(this.buttonCrop_Click);
            // 
            // textBoxCropBottom
            // 
            this.textBoxCropBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.textBoxCropBottom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCropBottom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxCropBottom.ForeColor = System.Drawing.Color.White;
            this.textBoxCropBottom.Location = new System.Drawing.Point(205, 107);
            this.textBoxCropBottom.Name = "textBoxCropBottom";
            this.textBoxCropBottom.Size = new System.Drawing.Size(50, 27);
            this.textBoxCropBottom.TabIndex = 7;
            this.textBoxCropBottom.Text = "0";
            this.textBoxCropBottom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxCropRight
            // 
            this.textBoxCropRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.textBoxCropRight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCropRight.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxCropRight.ForeColor = System.Drawing.Color.White;
            this.textBoxCropRight.Location = new System.Drawing.Point(205, 57);
            this.textBoxCropRight.Name = "textBoxCropRight";
            this.textBoxCropRight.Size = new System.Drawing.Size(50, 27);
            this.textBoxCropRight.TabIndex = 5;
            this.textBoxCropRight.Text = "0";
            this.textBoxCropRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxCropLeft
            // 
            this.textBoxCropLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.textBoxCropLeft.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCropLeft.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxCropLeft.ForeColor = System.Drawing.Color.White;
            this.textBoxCropLeft.Location = new System.Drawing.Point(70, 57);
            this.textBoxCropLeft.Name = "textBoxCropLeft";
            this.textBoxCropLeft.Size = new System.Drawing.Size(50, 27);
            this.textBoxCropLeft.TabIndex = 1;
            this.textBoxCropLeft.Text = "0";
            this.textBoxCropLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxCropTop
            // 
            this.textBoxCropTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.textBoxCropTop.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCropTop.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxCropTop.ForeColor = System.Drawing.Color.White;
            this.textBoxCropTop.Location = new System.Drawing.Point(70, 107);
            this.textBoxCropTop.Name = "textBoxCropTop";
            this.textBoxCropTop.Size = new System.Drawing.Size(50, 27);
            this.textBoxCropTop.TabIndex = 3;
            this.textBoxCropTop.Text = "0";
            this.textBoxCropTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Location = new System.Drawing.Point(155, 110);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(60, 25);
            this.lblB.TabIndex = 6;
            this.lblB.Text = "Снизу";
            // 
            // lblR
            // 
            this.lblR.AutoSize = true;
            this.lblR.Location = new System.Drawing.Point(155, 60);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(72, 25);
            this.lblR.TabIndex = 4;
            this.lblR.Text = "Справа";
            // 
            // lblL
            // 
            this.lblL.AutoSize = true;
            this.lblL.Location = new System.Drawing.Point(15, 60);
            this.lblL.Name = "lblL";
            this.lblL.Size = new System.Drawing.Size(60, 25);
            this.lblL.TabIndex = 0;
            this.lblL.Text = "Слева";
            // 
            // lblT
            // 
            this.lblT.AutoSize = true;
            this.lblT.Location = new System.Drawing.Point(15, 110);
            this.lblT.Name = "lblT";
            this.lblT.Size = new System.Drawing.Size(70, 25);
            this.lblT.TabIndex = 2;
            this.lblT.Text = "Сверху";
            // 
            // tabPageLength
            // 
            this.tabPageLength.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabPageLength.Controls.Add(this.buttonCropLength);
            this.tabPageLength.Controls.Add(this.textBoxCropEnd);
            this.tabPageLength.Controls.Add(this.lblEnd);
            this.tabPageLength.Controls.Add(this.textBoxCropStart);
            this.tabPageLength.Controls.Add(this.lblStart);
            this.tabPageLength.Location = new System.Drawing.Point(4, 34);
            this.tabPageLength.Name = "tabPageLength";
            this.tabPageLength.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLength.Size = new System.Drawing.Size(312, 262);
            this.tabPageLength.TabIndex = 1;
            this.tabPageLength.Text = "Обрезка по длине";
            // 
            // buttonCropLength
            // 
            this.buttonCropLength.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.buttonCropLength.FlatAppearance.BorderSize = 0;
            this.buttonCropLength.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCropLength.ForeColor = System.Drawing.Color.White;
            this.buttonCropLength.Location = new System.Drawing.Point(50, 160);
            this.buttonCropLength.Name = "buttonCropLength";
            this.buttonCropLength.Size = new System.Drawing.Size(200, 35);
            this.buttonCropLength.TabIndex = 4;
            this.buttonCropLength.Text = "Обрезать";
            this.buttonCropLength.UseVisualStyleBackColor = false;
            this.buttonCropLength.Click += new System.EventHandler(this.buttonCropLength_Click);
            // 
            // textBoxCropEnd
            // 
            this.textBoxCropEnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.textBoxCropEnd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCropEnd.ForeColor = System.Drawing.Color.White;
            this.textBoxCropEnd.Location = new System.Drawing.Point(120, 80);
            this.textBoxCropEnd.Name = "textBoxCropEnd";
            this.textBoxCropEnd.Size = new System.Drawing.Size(80, 24);
            this.textBoxCropEnd.TabIndex = 3;
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.ForeColor = System.Drawing.Color.White;
            this.lblEnd.Location = new System.Drawing.Point(20, 80);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(139, 25);
            this.lblEnd.TabIndex = 2;
            this.lblEnd.Text = "Конечный кадр";
            // 
            // textBoxCropStart
            // 
            this.textBoxCropStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.textBoxCropStart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCropStart.ForeColor = System.Drawing.Color.White;
            this.textBoxCropStart.Location = new System.Drawing.Point(120, 40);
            this.textBoxCropStart.Name = "textBoxCropStart";
            this.textBoxCropStart.Size = new System.Drawing.Size(80, 24);
            this.textBoxCropStart.TabIndex = 1;
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.ForeColor = System.Drawing.Color.White;
            this.lblStart.Location = new System.Drawing.Point(20, 40);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(148, 25);
            this.lblStart.TabIndex = 0;
            this.lblStart.Text = "Начальный кадр";
            // 
            // tabPageAdd
            // 
            this.tabPageAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabPageAdd.Controls.Add(this.buttonAddFrame);
            this.tabPageAdd.Controls.Add(this.numericUpDownFrameToAddAfter);
            this.tabPageAdd.Controls.Add(this.lblAddPos);
            this.tabPageAdd.Location = new System.Drawing.Point(4, 34);
            this.tabPageAdd.Name = "tabPageAdd";
            this.tabPageAdd.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAdd.Size = new System.Drawing.Size(312, 262);
            this.tabPageAdd.TabIndex = 2;
            this.tabPageAdd.Text = "Добавление кадров";
            // 
            // buttonAddFrame
            // 
            this.buttonAddFrame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.buttonAddFrame.FlatAppearance.BorderSize = 0;
            this.buttonAddFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddFrame.ForeColor = System.Drawing.Color.White;
            this.buttonAddFrame.Location = new System.Drawing.Point(50, 120);
            this.buttonAddFrame.Name = "buttonAddFrame";
            this.buttonAddFrame.Size = new System.Drawing.Size(200, 35);
            this.buttonAddFrame.TabIndex = 2;
            this.buttonAddFrame.Text = "Выбрать и добавить";
            this.buttonAddFrame.UseVisualStyleBackColor = false;
            this.buttonAddFrame.Click += new System.EventHandler(this.buttonAddFrame_Click);
            // 
            // numericUpDownFrameToAddAfter
            // 
            this.numericUpDownFrameToAddAfter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.numericUpDownFrameToAddAfter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDownFrameToAddAfter.ForeColor = System.Drawing.Color.White;
            this.numericUpDownFrameToAddAfter.Location = new System.Drawing.Point(180, 60);
            this.numericUpDownFrameToAddAfter.Name = "numericUpDownFrameToAddAfter";
            this.numericUpDownFrameToAddAfter.Size = new System.Drawing.Size(60, 27);
            this.numericUpDownFrameToAddAfter.TabIndex = 1;
            // 
            // lblAddPos
            // 
            this.lblAddPos.AutoSize = true;
            this.lblAddPos.ForeColor = System.Drawing.Color.White;
            this.lblAddPos.Location = new System.Drawing.Point(20, 60);
            this.lblAddPos.Name = "lblAddPos";
            this.lblAddPos.Size = new System.Drawing.Size(221, 25);
            this.lblAddPos.TabIndex = 0;
            this.lblAddPos.Text = "Вставить после кадра № :";
            // 
            // buttonSetDelay
            // 
            this.buttonSetDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.buttonSetDelay.FlatAppearance.BorderSize = 0;
            this.buttonSetDelay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSetDelay.ForeColor = System.Drawing.Color.White;
            this.buttonSetDelay.Location = new System.Drawing.Point(839, 385);
            this.buttonSetDelay.Name = "buttonSetDelay";
            this.buttonSetDelay.Size = new System.Drawing.Size(320, 35);
            this.buttonSetDelay.TabIndex = 9;
            this.buttonSetDelay.Text = "Настройка времени кадров";
            this.buttonSetDelay.UseVisualStyleBackColor = false;
            this.buttonSetDelay.Click += new System.EventHandler(this.buttonSetDelay_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "GIF Files|*.gif";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "GIF Files|*.gif";
            // 
            // addFrameFileDialog
            // 
            this.addFrameFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1179, 730);
            this.Controls.Add(this.buttonPreview);
            this.Controls.Add(this.buttonSetDelay);
            this.Controls.Add(this.tabMethods);
            this.Controls.Add(this.labelTotalFrames);
            this.Controls.Add(this.labelCurrentFrame);
            this.Controls.Add(this.trackBarFrames);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonRedo);
            this.Controls.Add(this.buttonUndo);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonOpen);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinimumSize = new System.Drawing.Size(1040, 760);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактор GIF";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFrames)).EndInit();
            this.tabMethods.ResumeLayout(false);
            this.tabPageCrop.ResumeLayout(false);
            this.panelCropBorder.ResumeLayout(false);
            this.panelCropBorder.PerformLayout();
            this.tabPageLength.ResumeLayout(false);
            this.tabPageLength.PerformLayout();
            this.tabPageAdd.ResumeLayout(false);
            this.tabPageAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrameToAddAfter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonUndo;
        private System.Windows.Forms.Button buttonRedo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TrackBar trackBarFrames;
        private System.Windows.Forms.Button buttonPreview;
        private System.Windows.Forms.TabControl tabMethods;
        private System.Windows.Forms.TabPage tabPageCrop;
        private System.Windows.Forms.TabPage tabPageLength;
        private System.Windows.Forms.TabPage tabPageAdd;
        private System.Windows.Forms.Button buttonCrop;
        private System.Windows.Forms.TextBox textBoxCropLeft;
        private System.Windows.Forms.TextBox textBoxCropTop;
        private System.Windows.Forms.TextBox textBoxCropRight;
        private System.Windows.Forms.TextBox textBoxCropBottom;
        private System.Windows.Forms.Label lblL;
        private System.Windows.Forms.Label lblT;
        private System.Windows.Forms.Label lblR;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Button buttonCropLength;
        private System.Windows.Forms.TextBox textBoxCropStart;
        private System.Windows.Forms.TextBox textBoxCropEnd;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Button buttonAddFrame;
        private System.Windows.Forms.NumericUpDown numericUpDownFrameToAddAfter;
        private System.Windows.Forms.Label lblAddPos;
        private System.Windows.Forms.Button buttonSetDelay;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog addFrameFileDialog;
        private System.Windows.Forms.Label labelCurrentFrame;
        private System.Windows.Forms.Label labelTotalFrames;
        private System.Windows.Forms.Panel panelCropBorder;
        private System.Windows.Forms.Label lblPx1;
        private System.Windows.Forms.Label lblPx2;
        private System.Windows.Forms.Label lblPx3;
        private System.Windows.Forms.Label lblPx4;
    }
}