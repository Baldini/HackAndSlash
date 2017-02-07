using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Targetting : MonoBehaviour
{

    public List<Transform> targets;
    public Transform selectedTarget;

    private Transform myTransform;
    // Use this for initialization
    void Start()
    {
        targets = new List<Transform>();
        AddAllEnemies();
        selectedTarget = null;
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TargetEnemy();
        }
    }

    public void AddAllEnemies()
    {
        var Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var Enemy in Enemies)
        {
            AddTarget(Enemy.transform);
        }
    }

    private void sortTargetByDistance()
    {
        targets.Sort(delegate(Transform t1, Transform t2)
        {
            return (Vector3.Distance(t1.position, myTransform.position).CompareTo(Vector3.Distance(t2.position, myTransform.position)));
        });
    }

    public void TargetEnemy()
    {
        if (selectedTarget == null)
        {
            sortTargetByDistance();
            selectedTarget = targets[0];
        }
        else
        {
            int index = targets.IndexOf(selectedTarget);

            if (index < targets.Count - 1)
                index++;

            else
                index = 0;

            DesalectTarget();
            selectedTarget = targets[index];
        }
        SelectTarget();

    }
    private void DesalectTarget()
    {
        selectedTarget.renderer.material.color = Color.blue;
        selectedTarget = null;
    }

    private void SelectTarget()
    {
        PlayerAttack pa = (PlayerAttack)GetComponent("PlayerAttack");
        pa.target = selectedTarget.gameObject;
        selectedTarget.renderer.material.color = Color.red;
    }

    public void AddTarget(Transform Enemy)
    {
        targets.Add(Enemy);
    }
}
