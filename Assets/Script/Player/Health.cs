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

    private bool isInvulnerable = false; // Biến để kiểm tra trạng thái miễn nhiễm sát thương


    // [Header("iFrames")]
    // [SerializeField] private float iFramesDuration;
    // [SerializeField] private int numberOfFlases;
    // //change color when hurt

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        healthBar = FindObjectOfType<Healthbar>();
        uiManager = FindObjectOfType<UIManager>();
    }

    public void TakeDamage(float damage)
    {
        if (isInvulnerable) return;

        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        if (currentHealth > 0)
        {
            //hurt
            anim.SetTrigger("hurt");
            healthBar.SetHealth(currentHealth);
            StartCoroutine(InvulnerableCoroutine());
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

    private IEnumerator InvulnerableCoroutine()
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(1f); // Đợi 2 giây
        isInvulnerable = false;
    }
    //test take dmg
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            TakeDamage(1);
    }

    public void AddHealth(float value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, startingHealth);
        healthBar.SetHealth(currentHealth);
    }

}
