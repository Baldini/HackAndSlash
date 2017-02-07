using UnityEngine;
using System.Collections;

public class EnemyIA : MonoBehaviour
{
    public Transform target;
    public int moveSpeed;
    public int rotationSpeed;
    public int maxDistance = 2;

    private Transform _myTransform;

    void Awake()
    {
        _myTransform = transform;
    }

    // Use this for initialization
    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(target.position, _myTransform.position, Color.red);

        //Olha para o alvo
        _myTransform.rotation = Quaternion.Slerp(_myTransform.rotation, Quaternion.LookRotation(target.position - _myTransform.position), rotationSpeed * Time.deltaTime);

        //Não deixa ele chegar muito perto
        if (Vector3.Distance(target.position, _myTransform.position) > maxDistance)
        {
            //Se move em direção ao alvo
            _myTransform.position += _myTransform.forward * moveSpeed * Time.deltaTime;
        }

    }
}
