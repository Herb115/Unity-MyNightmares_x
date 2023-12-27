using System.Collections;
using System.Collections.Generic;
//using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float startingHealth = 100;          //初始血条
    public float currentHealth;                 //当前血条
    public Slider healthSlider;                 //血条滑块
    public AudioClip deathClip;                 //死亡音效
    public Image damageImage;                   //受伤图像
    public float flashSpeed = 5.0f;                 //
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f); 
    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
    bool isDead;        //主角自己死亡状态
    bool damaged;       //是否被敌人攻击状态
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        //playerShooting = GetComponent<PlayerShooting>();
        playerShooting = GetComponentInChildren<PlayerShooting>();
        currentHealth = startingHealth;
    }
    // Update is called once per frame
    void Update()
    {
        if(ScoreManager.levelup){
            currentHealth=startingHealth;//huixue
            healthSlider.value = currentHealth;
            ScoreManager.levelup=false;
        }
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }
    // 主角遭受到攻击    // 做成公有接口方便其他脚本调用
    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;         //获取滑动血条的值，与当前生命值  产生映射
        playerAudio.Play();                 //播放声音
        if (currentHealth <= 0 && !isDead)
        {
            anim.SetTrigger("Dead");
            Death();
        }
    }
    void Death()
    {
        isDead = true;
        playerShooting.DisableEffects();
       // anim.SetTrigger("Dead");
        playerAudio.clip = deathClip;
        playerAudio.Play();             //
        //禁用掉主角生前的活动  （移动、射击 …… ）
        playerShooting.enabled = false;
        playerMovement.enabled = false;
    }
    //public void RestartLevel()
    // {
    //     Application.LoadLevel(Application.loadedLevel);
    // }

    
    //道具拓展
    public void AddHP_1()//止痛剂瞬间回血10
    {
        if (currentHealth > 0)
        {
            if (currentHealth <= startingHealth - 10)
            {
                currentHealth += 10; 
                healthSlider.value = currentHealth;
            }
            if (currentHealth >= startingHealth)
            {
                currentHealth = startingHealth; 
                healthSlider.value = currentHealth;
            }

        }

    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "pillsHp")
    //    {
    //        AddHP_1(); Destroy(gameObject);
    //    }
    //}
}
