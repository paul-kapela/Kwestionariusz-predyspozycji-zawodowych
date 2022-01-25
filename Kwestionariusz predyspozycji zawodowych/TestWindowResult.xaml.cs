using System;
using System.Windows;
using System.Printing;
using GemBox.Document;
using System.Windows.Controls;
using System.ComponentModel;

namespace Kwestionariusz_predyspozycji_zawodowych
{
    /// <summary>
    /// Logika interakcji dla klasy TestWindowResult.xaml
    /// </summary>
    public partial class TestWindowResult : Window
    {
        public TestWindowResult()
        {
            InitializeComponent();
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            UpdateResults();
            DisableRadioButtons();
        }

        private void UpdateResults()
        {
            absolutelyYes1.IsChecked = TestKit.beforeResult[0, 0];
            ratherYes1.IsChecked = TestKit.beforeResult[0, 1];
            absolutelyNo1.IsChecked = TestKit.beforeResult[0, 2];
            iDontKnow1.IsChecked = TestKit.beforeResult[0, 3];

            absolutelyYes2.IsChecked = TestKit.beforeResult[1, 0];
            ratherYes2.IsChecked = TestKit.beforeResult[1, 1];
            absolutelyNo2.IsChecked = TestKit.beforeResult[1, 2];
            iDontKnow2.IsChecked = TestKit.beforeResult[1, 3];

            absolutelyYes3.IsChecked = TestKit.beforeResult[2, 0];
            ratherYes3.IsChecked = TestKit.beforeResult[2, 1];
            absolutelyNo3.IsChecked = TestKit.beforeResult[2, 2];
            iDontKnow3.IsChecked = TestKit.beforeResult[2, 3];

            absolutelyYes4.IsChecked = TestKit.beforeResult[3, 0];
            ratherYes4.IsChecked = TestKit.beforeResult[3, 1];
            absolutelyNo4.IsChecked = TestKit.beforeResult[3, 2];
            iDontKnow4.IsChecked = TestKit.beforeResult[3, 3];

            absolutelyYes5.IsChecked = TestKit.beforeResult[4, 0];
            ratherYes5.IsChecked = TestKit.beforeResult[4, 1];
            absolutelyNo5.IsChecked = TestKit.beforeResult[4, 2];
            iDontKnow5.IsChecked = TestKit.beforeResult[4, 3];

            absolutelyYes6.IsChecked = TestKit.beforeResult[5, 0];
            ratherYes6.IsChecked = TestKit.beforeResult[5, 1];
            absolutelyNo6.IsChecked = TestKit.beforeResult[5, 2];
            iDontKnow6.IsChecked = TestKit.beforeResult[5, 3];

            TestKit.OrderAfterResult();

            resultType1.Text = string.Format("{0} (liczba punktów: {1})", TestKit.afterResult[0].Description, TestKit.afterResult[0].Points.ToString());
            resultType2.Text = string.Format("{0} (liczba punktów: {1})", TestKit.afterResult[1].Description, TestKit.afterResult[1].Points.ToString());
            resultType3.Text = string.Format("{0} (liczba punktów: {1})", TestKit.afterResult[2].Description, TestKit.afterResult[2].Points.ToString());
            resultType4.Text = string.Format("{0} (liczba punktów: {1})", TestKit.afterResult[3].Description, TestKit.afterResult[3].Points.ToString());
            resultType5.Text = string.Format("{0} (liczba punktów: {1})", TestKit.afterResult[4].Description, TestKit.afterResult[4].Points.ToString());
            resultType6.Text = string.Format("{0} (liczba punktów: {1})", TestKit.afterResult[5].Description, TestKit.afterResult[5].Points.ToString());
        }

