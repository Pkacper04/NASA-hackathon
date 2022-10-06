using UnityEngine;

public class LanguageDatabase : MonoBehaviour
{

    #region PolishTranslation
    protected static string PolishTranslation(TranslateKeys key)
    {
        switch (key)
        {
            case TranslateKeys.StartGame:
                return "Rozpocznij Gre";
            case TranslateKeys.Settings:
                return "Ustawienia";
            case TranslateKeys.Credits:
                return "Tworcy";
            case TranslateKeys.Quit:
                return "Zamknij Gre";
            case TranslateKeys.Back:
                return "Wstecz";
            case TranslateKeys.Resolution:
                return "Rozdzielczosc";
            case TranslateKeys.Fullscreen:
                return "Pelny Ekran";
            case TranslateKeys.Volume:
                return "Glosnosc";
            case TranslateKeys.PressAnyKey:
                return "Nacisnij dowolny klawisz aby zaczac gre";
            case TranslateKeys.DayCounter:
                return "Dzien: ";
            case TranslateKeys.TechLocked:
                return "Nie zbadano technologii";
            case TranslateKeys.Sell:
                return "Sprzedaj";
            case TranslateKeys.LaunchSatelite:
                return "Wyslij satelite";
            case TranslateKeys.RocketPlatform:
                return "Platforma Rakietowa";
            case TranslateKeys.RocketPlatformDesc:
                return "W srodku rakiety mo¿esz eksplorowaæ kosmos i odkrywac nowe gwiazdy oraz planety. Poprzez granie w minigre zdobywasz pieniadze oraz punkty badawcze poprzez granie w minigre.";
            case TranslateKeys.ResearchCenter:
                return "Centrum badawcze";
            case TranslateKeys.ResearchCenterDesc:
                return "W centrum badawczym mozesz ulepszac swoje budynki i technologie, dzieki czemu mozesz zarabiac wiecej pieniedzy i zasobow.";
            case TranslateKeys.TrainingCenter:
                return "Centrum szkoleniowe";
            case TranslateKeys.TrainingCenterDesc:
                return "Centrum szkoleniowe pozwala zwiekszyc przychody w obu walutach poprzez szkolenia pracownikow.";
            case TranslateKeys.Observatory:
                return "Obserwatorium";
            case TranslateKeys.ObservatoryDesc:
                return "Dzieki obserwatorium mozesz zarabiac pieniadze.";
            case TranslateKeys.RecruitmentCenter:
                return "Dzial rekrutacyjny";
            case TranslateKeys.RecruitmentCenterDesc:
                return "Przez zatrudnianie pracownikow, mozesz zwiekszyc swoje przychody.";
            case TranslateKeys.TechTree:
                return "Ulepszenia";
            case TranslateKeys.SateliteUpgrades:
                return "Ulepszenia satelity";
            case TranslateKeys.BuildingsUpgrades:
                return "Ulepszenia budynkow";
            case TranslateKeys.MainUpgrades:
                return "Ulepszenia Glowne";
            case TranslateKeys.Observatory1:
                return "Obserwatorium Poziom 1";
            case TranslateKeys.Observatory2:
                return "Obserwatorium Poziom 2";
            case TranslateKeys.Observatory3:
                return "Obserwatorium Poziom 3";
            case TranslateKeys.Observatory1Desc:
                return "Generuje 2 punkty badawcze co 5 sekund";
            case TranslateKeys.Observatory2Desc:
                return "Generuje 4 punkty badawcze co 5 sekund";
            case TranslateKeys.Observatory3Desc:
                return "Generuje 8 punktow badawczych co 5 sekund";
            case TranslateKeys.RecruitmentCenter1:
                return "Dzial rekrutacyjny Poziom 1";
            case TranslateKeys.RecruitmentCenter2:
                return "Dzial rekrutacyjny Poziom 2";
            case TranslateKeys.RecruitmentCenter3:
                return "Dzial rekrutacyjny Poziom 3";
            case TranslateKeys.RecruitmentCenter1Desc:
                return "Generuje 5 monet co 5 sekund";
            case TranslateKeys.RecruitmentCenter2Desc:
                return "Generuje 10 monet co 5 sekund";
            case TranslateKeys.RecruitmentCenter3Desc:
                return "Generuje 15 monet co 5 sekund";
            case TranslateKeys.TrainingCenter1:
                return "Centrum szkoleniowe Poziom 1";
            case TranslateKeys.TrainingCenter2:
                return "Centrum szkoleniowe Poziom 2";
            case TranslateKeys.TrainingCenter3:
                return "Centrum szkoleniowe Poziom 3";
            case TranslateKeys.TrainingCenter1Desc:
                return "Zwieksza przychody w obu walutach o 1";
            case TranslateKeys.TrainingCenter2Desc:
                return "Zwieksza przychody w obu walutach o 2";
            case TranslateKeys.TrainingCenter3Desc:
                return "Zwieksza przychody w obu walutach o 3";
            case TranslateKeys.StarTrackers:
                return "Gwiezdne urzadzenie sledzace";
            case TranslateKeys.StarTrackersDesc:
                return "Zwieksza ilosc badanych obiektow do 4";
            case TranslateKeys.EarthPointingAntenna:
                return "Antena komunikacyjna";
            case TranslateKeys.EarthPointingAntennaDesc:
                return "Zwieksza ilosc badanych obiektow do 5";
            case TranslateKeys.SpacecraftBus:
                return "Magistrala";
            case TranslateKeys.SpacecraftBusDesc:
                return "Zwieksza ilosc badanych obiektow do 6";
            case TranslateKeys.MultilayerSunshield:
                return "Tarcza przeciwsloneczna";
            case TranslateKeys.MultilayerSunshieldDesc:
                return "Zwieksza czas poszukiwañ o 20%";
            case TranslateKeys.TrimFlap:
                return "Stabilizator";
            case TranslateKeys.TrimFlapDesc:
                return "Zwieksza czas poszukiwan o 20%";
            case TranslateKeys.SolarPowerArray:
                return "Uklad energii slonecznej";
            case TranslateKeys.SolarPowerArrayDesc:
                return "Zwieksza czas poszukiwan o 30%";
            case TranslateKeys.SciencieInstrumentModule:
                return "Uklady optyczne";
            case TranslateKeys.SciencieInstrumentModuleDesc:
                return "zwieksza szanse na rzadkie obiekty";
            case TranslateKeys.MainMirror:
                return "Glowne lustro";
            case TranslateKeys.MainMirrorDesc:
                return "Zwieksza szanse na rzadkie obiekty";
            case TranslateKeys.SecondaryMirror:
                return "Pomocnicze lustro";
            case TranslateKeys.SecondaryMirrorDesc:
                return "Zwieksza szanse na rzadkie obiekty";
            case TranslateKeys.RocketPlatformDesc2:
                return "Odblokowuje opcje wyslania satelity w kosmos";
            case TranslateKeys.BuyUpgrade:
                return "Kup ulepszenie";
            case TranslateKeys.Bought:
                return "Zakupiono";
            case TranslateKeys.FirstLaunch:
                return "Wystrzelony w 1990 roku Kosmiczny Teleskop Hubble'a byl najwiekszym teleskopem kosmicznym w historii. Jednak w 2018 roku Kosmiczny Teleskop Jamesa Webba pobil ten rekord.";
            case TranslateKeys.GoldenMirror:
                return "Warstwy zlota pokrywaj¹ce zwierciadla lunety maja grubosc zaledwie 1000 atomow. Rzeczywiscie, do pokrycia calego lustra o szerokosci 21 stop uzyto tylko ilosci z³ota wielkosci pilki golfowej.";
            case TranslateKeys.HowWebbWorks:
                return "Teleskop Webb’a wykorzystuje swiatlo podczerwone, ktore nie jest postrzegane przez ludzkie oko, do badania kazdej fazy kosmicznej historii. Cztery instrumenty naukowe teleskopu s¹ specjalnie zaprojektowane do przechwytywania swiatla podczerwonego i sa w stanie zajrzec przez kosmiczny pyl, aby badac chlodniejsze lub bardzo odlegle obiekty.";
            case TranslateKeys.OstatniaCiekawostka:
                return "Webb pozwala naukowcom badac planety, zarowno w naszym Ukladzie Slonecznym, jak i poza nim, bardziej szczegolowo niz kiedykolwiek wczesniej. Zostal zaprojektowany, aby pomoc okreslic elementy, ktore je tworza i odkryc potencjal tych swiatow do podtrzymywania zycia. Teleskop moze nawet wykryc oznaki obcego zycia znane jako biosygnatury.";
            case TranslateKeys.WebbObserve:
                return "Webb to idealny teleskop do badania brazowych karlow i lepszego zrozumienia ich natury. Brazowy karzel to dziwny kosmiczny obiekt, ktory mozna uznac za ‘nieudana gwiazde’: nie jest wystarczajaco masywny, by byc gwiazda, ale masywniejszy niz planeta.";
            case TranslateKeys.WebbTemperature:
                return "Strona Kosmicznego Teleskopu Jamesa Webba ktora zawsze bedzie zwrocona w strone Slonca, bedzie stale znajdowac sie w temperaturze 185? F (85?C). Jednak druga strona, zawierajaca lustra i instrumenty, bedzie stale znajdowac sie w temperaturze -388? F(-233.33?C).";
            case TranslateKeys.WherelsWebb:
                return "Oprocz okrazania Slonca, Webb ciasno orbituje wokol punktu w przestrzeni znanego jako Lagrange 2 lub L2. Ten punkt znajduje sie 1,5 miliona kilometrow od Ziemi. Jego odlegle polozenie daje Webbowi niezaklocony widok nieba i pomaga mu widziec znacznie dalej we Wszechswiecie niz Kosmiczny Teleskop Hubble'a.";
            case TranslateKeys.Jupiter:
                return "Jowisz";
            case TranslateKeys.JupiterDesc:
                return "Jowisz jest piata planeta od Slonca i najwieksza w naszym Ukladzie Slonecznym. To gazowy olbrzym, ktory ma mase 2,5 razy wieksza niz wszystkie inne planety w naszym Ukladzie Slonecznym razem wziete.";
            case TranslateKeys.Mars:
                return "Mars";
            case TranslateKeys.MarsDesc:
                return "Mars jest czwarta planeta od S³onca i druga najmniejsza planeta w naszym Ukladzie Slonecznym. Mars jest planeta planetarna z cienka atmosfera, ma rdzen wykonany z zelaza i niklu.";
            case TranslateKeys.Mercury:
                return "Merkury";
            case TranslateKeys.MercuryDesc:
                return "Merkury jest najmniejsza planeta w Ukladzie Slonecznym i najblizsza Sloncu.";
            case TranslateKeys.Polaris:
                return "Polaris";
            case TranslateKeys.PolarisDesc:
                return "Polaris jest gwiazda w polnocnej konstelacji okolobiegunowej Ursa Minor. Nazywa siê ja Alpha Ursae Minoris i jest powszechnie nazywana Gwiazda Polarna";
            case TranslateKeys.Saturn:
                return "Saturn";
            case TranslateKeys.SaturnDesc:
                return "Saturn jest szosta planeta od Slonca i druga co do wielkosci w Ukladzie Slonecznym, po Jowiszu. To gazowy olbrzym o srednim promieniu okolo dziewiec i pol razy wiekszym od Ziemi. Ma tylko jedna osma sredniej gestosci Ziemi.";
            case TranslateKeys.Venus:
                return "Wenus";
            case TranslateKeys.VenusDesc:
                return "Wenus jest druga planeta od Slonca. Jako najjasniejszy, po Ksiezycu, naturalny obiekt na ziemskim niebie, Wenus mo¿e rzucac cienie i byc widoczna golym okiem w bialy dzien.";
            case TranslateKeys.Antares:
                return "Antares";
            case TranslateKeys.AntaresDesc:
                return "Antares jest czerwonym nadolbrzymem, duza wyewoluowana masywna gwiazda i jedna z najwiekszych gwiazd widocznych golym okiem. Jego dokladna wielkosc pozostaje niepewna, ale gdyby zostala umieszczona w centrum Uk³adu Slonecznego, siegalaby gdzies pomiedzy orbitami Marsa i Jowisza.";
            case TranslateKeys.Arcturus:
                return "Arktur";
            case TranslateKeys.ArcturusDesc:
                return "Arktur jest najjasniejsza gwiazda w polnocnej konstelacji Butesa. Jest to trzecia najjasniejsza z pojedynczych gwiazd na nocnym niebie i najjasniejsza na polnocnej polkuli niebieskiej.";
            case TranslateKeys.Neptune:
                return "Neptun";
            case TranslateKeys.NeptuneDesc:
                return "Neptun jest osma planeta od Slonca i najdalsza znana planeta sloneczna. W Ukladzie Slonecznym jest to czwarta co do wielkosci planeta pod wzgledem srednicy, trzecia pod wzgledem masy planeta i najgestsza planeta olbrzym. Jest 17 razy wieksza od masy Ziemi i nieco masywniejsza niz jej prawie blizniak Uran.";
            case TranslateKeys.Triton:
                return "Tryton";
            case TranslateKeys.TritonDesc:
                return "Tryton jest najwiekszym naturalnym satelita planety Neptun i byl pierwszym odkrytym ksiezycem Neptuna. Jest to jedyny duzy ksiezyc w Ukladzie Slonecznym o orbicie wstecznej, orbicie w kierunku przeciwnym do obrotu swojej planety.";
            case TranslateKeys.Uranus:
                return "Uran";
            case TranslateKeys.UranusDesc:
                return "Uran jest siodma planeta od Slonca. Ma trzeci co do wielkosci promien planety i czwarta co do wielkosci mase planetarna w Ukladzie Slonecznym. Uran jest podobny w skladzie do Neptuna.";
            case TranslateKeys.Brahe:
                return "Brahe";
            case TranslateKeys.BraheDesc:
                return "Brahe jest czesto nazywany 55 cancri c. Egzoplaneta na ekscentrycznej orbicie wokol podobnej do Slonca gwiazdy 55 Cancri A. Ma mase niewiele wieksza niz 1/6 masy Jowisza";
            case TranslateKeys.EpsilonErandi:
                return "Epsilon Erandi";
            case TranslateKeys.EpsilonErandiDesc:
                return "Epsilon Eridani formalnie nazywa sie Ran. Jest gwiazda w poludniowej konstelacji Eridanus. Szacuje sie, ze gwiazda ma mniej niz miliard lat. Ze wzgledu na swoja wzgledna mlodosc Epsilon Eridani ma wyzszy poziom aktywnosci magnetycznej niz dzisiejsze Slonce, z wiatrem gwiazdowym 30 razy silniejszym.";
            case TranslateKeys.Kepler452:
                return "Kepler-452b";
            case TranslateKeys.Kepler452Desc:
                return "Kepler-452b to jedyna planeta odkryta przez Keplera. Egzoplaneta super-ziemia krazaca w obrebie wewnetrznej krawedzi ekosfery gwiazdy Kepler-452";
            case TranslateKeys.ProximaCentauri:
                return "Proxima Centauri B";
            case TranslateKeys.ProximaCentauriDesc:
                return "Proxima Centauri B jest egzoplaneta krazaca w ekosferze czerwonego karla Proxima Centauri, najblizszej Sloncu gwiazdy i bedacej czescia potrojnego ukladu gwiazd Alfa Centauri.";
            case TranslateKeys.Wasp17b:
                return "Wasp-17b";
            case TranslateKeys.Wasp17bDesc:
                return "Wasp-17b jest egzoplaneta w gwiazdozbiorze Skorpiona krazacym wokol gwiazdy Wasp-17. Jest to pierwsza planeta, ktora ma orbite wsteczna, co oznacza, ze ??krazy w kierunku przeciwnym do obrotu swojej gwiazdy macierzystej";
            case TranslateKeys.Cutscene1:
                return "Po latach ciezkiej pracy ludziom w koncu udalo siê wyslac Kosmiczny Teleskop Hubble'a w kosmos. To byl ogromny przelom w historii ludzkosci.";
            case TranslateKeys.Cutscene2:
                return "Jednak ludzkie pragnienie wiedzy jest niepojecie ogromne. Ludzie chca wiedziec coraz wiecej o kosmosie.";
            case TranslateKeys.Cutscene3:
                return "Nie zajelo im duzo czasu rozpoczecie budowy nowego teleskopu. Dzieki niemu moga poszerzyc znany wszechswiat po brzegi.";
            case TranslateKeys.NewspaperMainText:
                return "Zrobili to! Obiekty odkryte w przestrzeni kosmicznej to";
            case TranslateKeys.YouEarned:
                return "Za dokonane odkrycia otrzymujesz";
            case TranslateKeys.Cash:
                return "Monety";
            case TranslateKeys.ResearchPoints:
                return "Punkty zasobów";
            case TranslateKeys.Popup1:
                return "Witaj w samouczku";
            case TranslateKeys.Popup1Desc:
                return "Podazaj za wskazowkami wyswietlanymi na ekranie aby szybko sie wszystkiego nauczyc. Kup wszystkie ulepszenia satelity aby ukonczyc gre.";
            case TranslateKeys.Popup2:
                return "Monety i Punkty Zasobow";
            case TranslateKeys.Popup2Desc:
                return "Oto twoje monety i punkty zasobow. Przy uzyciu monet mozesz kupowac lub ulepszac budowle. Przy uzyciu punktow zasobow mozesz odblokowac budowle oraz ulepszac satelite.";
            case TranslateKeys.Popup3:
                return "Pasek postepu";
            case TranslateKeys.Popup3Desc:
                return "Oto pasek postepu, gdy kupujesz ulepszenia satelity, pasek bedzie rosl.";
            case TranslateKeys.Popup4:
                return "Wybuduj Osrodek Badawczy";
            case TranslateKeys.Popup4Desc:
                return "Kliknij na wolne miejsce i wybuduj Osrodek Badawczy.";
            case TranslateKeys.Popup5:
                return "Kliknij aby wybudowac";
            case TranslateKeys.Popup5Desc:
                return "Klkinij przycisk po prawej stronie aby wybudowac.";
            case TranslateKeys.Popup6:
                return "Otworz zakladke badan";
            case TranslateKeys.Popup6Desc:
                return "Kliknij na ikone aby otworzyc zakladke badan.";
            case TranslateKeys.Popup7:
                return "Wybuduj Rakiete";
            case TranslateKeys.Popup7Desc:
                return "Sprobuj wybudowac rakiete samemu.";
            case TranslateKeys.Popup8:
                return "Rozpocznij Minigre";
            case TranslateKeys.Popup8Desc:
                return "Nacisnij wyslij satelite abyt rozpoczac minigre.";
            case TranslateKeys.Popup9:
                return "Zasady Minigry";
            case TranslateKeys.Popup9Desc:
                return "Operujesz wlasnie teleskopem. Twoim zadaniem jest odkrycie nowych obiektow. Poruszaj myszka po ekranie aby znalezc nieznane obiekty. Po znalezieniu obiektu przytrzymaj lewy przycisk myszy aby poddac obiekt analizie. Pamietaj o ograniczonym czasie widocznym w lewym gornym rogu ekranu.";
            case TranslateKeys.Popup10:
                return "Ukonczyles samouczek";
            case TranslateKeys.Language:
                return "Jezyk";
            default:
                return "klucz nie istnieje";
        }
    }

