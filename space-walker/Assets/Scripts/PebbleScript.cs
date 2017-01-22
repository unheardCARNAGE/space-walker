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
            GetComponent<Rigidbody>().AddExplosionForce(500f, new Vector3(-3.5f, 0f, 1.3f), 5f, 2f);
        }
    }
}
