public class Achievement
{
    private string name;
    private string desc;
    private bool unlocked;
    private int spriteIndex;

    Achievement(string name, string desc, int spriteIndex)
    {
        this.name = name;
        this.desc = desc;
        this.unlocked = false;
        this.spriteIndex = spriteIndex;
    }

    public bool EarnAchievement()
    {
        if (!unlocked)
        {
            unlocked = true;
            return true;
        }
        return false;
    }
}
