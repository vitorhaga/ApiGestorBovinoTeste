using ApiGestorBovino.GestorBovino.Business;
using ApiGestorBovino.GestorBovino.Handlers;
using ApiGestorBovino.GestorBovino.Models.Dtos.Requests;
using ApiGestorBovino.GestorBovino.Models.Entities;
using ApiGestorBovino.Models.DB;

namespace ApiGestorBovino.GestorBovinoEndPoints.EndPoints
{
    public static class GestorBovinoEndPoints
    {
        #region Pessoas
        public static void EndPointsPersons(this WebApplication app)
        {
            var endPointPersons = app.MapGroup(prefix:"persons");

            endPointPersons.MapPost(pattern: "", handler: async (PessoasReq request) =>
            {
                if (request.IsValidObject() && request.Nome!.IsValidString())
                {
                    try
                    {
                        var newPerson = new Pessoas(request);
                        return await new PessoasBusiness().CreatePerson(newPerson);
                    }
                    catch (Exception ex)
                    {
                        return Results.BadRequest(ex.Message);
                    }
                }
                else
                {
                    return Results.BadRequest("Dados Incompletos!");
                }
            });

            endPointPersons.MapPut(pattern: "", handler: async (PessoasReq request) =>
            {
                if (request.IsValidObject() && request.Nome!.IsValidString())
                {
                    try
                    {
                        var newPerson = new Pessoas(request);
                        return await new PessoasBusiness().UpdatePerson(newPerson);
                    }
                    catch (Exception ex)
                    {
                        return Results.BadRequest(ex.Message);
                    }
                }
                else
                {
                    return Results.BadRequest("Dados Incompletos!");
                }
            });

            endPointPersons.MapGet(pattern: "", handler: async() =>
            {
                var AllPersons = await new Pessoas().GetAllPersons();

                return AllPersons;
            });
        }
        #endregion
    }
}
