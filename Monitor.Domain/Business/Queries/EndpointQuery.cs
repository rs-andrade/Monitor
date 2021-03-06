using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Monitor.Data.NHibernate;
using Monitor.Domain.ViewModels;
using Monitor.Domain.Entities;
using System.Linq;
using Monitor.Data;
using Monitor.Domain.ViewModels.Endpoint;

namespace Monitor.Domain.Business.Queries
{
    public class EndpointQuery : IEndpointQuery
    {
        private readonly IMapper mapper;
        private readonly ISessionProvider sessionProvider;

        public EndpointQuery(IMapper mapper, ISessionProvider sessionProvider)
        {
            this.mapper = mapper;
            this.sessionProvider = sessionProvider;
        }

        public async Task<IEnumerable<DetalhesEndpointViewModel>> ListarEndpointsAsync()
        {
            using (var session = sessionProvider.OpenStatelessSession())
            {
                return await Task.FromResult(mapper.Map<IEnumerable<DetalhesEndpointViewModel>>(session.Query<Endpoint>()));
            }
        }

        public async Task<IEnumerable<DetalhesEndpointViewModel>> ListarEndpointsAsync(long handleSistema)
        {
            using (var session = sessionProvider.OpenStatelessSession())
            {
                return await Task.FromResult(mapper.Map<IEnumerable<DetalhesEndpointViewModel>>
                  (session.Query<Endpoint>().Where(x => x.Sistema.Handle == handleSistema).ToList()));
            }
        }

        public async Task<DetalhesEndpointViewModel> DetalhesEndpointAsync(long handle)
        {
            using (var session = sessionProvider.OpenStatelessSession())
            {
                return await Task.FromResult(mapper.Map<DetalhesEndpointViewModel>(session.Query<Endpoint>().Where(x => x.Handle == handle).FirstOrDefault()));
            }
        }
    }
}