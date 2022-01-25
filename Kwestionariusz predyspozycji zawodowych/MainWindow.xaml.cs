using Microsoft.Win32;
using System;
using System.Windows;
using System.IO;

namespace Kwestionariusz_predyspozycji_zawodowych
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            TestKit.mainWindow = this;
            TestKit.testWindowGrid = new TestWindowGrid();
            TestKit.testWindowTest = new TestWindowTest();
            TestKit.testWindowResult = new TestWindowResult();
            TestKit.aboutWindow = new AboutWindow();
            TestKit.saveFileDialog = new SaveFileDialog()
            {
                AddExtension = true,
                Title = "Zapisz wynik kwestionariusza",
                InitialDirectory = Directory.GetCurrentDirectory(),
                RestoreDirectory = true,
                CheckPathExists = true,
                DefaultExt = "rtf",
                Filter = "Dokument RTF|*.rtf|Wszystkie pliki|*.*",
                FilterIndex = 1,
                OverwritePrompt = true,
            };
            InitializeComponent();
        }

        private bool containsDigitsOnly(string toCheck)
        {
            foreach (char c in toCheck)
            {
                if (!char.IsDigit(c) && c != '.')
                {
                    return false;
                }
            }

            return true;
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            if ((nameTextBox.Text != "") && (ageTextBox.Text != ""))
            {
                if (containsDigitsOnly(ageTextBox.Text))
                {
                    TestKit.User.Name = nameTextBox.Text;
                    TestKit.User.Age = int.Parse(ageTextBox.Text);

                    if (genderComboBox.Text == "Mężczyzna")
                    {
                        TestKit.User.Gender = TestKit.Gender.Male;
                    }
                    else if (genderComboBox.Text == "Kobieta")
                    {
                        TestKit.User.Gender = TestKit.Gender.Female;
                    }
                    else
                    {
                        TestKit.User.Gender = TestKit.Gender.Undefined;
                    }

                    TestKit.testWindowGrid.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Wiek musi być liczbą.", "Błąd");
                }
            }
            else
            {
                MessageBox.Show("Nie możesz zostawić żadnego pustego pola!", "Błąd");
                return;
            }
        }

        private void aboutButton_Click(object sender, RoutedEventArgs e)
        {
            TestKit.aboutWindow.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz opuścić test?", "Kwestionariusz predyspozycji zawodowych", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
