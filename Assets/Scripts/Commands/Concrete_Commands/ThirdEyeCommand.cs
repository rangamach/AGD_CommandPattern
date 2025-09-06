using Command.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdEyeCommand : IUnitCommand
{
    private bool willHitTarget;
    private int previousHealth;
    public ThirdEyeCommand(CommandData commandData)
    {
        this.CommandData = commandData;

        willHitTarget = WillHitTarget();
    }
    public override void Execute() => GameService.Instance.ActionService.GetActionByType(Command.Actions.CommandType.ThirdEye).PerformAction(actorUnit, targetUnit, willHitTarget);

    public override bool WillHitTarget() => true;
    public override void Undo()
    {
        if (!targetUnit.IsAlive())
            targetUnit.Revive();

        int healthToRestore = (int)(previousHealth * 0.25f);
        targetUnit.RestoreHealth(healthToRestore);
        targetUnit.CurrentPower -= healthToRestore;
        actorUnit.Owner.ResetCurrentActivePlayer();
    }
}