        private void DisableRadioButtons()
        {
            absolutelyYes1.IsEnabled = false;
            ratherYes1.IsEnabled = false;
            absolutelyNo1.IsEnabled = false;
            iDontKnow1.IsEnabled = false;

            absolutelyYes2.IsEnabled = false;
            ratherYes2.IsEnabled = false;
            absolutelyNo2.IsEnabled = false;
            iDontKnow2.IsEnabled = false;

            absolutelyYes3.IsEnabled = false;
            ratherYes3.IsEnabled = false;
            absolutelyNo3.IsEnabled = false;
            iDontKnow3.IsEnabled = false;

            absolutelyYes4.IsEnabled = false;
            ratherYes4.IsEnabled = false;
            absolutelyNo4.IsEnabled = false;
            iDontKnow4.IsEnabled = false;

            absolutelyYes5.IsEnabled = false;
            ratherYes5.IsEnabled = false;
            absolutelyNo5.IsEnabled = false;
            iDontKnow5.IsEnabled = false;

            absolutelyYes6.IsEnabled = false;
            ratherYes6.IsEnabled = false;
            absolutelyNo6.IsEnabled = false;
            iDontKnow6.IsEnabled = false;
        }

        private DocumentModel CreateResultDocument()
        {
            DocumentModel resultDocument = new DocumentModel();

            SpecialCharacter lineBreak = new SpecialCharacter(resultDocument, SpecialCharacterType.LineBreak);
            CharacterFormat titleCharacterFormat = new CharacterFormat() { FontName = "Segoe UI", Size = 21, FontColor = Color.Black, Bold = true };
            CharacterFormat headingCharacterFormat = new CharacterFormat() { FontName = "Segoe UI", Size = 13, FontColor = Color.Black, Bold = true };
            CharacterFormat boldCharacterFormat = new CharacterFormat() { FontName = "Segoe UI", Size = 9, FontColor = Color.Black, Bold = true };
            CharacterFormat normalCharacterFormat = new CharacterFormat() { FontName = "Segoe UI", Size = 9, FontColor = Color.Black, Bold = false };

            resultDocument.Sections.Add(
                new Section(resultDocument,
                    new Paragraph(resultDocument,
                    new Run(resultDocument, "Wynik kwestionariusza predyspozycji zawodowych") { CharacterFormat = titleCharacterFormat.Clone() }) { ParagraphFormat = new ParagraphFormat() { Alignment = GemBox.Document.HorizontalAlignment.Center } },
                    new Paragraph(resultDocument,
                    lineBreak.Clone(),
                    new Run(resultDocument, "Imię i nazwisko: ") { CharacterFormat = boldCharacterFormat.Clone() },
                    new Run(resultDocument, TestKit.User.Name) { CharacterFormat = normalCharacterFormat.Clone() },
                    lineBreak.Clone(),
                    new Run(resultDocument, "Wiek: ") { CharacterFormat = boldCharacterFormat.Clone() },
                    new Run(resultDocument, TestKit.User.Age.ToString()) { CharacterFormat = normalCharacterFormat.Clone() },
                    lineBreak.Clone(),
                    new Run(resultDocument, "Płeć: ") { CharacterFormat = boldCharacterFormat.Clone() },
                    new Run(resultDocument, TestKit.User.GetGenderString()) { CharacterFormat = normalCharacterFormat.Clone() }
                    ),
                    new Paragraph(resultDocument,
                    new Run(resultDocument, "Twój wybór") { CharacterFormat = headingCharacterFormat.Clone() }) { ParagraphFormat = new ParagraphFormat() { Alignment = GemBox.Document.HorizontalAlignment.Center } },
                    new Paragraph(resultDocument,
                    new Run(resultDocument, string.Format("1. Typ realistyczny: {0}", TestKit.GetBeforeResultChoice(0))) { CharacterFormat = normalCharacterFormat.Clone() },
                    lineBreak.Clone(),
                    new Run(resultDocument, string.Format("2. Typ intelektualny: {0}", TestKit.GetBeforeResultChoice(1))) { CharacterFormat = normalCharacterFormat.Clone() },
                    lineBreak.Clone(),
                    new Run(resultDocument, string.Format("3. Typ społeczny: {0}", TestKit.GetBeforeResultChoice(2))) { CharacterFormat = normalCharacterFormat.Clone() },
                    lineBreak.Clone(),
                    new Run(resultDocument, string.Format("4. Typ konwencjonalny: {0}", TestKit.GetBeforeResultChoice(3))) { CharacterFormat = normalCharacterFormat.Clone() },
                    lineBreak.Clone(),
                    new Run(resultDocument, string.Format("5. Typ przedsiębiorczy: {0}", TestKit.GetBeforeResultChoice(4))) { CharacterFormat = normalCharacterFormat.Clone() },
                    lineBreak.Clone(),
                    new Run(resultDocument, string.Format("6. Typ artystyczny: {0}", TestKit.GetBeforeResultChoice(5))) { CharacterFormat = normalCharacterFormat.Clone() }
                    ),
                    new Paragraph(resultDocument,
                    new Run(resultDocument, "Najbardziej odpowiadające Tobie typy według testu") { CharacterFormat = headingCharacterFormat.Clone() }) { ParagraphFormat = new ParagraphFormat() { Alignment = GemBox.Document.HorizontalAlignment.Center } },
                    new Paragraph(resultDocument,
                    new Run(resultDocument, string.Format("1. {0}", resultType1.Text)) { CharacterFormat = normalCharacterFormat.Clone()},
                    lineBreak.Clone(),
                    new Run(resultDocument, string.Format("2. {0}", resultType2.Text)) { CharacterFormat = normalCharacterFormat.Clone() },
                    lineBreak.Clone(),
                    new Run(resultDocument, string.Format("3. {0}", resultType3.Text)) { CharacterFormat = normalCharacterFormat.Clone() },
                    lineBreak.Clone(),
                    new Run(resultDocument, string.Format("4. {0}", resultType4.Text)) { CharacterFormat = normalCharacterFormat.Clone() },
                    lineBreak.Clone(),
                    new Run(resultDocument, string.Format("5. {0}", resultType5.Text)) { CharacterFormat = normalCharacterFormat.Clone() },
                    lineBreak.Clone(),
                    new Run(resultDocument, string.Format("6. {0}", resultType6.Text)) { CharacterFormat = normalCharacterFormat.Clone() }
                    ),
                    new Paragraph(resultDocument,
                    new Run(resultDocument, "Typ realistyczny 1. ") { CharacterFormat = boldCharacterFormat.Clone() },
                    new Run(resultDocument, "Jesteś praktyczny. Preferujesz pracę przynoszącą konkretne, odczuwalne dla siebie i innych rezultaty. Nie przeszkadza Ci praca fizyczna. Interesuje Cię praca z techniką, wymagająca wysiłku umysłowego, dobrze rozwiniętych ruchowych zdolności.") { CharacterFormat = normalCharacterFormat.Clone() },
                    lineBreak.Clone(),
                    new Run(resultDocument, "Typ intelektualny 2. ") { CharacterFormat = boldCharacterFormat.Clone() },
                    new Run(resultDocument, "Jesteś bardziej teoretykiem niż praktykiem. Podoba Ci się nauka i studiowanie, badanie jakiejś dziedziny, dostarczenie nowej wiedzy. Preferujesz pracę przynoszącą radość poznania, a czasami odkrycia, wymagającą wysiłku umysłowego, zdolności do usystematyzowanej informacji, szerokiego horyzontu.") { CharacterFormat = normalCharacterFormat.Clone() },
                    lineBreak.Clone(),
                    new Run(resultDocument, "Typ społeczny 3. ") { CharacterFormat = boldCharacterFormat.Clone() },
                    new Run(resultDocument, "Jesteś komunikatywny, lubisz pracować z ludźmi i dla ludzi, dlatego interesuje Cię nauka, wychowanie, obsługa klienta, okazywanie pomocy potrzebującym, itp. Lubisz sprawy wypełnione emocjami, pracę żywą, wymagającą kontaktu z ludźmi oraz pełnej komunikacji.") { CharacterFormat = normalCharacterFormat.Clone() },
                    lineBreak.Clone(),
                    new Run(resultDocument, "Typ konwencjonalny 4. ") { CharacterFormat = boldCharacterFormat.Clone() },
                    new Run(resultDocument, "Lubisz pracować z dokumentami, tekstami, cyframi oraz wykorzystywać narzędzia i przyrządy komputerowe. Praca spokojna, bez ryzyka, z wąskim zakresem obowiązków. Może być związana z obróbką informacji, z obliczeniami, wyliczeniami, wymagająca dokładności, staranności, wytrwałości. Chciałbyś uciec od kontaktów i rozmów, odpowiedzialności zarządzania innymi oraz odpowiedzialności za rezultaty ich pracy.") { CharacterFormat = normalCharacterFormat.Clone() },
                    lineBreak.Clone(),
                    new Run(resultDocument, "Typ przedsiębiorczy 5. ") { CharacterFormat = boldCharacterFormat.Clone() },
                    new Run(resultDocument, "Jesteś organizatorem zorientowanym na pracę niewymagającą wiedzy twórczej. Preferujesz pracę dającą pełną swobodę, samodzielność, bezpieczną w uwarunkowaniach społecznych, wyżej stojącą w hierarchii od innych, dającą materialne zabezpieczenie; pracę pełną pomysłów, z ryzykiem, wymagającą inicjatywy, przedsiębiorczości, brania odpowiedzialności na siebie.") { CharacterFormat = normalCharacterFormat.Clone() },
                    lineBreak.Clone(),
                    new Run(resultDocument, "Typ artystyczny 6. ") { CharacterFormat = boldCharacterFormat.Clone() },
                    new Run(resultDocument, "Masz naturę artysty. Lubisz rodzaje działań dające możliwość swobodnego wyrażania własnego wnętrza, bez przymusu i ram czasowych, formalności; pracę dającą upływ fantazji, wyobraźni, wymagającą estetycznego smaku, specjalnych zdolności (artystycznych, literackich, muzycznych).") { CharacterFormat = normalCharacterFormat.Clone() }
                )
                )
                { PageSetup = new PageSetup() { PaperType = PaperType.A4} }
            );
            return resultDocument;
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            TestKit.saveFileDialog.FileName = string.Format("Wynik kwestionariusza {0}.rtf", TestKit.User.Name);
            TestKit.saveFileDialog.ShowDialog();

            if (TestKit.saveFileDialog.FileName != "")
            {
                CreateResultDocument().Save(TestKit.saveFileDialog.FileName);
            }
            else
            {
                MessageBox.Show("Nazwa lub/oraz ścieżka pliku nie może być pusta!", "Błąd");
            }
        }

        private void printButton_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.UserPageRangeEnabled = true;

            if (printDialog.ShowDialog() == true)
            {
                PrintOptions printOptions = new PrintOptions(printDialog.PrintTicket.GetXmlStream())
                {
                    FromPage = printDialog.PageRange.PageFrom - 1,
                    ToPage = printDialog.PageRange.PageTo == 0 ? int.MaxValue : printDialog.PageRange.PageTo - 1
                };

                CreateResultDocument().Print(printDialog.PrintQueue.FullName, printOptions);
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
            Closing -= Window_Closing;
            Close();
            if (TestKit.testWindowTest.recentlyPressedButton == TestWindowTest.Buttons.Left)
            {
                TestKit.afterResult[TestKit.testWindowTest.currentPair.Left.ProfessionCode - 1].Points--;
            }
            else
            {
                TestKit.afterResult[TestKit.testWindowTest.currentPair.Right.ProfessionCode - 1].Points--;
            }
            TestKit.testWindowTest.Show();
            TestKit.testWindowResult = new TestWindowResult();
        }
    }
}
