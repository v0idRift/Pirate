using Content.Server.Chemistry.EntitySystems;
using Content.Shared.Chemistry.Reagent;
using Content.Shared.FixedPoint;
using JetBrains.Annotations;
using Content.Server.Body.Components;
using Content.Shared.Chemistry.EntitySystems;
using Content.Shared.Disease;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;
using Content.Server.Chemistry.Containers.EntitySystems;

namespace Content.Server.Disease.Effects
{
    /// <summary>
    /// Adds or removes reagents from the
    /// host's chemstream.
    /// </summary>
    [UsedImplicitly]
    public sealed partial class DiseaseAdjustReagent : DiseaseEffect
    {
        /// <summary>
        ///     The reagent ID to add or remove.
        /// </summary>
        [DataField("reagent", customTypeSerializer:typeof(PrototypeIdSerializer<ReagentPrototype>))]
        public string? Reagent = null;

        [DataField("amount", required: true)]
        public FixedPoint2 Amount = default!;

        public override void Effect(DiseaseEffectArgs args)
        {
            if (!args.EntityManager.TryGetComponent<BloodstreamComponent>(args.DiseasedEntity, out var bloodstream))
                return;

            var stream = bloodstream.ChemicalSolution;
            if (stream == null)
                return;

            var solutionSys = args.EntityManager.EntitySysManager.GetEntitySystem<SolutionContainerSystem>();
            if (Reagent == null)
                return;

            // string proto = Reagent;
            // if (Amount < 0 && stream.ContainsPrototype(proto))
            //     solutionSys.RemoveReagent(args.DiseasedEntity, stream, new(proto, null), -Amount);

            // if (Amount > 0)
            //     solutionSys.TryAddReagent(args.DiseasedEntity, stream, proto, Amount, out _);
        }
    }
}
