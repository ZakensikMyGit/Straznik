using CommonUI.Events;
using CommonUI.Models;
using CommonUI.ModelServices;
using Prism.Events;

namespace CommonUI.ModelServices
{
    public class MarynarzService : IMarynarzService
    {
        private readonly IEventAggregator _eventAggregator;
        private List<Marynarz> Marynarze;

        public MarynarzService(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            Marynarze = new List<Marynarz>()
            {
            new Marynarz { Imie = "Zbigniew", Nazwisko = "Karaś", Stopien = "Kapitan" },
            new Marynarz { Imie = "Andrzej", Nazwisko = "Barok", Stopien = "Porucznik" },
            new Marynarz { Imie = "Marek", Nazwisko = "Sztos", Stopien = "Chorąży" },
            new Marynarz { Imie = "Tomasz", Nazwisko = "Bolan", Stopien = "Bosmanmat" },
            new Marynarz { Imie = "Grzegorz", Nazwisko = "Ulmas", Stopien = "Mat" },
            new Marynarz { Imie = "Marek", Nazwisko = "Nowak", Stopien = "Marynarz" },
            new Marynarz { Imie = "Jan", Nazwisko = "Kirsa", Stopien = "Bosman" }
              };
        }
        public IEnumerable<Marynarz> GetAll()
        {
            return Marynarze;
        }

        public void Update(Marynarz updateMarynarz)
        {
            var aktualnyMarynarz = Marynarze.FirstOrDefault(m => m.Imie == updateMarynarz.Imie && m.Nazwisko == updateMarynarz.Nazwisko);
            if (aktualnyMarynarz != null)
            {
                aktualnyMarynarz.Stopien = updateMarynarz.Stopien;
            }
             _eventAggregator.GetEvent<UpdatedMarynarzEvent>().Publish();
        }
    }
}

// DLA BAZY DANYCH
//  Entity Framework

//public MarynarzService(DbContext dbContext)
//{
//    _dbContext = dbContext;
//}

//public void Update(Marynarz marynarz)
//{
//    _dbContext.Marynarze.Update(marynarz);
//    _dbContext.SaveChanges();
//}