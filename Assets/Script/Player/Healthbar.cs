using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    // [SerializeField] private Health playerHealth;
    // [SerializeField] private Image totalhealthBar;
    // [SerializeField] private Image currenthealthBar;

    // private void Start()
    // {
    //     totalhealthBar.fillAmount = playerHealth.currentHealth / 10;
    // }

    // public void TakeDamage(float damage)
    // {
    //     totalhealthBar.fillAmount = playerHealth.currentHealth / 10;
    // }
    public Slider slider;
    public Gradient gradient;
    public Image fill;


    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
