﻿using Mapster;
using MediatR;
using Reto.Application.Contracts.Cliente;
using Reto.Domain.Repositories;

namespace Reto.Application.Core.Cliente.Commands;

public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, CreateClienteResult>
{
    private readonly IClienteRepository _clienteRepository;

    public CreateClienteCommandHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<CreateClienteResult> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = Domain.Entities.Cliente.Create(
            request.Nombre,
            request.Edad,
            request.Genero,
            request.Identificacion,
            request.Direccion,
            request.Telefono,
            request.Contrasenia);

        var result = await _clienteRepository.Create(cliente);

        return result.Adapt<CreateClienteResult>();
    }
}
