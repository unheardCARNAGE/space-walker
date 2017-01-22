using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRaySystem : MonoBehaviour {

	[SerializeField] Material transparentMaterial;
	[SerializeField] float viewArc = 40f;
	[SerializeField] float penetrationRange = 4f;

	Dictionary<MeshRenderer, Material> records = new Dictionary<MeshRenderer, Material>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		foreach(MeshRenderer o in GameObject.FindObjectsOfType<MeshRenderer>()){
			Vector3 toObject = o.transform.position - transform.position;
			if (Vector3.Angle(transform.forward, toObject) <= viewArc / 2
			   && Vector3.Distance(transform.position, o.transform.position) <= penetrationRange){
				XRayObject(o);
			} else{
				ResetObject(o);
			}
		}
	}

	void XRayObject(MeshRenderer mr){
		records.Add(mr, mr.material);
		mr.material = transparentMaterial;
	}

	void ResetObject(MeshRenderer mr){
		if(records.ContainsKey(mr)){
			mr.material = records[mr];
			records.Remove(mr);
		}
	}
}
