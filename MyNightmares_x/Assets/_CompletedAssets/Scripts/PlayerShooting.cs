using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject go;
    public float speed = 10.0f;
    public Transform ShotPos;
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;
    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;
    // Start is called before the first frame update
    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();

    }
    public void DisableEffects()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;

    }
    void Shoot()
    {
        timer = 0f;
        gunAudio.Play();
        gunLight.enabled = false;
        gunParticles.Stop();
        gunParticles.Play();
        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
        if(Physics.Raycast(shootRay, out shootHit,range,shootableMask)) {
        EnemyHealth enemyHealth=shootHit.collider.GetComponent<EnemyHealth>();
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage(damagePerShot, shootHit.point);

            }
            gunLine.SetPosition(1, shootHit.point);
        }
        else
        {
            Destroy(gameObject);
            gunLine.SetPosition(1,shootRay.origin+shootRay.direction*range);

        }
    }
    void shot()
    {
        GameObject rocked = Instantiate(go, ShotPos.position, Quaternion.identity);
        Rigidbody rb = rocked.GetComponent<Rigidbody>();
        rb.velocity = new Vector2(speed, 0);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot();
        }
        if (Input.GetButton("Fire2") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            shot();
        }
        if (timer >= timeBetweenBullets*effectsDisplayTime)
        {
            DisableEffects();
        }
    }
}
