using CommonUI.Models;

namespace CommonUI.ModelServices
{
    public class MarynarzService : IMarynarzService
    {
        public IEnumerable<Marynarz> GetAll()
        {
            yield return new Marynarz { Imie = "Zbigniew", Nazwisko = "Karaś", Stopien = "Kapitan" };
            yield return new Marynarz { Imie = "Andrzej", Nazwisko = "Barok", Stopien = "Porucznik" };
            yield return new Marynarz { Imie = "Marek", Nazwisko = "Sztos", Stopien = "Chorąży" };
            yield return new Marynarz { Imie = "Tomasz", Nazwisko = "Bolan", Stopien = "Bosmanmat" };
            yield return new Marynarz { Imie = "Grzegorz", Nazwisko = "Ulmas", Stopien = "Mat" };
            yield return new Marynarz { Imie = "Marek", Nazwisko = "Nowak", Stopien = "Marynarz" };
            yield return new Marynarz { Imie = "Jan", Nazwisko = "Kirsa", Stopien = "Bosman" };
        }
    }
}
