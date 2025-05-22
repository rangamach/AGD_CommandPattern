using Command.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStanceCommand : IUnitCommand
{
    private bool willHitTarget;
    public AttackStanceCommand(CommandData commandData)
    {
        this.CommandData = commandData;

        willHitTarget = WillHitTarget();
    }
    public override void Execute() => GameService.Instance.ActionService.GetActionByType(Command.Actions.CommandType.AttackStance).PerformAction(actorUnit, targetUnit, willHitTarget);

    public override bool WillHitTarget() => true;
    public override void Undo()
    {
        if (willHitTarget)
        {
            if (!targetUnit.IsAlive())
                targetUnit.Revive();
            targetUnit.RestoreHealth(actorUnit.CurrentPower);
            actorUnit.Owner.ResetCurrentActivePlayer();
        }
    }
}
