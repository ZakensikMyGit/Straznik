namespace CommonUI.Models
{
    public class FormaSluzby
    {
        public string Nazwa { get; set; }
        public string Miejsce { get; set; }
        public string Sluzba
        {
            get
            {
                return "(" + Miejsce + ") " + Nazwa;
            }
        }
    }
}