    #endregion PolishTranslation;


    #region EnglishTranslation
    protected static string EnglishTranslation(TranslateKeys key)
    {
        switch (key)
        {
            case TranslateKeys.StartGame:
                return "Start Game";
            case TranslateKeys.Settings:
                return "Settings";
            case TranslateKeys.Credits:
                return "Credits";
            case TranslateKeys.Quit:
                return "Quit";
            case TranslateKeys.Back:
                return "Back";
            case TranslateKeys.Resolution:
                return "Resolution";
            case TranslateKeys.Fullscreen:
                return "Fullscreen";
            case TranslateKeys.Volume:
                return "Volume";
            case TranslateKeys.PressAnyKey:
                return "Press Any Key To Start";
            case TranslateKeys.DayCounter:
                return "Day: ";
            case TranslateKeys.TechLocked:
                return "Technology Locked";
            case TranslateKeys.Sell:
                return "Sell";
            case TranslateKeys.LaunchSatelite:
                return "Launch Satelite";
            case TranslateKeys.RocketPlatform:
                return "Rocket Platform";
            case TranslateKeys.RocketPlatformDesc:
                return "Inside the rocket, you can explore new stars and planets while playing a minigame in which you earn cash and research points.";
            case TranslateKeys.ResearchCenter:
                return "Research Center";
            case TranslateKeys.ResearchCenterDesc:
                return "In a research center, you are able to buy upgrades for your buildings and new technologies, thanks to which you can earn more cash and research points.";
            case TranslateKeys.TrainingCenter:
                return "Training Center";
            case TranslateKeys.TrainingCenterDesc:
                return "Training center lets you earn more cash by training your employees.";
            case TranslateKeys.Observatory:
                return "Observatory";
            case TranslateKeys.ObservatoryDesc:
                return "Thanks to the observatory, you can obtain cash.";
            case TranslateKeys.RecruitmentCenter:
                return "Recruitment Center";
            case TranslateKeys.RecruitmentCenterDesc:
                return "By hiring more people inside the recruitment center, you can increase your earnings.";
            case TranslateKeys.TechTree:
                return "TechTree";
            case TranslateKeys.SateliteUpgrades:
                return "Satelite upgrades";
            case TranslateKeys.BuildingsUpgrades:
                return "Buildings upgrades";
            case TranslateKeys.MainUpgrades:
                return "Main upgrades";
            case TranslateKeys.Observatory1:
                return "Observatory Level 1";
            case TranslateKeys.Observatory2:
                return "Observatory Level 2";
            case TranslateKeys.Observatory3:
                return "Observatory Level 3";
            case TranslateKeys.Observatory1Desc:
                return "Generate 2 resource points every 5 second";
            case TranslateKeys.Observatory2Desc:
                return "Generate 4 resource points every 5 second";
            case TranslateKeys.Observatory3Desc:
                return "Generate 8 resource points every 5 second";
            case TranslateKeys.RecruitmentCenter1:
                return "Recruitment Center Level 1";
            case TranslateKeys.RecruitmentCenter2:
                return "Recruitment Center Level 2";
            case TranslateKeys.RecruitmentCenter3:
                return "Recruitment Center Level 3";
            case TranslateKeys.RecruitmentCenter1Desc:
                return "Generate 5 cash every 5 seconds";
            case TranslateKeys.RecruitmentCenter2Desc:
                return "Generate 10 cash every 5 seconds";
            case TranslateKeys.RecruitmentCenter3Desc:
                return "Generate 15 cash every 5 seconds";
            case TranslateKeys.TrainingCenter1:
                return "Training Center Level 1";
            case TranslateKeys.TrainingCenter2:
                return "Training Center Level 2";
            case TranslateKeys.TrainingCenter3:
                return "Training Center Level 3";
            case TranslateKeys.TrainingCenter1Desc:
                return "Increase cash and resources in all buildings by 1";
            case TranslateKeys.TrainingCenter2Desc:
                return "Increase cash and resources in all buildings by 2";
            case TranslateKeys.TrainingCenter3Desc:
                return "Increase cash and resources in all buildings by 3";
            case TranslateKeys.StarTrackers:
                return "Star trackers";
            case TranslateKeys.StarTrackersDesc:
                return "Increases the amount of researched objects by 1";
            case TranslateKeys.EarthPointingAntenna:
                return "Earth-pointing antenna";
            case TranslateKeys.EarthPointingAntennaDesc:
                return "Increases the amount of researched objects by 2";
            case TranslateKeys.SpacecraftBus:
                return "Spacecraft bus";
            case TranslateKeys.SpacecraftBusDesc:
                return "Increases the amount of researched objects by 3";
            case TranslateKeys.MultilayerSunshield:
                return "Multilayer sunshield";
            case TranslateKeys.MultilayerSunshieldDesc:
                return "Increases the duration of research by 20%";
            case TranslateKeys.TrimFlap:
                return "Trim flap";
            case TranslateKeys.TrimFlapDesc:
                return "Increases the duration of research by 20%";
            case TranslateKeys.SolarPowerArray:
                return "Solar power array";
            case TranslateKeys.SolarPowerArrayDesc:
                return "Increases the duration of research by 30%";
            case TranslateKeys.SciencieInstrumentModule:
                return "Science Instrument Module";
            case TranslateKeys.SciencieInstrumentModuleDesc:
                return "Increases the chance to find rarer objects";
            case TranslateKeys.MainMirror:
                return "Main mirror";
            case TranslateKeys.MainMirrorDesc:
                return "Increases the chance to find rarer objects";
            case TranslateKeys.SecondaryMirror:
                return "Secondary mirror";
            case TranslateKeys.SecondaryMirrorDesc:
                return "Increases the chance to find rarer objects";
            case TranslateKeys.RocketPlatformDesc2:
                return "Enables option to launch satelites";
            case TranslateKeys.BuyUpgrade:
                return "Buy upgrade";
            case TranslateKeys.Bought:
                return "Bought";
            case TranslateKeys.FirstLaunch:
                return "Launched in 1990, Hubble Space Telescope was the largest space telescope in history. However, James Webb Space Telescope (JWST) took over this record in 2018. At the size of a typical school bus, Hubble will be dwarfed by JWST’s tennis court size. ";
            case TranslateKeys.GoldenMirror:
                return "Gold layers plating the scope’s mirrors are only 1,000 atoms thick. Indeed, only a golf-ball-sized amount of gold was used to coat the entire 21-foot-wide mirror.";
            case TranslateKeys.HowWebbWorks:
                return "Webbs Telescope uses infrared light, which cannot be perceived by the human eye, to study every phase in cosmic history. The telescope's four scientific instruments are specifically designed to capture infrared light, and are able to peer through cosmic dust to study colder or very distant objects.";
            case TranslateKeys.OstatniaCiekawostka:
                return "Webb allows scientists to study planets, both within and beyond our solar system, in greater detail than ever before. It is designed to help determine the elements that make them up and unveil these worlds' potential to support life. The telescope may even detect signs of alien life known as biosignatures.";
            case TranslateKeys.WebbObserve:
                return "Webb is the ideal telescope to study brown dwarfs and better understand their nature. A brown dwarf is a strange cosmic object that can be considered a 'failed star': not massive enough to be a star, but more massive than a planet.";
            case TranslateKeys.WebbTemperature:
                return "First, the side of JWST that will always face the Sun will constantly sit at a scorching 185? F. However, the other side, containing the mirrors and instruments, will constantly sit at a frigid -388? F.";
            case TranslateKeys.WherelsWebb:
                return "In addition to orbiting the Sun, Webb makes a tight orbit around a point in space known as Lagrange 2, or L2. This point is located 1.5 million kilometres from Earth. Its distant location gives Webb an unobstructed view of the sky, and aids its ability to see much farther into the universe than the Hubble Space Telescope.";
            case TranslateKeys.Jupiter:
                return "Jupiter";
            case TranslateKeys.JupiterDesc:
                return "Jupiter is the fifth planet from the Sun and the largest in our solar system. It's a gas giant it has 2.5x mass of all other planets in our solar system combined.";
            case TranslateKeys.Mars:
                return "Mars";
            case TranslateKeys.MarsDesc:
                return "Mars is the fourth planet from the sun and the second-smallest planet in our solar system. Mars is cerrestial planet with a thin atmosphere, it has a core made out of iron and nickel.";
            case TranslateKeys.Mercury:
                return "Mercury";
            case TranslateKeys.MercuryDesc:
                return "Mercury is the smallest planet in the solar system and the closest to the Sun.";
            case TranslateKeys.Polaris:
                return "Polaris";
            case TranslateKeys.PolarisDesc:
                return "Polaris is a star in the northern circumpolar constellation of Ursa Minor. It is designated Alpha Ursae Minoris and is commonly called the North Star or Pole Star.";
            case TranslateKeys.Saturn:
                return "Saturn";
            case TranslateKeys.SaturnDesc:
                return "Saturn is the sixth planet from the Sun and the second-largest in the Solar System, after Jupiter. It is a gas giant with an average radius of about nine and a half times that of Earth.It has only one-eighth the average density of Earth.";
            case TranslateKeys.Venus:
                return "Venus";
            case TranslateKeys.VenusDesc:
                return "Venus is second planet from the Sun. As the brightest natural object in Earth's sky after the Moon, Venus can cast shadows and can be visible to the naked eye in broad daylight.";
            case TranslateKeys.Antares:
                return "Antares";
            case TranslateKeys.AntaresDesc:
                return "Antares is a red supergiant, a large evolved massive star and one of the largest stars visible to the naked eye. Its exact size remains uncertain, but if placed at the center of the Solar System, it would reach to somewhere between the orbits of Mars and Jupiter.";
            case TranslateKeys.Arcturus:
                return "Arcturus";
            case TranslateKeys.ArcturusDesc:
                return "Arcturus is the brightest star in the northern constellation of Boötes. It is the third-brightest of the individual stars in the night sky, and the brightest in the northern celestial hemisphere.";
            case TranslateKeys.Neptune:
                return "Neptune";
            case TranslateKeys.NeptuneDesc:
                return "Neptune is the eighth planet from the Sun and the farthest known solar planet. In the Solar System, it is the fourth-largest planet by diameter, the third-most-massive planet, and the densest giant planet. It is 17 times the mass of Earth, and slightly more massive than its near-twin Uranus.";
            case TranslateKeys.Triton:
                return "Triton";
            case TranslateKeys.TritonDesc:
                return "Triton is the largest natural satellite of the planet Neptune, and was the first Neptunian moon to be discovered. It is the only large moon in the Solar System with a retrograde orbit, an orbit in the direction opposite to its planet's rotation.";
            case TranslateKeys.Uranus:
                return "Uranus";
            case TranslateKeys.UranusDesc:
                return "Uranus is the seventh planet from the Sun. It has the third-largest planetary radius and fourth-largest planetary mass in the Solar System. Uranus is similar in composition to Neptune.";
            case TranslateKeys.Brahe:
                return "Brahe";
            case TranslateKeys.BraheDesc:
                return "Brahe is often called 55 cancri c. Exoplanet in an eccentric orbit around the sun-like star 55 Cancri A. It has mass of almost 1/6 of jupiter or roughly 1/2 of saturn";
            case TranslateKeys.EpsilonErandi:
                return "Epsilon Erandi";
            case TranslateKeys.EpsilonErandiDesc:
                return "Epsilon Eridani is formally named Ran. Is a star in the southern constellation of Eridanus. The star is estimated to be less than a billion years old. Because of its relative youth, Epsilon Eridani has a higher level of magnetic activity than the present-day Sun, with a stellar wind 30 times as strong";
            case TranslateKeys.Kepler452:
                return "Kepler-452b";
            case TranslateKeys.Kepler452Desc:
                return "Kepler-452b is the only planet that was discovered by Kepler. Its super-earth exoplanet orbiting within the inner edge of the habitable zone of star Kepler-452";
            case TranslateKeys.ProximaCentauri:
                return "Proxima Centauri B";
            case TranslateKeys.ProximaCentauriDesc:
                return "Proxima Centauri B is an exoplanet orbiting in the habitable zone of the red dwarf Proxima Centauri, the closest star to the Sun and part of the Alpha Centauri triple star system. ";
            case TranslateKeys.Wasp17b:
                return "Wasp-17b";
            case TranslateKeys.Wasp17bDesc:
                return "Wasp-17b is exoplanet in the constellation Scorpius that is orbiting the star Wasp-17.It is the first planet discovered to have a retrograde orbit, meaning it orbits in a direction counter to the rotation of its host star";
            case TranslateKeys.Cutscene1:
                return "After years of hard work, humans finally managed to send Hubble Space Telescope into space. It was a giant breakthrough in human history.";
            case TranslateKeys.Cutscene2:
                return "However, human desire for knowledge is incomprehensible. Humans want to know more and more about space.";
            case TranslateKeys.Cutscene3:
                return "It didn’t take them long to start building new telescope. With it, they can expand known universe to the brim.";
            case TranslateKeys.NewspaperMainText:
                return "They did it! They discovered new objects in spaces. Objects that were found";
            case TranslateKeys.YouEarned:
                return "With this new things you earned";
            case TranslateKeys.Cash:
                return "Cash";
            case TranslateKeys.ResearchPoints:
                return "Research Points";
            case TranslateKeys.Popup1:
                return "Welcome in tutorial";
            case TranslateKeys.Popup1Desc:
                return "Please follow steps displayed on screen and you will learn everything very quickly. Buy all satelite upgrades to finish the game.";
            case TranslateKeys.Popup2:
                return "Cash and Research Points";
            case TranslateKeys.Popup2Desc:
                return "This is your cash and research points. With cash you can buy or upgrade buildings. With research points you can unlock buildings and upgrade satelite.";
            case TranslateKeys.Popup3:
                return "Progress Bar";
            case TranslateKeys.Popup3Desc:
                return "This is progress bar, when you buy satelite upgrades it increases.";
            case TranslateKeys.Popup4:
                return "Build Research Center";
            case TranslateKeys.Popup4Desc:
                return "Click on free space and build Research Center.";
            case TranslateKeys.Popup5:
                return "Click To Build";
            case TranslateKeys.Popup5Desc:
                return "Click right button to build.";
            case TranslateKeys.Popup6:
                return "Open research tab";
            case TranslateKeys.Popup6Desc:
                return "Click on icon to open research tab.";
            case TranslateKeys.Popup7:
                return "Build Rocket";
            case TranslateKeys.Popup7Desc:
                return "Try to build rocket by yourself.";
            case TranslateKeys.Popup8:
                return "Start Minigame";
            case TranslateKeys.Popup8Desc:
                return "Click launch satelite to start minigame.";
            case TranslateKeys.Popup9:
                return "Minigame rules";
            case TranslateKeys.Popup9Desc:
                return "You're operating a telescope. Your goal is to discover new objects. Move your mouse on the screen to find undiscovered objects. After finding an object, hold left mouse button to analyse the object. Analyse every object on the screen before time runs out in the upper left corner of your screen.";
            case TranslateKeys.Popup10:
                return "You finished the tutorial";
            case TranslateKeys.Language:
                return "Language";
            default:
                return "Key does not exist";
        }
    }
    #endregion EnglishTransletion

}


