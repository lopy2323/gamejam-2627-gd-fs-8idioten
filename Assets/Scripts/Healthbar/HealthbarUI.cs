using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthbarUI : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Health playerHealth;

    [SerializeField] private Image fillImage;
    [SerializeField] private Gradient healthGradient;

    [SerializeField] private TMP_Text healthText;
    private void Start()
    {
        healthSlider.maxValue = playerHealth.MaxHealth;
        UpdateHealthBar();
    }

    private void OnEnable()
    {
        playerHealth.HealthChanged += UpdateHealthBar;
    }

    private void OnDisable()
    {
        playerHealth.HealthChanged -= UpdateHealthBar;
    }

    private void UpdateHealthBar()
    {
        healthSlider.value = playerHealth.CurrentHealth;
        float healthPercentage =
        (float)playerHealth.CurrentHealth / playerHealth.MaxHealth;

        fillImage.color = healthGradient.Evaluate(healthPercentage);
        healthText.text = Mathf.RoundToInt(healthPercentage * 100) + "%";
    }
}
