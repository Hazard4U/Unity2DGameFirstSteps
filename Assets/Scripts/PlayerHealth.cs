using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int MAX_HEALTH = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public SpriteRenderer spriteRenderer;

    private bool isInvincible = false;

    void Start()
    {
        currentHealth = MAX_HEALTH;
        healthBar.SetMaxHealth(MAX_HEALTH);
    }

    public void TakeDamage(int damage){
        if(!isInvincible){
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            StartCoroutine("Invincibility");
        }
    }

    private IEnumerator Invincibility(){
        isInvincible = true;
        StartCoroutine("StopInvincibility");
        while(isInvincible){
            spriteRenderer.color = new Color(1f, 1f,1f,0f);
            yield return new WaitForSeconds(0.2f);
            spriteRenderer.color = new Color(1f, 1f,1f,1f);
            yield return new WaitForSeconds(0.2f);
        }
    }

    private IEnumerator StopInvincibility(){
        yield return new WaitForSeconds(1.5f);
        isInvincible = false;
    }
}
