using System;
using System.Windows;
using System.ComponentModel;

namespace Kwestionariusz_predyspozycji_zawodowych
{
    /// <summary>
    /// Logika interakcji dla klasy TestWindowTest.xaml
    /// </summary>
    /// 

    public partial class TestWindowTest : Window
    {
        
        public int currentIndex;
        public enum Buttons { Left, Right }
        public Buttons recentlyPressedButton;
        public TestKit.Pair currentPair;

        public TestWindowTest()
        {
            InitializeComponent();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            currentIndex = 1;
            Update();
        }

        private void Update()
        {
            currentPair = TestKit.Pairs()[currentIndex - 1];
            leftButton.Content = currentPair.Left.Name;
            rightButton.Content = currentPair.Right.Name;
            definitionLeftTextBlock.Text = currentPair.Left.Description;
            definitionRightTextBlock.Text = currentPair.Right.Description;
        }

        private void NextPair()
        {
            if (currentIndex < TestKit.Pairs().Count)
            {
                currentIndex++;
                Update();
            }
            else
            {
                TestKit.testWindowResult.Show();
                Hide();
            }
            
        }

        private void leftButton_Click(object sender, RoutedEventArgs e)
        {
            TestKit.afterResult[currentPair.Left.ProfessionCode - 1].Points++;
            recentlyPressedButton = Buttons.Left;
            NextPair();
        }

        private void rightButton_Click(object sender, RoutedEventArgs e)
        {
            TestKit.afterResult[currentPair.Right.ProfessionCode - 1].Points++;
            recentlyPressedButton = Buttons.Right;
            NextPair();
        }

        private void definitionsExpander_Expanded(object sender, RoutedEventArgs e) => Height += 330;

        private void definitionsExpander_Collapsed(object sender, RoutedEventArgs e) => Height -= 330;

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
            if (currentIndex == 1)
            {
                TestKit.afterResult = new TestKit.Type[6]
                {
                    new TestKit.Type(0, "Typ realistyczny"),
                    new TestKit.Type(0, "Typ intelektualny"),
                    new TestKit.Type(0, "Typ społeczny"),
                    new TestKit.Type(0, "Typ konwencjonalny"),
                    new TestKit.Type(0, "Typ przedsiębiorczy"),
                    new TestKit.Type(0, "Typ artystyczny")
                };
                Hide();
                TestKit.testWindowGrid.Show();
            }
            else
            {
                if (recentlyPressedButton == Buttons.Left)
                {
                    TestKit.afterResult[currentPair.Left.ProfessionCode - 1].Points--;
                }
                else
                {
                    TestKit.afterResult[currentPair.Right.ProfessionCode - 1].Points--;
                }
                currentIndex--;
                Update();
            }
        }
    }
}
