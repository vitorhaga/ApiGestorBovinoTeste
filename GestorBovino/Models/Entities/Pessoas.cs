using ApiGestorBovino.GestorBovino.Handlers;
using ApiGestorBovino.GestorBovino.Models.Dtos.Requests;
using ApiGestorBovino.Models.DB;
using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGestorBovino.GestorBovino.Models.Entities
{
    public class Pessoas
    {
        [Column("codigo"),Key] public Guid Codigo { get; set; }
        [Column("data_inclusao")]public DateTime? DataInclusao {  get; set; }
        [Column("data_alteracao")] public DateTime? DataAlteracao { get; set; }
        [Column("data_exclusao")] public DateTime? DataExclusao { get; set; }
        [Column("nome")] public string? Nome { get; set; }
        [Column("cpf")] public string? Cpf { get; set; }
        [Column("cnpj")] public string? Cnpj { get; set; }
        [Column("telefone")] public string? Telefone { get; set; }
        public Pessoas(){}
        public Pessoas(PessoasReq pessoa)
        {
            DataInclusao = DateTime.Now;
            DataAlteracao = DateTime.Now;
            Nome = pessoa.Nome!;
            if (pessoa.Cpf!.IsValidString())
            {
                if (pessoa.Cpf!.IsValidCpf())
                    Cpf = pessoa.Cpf;
                else
                    throw new ArgumentException("Este Cpf é inválido!");
            }
            if (pessoa.Cnpj!.IsValidString())
            {
                if (pessoa.Cnpj!.IsValidCpf())
                    Cnpj = pessoa.Cnpj;
                else
                    throw new ArgumentException("Este Cnpj é inválido!");
            }
            Telefone = pessoa.Telefone;
        }
        public async Task<String> PersonExists()
        {
            DbContextBusiness context = new DbContextBusiness();
            if (Cnpj!.IsValidCnpj())
            {
                if (await context.Pessoas.AnyAsync(person => person.Cnpj == this.Cnpj))
                    return "Este Cnpj já existe!";
                else
                    return string.Empty;
            }
            else if (Cpf!.IsValidCpf())
            {
                if (await context.Pessoas.AnyAsync(person => person.Cpf == this.Cpf))
                    return "Este Cpf já existe!";
                else
                    return string.Empty;
            }
            else
            {
                if (await context.Pessoas.AnyAsync(person => person.Nome == this.Nome))
                    return "Este nome já existe!";
                else
                    return string.Empty;
            }
        }
        public async Task<List<Pessoas>> GetAllPersons()
        {
            DbContextBusiness context = new DbContextBusiness();
            return await context.Pessoas.Where(persons => persons.DataExclusao == null).ToListAsync();
        }
        public async Task<bool> Get(Pessoas person)
        {
            DbContextBusiness context = new DbContextBusiness();
            return await context.Pessoas.AnyAsync(persons => persons.Codigo == person.Codigo);
        }
        public async void Insert()
        {
            DbContextBusiness context = new DbContextBusiness();
            await context.Pessoas.AddAsync(this);
            await context.SaveChangesAsync();
        }
    }
}
