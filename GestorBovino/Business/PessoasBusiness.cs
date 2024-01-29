using ApiGestorBovino.Models.DB;
using ApiGestorBovino.GestorBovino.Models.Entities;
using ApiGestorBovino.GestorBovino.Handlers;
using Microsoft.IdentityModel.Tokens;

namespace ApiGestorBovino.GestorBovino.Business
{
    public class PessoasBusiness
    {
        public async Task<IResult> CreatePerson(Pessoas newPerson)
        {
            var exists = await newPerson.PersonExists();

            if (!exists.IsNullOrEmpty())
                return Results.Conflict(exists);

            newPerson.Insert();

            return Results.Ok(newPerson);
        }

        public async Task<IResult> UpdatePerson(Pessoas person)
        {
            var exists = await person.Get(person);

            if (!(bool)exists)
                return Results.Conflict(exists);

            person.Insert();

            return Results.Ok(person);
        }
    }
}
