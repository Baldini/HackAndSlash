using UnityEngine;
using System.Collections;
using System;

public class BaseCharacter : MonoBehaviour
{
    private string _name;
    private int _level;
    private uint _freeExp;

    public string Name { get { return _name; } set { _name = value; } }
    public int Level { get { return _level; } set { _level = value; } }
    public uint FreeExp { get { return _freeExp; } set { _freeExp = value; } }


    private Attribute[] _primaryAttribute;
    private Vital[] _vital;
    private Skill[] _skill;


    public void Awake()
    {
        _name = string.Empty;
        _level = 0;
        _freeExp = 0;

        _primaryAttribute = new Attribute[Enum.GetValues(typeof(AttributeName)).Length];
        _vital = new Vital[Enum.GetValues(typeof(VitalName)).Length];
        _skill = new Skill[Enum.GetValues(typeof(SkillName)).Length];

        SetupPrimaryAttributes();
        SetupVitals();
        SetupSkills();
    }

    public void AddExp(uint exp)
    {
        _freeExp += exp;
        CalculateLevel();
    }
    public void CalculateLevel()
    {

    }
    private void SetupPrimaryAttributes()
    {
        for (int i = 0; i < _primaryAttribute.Length; i++)
        {
            _primaryAttribute[i] = new Attribute();
        }
    }
    private void SetupVitals()
    {
        for (int i = 0; i < _vital.Length; i++)
        {
            _vital[i] = new Vital();
        }
        SetupVitalModifiers();

    }
    private void SetupSkills()
    {
        for (int i = 0; i < _skill.Length; i++)
        {
            _skill[i] = new Skill();
        }
        SetupSkillModifiers();

    }
    public Attribute getPrimaryAttribute(int index)
    {
        return _primaryAttribute[index];
    }
    public Vital getVital(int index)
    {
        return _vital[index];
    }
    public Skill getSkill(int index)
    {
        return _skill[index];
    }
    private void SetupVitalModifiers()
    {
        //Health
        getVital((int)VitalName.Health).AddModifier(new ModifyingAttribute(getPrimaryAttribute((int)AttributeName.Constituion), .5f));
        //Energy
        getVital((int)VitalName.Energy).AddModifier(new ModifyingAttribute(getPrimaryAttribute((int)AttributeName.Constituion), 1f));
        //Mana
        getVital((int)VitalName.Mana).AddModifier(new ModifyingAttribute(getPrimaryAttribute((int)AttributeName.Willpower), 1f));
    }
    private void SetupSkillModifiers()
    {
        //Melee Attack
        getSkill((int)SkillName.Melee_Offence).AddModifier(new ModifyingAttribute(getPrimaryAttribute((int)AttributeName.Migth), .33f));
        getSkill((int)SkillName.Melee_Offence).AddModifier(new ModifyingAttribute(getPrimaryAttribute((int)AttributeName.Nimbleness), .33f));
        //Melee Defense
        getSkill((int)SkillName.Melee_Defense).AddModifier(new ModifyingAttribute(getPrimaryAttribute((int)AttributeName.Speed), .33f));
        getSkill((int)SkillName.Melee_Defense).AddModifier(new ModifyingAttribute(getPrimaryAttribute((int)AttributeName.Constituion), .33f));
        //Ranged Attack
        getSkill((int)SkillName.Ranged_Offence).AddModifier(new ModifyingAttribute(getPrimaryAttribute((int)AttributeName.Concentration), .33f));
        getSkill((int)SkillName.Ranged_Offence).AddModifier(new ModifyingAttribute(getPrimaryAttribute((int)AttributeName.Speed), .33f));
        //Ranged Defense
        getSkill((int)SkillName.Ranged_Defence).AddModifier(new ModifyingAttribute(getPrimaryAttribute((int)AttributeName.Speed), .33f));
        getSkill((int)SkillName.Ranged_Defence).AddModifier(new ModifyingAttribute(getPrimaryAttribute((int)AttributeName.Nimbleness), .33f));
        //Magic Attack
        getSkill((int)SkillName.Magic_Offence).AddModifier(new ModifyingAttribute(getPrimaryAttribute((int)AttributeName.Concentration), .33f));
        getSkill((int)SkillName.Magic_Offence).AddModifier(new ModifyingAttribute(getPrimaryAttribute((int)AttributeName.Willpower), .33f));
        //Magic Defense
        getSkill((int)SkillName.Magic_Defence).AddModifier(new ModifyingAttribute(getPrimaryAttribute((int)AttributeName.Concentration), .33f));
        getSkill((int)SkillName.Magic_Defence).AddModifier(new ModifyingAttribute(getPrimaryAttribute((int)AttributeName.Willpower), .33f));
    }
    public void StatUpdate()
    {
        
        for (int i = 0; i < _vital.Length; i++)
            _vital[i].Update();

        for (int i = 0; i < _skill.Length; i++)
            _skill[i].Update();

    }
}
