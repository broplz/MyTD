using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerControl : MonoBehaviour
{
    [SerializeField]
    private float timeAttacks;

    [SerializeField]
    private float attackRadius;

    private Projectile projectile;

    private Enemy targetEnemy = null;

    private float attackCounter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
