using Command.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IUnitCommand : ICommand
{
    public CommandData CommandData;

    protected UnitController actorUnit;
    protected UnitController targetUnit;
    public abstract void Execute();
    public abstract bool WillHitTarget();
    public abstract void Undo();
    public void SetActorUnit(UnitController actorUnit) => this.actorUnit = actorUnit;
    public void SetTargetUnit(UnitController targetUnit) => this.targetUnit = targetUnit;
}
