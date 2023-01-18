# Saper
Projekt zrealizowany na 2 roku studiów w ramach przedmiotu "Projekt programistyczy indywidualny".

## 1. Wstęp
### a. Cel
Celem projektu było odtworzenie gry logicznej „Saper”.
### b. Idea
Saper jest grą logiczną z 1981 r. Rozgrywka jest przeznaczona dla jednej osoby, a celem gry
jest odnalezienie wszystkich min. Gracz odkrywa kolejne pola początkowo losowo, później
kierowany cyferkami na polu minowym. Każde pole ma przypisaną konkretną cyfrę
oznaczającą liczbę sąsiadujących pól, na których znajduje się bomba. Jeżeli liczba ta wynosi
zero, to odkrywane jest każde sąsiadujące pole, na którym nie znajduje się bomba.
### c. Założenia
Projekt miał odtwarzać podstawowe funkcjonalności gry:
- Generowanie losowego pola minowego
- Podliczanie czasu rozgrywki
- Różne poziomy trudności
- Możliwość dostosowania rozmiarów planszy
Poza podstawowymi funkcjonalnościami miał zostać poszerzony o dodatkowe
funkcjonalności - opcje umożliwiające dostosowanie rozgrywki do potrzeb użytkownika:
- System podpowiedzi
- Autorozgrywanie
- Ujawnienie wszystkich bomb
- Wykonanie następnego ruchu
- Możliwość dostosowania rozmiaru planszy oraz poziomu trudności.
Projekt został napisany w języku C# z wykorzystaniem Windows Forms.
## 2. Opis algorytmów

**Algorytm odsłaniania pól.**

Jeżeli gracz odsłoni pole, do którego przypisana jest cyfra zero, to algorytm rozpoczyna
przeszukiwanie sąsiadujących pól. Przeszukiwanie zaczyna się od górnego pola i idzie zgodnie
z ruchem wskazówek zegara. Jeżeli pole nie posiada górnego pola, to przeszukiwanie
rozpoczyna się od pierwszego dostępnego pola.
Algorytm sprawdza stan sąsiadującego pola. Jeżeli na polu jest bomba, to pole pozostaje bez
zmian. Jeżeli na polu jest cyfra nie będąca zerem, to pole jest odsłaniane. Jeżeli na polu
znajduje się cyfra zero, to pole jest odsłaniane oraz aktywowany zostaje dla niego algorytm.
Wykonanie kończy się, gdy nie ma już żadnych sąsiadujących pól do przeszukania.

**Algorytm podpowiedzi.**

Algorytm przydziela polom kolory zależne od przeanalizowanego stanu. Kolor zielony - jeżeli
na polu na pewno nie ma bomby, kolor czerwony, jeżeli na polu na pewno jest bomba oraz
kolor żółty, jeżeli pole ma nieznany stan.
Pola są analizowane pod kątem różnych kryteriów. Najpierw sprawdzane jest odsłonięcie
pola. Jeżeli pole jest nieodsłonięte, to algorytm przechodzi do następnego pola. Jeżeli pole
jest odsłonięte, to algorytm analizuje cyfrę na polu i porównuje ją z liczbą nieodsłoniętych
sąsiadujących pól, które zostały oznaczone jako pola czerwone lub z liczbą odsłoniętych pól.

**Algorytm autorozgrywania**

Algorytm korzysta z algorytmu podpowiedzi, w celu określenia pola do otwarcia. Jeżeli żadne
z pól nie jest oznaczone jako pole czerwone, to pola otwierane są losowo. 
## 3. Opis programu
### a. Struktura
Program został napisany w języku C# przy wykorzystaniu frameworka Windows Forms. Na
część wizualną programu składają się dwie klasy (formularze). Pierwszy - menu, w którym
gracz może dostosować parametry rozgrywki, oraz drugi, w którym odbywa się rozgrywka.
Na pole minowe składają się dwie klasy: Minefield i Cell. Klasa Cell jest klasą dziedziczącą po
klasie wbudowanej Button. Minefield jest klasą wykorzystującą Cell jako swoje pole.
Ostatnią klasą jest klasa Program, w pełni wygenerowana przez środowisko. Zawiera ona
metodę Main, która odpowiada za uruchomienie pierwszego okna.
### b. Cell (pole)
Podstawową klasą jest klasa Cell, dziedzicząca po klasie wbudowanej Button. Jest więc
jedynie przyciskiem, który zawiera dodatkowe pola, niezbędne do prowadzenia rozgrywki:
- x (pole typu int, współrzędna położenia na polu minowym)
- y (pole typu int, współrzędna położenia na polu minowym)
- bomb (pole typu bool, określa czy na polu znajduje się bomba)
- number (pole typu short, określa liczbę, która kryje się na polu)
- opened (pole typu bool, określa czy pole zostało otwarte)
- flag (pole typu bool, określa czy pole zostało oflagowane przez gracza)
- autoplayFlag (pole typu short, określa stan pola, wykorzystywany przy autorzgrywaniu)
Każde z pól ma zdefiniowany getter oraz setter. Klasa zawiera dwa konstruktory oraz jedną
funkcję.
Funkcja Open() służy do otwierania danego pola
### c. Minefield (Pole minowe)
Struktura klasy
Klasa korzystająca z klasy Cell. Służy do tworzenia pola minowego i prowadzenia rozgrywki.
Klasa zawiera pola:
- field (pole typu Cell, tablica z polem gry)
- height (pole typu int, wysokość pola)
- width (pole typu int, szerokość pola)
- winCounter (pole typu int, licznik określający zwycięstwo)
- bombs (liczba bomb na polu minowym)
Klasa zawiera jeden konstruktor. Klasa zawiera wszystkie funkcje niezbędne do prowadzenia
rozgrywki na polu minowym. 

