using System.Windows;
using System.ComponentModel;

namespace Kwestionariusz_predyspozycji_zawodowych
{
    /// <summary>
    /// Logika interakcji dla klasy AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
