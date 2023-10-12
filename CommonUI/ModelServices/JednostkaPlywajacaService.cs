using CommonUI.Models;

namespace CommonUI.ModelServices
{
    public class JednostkaPlywajacaService : IJednostkaPlywajacaService
    {
        public IEnumerable<JednostkaPlywajaca> GetAll()
        {
            yield return new JednostkaPlywajaca { Kategoria = "I", NumerBurtowy = "312" };
            yield return new JednostkaPlywajaca { Kategoria = "II", NumerBurtowy = "212" };
            yield return new JednostkaPlywajaca { Kategoria = "II", NumerBurtowy = "214" };
            yield return new JednostkaPlywajaca { Kategoria = "IV", NumerBurtowy = "070" };
        }
    }
}
