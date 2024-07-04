using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCases.Pets.GetById;
public class GetPetByIdUseCase
{
    public ResponsePetJson Execute(int id)
    {
        return new ResponsePetJson 
        { 
            Id = id, 
            Name = "Cherry",
            Type = Communication.Enums.PetType.Cat,
            BirthDay = new DateTime(year: 2023, month: 01, day: 01),
        };
    }
}
