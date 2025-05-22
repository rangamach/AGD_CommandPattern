using Command.Actions;
using Command.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerserkAttackCommand : IUnitCommand
{
    private bool willHitTarget;
    public BerserkAttackCommand(CommandData commandData)
    {
        this.CommandData = commandData;

        willHitTarget = WillHitTarget();
    }
    public override void Execute() => GameService.Instance.ActionService.GetActionByType(Command.Actions.CommandType.BerserkAttack).PerformAction(actorUnit, targetUnit, willHitTarget);

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

    public override bool WillHitTarget() => true;
}
