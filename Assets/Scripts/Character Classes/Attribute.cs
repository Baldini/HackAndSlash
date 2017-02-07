using System.Collections;

public class Attribute : BaseStats
{
    public Attribute()
        : base()
    {
        ExpToLevel = 50;
        LevelModifier = 1.05f;
    }
}

public enum AttributeName
{
    Migth,
    Constituion,
    Nimbleness,
    Speed,
    Concentration,
    Willpower,
    Charisma
}