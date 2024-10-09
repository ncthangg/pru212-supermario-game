using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    protected Healthbar healthBar;
    protected UIManager uiManager;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        healthBar = FindObjectOfType<Healthbar>();
        uiManager = FindObjectOfType<UIManager>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        if (currentHealth > 0)
        {
            //hurt
            anim.SetTrigger("hurt");
            healthBar.SetHealth(currentHealth);
        }
        else
        {
            //dead
            if (!dead)
            {
                healthBar.SetHealth(currentHealth);
                anim.SetTrigger("dead");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
                uiManager.GameOver();
            }
        }
    }

    //test take dmg

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            TakeDamage(1);
    }
}
