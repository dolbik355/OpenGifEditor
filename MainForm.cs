using ImageMagick;
using ImageMagick.Drawing;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace OpenGifImage
{
    public partial class MainForm : Form
    {
        private Timer _scrollTimer;
        private MagickImageCollection _gif;
        private MagickImage _overlay;
        private int _currentFrameIndex = 0;
        private readonly UndoRedoStack _undoRedoStack = new UndoRedoStack();

        private bool _isDirty = false;
        private string _currentFileName = "Без названия";

        public MainForm()
        {
            MagickNET.SetTempDirectory(Path.GetTempPath()); 
            ResourceLimits.Memory = (ulong)(1.5 * 1024 * 1024 * 1024);
            ResourceLimits.Memory = (ulong)(1.5 * 1024L * 1024L * 1024L);
            int targetThreads = Environment.ProcessorCount > 1 ? Environment.ProcessorCount - 1 : 1;
            ResourceLimits.Thread = (uint)targetThreads;

            InitializeComponent();
            ApplyDarkTheme();

            this.MinimumSize = new Size(1050, 750);
            this.FormClosing += MainForm_FormClosing;
            this.AllowDrop = true;
            this.DragEnter += MainForm_DragEnter;
            this.DragDrop += MainForm_DragDrop;

            textBoxCropLeft.TextChanged += CoordsChanged;
            textBoxCropTop.TextChanged += CoordsChanged;
            textBoxCropRight.TextChanged += CoordsChanged;
            textBoxCropBottom.TextChanged += CoordsChanged;
            textBoxCropLeft.KeyPress += TextBox_Numeric_KeyPress;
            textBoxCropTop.KeyPress += TextBox_Numeric_KeyPress;
            textBoxCropRight.KeyPress += TextBox_Numeric_KeyPress;
            textBoxCropBottom.KeyPress += TextBox_Numeric_KeyPress;
            textBoxCropStart.KeyPress += TextBox_Numeric_KeyPress;
            textBoxCropEnd.KeyPress += TextBox_Numeric_KeyPress;

            ToggleUIControls(false);

            _scrollTimer = new Timer();
            _scrollTimer.Interval = 50; 
            _scrollTimer.Tick += (s, ev) =>
            {
                _scrollTimer.Stop();
                _currentFrameIndex = trackBarFrames.Value;
                UpdateUI(); 
            };
        }

        private void ApplyDarkTheme()
        {
            this.BackColor = AppColors.FormBackground;
            this.ForeColor = AppColors.TextColor;
        }

        private void ToggleUIControls(bool isEnabled)
        {
            buttonSave.Enabled = isEnabled;
            buttonCrop.Enabled = isEnabled;
            buttonCropLength.Enabled = isEnabled;
            buttonAddFrame.Enabled = isEnabled;
            buttonSetDelay.Enabled = isEnabled;
            buttonPreview.Enabled = isEnabled;
            trackBarFrames.Enabled = isEnabled;
            tabMethods.Enabled = isEnabled;

            if (!isEnabled)
            {
                buttonUndo.Enabled = false;
                buttonRedo.Enabled = false;
            }
        }

        private DialogResult PromptToSave()
        {
            if (!_isDirty || _gif == null) return DialogResult.No;

            DialogResult result = MessageBox.Show(
                $"Вы хотите сохранить изменения в файле \"{_currentFileName}\"?",
                "Сохранение файла",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                return SaveFile() ? DialogResult.Yes : DialogResult.Cancel;
            }

            return result;
        }

        private bool SaveFile()
        {
            if (_gif == null) return false;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;
                string tmp = path + ".tmp";

                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    uint baseW = _gif[0].Width;
                    uint baseH = _gif[0].Height;

                    foreach (var frame in _gif)
                    {
                        if (frame.Width != baseW || frame.Height != baseH)
                            frame.Resize(baseW, baseH);
                        frame.Page = new MagickGeometry(0, 0, baseW, baseH);
                    }
                    _gif.Write(tmp, MagickFormat.Gif);

                    if (File.Exists(path)) File.Delete(path);
                    File.Move(tmp, path);

                    _isDirty = false;
                    _currentFileName = Path.GetFileName(path);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении файла.\n\nДетали: {ex.Message}", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
            return false;
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (PromptToSave() == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }

            _gif?.Dispose();
            _overlay?.Dispose();
            _undoRedoStack.Clear();
        }

        private void UpdateUI()
        {
            if (_gif == null || _gif.Count == 0) return;

            ToggleUIControls(true);
            trackBarFrames.Maximum = Math.Max(0, _gif.Count - 1);
            _currentFrameIndex = Math.Min(_currentFrameIndex, trackBarFrames.Maximum);
            trackBarFrames.Value = _currentFrameIndex;

            numericUpDownFrameToAddAfter.Maximum = _gif.Count;
            numericUpDownFrameToAddAfter.Minimum = 0;

            labelCurrentFrame.Text = $"Текущий кадр: {_currentFrameIndex + 1}";
            labelTotalFrames.Text = $"Всего кадров: {_gif.Count}";

            buttonUndo.Enabled = _undoRedoStack.CanUndo;
            buttonRedo.Enabled = _undoRedoStack.CanRedo;

            try
            {
                using (var frameClone = new MagickImage(_gif[_currentFrameIndex]))
                {
                    if (_overlay != null)
                    {
                        frameClone.Composite(_overlay, CompositeOperator.Over);
                    }

                    using (var ms = new MemoryStream())
                    {
                        frameClone.Write(ms, MagickFormat.Bmp);
                        ms.Position = 0;

                        var oldImage = pictureBox1.Image;
                        pictureBox1.Image = new Bitmap(ms);
                        oldImage?.Dispose(); 
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка отрисовки главного окна: " + ex.Message);
            }
        }

        private int ParseInt(string s, int def = 0)
        {
            return int.TryParse(s.Trim(), out int r) ? r : def;
        }

        private void ResetCropFields()
        {
            textBoxCropLeft.Text = "0";
            textBoxCropTop.Text = "0";
            textBoxCropRight.Text = "0";
            textBoxCropBottom.Text = "0";
        }

        private bool ValidateCropInputs(out int l, out int t, out int r, out int b)
        {
            l = ParseInt(textBoxCropLeft.Text);
            t = ParseInt(textBoxCropTop.Text);
            r = ParseInt(textBoxCropRight.Text);
            b = ParseInt(textBoxCropBottom.Text);

            if (_gif == null) return false;

            int w = (int)_gif[0].Width;
            int h = (int)_gif[0].Height;

            if (l < 0 || t < 0 || r < 0 || b < 0 || l + r >= w || t + b >= h)
            {
                MessageBox.Show("Значения обрезки превышают размер изображения или заданы некорректно!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void GenerateOverlay()
        {
            if (_gif == null || _gif.Count == 0) return;

            int l = ParseInt(textBoxCropLeft.Text);
            int t = ParseInt(textBoxCropTop.Text);
            int r = ParseInt(textBoxCropRight.Text);
            int b = ParseInt(textBoxCropBottom.Text);

            int w = (int)_gif[0].Width;
            int h = (int)_gif[0].Height;

            if (l < 0 || t < 0 || r < 0 || b < 0 || l + r >= w || t + b >= h)
            {
                _overlay?.Dispose();
                _overlay = null;
                UpdateUI();
                return;
            }

            if (l == 0 && t == 0 && r == 0 && b == 0)
            {
                _overlay?.Dispose();
                _overlay = null;
                UpdateUI();
                return;
            }

            int centerW = w - l - r;
            int centerH = h - t - b;

            _overlay?.Dispose();
            _overlay = new MagickImage(MagickColor.FromRgba(0, 0, 0, 0), (uint)w, (uint)h);

            var draw = new Drawables();

            draw.FillColor(MagickColor.FromRgba(255, 0, 0, 150));
            draw.Rectangle(0, 0, w, t);
            draw.Rectangle(0, t + centerH, w, h);
            draw.Rectangle(0, t, l, t + centerH);
            draw.Rectangle(l + centerW, t, w, t + centerH);

            draw.StrokeColor(MagickColor.FromRgba(255, 0, 0, 255));
            draw.StrokeWidth(2);
            draw.FillColor(MagickColor.FromRgba(0, 0, 0, 0));
            draw.Rectangle(l, t, l + centerW, t + centerH);

            draw.Draw(_overlay);
            UpdateUI();
        }

        private void CoordsChanged(object sender, EventArgs e)
        {
            GenerateOverlay();
        }

        private void ApplyAction(MagickImageCollection tempGif, string title)
        {
            using (var apf = new ActionPreviewForm(tempGif, title))
            {
                if (apf.ShowDialog() == DialogResult.OK)
                {
                    _undoRedoStack.PushState(_gif); 

                    _gif.Dispose();                 
                    _gif = tempGif;                 

                    _isDirty = true;
                    ResetCropFields();              
                    UpdateUI();                     
                }
                else
                {
                    tempGif.Dispose();              
                }
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (PromptToSave() == DialogResult.Cancel) return;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var loadedGif = new MagickImageCollection(openFileDialog.FileName);
                    loadedGif.Coalesce(); 

                    _gif?.Dispose();
                    _gif = loadedGif;

                    _currentFileName = Path.GetFileName(openFileDialog.FileName);
                    _isDirty = false;

                    _undoRedoStack.Clear();
                    _currentFrameIndex = 0;

                    ResetCropFields();
                    UpdateUI();
                }
                catch (MagickException ex)
                {
                    MessageBox.Show($"Файл поврежден или не является поддерживаемым изображением.\n\nДетали: {ex.Message}", "Ошибка чтения файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка при доступе к файлу.\nВозможно, он заблокирован другой программой.\n\nДетали: {ex.Message}", "Системная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFile();
        }
        private async void buttonCrop_Click(object sender, EventArgs e)
        {
            if (!ValidateCropInputs(out int l, out int t, out int r, out int b)) return;

            ToggleUIControls(false); 

            string originalText = buttonCrop.Text;
            buttonCrop.Text = "Обработка...";

            var temp = (MagickImageCollection)_gif.Clone();
            uint newW = (uint)(_gif[0].Width - l - r);
            uint newH = (uint)(_gif[0].Height - t - b);

            try
            {
                await System.Threading.Tasks.Task.Run(() =>
                {
                    foreach (var f in temp)
                    {
                        f.Crop(new MagickGeometry(l, t, newW, newH));
                        f.Page = new MagickGeometry(0, 0, newW, newH);
                    }
                });

                ApplyAction(temp, "Подтверждение обрезки");
            }
            catch (Exception ex)
            {
                temp.Dispose();
                MessageBox.Show($"Ошибка обрезки: {ex.Message}");
            }
            finally
            {
                buttonCrop.Text = originalText;
                ToggleUIControls(true); 
            }
        }

        private void buttonCropLength_Click(object sender, EventArgs e)
        {
            if (_gif == null) return;

            if (string.IsNullOrWhiteSpace(textBoxCropStart.Text) || string.IsNullOrWhiteSpace(textBoxCropEnd.Text))
            {
                MessageBox.Show("Пожалуйста, введите начальный и конечный кадр.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int s = ParseInt(textBoxCropStart.Text) - 1;
            int end = ParseInt(textBoxCropEnd.Text);

            if (s < 0 || end > _gif.Count || s >= end)
            {
                MessageBox.Show($"Неверный диапазон!\nНачальный кадр должен быть меньше конечного.\nДопустимые значения: от 1 до {_gif.Count}.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            var temp = new MagickImageCollection();

            try
            {
                for (int i = s; i < end; i++)
                {
                    temp.Add(_gif[i].Clone());
                }
                ApplyAction(temp, "Подтверждение изменения длины");
            }
            catch (Exception ex)
            {
                temp.Dispose(); 
                MessageBox.Show($"Ошибка при извлечении кадров.\n\nДетали: {ex.Message}", "Сбой операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void buttonAddFrame_Click(object sender, EventArgs e)
        {
            if (_gif == null || addFrameFileDialog.ShowDialog() != DialogResult.OK) return;

            ToggleUIControls(false);
            var temp = (MagickImageCollection)_gif.Clone();

            try
            {
                using (var newFrame = new MagickImage(addFrameFileDialog.FileName))
                {
                    newFrame.Resize((uint)_gif[0].Width, (uint)_gif[0].Height);
                    newFrame.Page = new MagickGeometry(0, 0, _gif[0].Width, _gif[0].Height);
                    newFrame.AnimationDelay = 10;
                    temp.Insert((int)numericUpDownFrameToAddAfter.Value, (MagickImage)newFrame.Clone());
                }
                foreach (var frame in temp)
                {
                    frame.Page = new MagickGeometry(0, 0, _gif[0].Width, _gif[0].Height);
                }

                ApplyAction(temp, "Добавить выбранный кадр?");
            }
            catch (Exception ex)
            {
                temp.Dispose();
                MessageBox.Show($"Ошибка при добавлении кадра: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ToggleUIControls(true);
            }
        }

        private void buttonSetDelay_Click(object sender, EventArgs e)
        {
            if (_gif == null) return;

            int[] current = new int[_gif.Count];
            for (int i = 0; i < _gif.Count; i++) current[i] = (int)(_gif[i].AnimationDelay * 10);

            using (var df = new FrameDelayForm(current))
            {
                if (df.ShowDialog() == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    var temp = (MagickImageCollection)_gif.Clone();

                    try
                    {
                        for (int i = 0; i < temp.Count; i++)
                        {
                            temp[i].AnimationDelay = (uint)Math.Max(1, df.NewDelays[i] / 10);
                        }
                        ApplyAction(temp, "Применить новые задержки?");
                    }
                    catch (Exception ex)
                    {
                        temp.Dispose();
                        MessageBox.Show($"Ошибка применения задержек.\n\nДетали: {ex.Message}", "Сбой операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        Cursor.Current = Cursors.Default;
                    }
                }
            }
        }
        private void buttonUndo_Click(object sender, EventArgs e)
        {
            if (_undoRedoStack.CanUndo)
            {
                _gif = _undoRedoStack.Undo(_gif);
                _isDirty = true;
                UpdateUI();
            }
        }

        private void buttonRedo_Click(object sender, EventArgs e)
        {
            if (_undoRedoStack.CanRedo)
            {
                _gif = _undoRedoStack.Redo(_gif);
                _isDirty = true;
                UpdateUI();
            }
        }

        private void trackBarFrames_Scroll(object sender, EventArgs e)
        {
            _scrollTimer.Stop();
            _scrollTimer.Start();
            labelCurrentFrame.Text = $"Текущий кадр: {trackBarFrames.Value + 1}";
        }

        private void buttonPreview_Click(object sender, EventArgs e)
        {
            if (_gif == null) return;

            using (var clonedGif = (MagickImageCollection)_gif.Clone())
            using (var previewForm = new PreviewForm(clonedGif, "Просмотр анимации"))
            {
                previewForm.ShowDialog();
            }
        }
        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0 && files[0].ToLower().EndsWith(".gif"))
                    e.Effect = DragDropEffects.Copy;
                else
                    e.Effect = DragDropEffects.None;
            }
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            if (PromptToSave() == DialogResult.Cancel) return;

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                string filePath = files[0];
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    var loadedGif = new ImageMagick.MagickImageCollection(filePath);
                    loadedGif.Coalesce();

                    _gif?.Dispose();
                    _gif = loadedGif;
                    _currentFileName = System.IO.Path.GetFileName(filePath);
                    _isDirty = false;
                    _undoRedoStack.Clear();
                    _currentFrameIndex = 0;
                    ResetCropFields();
                    UpdateUI();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось открыть перетаскиваемый файл.\n\nДетали: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }
        private void TextBox_Numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
                System.Media.SystemSounds.Beep.Play();
            }
        }
    }
}