**Win()**

Funkcja Win() sprawdza stan pola winCounter, aby określić czy gra została wygrana.

**OpenCell()**

Funkcja OpenCell() wywołuje funkcję Open() z klasy Cell, aktualizuje stan winCountera, a
następnie może wywołać funkcję Opener().
Jako argumenty wywołania przyjmuje dwie współrzędne, określające położenie otwieranego
pola.

**Opener()**

Funkcja Opener() służy do otwierania sąsiadujących pól, gdy gracz otworzy pole z zerem.
Kolejno przechodzi przez sąsiadujące pola rozpoczynając od pola nad polem otwieranym. 
Jeżeli pole spełnia warunki, to zostaje dla niego wywołana funkcja OpenCell().
Jako argumenty wywołania przyjmuje dwie współrzędne, określające położenie otwieranego
pola.

**CountBombs()**

Funkcja CountBombs() służy do określenia liczby bomb sąsiadujących z danym polem.
Jako argumenty wywołania przyjmuje dwie współrzędne, określające położenie
rozpatrywanego przez funkcję pola.

**Neighbour()**

Funkcja Neighbour() sprawdza czy dane pole leży w granicach pola minowego, czy nie zostało
otwarte oraz czy nie zawiera flagi. Funkcja jest wykorzystywana przez funkcję Opener(), w
celu określenia czy pole może zostać otwarte przez algorytm.
Jako argumenty wywołania przyjmuje dwie współrzędne, określające położenie
rozpatrywanego przez funkcję pola.

**AutoplayNeighbour()**

Funkcja AutoplayNeighbour() sprawdza czy dane pole leży w granicach planszy oraz czy nie
zostało otwarte.
Jako argumenty wywołania przyjmuje dwie współrzędne, określające położenie
rozpatrywanego przez funkcję pola.

**BombNeighbour()**

Funkcja BombNeighbour() sprawdza czy dane pole leży w granicach planszy oraz czy jest tam
bomba.
Jako argumenty wywołania przyjmuje dwie współrzędne, określające położenie
rozpatrywanego przez funkcję pola.

**ColorChanger()**

Funkcja ColorChanger() ustala flagę pola podczas autorozgrywania lub pokazywania
podpowiedzi. W drugim wypadku zmienia również kolor pól.
Jako argumenty wywołania przyjmuje dwie współrzędne, określające położenie
rozpatrywanego przez funkcję pola, liczbę typu short określającą flagę autorozgrywania oraz
argument typu bool określający czy funkcja ma zmieniać kolory pola czy jedynie
zaktualizować stan flagi.

**AutoplayColor()**

Funkcja AutoplayColor() określa jaki kolor powinno mieć pole i zwraca odpowiedni kolor.
Jako argumenty wywołania przyjmuje dwie współrzędne, określające położenie
rozpatrywanego przez funkcję pola.

**Checker()**

Funkcja Checker() przechodzi przez kolejne pola sąsiadujące z polem o współrzędnych
podanych jako argumenty funkcji, sprawdza czy sprawdzają one kryteria funkcji
AutoplayNeighbour(), a jeżeli tak, to zmienia kolor pola w zależności od wskazania funkcji
AutoplayColor().
Jako argumenty wywołania przyjmuje dwie współrzędne, określające położenie
rozpatrywanego przez funkcję pola oraz argument typu bool określający czy funkcja ma
zmieniać kolory pól.
