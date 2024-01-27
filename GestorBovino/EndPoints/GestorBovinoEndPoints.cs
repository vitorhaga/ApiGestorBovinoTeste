
using ApiGestorBovino.GestorBovino.Models.Dtos.Requests;
using ApiGestorBovino.GestorBovino.Models.Entities;
using ApiGestorBovino.Models.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;

namespace ApiGestorBovino.GestorBovinoEndPoints.EndPoints
{
    public static class GestorBovinoEndPoints
    {
        #region Pessoas
        public static void EndPointsPersons(this WebApplication app)
        {
            var endPointPersons = app.MapGroup(prefix:"persons");

            endPointPersons.MapPost(pattern: "", handler: async (PessoasReq request, DbContextBusiness context) =>
            {
                if (request != null)
                {
                    bool exists = false;
                    if (!request.Cnpj.IsNullOrEmpty())
                    {
                        exists = await context.Pessoas.AnyAsync(person => person.Cnpj == request.Cnpj);
                    }
                    else if (!request.Cpf.IsNullOrEmpty())
                    {
                        exists = await context.Pessoas.AnyAsync(person => person.Cpf == request.Cpf);
                    }
                    else
                    {
                        exists = await context.Pessoas.AnyAsync(person => person.Nome == request.Nome);
                    }
                    if(exists)
                        return Results.Conflict("Esta pessoa já existe!");
                    //Criar a camada de business para fazer este processo
                    var newPerson = new Pessoas(request);
                    await context.Pessoas.AddAsync(newPerson);
                    await context.SaveChangesAsync();
                    // retornar o que a camada de business devolver!!
                    return Results.Ok(newPerson);
                }
                else
                {
                    return Results.BadRequest();
                }
            });
        }
        #endregion
    }
}
