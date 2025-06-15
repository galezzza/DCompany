using CSharpFunctionalExtensions;
using DCompany.Shared.SharedKernel;

namespace DCompany.Shared.Core.Handlers;

public interface ICommandHandler<in TCommand, TResponse>
        where TCommand : ICommand
{
    Task<Result<TResponse, ErrorList>> HandleAsync(TCommand command, CancellationToken cancellationToken);
}

public interface ICommandHandler<in TCommand>
    where TCommand : ICommand
{
    Task<UnitResult<ErrorList>> HandleAsync(TCommand command, CancellationToken cancellationToken);
}
