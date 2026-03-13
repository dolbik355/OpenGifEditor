using System;
using System.Windows.Forms;

namespace OpenGifImage
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += (sender, args) =>
            {
                MessageBox.Show($"Произошла непредвиденная ошибка в работе программы.\nОна не будет закрыта, но рекомендуется сохранить данные.\n\nДетали: {args.Exception.Message}",
                    "Критический сбой", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                Exception ex = (Exception)args.ExceptionObject;
                MessageBox.Show($"Критический сбой системы: {ex.Message}", "Фатальная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            Application.Run(new MainForm());
        }
    }
}