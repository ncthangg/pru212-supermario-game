using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    private void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        if (currentHealth > 0)
        {
            //hurt
            anim.SetTrigger("hurt");
        }
        else
        {
            //dead
            if (!dead)
            {
                anim.SetTrigger("dead");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
            }
        }
    }

    //test take dmg

    //private void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.E))
    //        TakeDamage(1);
    //}
}
