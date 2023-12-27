using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{

    PlayerHealth gc;
    PlayerMovement gb;
    AccelerationEffect ge;
    public bool feather;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (gameObject.tag == "pillsHp")
            {
                gc.AddHP_1();
                ge.AM();//1s闪烁
            }
            else if (gameObject.tag == "featherBuff")
            {
                if (feather==false) 
                { 
                    gb.Accelerate();
                    ge.AE();//加速特效
                    feather = true;
                }
                else 
                {
                    gb.Accelerate();
                }
            }
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.Find("Player").GetComponent<PlayerHealth>();
        gb = GameObject.Find("Player").GetComponent<PlayerMovement>();
        ge = GameObject.FindWithTag("player_x").GetComponent<AccelerationEffect>();

        feather = false;
    }

    // Update is called once per frame

    public float speed = 25;
    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0, Space.Self);
    }
}
