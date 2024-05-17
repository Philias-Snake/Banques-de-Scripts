using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int maxHealth = 10;
    private int currentHealth;

    private float invincibilityTimeAfterHit = 3f;
    private float invincibilityFlashDelay = 0.2f;
    private bool isInvincible = false;

    public SpriteRenderer graphics;
    public HealthBar healthBar;

    public GameObject gameOverUI;

    public bool isPaused = false;

    public AudioClip hitSound;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void HealPlayer(int amount)
    {
        if((currentHealth + amount) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }

        healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            if(currentHealth <= 0)
            {
                StartCoroutine(Die(0f));
            }

            isInvincible=true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
    }

    public IEnumerator Die(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameOverUI.SetActive(true);
        isPaused = !isPaused;
        Time.timeScale = 0f;
        isPaused = true;
    }

    public IEnumerator InvincibilityFlash()
    {
        while (isInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTimeAfterHit);
        isInvincible = false;
    }
}