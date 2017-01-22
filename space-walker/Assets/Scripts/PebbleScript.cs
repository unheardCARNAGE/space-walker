using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PebbleScript : MonoBehaviour {
    public Transform wave;
    public float maxRayDistance = 100.0f;

    public void CreateRay()
    {
        Ray ray = new Ray(transform.position, -wave.transform.forward);

        RaycastHit hit;

        Debug.DrawRay(transform.position, -wave.transform.forward * maxRayDistance, Color.red);

        if (!Physics.Raycast(ray, out hit, maxRayDistance, LayerMask.GetMask("Obstacle")))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0f, Random.Range(.25f, .5f), Random.Range(-1.5f, -1f)) * 500f);
        }
    }
}
