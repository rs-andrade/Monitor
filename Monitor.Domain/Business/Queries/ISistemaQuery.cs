using System.Collections.Generic;
using System.Threading.Tasks;
using Monitor.Domain.ViewModels;
using Monitor.Domain.ViewModels.Sistema;

namespace Monitor.Domain.Business.Queries
{
    public interface ISistemaQuery
    {
        Task<IEnumerable<DetalhesSistemaViewModel>> ListarSistemasAsync();
        Task<IEnumerable<DetalhesSistemaViewModel>> ListarSistemasAsync(long handleAmbiente);
        Task<DetalhesSistemaViewModel> DetalhesSistemaAsync(long handle);
    }
}