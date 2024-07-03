﻿using Petfolio.Communication.Requests;
using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCases.Pet.Register;
public class RegisterPetUseCase
{
    public ResponseRegisterPetJson Execute(RequestRegisterPetJson request)
    {
        return new ResponseRegisterPetJson()
        {
            Id = 1,
            Name = request.Name,
        };
    }
}
