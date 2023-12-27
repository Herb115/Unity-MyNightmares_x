using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Props : MonoBehaviour
{
        public GameObject[] props;
        PlayerHealth gc;


        void Start()
        {
            gc = GameObject.Find("Player").GetComponent<PlayerHealth>();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
