using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SocietyAgendor.UI.Models;
using SocietyAgendor.UI.Service;

namespace SocietyAgendor.UI.Controllers
{
    public class AgendamentoController : Controller
    {
        private readonly IAgendamentoService _agendamentoService;
        private readonly IClienteService _clienteService;
        private readonly IEstabelecimentoService _estabelecimentoService;
        private readonly IHorarioService _horarioService;

        public AgendamentoController(IAgendamentoService agendamentoService,
                                     IClienteService clienteService,
                                     IEstabelecimentoService estabelecimentoService,
                                     IHorarioService horarioService)
        {
            _agendamentoService = agendamentoService;
            _clienteService = clienteService;
            _estabelecimentoService = estabelecimentoService;
            _horarioService = horarioService;
        }
        public async Task<IActionResult> Index()
        {
            var items = await _agendamentoService.GetAgendamentosAsync();

            return View(items);
        }

        public async Task<IActionResult> CreateAgendamento(int? clienteId)
        {
            ViewBag.ClientesList = await GetClientesListAsync();
            ViewBag.EstabelecimentosList = await GetEstabelecimentosListAsync();

            if (clienteId.HasValue)
            {
                var agendamento = new AgendamentoModel
                {
                    Cliente_Id = clienteId.GetValueOrDefault()
                };

                return View(agendamento);
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateAgendamento(AgendamentoModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Propriedades Inválidas");
            }

            model.DiaSemana_Id = (int)model.DataAgendamento.GetValueOrDefault().DayOfWeek + 1;
            await _agendamentoService.CreateAgendamentoAsync(model);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateAgendamento(int agId)
        {
            var agendamentos = await _agendamentoService.GetAgendamentosAsync();
            var agendamento = agendamentos.Where(x => x.Agendamento_Id == agId).FirstOrDefault();

            ViewBag.ClientesList = await GetClientesListAsync();
            ViewBag.EstabelecimentosList = await GetEstabelecimentosListAsync();
            ViewBag.HorariosDisponiveisList = await GetHorariosDisponiveisListAsync(agendamento.DataAgendamento.GetValueOrDefault());

            return View(agendamento);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAgendamento(AgendamentoModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Propriedades Inválidas");
            }

            model.DiaSemana_Id = (int)model.DataAgendamento.GetValueOrDefault().DayOfWeek + 1;
            await _agendamentoService.UpdateAgendamentoAsync(model);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteAgendamento(int agId)
        {
            var agendamentos = await _agendamentoService.GetAgendamentosAsync();
            var agendamento = agendamentos.Where(x => x.Agendamento_Id == agId).FirstOrDefault();

            return View(agendamento);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAgendamento(AgendamentoModel agendamento)
        {
            await _agendamentoService.DeleteAgendamentoAsync((int)agendamento.Agendamento_Id);

            return RedirectToAction("Index");
        }


        //lists
        private async Task<SelectList> GetClientesListAsync()
        {
            var clientes = await _clienteService.GetClientesAsync();
            clientes.Insert(0, new ClienteModel { Cliente_Id = -1, Cliente_Nome = "Selecione um Cliente..." });

            return new SelectList(clientes, "Cliente_Id", "Cliente_Nome");
        }

        private async Task<SelectList> GetEstabelecimentosListAsync()
        {
            var estabelecimentos = await _estabelecimentoService.GetEstabelecimentoAsync();
            estabelecimentos.Insert(0, new EstabelecimentoModel { Estabelecimento_Id = -1, Estabelecimento_Nome = "Selecione um Estebelecimento..." });

            return new SelectList(estabelecimentos, "Estabelecimento_Id", "Estabelecimento_Nome");
        }

        public async Task<SelectList> GetHorariosDisponiveisListAsync(DateTime dia)
        {
            var horarios = await _horarioService.GetHorariosDisponiveisAsync(dia);
            return new SelectList(horarios, "Horario_Id", "Horario_Desc");
        }
    }
}