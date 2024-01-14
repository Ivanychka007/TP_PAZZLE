using System;
using System.Windows.Forms;

namespace University.Puzzle.UI
{
    internal static class Program
    {
        /// <summary>
        /// Точка входа в приложение.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            new AuthorizationRegistrationForm().Show();
            Application.Run();
        }
    }
}
