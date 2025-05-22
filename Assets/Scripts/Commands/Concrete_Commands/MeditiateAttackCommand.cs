using Command.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeditiateAttackCommand : IUnitCommand
{
    private bool willHitTarget;
    private int previousMaxHealth;
    public MeditiateAttackCommand(CommandData commandData)
    {
        this.CommandData = commandData;

        willHitTarget = WillHitTarget();
    }
    public override void Execute() => GameService.Instance.ActionService.GetActionByType(Command.Actions.CommandType.Meditate).PerformAction(actorUnit, targetUnit, willHitTarget);

    public override bool WillHitTarget() => true;
    public override void Undo()
    {
        if (willHitTarget)
        {
            var healthToReduce = targetUnit.CurrentMaxHealth - previousMaxHealth;
            targetUnit.CurrentMaxHealth = previousMaxHealth;
            targetUnit.TakeDamage(healthToReduce);
        }
        actorUnit.Owner.ResetCurrentActivePlayer();
    }
}
