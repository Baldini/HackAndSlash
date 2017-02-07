using System;
using UnityEngine;
using System.Collections;

public class CharacterGenerator : MonoBehaviour
{
    private PlayerCharacter _toon;
    private const int StartingPoints = 350;
    private const int minStartingAttValue = 10;
    private const int StartingValue = 60;
    private int pointsLeft;
    private const int offset = 5;
    private const int lineHeigth = 20;
    private const int StatLabelWidth = 100;
    private const int BaseValueWidth = 30;
    private const int ButtonWidth = 20;
    private const int ButtonHeight = 20;
    private const int basicPosition = 40;

    public GUIStyle myStyle;
    void Start()
    {
        pointsLeft = StartingPoints;
        _toon = new PlayerCharacter();
        _toon.Awake();
        foreach (int item in Enum.GetValues(typeof(AttributeName)))
        {
            _toon.getPrimaryAttribute(item).BaseValue = StartingValue;
            pointsLeft -= StartingValue - minStartingAttValue;
        }
        _toon.StatUpdate();
    }

    void Update()
    {

    }

    void OnGUI()
    {
        DisplayName();
        DisplayAttributes();
        DisplayVitals();
        DisplaySkills();
        DisplayPointsLeft();
    }

    private void DisplayName()
    {
        GUI.Label(new Rect(10, 10, 50, 25), "Name:");
        _toon.Name = GUI.TextField(new Rect(65, 10, 100, 35), _toon.Name);
    }

    private void DisplayAttributes()
    {
        foreach (int item in Enum.GetValues(typeof(AttributeName)))
        {
            GUI.Label(new Rect(offset, 40 + (item * lineHeigth), StatLabelWidth, lineHeigth), ((AttributeName)item).ToString(), myStyle);
            GUI.Label(new Rect(StatLabelWidth + offset, basicPosition + (item * lineHeigth), BaseValueWidth, lineHeigth), _toon.getPrimaryAttribute(item).AdjustedValue().ToString());
            if (GUI.Button(new Rect(StatLabelWidth + BaseValueWidth + offset, basicPosition + (item * ButtonHeight), ButtonWidth, ButtonHeight), "-"))
            {
                if (_toon.getPrimaryAttribute(item).BaseValue > minStartingAttValue)
                {
                    _toon.getPrimaryAttribute(item).BaseValue -= 1;
                    pointsLeft += 1;
                    _toon.StatUpdate();
                }
            }
            if (GUI.Button(new Rect(StatLabelWidth + BaseValueWidth + offset + ButtonWidth, basicPosition + (item * ButtonHeight), ButtonWidth, ButtonHeight), "+"))
            {
                if (pointsLeft > 0)
                {
                    _toon.getPrimaryAttribute(item).BaseValue += 1;
                    pointsLeft -= 1;
                    _toon.StatUpdate();
                }
            }
        }
    }

    private void DisplayVitals()
    {
        foreach (int item in Enum.GetValues(typeof(VitalName)))
        {
            GUI.Label(new Rect(offset, basicPosition + ((item + 7) * lineHeigth), StatLabelWidth, lineHeigth), ((VitalName)item).ToString());
            GUI.Label(new Rect(StatLabelWidth + offset, basicPosition + ((item + 7) * lineHeigth), BaseValueWidth, lineHeigth), _toon.getVital(item).AdjustedBaseValue.ToString());
        }
    }

    private void DisplaySkills()
    {
        foreach (int item in Enum.GetValues(typeof(SkillName)))
        {
            GUI.Label(new Rect(BaseValueWidth + StatLabelWidth + offset + ButtonWidth * 2 + offset, basicPosition + (item * lineHeigth), StatLabelWidth, lineHeigth), ((SkillName)item).ToString());
            GUI.Label(new Rect(BaseValueWidth + offset + StatLabelWidth + StatLabelWidth + offset + ButtonWidth * 2 + offset, basicPosition + (item * lineHeigth), BaseValueWidth, lineHeigth), _toon.getSkill(item).AdjustedBaseValue.ToString());
        }
    }

    private void DisplayPointsLeft()
    {
        GUI.Label(new Rect(250, 10, 100, 25), "Points Left: " + pointsLeft.ToString());
    }
}
