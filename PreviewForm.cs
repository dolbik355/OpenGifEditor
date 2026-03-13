using ImageMagick;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace OpenGifImage
{
    public partial class PreviewForm : Form
    {
        private readonly MagickImageCollection _previewGif;
        private int _currentFrame = 0;
        private readonly Timer _animationTimer;
        private bool _isPlaying = true;

        public PreviewForm(MagickImageCollection gif, string title = "Просмотр")
        {
            _previewGif = gif;
            InitializeComponent();
            this.Text = title;
            this.StartPosition = FormStartPosition.CenterParent;
            this.DoubleBuffered = true;
            this.MinimumSize = new Size(600, 450); 

            if (_previewGif != null && _previewGif.Count > 0)
            {
                trackBarPreview.Minimum = 0;
                trackBarPreview.Maximum = _previewGif.Count - 1;
                if (_previewGif.Count > 100) trackBarPreview.TickFrequency = 10;
                else if (_previewGif.Count > 50) trackBarPreview.TickFrequency = 5;
                else trackBarPreview.TickFrequency = 1;
                _animationTimer = new Timer();
                _animationTimer.Tick += AnimationTimer_Tick;
                ShowFrame(0);
            }
            btnPlayPause.Click += btnPlayPause_Click;
            trackBarPreview.Scroll += trackBarPreview_Scroll;
        }

        private void ShowFrame(int index)
        {
            if (_previewGif == null || _previewGif.Count == 0) return;
            int safeIndex = Math.Max(0, Math.Min(index, _previewGif.Count - 1));

            try
            {
                this.SuspendLayout();

                using (var frameClone = new MagickImage(_previewGif[safeIndex]))
                using (var ms = new MemoryStream())
                {
                    frameClone.Write(ms, MagickFormat.Bmp);
                    ms.Position = 0;

                    var oldImage = pictureBoxPreview.Image;
                    pictureBoxPreview.Image = new Bitmap(ms);
                    oldImage?.Dispose(); 
                }

                _currentFrame = safeIndex;
                if (trackBarPreview.Value != safeIndex)
                    trackBarPreview.Value = safeIndex;
                string newText = $"Кадр {safeIndex + 1} / {_previewGif.Count}";
                if (lblFrameInfo.Text != newText)
                    lblFrameInfo.Text = newText;
                uint delayTicks = _previewGif[safeIndex].AnimationDelay;
                int interval = (delayTicks <= 1) ? 100 : (int)(delayTicks * 10);
                _animationTimer.Interval = Math.Max(20, interval); 
            }
            catch (Exception ex)
            {
                _animationTimer.Stop();
                Console.WriteLine($"Ошибка отрисовки: {ex.Message}");
            }
            finally
            {
                this.ResumeLayout(false);
            }
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (_previewGif == null || _previewGif.Count <= 1) return;

            _currentFrame = (_currentFrame + 1) % _previewGif.Count;
            ShowFrame(_currentFrame);
        }

        private void trackBarPreview_Scroll(object sender, EventArgs e)
        {
            _currentFrame = trackBarPreview.Value;
            ShowFrame(_currentFrame);
        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            _isPlaying = !_isPlaying;
            _animationTimer.Enabled = _isPlaying;
            btnPlayPause.Text = _isPlaying ? "Пауза" : "Воспроизвести";
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (panelBottom != null && trackBarPreview != null && btnPlayPause != null)
            {
                btnPlayPause.Left = 15;

                trackBarPreview.Left = btnPlayPause.Right + 15;
                int calculatedWidth = panelBottom.Width - trackBarPreview.Left - 25;
                trackBarPreview.Width = Math.Max(100, calculatedWidth);
                if (lblFrameInfo.Dock != DockStyle.Top)
                {
                    lblFrameInfo.Left = (panelBottom.Width - lblFrameInfo.Width) / 2;
                }
            }
        }

        private void PreviewForm_Shown(object sender, EventArgs e)
        {
            if (_previewGif != null && _previewGif.Count > 1)
                _animationTimer.Start();
        }

        private void PreviewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _animationTimer?.Stop();
            _animationTimer?.Dispose();
            pictureBoxPreview.Image?.Dispose();
        }
        private void btnApply_Click(object sender, EventArgs e) { this.DialogResult = DialogResult.OK; this.Close(); }
        private void btnCancel_Click(object sender, EventArgs e) { this.DialogResult = DialogResult.Cancel; this.Close(); }
    }
}