#region TranslateKeys
public enum TranslateKeys
{
    StartGame,
    Settings,
    Credits,
    Quit,
    Back,
    Resolution,
    Fullscreen,
    Volume,
    PressAnyKey,
    DayCounter,
    TechLocked,
    Sell,
    LaunchSatelite,
    RocketPlatform,
    RocketPlatformDesc,
    ResearchCenter,
    ResearchCenterDesc,
    TrainingCenter,
    TrainingCenterDesc,
    Observatory,
    ObservatoryDesc,
    RecruitmentCenter,
    RecruitmentCenterDesc,
    TechTree,
    SateliteUpgrades,
    BuildingsUpgrades,
    MainUpgrades,
    Observatory1,
    Observatory2,
    Observatory3,
    Observatory1Desc,
    Observatory2Desc,
    Observatory3Desc,
    RecruitmentCenter1,
    RecruitmentCenter2,
    RecruitmentCenter3,
    RecruitmentCenter1Desc,
    RecruitmentCenter2Desc,
    RecruitmentCenter3Desc,
    TrainingCenter1,
    TrainingCenter2,
    TrainingCenter3,
    TrainingCenter1Desc,
    TrainingCenter2Desc,
    TrainingCenter3Desc,
    StarTrackers,
    EarthPointingAntenna,
    SpacecraftBus,
    MultilayerSunshield,
    TrimFlap,
    SolarPowerArray,
    SciencieInstrumentModule,
    MainMirror,
    SecondaryMirror,
    StarTrackersDesc,
    EarthPointingAntennaDesc,
    SpacecraftBusDesc,
    MultilayerSunshieldDesc,
    TrimFlapDesc,
    SolarPowerArrayDesc,
    SciencieInstrumentModuleDesc,
    MainMirrorDesc,
    SecondaryMirrorDesc,
    RocketPlatformDesc2,
    BuyUpgrade,
    Bought,
    FirstLaunch,
    GoldenMirror,
    HowWebbWorks,
    OstatniaCiekawostka,
    WebbObserve,
    WebbTemperature,
    WherelsWebb,
    //Common
    Jupiter,
    JupiterDesc,
    Mars,
    MarsDesc,
    Mercury,
    MercuryDesc,
    Polaris,
    PolarisDesc,
    Saturn,
    SaturnDesc,
    Venus,
    VenusDesc,
    //Uncommon
    Antares,
    AntaresDesc,
    Arcturus,
    ArcturusDesc,
    Neptune,
    NeptuneDesc,
    Triton,
    TritonDesc,
    Uranus,
    UranusDesc,
    //rare
    Brahe,
    BraheDesc,
    EpsilonErandi,
    EpsilonErandiDesc,
    Kepler452,
    Kepler452Desc,
    ProximaCentauri,
    ProximaCentauriDesc,
    Wasp17b,
    Wasp17bDesc,
    //Cutscenki
    Cutscene1,
    Cutscene2,
    Cutscene3,
    NewspaperMainText,
    YouEarned,
    Cash,
    ResearchPoints,
    Popup1,
    Popup1Desc,
    Popup2,
    Popup2Desc,
    Popup3,
    Popup3Desc,
    Popup4,
    Popup4Desc,
    Popup5,
    Popup5Desc,
    Popup6,
    Popup6Desc,
    Popup7,
    Popup7Desc,
    Popup8,
    Popup8Desc,
    Popup9,
    Popup9Desc,
    Popup10,
    Language,
}
#endregion TranslateKeys

