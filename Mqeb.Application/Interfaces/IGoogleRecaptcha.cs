using System.Threading.Tasks;

namespace Mqeb.Application.Interfaces
{
    public interface IGoogleRecaptcha
    {
        Task<bool> IsSatisfy();
    }
}