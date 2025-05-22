using Command.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanseCommand : IUnitCommand
{
    private bool willHitTarget;
    private int prevPower;
    public CleanseCommand(CommandData commandData)
    {
        this.CommandData = commandData;

        willHitTarget = WillHitTarget();
    }
    public override void Execute() => GameService.Instance.ActionService.GetActionByType(Command.Actions.CommandType.Cleanse).PerformAction(actorUnit, targetUnit, willHitTarget);

    public override bool WillHitTarget() => true;
    public override void Undo()
    {
        if (willHitTarget)
        {
            if (willHitTarget)
                targetUnit.CurrentPower = prevPower;

            actorUnit.Owner.ResetCurrentActivePlayer();
        }
    }
}
