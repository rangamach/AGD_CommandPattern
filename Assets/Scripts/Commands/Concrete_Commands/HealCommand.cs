using Command.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCommand : IUnitCommand
{
    private bool willHitTarget;
    public HealCommand(CommandData commandData)
    {
        this.CommandData = commandData;

        willHitTarget = WillHitTarget();
    }
    public override void Execute() => GameService.Instance.ActionService.GetActionByType(Command.Actions.CommandType.Heal).PerformAction(actorUnit, targetUnit, willHitTarget);

    public override bool WillHitTarget() => true;
    public override void Undo()
    {
        if (willHitTarget)
        {
            targetUnit.TakeDamage(actorUnit.CurrentPower);
            actorUnit.Owner.ResetCurrentActivePlayer();
        }
    }
}
