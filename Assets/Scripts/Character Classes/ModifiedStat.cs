using System.Collections.Generic;
using System;
using UnityEngine;

public class ModifiedStat : BaseStats
{
    private List<ModifyingAttribute> _mods; //Lista de atributos para modificar o stats
    private int _modValue;                  //Valor adicionado para o valor base do modificador

    public ModifiedStat()
    {
        _mods = new List<ModifyingAttribute>();
        _modValue = 0;
    }

    public void AddModifier(ModifyingAttribute mod)
    {
        _mods.Add(mod);
    }

    private void CalculateModValue()
    {

        _modValue = 0;
        if (_mods.Count > 0)
            foreach (var Att in _mods)
                _modValue += Convert.ToInt32(Att.attribute.AdjustedValue() * Att.ratio);
    }

    public new int AdjustedBaseValue
    {
        get { return BaseValue + BuffValue + _modValue; }
    }

    public void Update()
    {
        CalculateModValue();
    }

}

public struct ModifyingAttribute
{
    public Attribute attribute;
    public float ratio;

    public ModifyingAttribute(Attribute att, float r)
    {
        attribute = att;
        ratio = r;
    }
}