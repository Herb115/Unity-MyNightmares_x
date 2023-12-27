using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public class destroy : MonoBehaviour
{
    public GameObject explosion;
    public float t = 3.0f;
    public int damage = 100;
    public GameObject go;

    // Start is called before the first frame update
    void Start()
    {
        //没击中任何目标，按生命周期销毁
        Destroy(gameObject, t);
    }
    //如果击中了
    private void OnTriggerEnter(Collider collision)
    {


        if (collision.gameObject.tag == "Enemy")

        {
            //  int index = Random.Range(0, adeath.Length);
            // AudioSource.PlayClipAtPoint(adeath[index], transform.position);

            //collision.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
            //获取敌人生命值HP，HP--   首先获取到敌人
            //collision.gameObject.GetComponent<EnemyHealth>().currentHealth--;

            Destroy(collision.gameObject);

        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
