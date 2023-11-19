public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int goalPoints) : base(name, description) {
        this.goalPoints = goalPoints;
    }

    public override void RecordProgress()
    {
        goalPoints += goalPoints;
    }

    public override string Display()
    {
        return base.Display();
    }
    public override bool IsCompleted()
    {
        return false; // Eternal Goals are never marked as completed
    }
}