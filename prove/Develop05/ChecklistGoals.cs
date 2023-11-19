public class ChecklistGoal : Goal
{
    private int requiredTimes;
    private int bonusPoints;
    private int completedTimes;

    // do not change this constructor order.
    // switching required times and bonus points caused it to create the goal with the wrong values. 
    // i set bonus points at 500 and it created the goal with the requirement to complete the goal 500 times. 
    public ChecklistGoal(string name, string description, int goalPoints, int requiredTimes, int bonusPoints)
        : base(name, description)
    {
        this.goalPoints = goalPoints;
        this.requiredTimes = requiredTimes;
        this.bonusPoints = bonusPoints;
        completedTimes = 0;
    }

    public ChecklistGoal(string name, string description, int goalPoints, int requiredTimes, int bonusPoints, int completedTimes)
        : base(name, description)
    {
        this.goalPoints = goalPoints;
        this.requiredTimes = requiredTimes;
        this.bonusPoints = bonusPoints;
        this.completedTimes = completedTimes;
    }

    public override void RecordProgress()
    {
        completedTimes++;
        goalPoints += bonusPoints == requiredTimes ? bonusPoints : 0; // Bonus points for each recording

        if (completedTimes == requiredTimes)
        {
            goalPoints += bonusPoints; // Bonus points when checklist is completed
        }
    }

    public override string Display()
    {
        return $"{base.Display()} - Completed {completedTimes}/{requiredTimes} times";
    }

    public override string Save()
    {
        return $"{base.Save()},{bonusPoints},{completedTimes},{requiredTimes}";
    }
    public override bool IsCompleted()
    {
        return completedTimes >= requiredTimes;
    }
}