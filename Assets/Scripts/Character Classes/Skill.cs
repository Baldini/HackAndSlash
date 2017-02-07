using UnityEngine;
using System.Collections;

public class Skill : ModifiedStat
{
    private bool _know;

    public Skill()
    {
        _know = false;
        ExpToLevel = 25;
        LevelModifier = 1.1f;
    }
    public bool Know
    {
        get
        { return _know; }
        set
        { _know = value; }
    }
}

public enum SkillName
{
    Melee_Offence,
    Melee_Defense,
    Ranged_Offence,
    Ranged_Defence,
    Magic_Offence,
    Magic_Defence
}