public struct CommandData
{
    public int ActorUnitID;
    public int TargetUnitID;
    public int ActorPlayerID;
    public int TargetPlayerID;

    public CommandData(int actorUnitID, int targetUnitID, int actorPlayerID, int targetPlayerID)
    {
        this.ActorUnitID = actorUnitID;
        this.TargetUnitID = targetUnitID;
        this.ActorPlayerID = actorPlayerID;
        this.TargetPlayerID = targetPlayerID;
    }
}
