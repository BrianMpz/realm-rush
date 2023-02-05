using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float maxHitPoints = 5;
    [SerializeField] float DiffRamp = 1;
    [SerializeField] float currentHitPoints = 0;

    Enemy enemy;

    void OnEnable()
    {
        currentHitPoints = maxHitPoints;        
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other) 
    {
        ProcessHit();
    }

    void ProcessHit() 
    {
        currentHitPoints--;

        if(currentHitPoints <= 0)
        {
            maxHitPoints += DiffRamp;
            gameObject.SetActive(false);
            enemy.RewardGold();
            maxHitPoints += DiffRamp;
        }
    }
}
