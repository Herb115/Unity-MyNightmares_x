using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    
  
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;
    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;

    public int index;
    Props gc;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        currentHealth = startingHealth;
    }
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<Props>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }
    public void TakeDamage(int amount,Vector3 hitPoint)
    {
        if (isDead)
            return;
        enemyAudio.Play();
        currentHealth -= amount*(ScoreManager.level);//伤害提升
        hitParticles.transform.position = hitPoint;
        hitParticles.Play();
        if (currentHealth <= 0)
        {
            Death();
        }
    }
    void Death()
    {
        isDead = true;
        capsuleCollider.isTrigger = true;
        anim.SetTrigger("Dead");
        enemyAudio.clip = deathClip;
        enemyAudio.Play();

        index = UnityEngine.Random.Range(0, gc.props.Length + 1);
        if (index < gc.props.Length)
        {
            Instantiate(gc.props[index], transform.position, transform.rotation);
        }
    }
    public void StartSinking()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        ScoreManager.score += scoreValue;
        Destroy(gameObject, 2f);
    }
}
