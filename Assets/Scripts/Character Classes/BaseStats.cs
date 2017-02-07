using UnityEngine;
using System.Collections;
using System;

public class BaseStats
{
    private int _baseValue;         //Valor base para o Stats
    private int _buffValue;         //Valor do buff para Stats
    private int _expToLevel;        //Valor total da experiencia que precisa para upar
    private float _LevelModifier;   //Valor do modificador de Exp

    public BaseStats()
    {
        _baseValue = 0;
        _buffValue = 0;
        _LevelModifier = 1.1f;
        _expToLevel = 100;
    }

    #region Getters/Setters
    public int BaseValue
    {
        get
        { return _baseValue; }
        set
        { _baseValue = value; }
    }

    public int BuffValue
    {
        get
        { return _buffValue; }
        set
        { _buffValue = value; }
    }

    public int ExpToLevel
    {
        get
        { return _expToLevel; }
        set
        { _expToLevel = value; }
    }

    public float LevelModifier
    {
        get
        { return _LevelModifier; }
        set
        { _LevelModifier = value; }
    }
    #endregion

    #region Methods
    private int calculateExpToLevel()
    {
        return Convert.ToInt32(_expToLevel * _LevelModifier);
    }

    public void LevelUp()
    {
        _expToLevel = calculateExpToLevel();
        _baseValue++;
    }

    public int AdjustedValue()
    {
        return _baseValue + _buffValue;
    }
    #endregion
}
