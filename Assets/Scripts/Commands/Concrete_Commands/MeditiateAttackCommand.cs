using Command.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeditiateAttackCommand : IUnitCommand
{
    private bool willHitTarget;
    public MeditiateAttackCommand(CommandData commandData)
    {
        this.CommandData = commandData;

        willHitTarget = WillHitTarget();
    }
    public override void Execute() => GameService.Instance.ActionService.GetActionByType(Command.Actions.CommandType.Meditate).PerformAction(actorUnit, targetUnit, willHitTarget);

    public override bool WillHitTarget() => true;
}
