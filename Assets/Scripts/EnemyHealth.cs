using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{

    public int MaxHealth = 100;
    public int currentHealth = 100;
    public float HealthBarLength;
    // Use this for initialization
    void Start()
    {
        HealthBarLength = Screen.width / 2;
    }

    // Update is called once per frame
    void Update()
    {
        AddjustCurrentHealth(0);
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 40, HealthBarLength, 20), currentHealth + "/" + MaxHealth);
    }

    public void AddjustCurrentHealth(int adj)
    {
        currentHealth += adj;
        if (currentHealth < 1)
            currentHealth = 0;
        if (currentHealth > MaxHealth)
            currentHealth = MaxHealth;
        if (MaxHealth < 1)
            MaxHealth = 1;

        HealthBarLength = (Screen.width / 2) * (currentHealth / (float)MaxHealth);
    }
}
