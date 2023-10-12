namespace CommonUI.Models
{
    public class JednostkaPlywajaca
    {
        public string Kategoria { get; set; }
        public string NumerBurtowy { get; set; }
        public string JednPlyw
        {
            get
            {
                return "SG" + NumerBurtowy;
            }
        }
    }
}
