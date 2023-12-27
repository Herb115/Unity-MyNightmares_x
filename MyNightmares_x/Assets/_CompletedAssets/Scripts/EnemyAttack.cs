using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttack = 0.5f;      //每次攻击间的间隔时间
    public int attackDemage = 10;              //发动每次攻击的伤害值， 公有接口 方便调整伤害值
    //获取组件和其他物体的引用
    Animator anim;                      //动画控制器
    GameObject player;                  //获取游戏物体    便于后面对主角游戏物体Player的引用
    PlayerHealth playerHealth;          //方便后续对PlayerHealth 脚本的引用
    EnemyHealth enemyHealth;            //对EnemyHealth 脚本的引用
    bool playerInRange;           //看主角是否处于当前的攻击范围之内
    float timer;                  //计时器变量，主要用于每次间隔时间的计算
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //对主角游戏物体的引用
        playerHealth = player.GetComponent<PlayerHealth>();
        //引用主角的生命值脚本组件  PlayerHealth
        enemyHealth = GetComponent<EnemyHealth>();
        //引用敌人自身的生命值脚本组件  EnemyHealth
        anim = GetComponent<Animator>();
        //引用敌人自身的动画控制器组件    ，以便进行动画逻辑，动画状态机
    }
    //用于计算碰撞器（主要是球星碰撞器，面板中设置的是  可触发 形式）
    //用OnTriggerEnter函数，来检测是否与主角发生接触 ，如果发生接触，会传递一个Collider参数
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }
    //如果主角已经和敌人自身脱离，则不在攻击范围之内，playerInRange = false;
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;            // 每帧调用时间
        // 当计时器的时间>间隔时间  && 在攻击范围内（true） &&  敌人当前生命值不为0 存活
        if (timer >= timeBetweenAttack && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack();       //  敌人攻击主角
        }
        // 如果敌人死
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("PlayerDead");          // 敌人自身的动画控制器的触发器设置为 "PlayerDead"
        }
    }
    // Attack()函数 用于敌人攻击主角
    void Attack()
    {
        timer = 0f;
        // 如果主角生命值>0  此时敌人可以攻击
        if (playerHealth.currentHealth > 0)
        {
            // 调用 主角脚本 PlayerHealth 里的被攻击函数     //public void TakeDamage(int amount)
            playerHealth.TakeDamage(attackDemage);
        }
    }
}