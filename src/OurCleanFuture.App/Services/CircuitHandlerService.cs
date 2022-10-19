using Microsoft.AspNetCore.Components.Server.Circuits;

namespace OurCleanFuture.App.Services;

public class CircuitHandlerService : CircuitHandler
{
    private readonly StateContainerService _stateContainer;

    public CircuitHandlerService(StateContainerService stateContainer) => _stateContainer = stateContainer;

    public override Task OnCircuitOpenedAsync(Circuit circuit, CancellationToken cancellationToken)
    {
        Log.Information("Circuit {CircuitId} opened.", circuit.Id);
        return base.OnCircuitOpenedAsync(circuit, cancellationToken);
    }

    public override Task OnCircuitClosedAsync(Circuit circuit, CancellationToken cancellationToken)
    {
        Log.Information(
            "{User} has disconnected circuit {CircuitId}.",
            _stateContainer.ClaimsPrincipalEmail ?? "Unauthenticated user",
            circuit.Id
        );
        return base.OnCircuitClosedAsync(circuit, cancellationToken);
    }
}
