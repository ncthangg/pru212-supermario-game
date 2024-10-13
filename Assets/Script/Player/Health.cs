using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    protected Healthbar healthBar;
    protected UIManager uiManager;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlases;
    //change color when hurt
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        healthBar = FindObjectOfType<Healthbar>();
        uiManager = FindObjectOfType<UIManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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

    private IEnumerator Invunerability()
    {//invunerability duration
        Physics2D.IgnoreLayerCollision(3, 10, true);
        for (int i = 0; i < numberOfFlases; i++)
        {
            spriteRenderer.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlases*2));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlases * 2));
        }
        Physics2D.IgnoreLayerCollision(3, 10, false);
    }

    public void AddHealth(float value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, startingHealth);
        healthBar.SetHealth(currentHealth);
    }

}
