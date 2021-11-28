using FindNumbersDivider.CrossCutting.Application;
using System.Threading.Tasks;

namespace FindNumbersDivider.Application.Interfaces
{
    public interface IFindNumbersDividerAppService
    {
        Task<GenericResponse> FindDividersAccordingToNumber(int number);
    }
}