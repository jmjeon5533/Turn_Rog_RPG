using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [HideInInspector]
    public int MaxHP;
    public int HP;
    private int BaseDamage;
    public int AddDamage;
    private int BaseSpeed;
    public int AddSpeed;
    void Start()
    {
        MaxHP = HP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
