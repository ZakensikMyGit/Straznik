using CommonUI.Models;

namespace CommonUI.ModelServices
{
    public class FormaSluzbyService : IFormaSluzbyService
    {
        public IEnumerable<FormaSluzby> GetAll()
        {
            yield return new FormaSluzby { Nazwa = "Patrol 1", Miejsce = "MWW" };
            yield return new FormaSluzby { Nazwa = "Patrol 2", Miejsce = "WSE" };
            yield return new FormaSluzby { Nazwa = "Eskorta LNG", Miejsce = "MWW" };
            yield return new FormaSluzby { Nazwa = "Dyżur w porcie", Miejsce = "Ś-cie" };
        }
    }
}
