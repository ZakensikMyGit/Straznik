using CommonUI.Models;

namespace CommonUI.ModelServices
{
    public interface IMarynarzService
    {
        IEnumerable<Marynarz> GetAll();
        void Update(Marynarz updatedMarynarz);
    }
}