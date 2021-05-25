using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    float health = 100f;
    public float hurtBloodPoint = 20f;
    SpriteRenderer healthBar;
    Vector3 healthBarScale;
    private Animator player;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.Find("HealthBarUI").GetComponent<SpriteRenderer>();
        healthBarScale = healthBar.transform.localScale;
        player = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            if(health> 0)//血条更新
            {
                takeDamage();
            }
            else//死亡动画
            {
                player.SetTrigger("Die");
            }
        }
    }
    void takeDamage()
    {
        health -= hurtBloodPoint;
        UpdateHealthBar();
    }
    void UpdateHealthBar()
    {
        healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - health * 0.01f);
        healthBar.transform.localScale = new Vector3(health * 0.01f, 1, 1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
