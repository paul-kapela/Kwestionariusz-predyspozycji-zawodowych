using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwestionariusz_predyspozycji_zawodowych
{
    public static class TestKit
    {
        public static MainWindow mainWindow;
        public static TestWindowGrid testWindowGrid;
        public static TestWindowTest testWindowTest;
        public static TestWindowResult testWindowResult;
        public static AboutWindow aboutWindow;
        public static SaveFileDialog saveFileDialog;

        public static bool[,] beforeResult = new bool[6, 4];
        public static Type[] afterResult = new Type[6]
        {
            new Type(0, "Typ realistyczny"),
            new Type(0, "Typ intelektualny"),
            new Type(0, "Typ społeczny"),
            new Type(0, "Typ konwencjonalny"),
            new Type(0, "Typ przedsiębiorczy"),
            new Type(0, "Typ artystyczny")
        };

        public static string GetBeforeResultChoice(int index)
        {
            if (beforeResult[index, 0] == true)
            {
                return "Absolutnie tak";
            }
            else if (beforeResult[index, 1] == true)
            {
                return "Raczej tak";
            }
            else if (beforeResult[index, 2] == true)
            {
                return "Absolutnie nie";
            }
            else if (beforeResult[index, 3] == true)
            {
                return "Nie wiem";
            }
            else
            {
                return "Nie wiem";
            }
        }

        public static void OrderAfterResult()
        {
            Array.Sort(afterResult, (x, y) => y.Points.CompareTo(x.Points));
        }

        public enum Gender { Male, Female, Undefined }

        public static class User
        {
            public static string Name { get; set; }
            public static int Age { get; set; }
            public static Gender Gender { get; set; }

            public static string GetGenderString()
            {
                switch (Gender)
                {
                    case Gender.Male:
                        return "Mężczyzna";
                        break;
                    case Gender.Female:
                        return "Kobieta";
                        break;
                    case Gender.Undefined:
                        return "Nieokreślona";
                        break;
                    default:
                        return "Nieokreślona";
                        break;
                }
            }
        }

        public class Profession
        {
            public string Name { get; internal set; }
            public string Description { get; internal set; }
            public int ProfessionCode { get; internal set; }

            public Profession(string name, string description, int professionCode)
            {
                Name = name;
                Description = description;
                ProfessionCode = professionCode;
            }
        }

        public class Pair
        {
            public Profession Left { get; internal set; }
            public Profession Right { get; internal set; }
        }

        public class Type
        {
            public int Points { get; set; }
            public string Description { get; internal set; } 

            public Type(int points, string description)
            {
                Points = points;
                Description = description;
            }
        }

        public static List<Profession> Professions = new List<Profession>()
        {
            new Profession("Inżynier", "Inżynier to osoba, która ma umiejętności i wiedzę zdobytą w zakresie nauk inżynieryjnych i technicznych. Jest to także określenie tytułu zawodowego nadawanego przez uczelnie wyższe po ukończeniu studiów inżynierskich.", 1),
            new Profession("Socjolog", "Socjolog to naukowiec, który prowadzi badania wybranych grup społecznych pod kątem różnych dyscyplin socjologicznych - socjologii ogólnej, pracy, kultury, etc.", 2),
            new Profession("Cukiernik", "Cukiernik (ciastkarz) to osoba, która wykonuje czynności związane z wypiekiem ciast i ciastek.", 1),
            new Profession("Ksiądz", "Ksiądz to duchowny w poszczególnych religiach, który odpowiada na przykład za sakramenty albo msze.", 3),
            new Profession("Kucharz", "Kucharz to osoba, która przyrządza zgodnie z zasadami sztuki kulinarnej potrawy w zakładach gastronomicznych, najczęściej według zamówienia przyjętego przez kelnera.", 1),
            new Profession("Statystyk", "Statystyk to osoba, która zajmuje się analizowaniem i opracowaniem danych, zwłaszcza ekonomicznych i społecznych. Planuje, organizuje oraz koordynuje przebieg zbierania statystycznych informacji,  analizuje uzyskane wyniki, a następnie prezentuje je w formie zestawień i raportów. Pracuje także nad stworzeniem nowych modeli oraz technik prowadzenia badań i zbierania danych.", 4),
            new Profession("Fotograf", "Fotograf to osoba, której praca polega na utrwalaniu osób, rzeczy, przyrody, martwej natury itp. za pomocą aparatu cyfrowego lub analogowego.", 1),
            new Profession("Przedstawiciel handlowy", "Przedstawiciel handlowy to osoba odpowiedzialna za pozyskanie i obsługę klientów dla zatrudniającego go przedsiębiorstwa.", 5),
            new Profession("Mechanik", "Mechanik to osoba zajmująca się projektowaniem, konstruowaniem, budową, eksploatacją i naprawą maszyn, urządzeń i mechanizmów.", 1),
            new Profession("Dekorator", "Dekorator to osoba, która zawodowo zajmuje się przeprowadzeniem metamorfoz wizualnych w sklepach, magazynach i innych pomieszczeniach, a także prywatnych domach czy mieszkaniach.", 6),
            new Profession("Filozof", "Filozof to człowiek zajmujący się ogólnymi, podstawowymi zagadkami świata: naturą istnienia i rzeczywistości, poznawalnością prawdy czy tym, jakie działanie jest pożądane.", 2),
            new Profession("Lekarz", "Lekarz to osoba posiadająca wiedzę i uprawnienia do leczenia ludzi i zwierząt.", 3),
            new Profession("Ekolog", "Ekolog to osoba zajmująca się ekologią, czyli nauką o strukturze i funkcjonowaniu przyrody.", 2),
            new Profession("Księgowy", "Księgowy to pracownik działu księgowości, osoba zajmująca się wszelkimi czynnościami związanymi z prowadzeniem ksiąg rachunkowych podmiotów gospodarczych.", 4),
            new Profession("Programista", "Programista to osoba, która tworzy programy komputerowe w pewnym języku programowania. Termin ten może odnosić się także do specjalisty w jednej dziedzinie programowania.", 2),
            new Profession("Adwokat", "Adwokat to prawnik świadczący pomoc prawną w szczególności polegającą na udzielaniu porad prawnych, sporządzaniu opinii prawnych, opracowywaniu projektów aktów prawnych oraz występowaniu przed sądami i urzędami.", 5),
            new Profession("Krytyk filmowy", "Krytyk filmowy to osoba profesjonalnie recenzująca filmy.", 2),
            new Profession("Tłumacz literatury", "Tłumacz literatury to osoba, która zajmuje się tłumaczeniem książek z ich oryginalnego języka na inny.", 6),
            new Profession("Agent ubezpieczeniowy", "Agent ubezpieczeniowy to przedsiębiorca prowadząca działalność w zakresie ubezpieczeń, przedstawiciel firmy ubezpieczeniowej.", 3),
            new Profession("Archiwista", "Archiwista (archiwariusz) to osoba zajmująca się działaniami mającymi na celu przechowywanie dokumentów dla ich późniejszego udostępnienia.", 4),
            new Profession("Trener", "Trener to osoba zajmująca się przygotowaniem fizycznym i psychicznym swoich podopiecznych (najczęściej grupy) w wielu dziedzinach życia, m.in. sportu. Najczęściej wyspecjalizowany jest w jednej, konkretnej dyscyplinie (np. piłka nożna, koszykówka czy gimnastyka). Jego zadaniem jest umotywowywanie i wyszkolenie osób, z którymi pracuje.", 3),
            new Profession("Telereporter", "Telereporter to osoba pracująca w telewizji, nadająca reportaż z innego miejsca niż studio telewizyjne.", 5),
            new Profession("Wywiadowca", "Wywiadowca to osoba pozyskująca informacje dla swojego zleceniodawcy.", 3), 
            new Profession("Znawca sztuki", "Znawca sztuki to osoba mająca szerokie rozeznanie w danej dziedzinie sztuki.", 6),
            new Profession("Notariusz", "Notariusz w systemach prawnych należących do systemu prawa kontynentalnego to prawnik tworzący akty stosowania prawa, w pewnym stopniu również świadczący pomoc prawną.", 4),
            new Profession("Broker", "Broker to osoba działająca na giełdzie, świadcząca określone usługi działając na cudzy rachunek.", 5),
            new Profession("Operator", "Operator to specjalista obsługujący jakąś maszynę lub urządzenie.", 4),
            new Profession("Stylista", "Stylista to osoba pomagająca klientowi w odpowiednim ubraniu się czy umalowaniu.", 6),
            new Profession("Fotokorespondent", "Fotokorespondent to osoba relacjonująca zdarzenia z pewnego miejsca, robiąc dodatkowo tam zdjęcia i je wysyłając.", 5),
            new Profession("Restaurator", "Restaurator to osoba prowadząca i zarządzająca działaniem restauracji, czasami więcej niż jedną.", 6),
            new Profession("Architekt krajobrazu", "Architekt krajobrazu zajmuje się planowaniem i projektowaniem przestrzeni, w której funkcjonuje człowiek, skupia się na krajobrazie, przestrzeni zielonej i wprowadzaniu elementów przyrody do otoczenia człowieka. Materiałami, z którymi pracuje są nie tylko rośliny, ale też woda, rzeźba terenu, elementy architektoniczne.", 1),
            new Profession("Biolog badacz", "Biolog badacz to osoba zajmująca się badaniami w dziedzinie biologii.", 2),
            new Profession("Kierowca", "Kierowca to osoba, która zawodowo zajmuje miejsce kierującego pojazdem silnikowym określonym jako auto.", 1),
            new Profession("Marynarz", "Marynarz w szerszym ujęciu to każdy członek załogi jednostki pływającej bez względu na pełnioną funkcję oraz stopień. Pojęcie to dotyczy wtedy jednakowo: marynarki handlowej, marynarki wojennej oraz żeglugi śródlądowej.", 3),
            new Profession("Meterolog", "Meteorolog (synoptyk) to osoba prowadząca badania naukowe i opracowująca modele teoretyczne odnoszące się do składu, struktury i dynamiki atmosfery w powiązaniu z oddziaływaniem podłoża. Meteorolog przygotowuje także prognozy pogody.", 1),
            new Profession("Kartograf", "Kartograf to osoba, która przygotowuje graficzny i opisowy projekt map lub planów przeznaczonych zarówno dla specjalistów jak i ogólnego użytku.", 4),
            new Profession("Radiomechanik", "Radiomechanik to specjalista w dziedzinie mechaniki radiowej i montażu części sprzętu radiowego.", 1),
            new Profession("Rzeźbiarz", "Rzeźbiarz to osoba zajmująca wyrabianiem rzeźb.", 6),
            new Profession("Geolog", "Geolog to specjalista, który zajmuje się studiami i badaniem budowy ziemi oraz analizą procesów geologicznych, którym ona ulega. Jako teoretyk, geolog porusza się w dziedzinie geologii podstawowej, jako praktyk zaś - w dziedzinie geologii stosowanej.", 2),
            new Profession("Tłumacz-przewodnik", "Tłumacz-przewodnik to osoba wspomagająca osobę głuchoniemą w normalnym funkcjonowaniu w społeczeństwie.", 3),
            new Profession("Dziennikarz", "Dziennikarz to osoba zajmująca się przygotowywaniem i prezentowaniem materiałów w środkach masowego przekazu.", 5),
            new Profession("Reżyser", "Reżyser to autor dzieła scenicznego lub filmowego odpowiedzialny za jego całokształt, inicjator spektaklu, filmu, widowiska muzycznego bądź estradowego. Tworzy koncepcję artystyczną sztuki, inspiruje współpracowników i kieruje nimi, a celem lepszego zademonstrowania swojej niepowtarzalnej indywidualności – adaptuje, przerabia tekst oryginalny.", 6),
            new Profession("Bibliograf", "Bibliograf to specjalista w dziedzinie bibliografii, czyli rejestrowaniu rękopisów i druków.", 2),
            new Profession("Audytor", "Audytor (lub biegły rewident) to osoba fizyczna posiadająca uprawnienia zawodowe w zakresie wykonywania czynności rewizji finansowej w tym uprawnienia do badania sprawozdań finansowych. Tytuł biegły rewident podlega ochronie prawnej.", 4),
            new Profession("Farmaceuta", "Farmaceuta to osoba udzielająca usług farmaceutycznych, która ukończyła studia w szkole wyższej na kierunku farmacja.", 2),
            new Profession("Radca prawny", "Radca prawny to zawód zaufania publicznego zajmujący się świadczeniem pomocy prawnej, w szczególności polegającej na udzielaniu porad i konsultacji prawnych, sporządzaniu opinii prawnych, opracowywaniu projektów aktów prawnych oraz występowaniu przed sądami i urzędami w charakterze pełnomocnika lub obrońcy.", 3),
            new Profession("Genetyk", "Genetyk to lekarz zajmujący kwestiami związanymi z dziedziczeniem cech oraz chorobami wrodzonymi i dziedzicznymi, bądź badacz genetyki.", 2),
            new Profession("Architekt", "Architekt to osoba zajmująca się zazwyczaj projektowaniem architektonicznym obiektów budowlanych lub osoba specjalizująca się w dziedzinie projektowania i wznoszenia budowli.", 6),
            new Profession("Sprzedawca", "Sprzedawca to osoba dokonująca sprzedaży dóbr materialnych lub usług, oferując je nabywcy.", 3),
            new Profession("Operator łączności", "Operator łączności to osoba zarządzająca łącznością w różnych dziedzinach.", 4),
            new Profession("Pracownik socjalny", "Pracownik socjalny to osoba opiekująca się osobami potrzebującymi i organizująca im pomoc, udzielająca porad, kierująca do właściwych instytucji, współpracująca z organizacjami, które odpowiadają za organizowanie pomocy społecznej. ", 3),
            new Profession("Przedsiębiorca", "Przedsiębiorca to osoba podejmująca się prowadzenia we własnym imieniu działalności gospodarczej.", 5),
            new Profession("Wykładowca uczelni wyższej", "Wykładowca uczelni wyższej to osoba udzielająca wykładów i nauczająca jej studentów.", 3),
            new Profession("Muzyk", "Muzyk to osoba zajmująca się wykonywaniem (instrumentalista, wokalista, dyrygent) lub tworzeniem (kompozytor, producent muzyczny, aranżer) muzyki. Muzyk do swej pracy wykorzystuje m.in. instrumenty muzyczne, głos ludzki, głosy zwierząt, inne efekty akustyczne (np. uderzanie młotem w kowadło) czy też technologie komputerowe. Określenie muzyk odnosi się zarówno do osób posiadających wykształcenie muzyczne, jak i muzyków-amatorów.", 6),
            new Profession("Ekonomista", "Ekonomista to osoba zajmująca się ekonomią.", 4),
            new Profession("Menedżer", "Menedżer to osoba, której podstawowym zadaniem jest realizacja procesu zarządzania – planowanie i podejmowanie decyzji, organizowanie, przewodzenie – motywowanie i kontrolowanie.", 5),
            new Profession("Korektor", "Korektor to osoba, która eliminuje błędy i przygotowuje gotowy tekst do wydruku.", 4),
            new Profession("Dyrygent", "Dyrygent to osoba kierująca zespołami muzycznymi, takimi jak orkiestry symfoniczne, orkiestry smyczkowe, orkiestry dęte, zespoły kameralne, chóry, zespoły wokalne, zespoły wokalno-instrumentalne, a także kierująca wykonaniami oper i spektakli muzycznych. Kompetencje dyrygenta polegają na odpowiednim przygotowaniu zespołu, wytworzeniu odpowiedniej, twórczej atmosfery oraz zorganizowaniu całej grupy wykonawców w celu osiągnięcia jak najlepszego efektu.", 6),
            new Profession("Inspektor celny", "Inspektor celny to pracownik Służby Celnej, kontrolujący osoby przekraczające granice danego kraju, w którym pracuje.", 5),
            new Profession("Artysta modelarz", "Artysta modelarz to artysta zajmujący się modelarstwem, czyli odwzorowywaniem rzeczywistych obiektów w postaci pomniejszonych modeli.", 6),
            new Profession("Telefonista", "Telefonista to osoba obsługująca centralę telefoniczną, m. in. łącząca rozmówców.", 1),
            new Profession("Ornitolog", "Ornitolog to człowiek zajmujący się ornitologią, czyli działem zoologii zajmującym się ptakami.", 2),
            new Profession("Agronom", "Agronom to rolnik, specjalista w dziedzinie agronomii, teoretycznej i praktycznej nauki o gospodarstwie rolnym.", 1),
            new Profession("Topograf", "Topograf to osoba zawodowo zajmująca się topografią, sporządzająca zdjęcia terenu.", 4),
            new Profession("Leśnik", "Leśnik to pracownik Lasów Państwowych.", 1),
            new Profession("Dyrektor", "Dyrektor to osoba kierująca pracą organizacji, instytucji, bądź przedsiębiorstwa.", 5),
            new Profession("Krawiec", "Krawiec to rzemieślnik, zajmujący się szyciem ubrań i innych rzeczy z tkanin.", 1),
            new Profession("Choreograf", "Choreograf to reżyser tanecznego utworu scenicznego.", 6),
            new Profession("Historyk", "Historyk to osoba zajmująca się historią.", 2),
            new Profession("Inspektor policji", "Inspektor policji to najwyższy stopień w polskiej Policji, odpowiadająca za nadzorowanie pracy policjantów.", 4),
            new Profession("Antropolog", "Antropolog to człowiek zajmujący się antropologią, czyli interdyscyplinarną dziedziną nauki na pograniczu nauk humanistycznych, społecznych i przyrodniczych.", 2),
            new Profession("Przewodnik wycieczek", "Przewodnik wycieczek to osoba, która oprowadza turystów zwiedzających dane miejsce i opowiada im o nim.", 3),
            new Profession("Bakteriolog", "Bakteriolog to osoba, która zajmuje się badaniami nad bakteriami i ich wpływem na otoczenie.", 2),
            new Profession("Aktor", "Aktor to osoba odgrywająca za pomocą szczególnego zachowania, technik cielesnych i głosowych rolę w teatrze lub w filmie.", 6),
            new Profession("Kelner", "Kelner to osoba zajmująca się pełną obsługą konsumenta w restauracjach.", 3),
            new Profession("Towaroznawca", "Towaroznawca to osoba badająca i oceniająca właściwości użytkowych towarów oraz czynników wpływających na jakość.", 5),
            new Profession("Główny księgowy", "Główny księgowy to osoba odpowiedzialna za prowadzenie rachunkowości w przedsiębiorstwie. Zazwyczaj główny księgowy jest zwierzchnikiem pozostałych księgowych w przedsiębiorstwie, a w szczególności księgowych prowadzących rachunkowość finansową (statutową).", 4),
            new Profession("Agent wywiadu", "Agent wywiadu to osoba zwerbowana, wyszkolona, kierowana i zatrudniona w celu zbierania i przekazywania informacji.", 5),
            new Profession("Wizażysta", "Wizażysta to specjalista zajmujący się tworzeniem czyjegoś wizerunku, a także osoba świadcząca usługi w dziedzinie makijażu artystycznego.", 6),
            new Profession("Psycholog", "Psycholog to osoba posiadająca właściwe kwalifikacje, potwierdzone wymaganymi dokumentami, do udzielania świadczeń psychologicznych polegających w szczególności na: diagnozie psychologicznej, opiniowaniu, orzekaniu, psychoterapii (po ukończeniu studiów podyplomowych w tym zakresie) oraz na udzielaniu pomocy psychologicznej.", 3),
            new Profession("Pszczelarz", "Pszczelarz (bartnik) to osoba zajmująca się pracą w pasiece lub barci, przy pszczołach.", 1),
            new Profession("Handlowiec", "Handlowiec to specjalista prowadzący sprzedaż produktów lub usług.", 5),
            new Profession("Sędzia", "Sędzia to funkcjonariusz publiczny uprawniony do orzekania w sprawach należących do właściwości sądów i trybunałów, na zasadach niezawisłości i bezstronności.", 3),
            new Profession("Scenograf", "Scenograf (dawniej dekorator teatralny) to autor oprawy plastycznej i architektonicznej do teatru, filmu, telewizji lub na estradę, który ściśle współpracuje z reżyserem. Do zadań scenografa należy także określenie innych elementów stanowiących scenografię, na przykład oświetlenia, dekoracji, rekwizytów, kostiumów.", 4)
        };

        public static List<Pair> Pairs()
        {
            List<Pair> pairs = new List<Pair>();
            Pair temp_pair = new Pair();

            int i = 1;

            foreach (Profession profession in Professions)
            {
                if (i == 1)
                {
                    temp_pair = new Pair
                    {
                        Left = profession
                    };
                    i = 2;
                }
                else if (i == 2)
                {
                    temp_pair.Right = profession;
                    pairs.Add(temp_pair);
                    i = 1;
                }
            }

            return pairs;
        }
    }
}
