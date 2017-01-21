using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {
    public float timer = 30f;
    public float resetTimer = 30f;     

    void Start()
    {
        Invoke("Warning", timer - 5);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            //turn player raycast on
            //start wave animation
            //time to keep raycast and wave anim up
            timer = resetTimer;
            Invoke("Warning", timer - 5);
            //turn player raycast off
            //end wave animation
        }
    }

    void Warning()
    {
        Debug.Log("Warning");
    }
}
