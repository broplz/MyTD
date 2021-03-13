using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int target = 0;
    private GameObject[] wayPoints;
	[SerializeField] private float navigation;
    [SerializeField] private int health;
    [SerializeField] private float speed = 0.1f;

    private Transform enemy;
    private float navigationTime = 0;

    private void Awake()
    {
        wayPoints = GameObject.FindGameObjectsWithTag("MovingPoint");
        Debug.Log($"Waypoint length {wayPoints.Length}");
    }

    // Start is called before the first frame update
    private void Start()
    {
        enemy = GetComponent<Transform>();
        Manager.Instance.RegisterEnemy(this);
    }

    // Update is called once per frame
    private void Update()
    {
        if (wayPoints != null)
        {
            navigationTime += Time.deltaTime * speed;
            if (navigationTime > navigation)
            {
                enemy.position = Vector2.MoveTowards(enemy.position, 
                    wayPoints[target].transform.position, navigationTime);
                navigationTime = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MovingPoint"))
        {
            target += 1;
        }
        if (target == wayPoints.Length)
        {
            Manager.Instance.UnregisterEnemy(this);
            Debug.Log($"target {target}");
        }
        else if (collision.CompareTag("Projectile"))
        {
            Projectile newP = collision.gameObject.GetComponent<Projectile>();
            EnemyHit(newP.AttackDamage);
            Destroy(collision.gameObject);
        }
    }

    public void EnemyHit(int hitpoints)
    {
        if (health - hitpoints > 0)
        {
            //enemy hurts
            health -= hitpoints;
        }
        else
        {
            //enemy dies
            
        }
    }
}
