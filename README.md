# TBP Software – Zadatak

## Pokretanje projekta

Otvori `Assignment.sln` u Visual Studio-u i pokreni projekat. Solution sadrži dva projekta:

- **Assignment** – WPF aplikacija koju treba implementirati
- **Assignment.Tests** – MSTest projekat sa skeleton testovima koje treba popuniti

---

## Zadatak

Aplikacija se pokreće na glavnoj formi koja sadrži dva dugmeta:

- **Loaders** – prikazuje `LoadersView` u donjem delu forme
- **To-Do List** – prikazuje `ToDoListView` u donjem delu forme

---

### 1. Loaders – Multithreading

Prilikom inicijalizacije forme inicijalizuju se tri thread-a. Svaki thread prilikom inicijalizacije dobija nasumično vreme izvršavanja između **10 i 50 sekundi**.

Svaki thread ažurira svoj napredak svakih **1 sekundu**. Napredak se izražava kao broj od **0 do 100%** i izračunava se u odnosu na ukupno vreme izvršavanja thread-a.

Zahtevi:

- Napredak svakog thread-a prikazuje se posebno pored labele "Thread progress"
- Dugme **Cancel** zaustavlja odgovarajući thread
- **Total progress** prikazuje prosek napretka samo aktivnih (ne-cancelovanih) thread-ova
- Ako su svi thread-ovi cancelovani, total progress je 0%

---

### 2. To-Do List – Bindings

Forma se sastoji od dva dela:

**Desna strana – submit forma (delimično implementirana, potrebno završiti):**
- Polje za unos imena taska
- Dropdown za izbor prioriteta (vrednosti: 1, 2, 3)
- Dugme **Submit** dodaje novi To-Do item u listu

**Leva strana – lista To-Do stavki:**
- Prikazuje sve dodate stavke
- Svaka stavka prikazuje ime i prioritet
- Boja stavke zavisi od prioriteta:
  - Prioritet **1** → crvena (Red)
  - Prioritet **2** → žuta (Yellow)
  - Prioritet **3** → zelena (Green)

**Redosled stavki pri dodavanju:**
- Prioritet **1** → stavka se ubacuje iza poslednje stavke sa prioritetom 1, a ispred prve stavke sa prioritetom 2
- Prioritet **2** → stavka se ubacuje iza poslednje stavke sa prioritetom 2, a ispred prve stavke sa prioritetom 3
- Prioritet **3** → stavka ide na kraj liste

Napomena: trajno čuvanje podataka (baza, fajl) nije potrebno.

---

## Unit testovi

U projektu `Assignment.Tests` nalaze se skeleton testovi koje je potrebno implementirati:

- `ThreadWorkerTests` – testovi za model jednog thread-a
- `LoadersViewModelTests` – testovi za logiku ukupnog napretka

Svaki test sadrži komentarisane `Arrange`, `Act` i `Assert` sekcije kao vodič. Potrebno je:

1. Kreirati odgovarajuće klase u glavnom projektu (`ThreadWorker` ili slično)
2. Otkomentarisati kod u testovima i ukloniti `Assert.Inconclusive`
3. Proveriti da svi testovi prolaze

**Napomena za dizajn:** Da bi testovi mogli da rade bez pokretanja pravih thread-ova, `ThreadWorker` model treba da ima odvojene propertije za `Duration` i `Elapsed` koji se mogu postaviti direktno u testu. Timer koji ažurira `Elapsed` svake sekunde treba da bude odvojen od same logike izračunavanja napretka.

---

## Git

Inicijalizuj git repozitorijum i commituj svoje izmene prateći dobre prakse.
