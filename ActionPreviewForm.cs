using ImageMagick;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace OpenGifImage
{
    public partial class ActionPreviewForm : Form
    {
        private readonly MagickImageCollection _tempGif;
        private int _currentFrame = 0;
        private Timer _timer;
        private bool _isPlaying = true;

        public ActionPreviewForm(MagickImageCollection gifClone, string title)
        {
            
            if (gifClone == null || gifClone.Count == 0)
            {
                throw new ArgumentException("Коллекция кадров не может быть пустой.", nameof(gifClone));
            }

            _tempGif = gifClone;
            InitializeComponent();
            
            this.Text = title;
            this.DoubleBuffered = true; 
            trackBarPreview.Minimum = 0;
            trackBarPreview.Maximum = _tempGif.Count - 1;
            trackBarPreview.TickFrequency = _tempGif.Count > 50 ? 5 : 1; 
            _timer = new Timer();
            _timer.Tick += Timer_Tick;
            btnPlayPause.Click += BtnPlayPause_Click;
            trackBarPreview.Scroll += TrackBarPreview_Scroll;
            btnApply.Click += (s, e) => { this.DialogResult = DialogResult.OK; this.Close(); };
            btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            ShowFrame(0);

            if (_tempGif.Count > 1)
            {
                _timer.Start();
            }
            else
            {
                _isPlaying = false;
                btnPlayPause.Enabled = false; 
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
           
            if (_tempGif == null || _tempGif.Count <= 1) return;
            
            _currentFrame = (_currentFrame + 1) % _tempGif.Count;
            ShowFrame(_currentFrame);
        }

        private void ShowFrame(int index)
        {
            if (_tempGif == null || _tempGif.Count == 0) return;

       
            int safeIndex = Math.Max(0, Math.Min(index, _tempGif.Count - 1));

            try
            {
                using (var ms = new MemoryStream())
                {
                  
                    _tempGif[safeIndex].Write(ms, MagickFormat.Bmp);
                    ms.Position = 0;

                    var oldImg = pictureBoxPreview.Image;
                    pictureBoxPreview.Image = new Bitmap(ms);
                    
                
                    oldImg?.Dispose(); 
                }

                
                lblFrameInfo.Text = $"Кадр {safeIndex + 1} / {_tempGif.Count}";
                
                if (trackBarPreview.Value != safeIndex)
                {
                    trackBarPreview.Value = safeIndex;
                }

             
                uint delayTicks = _tempGif[safeIndex].AnimationDelay;
                int intervalMs = (delayTicks <= 1) ? 100 : (int)(delayTicks * 10);
                
           
                _timer.Interval = Math.Max(20, intervalMs); 
            }
            catch (Exception ex)
            {
            
                Console.WriteLine($"Ошибка отрисовки предпросмотра: {ex.Message}");
                _timer.Stop(); 
            }
        }

        private void TrackBarPreview_Scroll(object sender, EventArgs e)
        {
  
            _currentFrame = trackBarPreview.Value;
            ShowFrame(_currentFrame);
        }

        private void BtnPlayPause_Click(object sender, EventArgs e)
        {
            _isPlaying = !_isPlaying;
            _timer.Enabled = _isPlaying;
            btnPlayPause.Text = _isPlaying ? "Пауза" : "Воспроизвести";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
 
            if (_timer != null)
            {
                _timer.Stop();
                _timer.Dispose();
            }
            
            if (pictureBoxPreview.Image != null)
            {
                pictureBoxPreview.Image.Dispose();
                pictureBoxPreview.Image = null;
            }
            
            base.OnFormClosing(e);
        }
    }
}