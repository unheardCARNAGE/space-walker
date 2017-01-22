using UnityEngine;
using System.Collections;

public class SpinForever : MonoBehaviour {

  public float pulsate_rate;
  public float pulsate_max_time;
  public float speed;

  private float pulsate_timer;
  private bool is_zooming;

	// Use this for initialization
	void Start () {
    is_zooming = true;
	}
	
	// Update is called once per frame
	void Update () {
    transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));

    if (pulsate_rate > 0) {
      if (is_zooming) {
        Vector3 temp_pos = transform.position;
        temp_pos.z += pulsate_rate * Time.deltaTime;
        transform.position = temp_pos;
        pulsate_timer += Time.deltaTime;
        if (pulsate_timer > pulsate_max_time) {
          is_zooming = false;
          pulsate_timer -= pulsate_max_time;
        }
      }
      else {
        Vector3 temp_pos = transform.position;
        temp_pos.z -= pulsate_rate * Time.deltaTime;
        transform.position = temp_pos;
        pulsate_timer += Time.deltaTime;
        if (pulsate_timer > pulsate_max_time) {
          is_zooming = true;
          pulsate_timer -= pulsate_max_time;
        }
      }

    }
	}
}
