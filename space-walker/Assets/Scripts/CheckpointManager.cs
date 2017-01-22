using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour {
    public GameObject player;

	void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Start()
    {

    }
}
