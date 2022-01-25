using System;
using System.Windows;
using System.ComponentModel;

namespace Kwestionariusz_predyspozycji_zawodowych
{
    /// <summary>
    /// Logika interakcji dla klasy TestWindowGrid.xaml
    /// </summary>
    public partial class TestWindowGrid : Window
    {
        public TestWindowGrid()
        {
            InitializeComponent();
        }

        private bool[,] GetSelections()
        {
            bool[,] selections = new bool[6, 4];

            selections[0, 0] = absolutelyYes1.IsChecked.Value;
            selections[0, 1] = ratherYes1.IsChecked.Value;
            selections[0, 2] = absolutelyNo1.IsChecked.Value;
            selections[0, 3] = iDontKnow1.IsChecked.Value;

            selections[1, 0] = absolutelyYes2.IsChecked.Value;
            selections[1, 1] = ratherYes2.IsChecked.Value;
            selections[1, 2] = absolutelyNo2.IsChecked.Value;
            selections[1, 3] = iDontKnow2.IsChecked.Value;

            selections[2, 0] = absolutelyYes3.IsChecked.Value;
            selections[2, 1] = ratherYes3.IsChecked.Value;
            selections[2, 2] = absolutelyNo3.IsChecked.Value;
            selections[2, 3] = iDontKnow3.IsChecked.Value;

            selections[3, 0] = absolutelyYes4.IsChecked.Value;
            selections[3, 1] = ratherYes4.IsChecked.Value;
            selections[3, 2] = absolutelyNo4.IsChecked.Value;
            selections[3, 3] = iDontKnow4.IsChecked.Value;

            selections[4, 0] = absolutelyYes5.IsChecked.Value;
            selections[4, 1] = ratherYes5.IsChecked.Value;
            selections[4, 2] = absolutelyNo5.IsChecked.Value;
            selections[4, 3] = iDontKnow5.IsChecked.Value;

            selections[5, 0] = absolutelyYes6.IsChecked.Value;
            selections[5, 1] = ratherYes6.IsChecked.Value;
            selections[5, 2] = absolutelyNo6.IsChecked.Value;
            selections[5, 3] = iDontKnow6.IsChecked.Value;

            return selections;
        }

        private bool AreSelectionsGood(bool[,] toCheck)
        {
            int i = 0;

            foreach (bool boolean in toCheck)
            {
                if (boolean == true)
                {
                    i++;
                }
            }
            
            if (i != 6)
            {
                return false;
            }

            return true;
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            if (AreSelectionsGood(GetSelections()) == true)
            {
                TestKit.beforeResult = GetSelections();
                TestKit.testWindowTest.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Nie możesz pozostawić żadnego miejsca pustego!", "Błąd");
                return;
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
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

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            TestKit.beforeResult = new bool[6, 4];
            Hide();
            TestKit.mainWindow.Show();
        }
    }
}
