namespace CommonUI.Models
{
    public class Marynarz
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Stopien { get; set; }
        public string Funkcjonariusz
        {
            get
            {
                return Nazwisko + " " + Imie;
            }
        }
    }
}
