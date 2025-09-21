/*
Originial Coder: Zackery E.
Recent Coder: Owynn A.
Recent Changes: Formatting and Commenting
Last date worked on: 9/8/2025
*/

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{
    public IntData health;
    public Slider slider;
    public UnityEvent onDamage, onHeal, onDepleted;
    public int maxHealth;
    public int currentBarHealth;
    public void Awake()
    {
        Debug.Log("Healthbar Awake");
        currentBarHealth = health.value;
        UpdateSlider();
    }//End Awake

    public void UpdateHealthBar()
    {
        if (currentBarHealth < 0)
        {
            currentBarHealth = 0;
        }

        RunHealthEvents();
        currentBarHealth = health.value;
        UpdateSlider();
    }//End UpdateHealth

    private void RunHealthEvents()
    {
        if (health.value <= 0) //health is depleted
        {
            onDepleted.Invoke();
        }
        else if (currentBarHealth < health.value) //health increased
        {
            onHeal.Invoke();
        }
        else if (currentBarHealth > health.value) //health is decreased
        {
            onDamage.Invoke();
        } 
    }//End RunHelathEvents

    private void UpdateSlider()
    {
        slider.maxValue = maxHealth;
        slider.value = (currentBarHealth <= maxHealth) ? currentBarHealth : maxHealth;
    }//End UpdateSlider
}