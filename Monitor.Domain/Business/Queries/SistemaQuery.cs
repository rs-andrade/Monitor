using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Monitor.Data.NHibernate;
using Monitor.Domain.ViewModels;
using Monitor.Domain.Entities;
using System.Linq;
using Monitor.Data;
using Monitor.Domain.ViewModels.Sistema;

namespace Monitor.Domain.Business.Queries
{
    public class SistemaQuery : ISistemaQuery
    {
        private readonly IMapper mapper;
        private readonly ISessionProvider sessionProvider;

        public SistemaQuery(IMapper mapper, ISessionProvider sessionProvider)
        {
            this.mapper = mapper;
            this.sessionProvider = sessionProvider;
        }

        public async Task<IEnumerable<DetalhesSistemaViewModel>> ListarSistemasAsync()
        {
            using (var session = sessionProvider.OpenStatelessSession())
            {
                return await Task.FromResult(mapper.Map<IEnumerable<DetalhesSistemaViewModel>>(session.Query<Sistema>()));
            }
        }

        public async Task<IEnumerable<DetalhesSistemaViewModel>> ListarSistemasAsync(long handleAmbiente)
        {
            using (var session = sessionProvider.OpenStatelessSession())
            {
                return await Task.FromResult(mapper.Map<IEnumerable<DetalhesSistemaViewModel>>
                  (session.Query<Sistema>().Where(x => x.Ambiente.Handle == handleAmbiente).ToList()));
            }
        }

        public async Task<DetalhesSistemaViewModel> DetalhesSistemaAsync(long handle)
        {
            using (var session = sessionProvider.OpenStatelessSession())
            {
                return await Task.FromResult(mapper.Map<DetalhesSistemaViewModel>(session.Query<Sistema>().Where(x => x.Handle == handle).FirstOrDefault()));
            }
        }

    }
}