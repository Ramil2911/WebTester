using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Server.Circuits;

namespace tester.Data.Services
{
    public class CircuitHandlerService : CircuitHandler
    {
        public ConcurrentDictionary<string, Circuit> Circuits { get; 
            set; }

        public CircuitHandlerService()
        {
            Circuits = new ConcurrentDictionary<string, Circuit>();
        }

        public override Task OnCircuitOpenedAsync(Circuit circuit, 
            CancellationToken cancellationToken)
        {
            Circuits[circuit.Id] = circuit;
            return base.OnCircuitOpenedAsync(circuit, 
                cancellationToken);
        }

        public override Task OnCircuitClosedAsync(Circuit circuit, CancellationToken cancellationToken)
        {
            Circuit circuitRemoved;
            Circuits.TryRemove(circuit.Id, out circuitRemoved);
            return base.OnCircuitClosedAsync(circuit, cancellationToken);
        }
    }
}