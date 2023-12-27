using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerAnimation : MonoBehaviour
{
    public Animator animator;
    public string[] plays;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void play(int i)
    {
        animator.Play(plays[i]);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            play(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            play(1);
        }
    }
}
