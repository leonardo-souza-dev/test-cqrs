using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestCQRS.App;
using TestCQRS.Queries;
using TestCQRS.Domain.Entities;
using System.Net;
using Util;
using TestCQRS.Domain.Repositories;

namespace TestCQRS.Web.Controllers
{
    public class HomeController : Controller
    {
        private ITransacaoService _transacaoService;

        public HomeController(ITransacaoService transacaoService)
        {
            _transacaoService = transacaoService;
        }

        [Route("obter-transacoes")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Transaction>), (int)HttpStatusCode.OK)]
        public List<Transaction> ObterTransacoes()
        {
            var command = new ObterTransacoesCommand
            {
                Data = DateTime.Now
            };

            var handler = new TransacaoCommandHandler();
            var result = handler.Handle(command);

            return result.Dado;
        }

        [Route("salvar-transacao")]
        [HttpPost]
        [ProducesResponseType(typeof(Transaction), (int)HttpStatusCode.OK)]
        public Transaction SalvarTransacao([FromBody] TransacaoDTO dto)
        {
            var command = new SalvarTransacaoCommand
            {
                Data = dto.Data,
                Descricao = dto.Descricao,
                Valor = dto.Valor
            };

            var handler = new TransacaoCommandHandler();
            var result = handler.Handle(command);

            return result.Dado;
        }
    }

    // TODO: Encontrar melhor lugar para deixar estas classes
    
    // MODEL
    public class ObterTransacoes
    {
        public DateTime Data { get; set; }
    }

    public class ObterTransacoesCommand : ICommand
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }

        public ObterTransacoesCommand() => this.Id = Guid.NewGuid();
    }

    public class SalvarTransacaoCommand : ICommand
    {
        public Guid Id { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }

        public SalvarTransacaoCommand() => this.Id = Guid.NewGuid();
    }

    public class TransacaoCommandHandler : ICommandHandler
    {
        private ITransacaoRepository _transacaoRepository;

        public TransacaoCommandHandler()
        {
            _transacaoRepository = new TransacaoRepository();
        }

        public Result<List<Transaction>> Handle(ObterTransacoesCommand command)
        {
            var result = new Result<List<Transaction>>();
            var transacoes = _transacaoRepository.ObterTransacoes(command.Data);
            result.Dado = transacoes;

            return result;
        }

        public Result<Transaction> Handle(SalvarTransacaoCommand command)
        {
            var transacao = _transacaoRepository.Salvar(command.Descricao, 
                                                        command.Valor, 
                                                        command.Data);

            return new Result<Transaction> { Dado = transacao };
        }
    }


    public interface ICommandHandler
    {
        Result<List<Transaction>> Handle(ObterTransacoesCommand command);
        Result<Transaction> Handle(SalvarTransacaoCommand command);
    }

    public interface ICommand
    {
        Guid Id { get; }
    }

    public class TransacaoRepository : ITransacaoRepository
    {
        public List<Transaction> ObterTransacoes(DateTime data)
        {
            return new List<Transaction> 
            {
                new Transaction(new DateTime(2020, 5, 17), "Café", 3, true),
                new Transaction(new DateTime(2020, 5, 18), "Livro", 30, true)
            };
        }

        public Transaction Salvar(string descricao, decimal valor, DateTime data)
        {
            return new Transaction(data, descricao, valor, true);
        }
    }

    public class TransacaoDTO
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
    }    
}
