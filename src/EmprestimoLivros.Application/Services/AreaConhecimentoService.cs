using AutoMapper;
using EmprestimoLivros.Application.DTOs.AreaConhecimento.Request;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Application.Validator;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Infra.Data.Interfaces;
using EmprestimoLivros.Infra.Data.Repositories;

namespace EmprestimoLivros.Application.Services
{
    public class AreaConhecimentoService : IAreaConhecimentoService
    {
        private readonly IMapper _mapper;
        private readonly AreaConhecimentoValidator _acValidator;
        private readonly IAreaConhecimentoRepository _areaConhecimentoRepository;
        public AreaConhecimentoService(IAreaConhecimentoRepository areaConhecimentoRepository, IMapper mapper, AreaConhecimentoValidator areaConhecimentoValidator)
        {
            _acValidator = areaConhecimentoValidator;
            _mapper = mapper;
            _areaConhecimentoRepository = areaConhecimentoRepository;
        }

        public async Task<AreaConhecimento> BuscarAreaConhecimento(int Id)
        {
            await _acValidator.ValidaId(Id);
            return await _areaConhecimentoRepository.BuscarAreaConhecimento(Id);
        }

        public async Task CadastrarAreaConheicmento(CadastrarAreaConhecimentoRequestDTO areaConhecimentoDTO)
        {
            var areaConhecimento = await _areaConhecimentoRepository.BuscarAreaConhecimento(areaConhecimentoDTO.Id);

            if (areaConhecimento != null)
                throw new Exception("Id já cadastrado.");

            await _acValidator.validaCamposAreaConhecimento(areaConhecimentoDTO);
            AreaConhecimento ac = _mapper.Map<AreaConhecimento>(areaConhecimentoDTO);
            await _areaConhecimentoRepository.CadastrarAreaConheicmento(ac);
        }

        public async Task<IEnumerable<AreaConhecimento>> ListarTodasAreas()
        {
            return await _areaConhecimentoRepository.ListarTodasAreas();
        }

        public async Task RemoverAreaConhecimento(int Id)
        {
            var areaConhecimento = await _areaConhecimentoRepository.BuscarAreaConhecimento(Id);

            if (areaConhecimento == null)
                throw new Exception("Id não existe.");

            await _areaConhecimentoRepository.RemoverAreaConhecimento(Id);
        }
    }
}
