using Command.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : IUnitCommand
{
    private bool willHitTarget;
    public AttackCommand(CommandData commandData)
    {
        this.CommandData = commandData;
        willHitTarget = WillHitTarget();
    }
    public override void Execute() => GameService.Instance.ActionService.GetActionByType(Command.Actions.CommandType.Attack).PerformAction(actorUnit,targetUnit,willHitTarget);

    public override bool WillHitTarget() => true;
}
