public class SimpleGoal : Goal
{
    private bool isCheckedOff; 

    public SimpleGoal(string name, string description, int goalPoints) : base(name, description){
        this.goalPoints = goalPoints;
    }

    public SimpleGoal(string name, string description, int goalPoints, string isCheckedOff) : base(name, description){
        this.goalPoints = goalPoints;
        if (isCheckedOff == "True") {
            this.isCheckedOff = true;
        } else {
            this.isCheckedOff = false;
        }
    }
    
    public override void RecordProgress()
    {
        goalPoints += goalPoints;
        isCheckedOff = true; 
    }

    public override bool IsCompleted()
    {
        return isCheckedOff;
    }
}