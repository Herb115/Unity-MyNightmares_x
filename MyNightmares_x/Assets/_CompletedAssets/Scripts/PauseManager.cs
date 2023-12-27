using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.enabled = !canvas.enabled;
            Pause();
        }
        void Pause()
        {
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        }
    }
}
