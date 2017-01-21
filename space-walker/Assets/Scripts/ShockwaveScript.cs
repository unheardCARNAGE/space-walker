using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]

public class ShockwaveScript : MonoBehaviour {
    [SerializeField]
    float cycle = 8f;
    [SerializeField]
    float warmupTime = 5f;
    [SerializeField]
    float flashDuration = 0.5f;
    [SerializeField]
    float cooldown = 0.5f;
    [SerializeField]
    float warmedUpBrightness = 2f;
    [SerializeField]
    float flashBrightness = 4f;

    Light light;
    float currentTime = 0f;

    public float timer = 30f;
    public float resetTimer = 30f;

    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= cycle)
        {
            currentTime += Time.deltaTime;
            ChangeBrightness();
            if (timer <= 0)
            {
                timer = resetTimer;
            }
        }
    }

    void ChangeBrightness()
    {
        float brightness = 0f;
        if (currentTime >= cycle - (warmupTime + flashDuration) && currentTime < cycle - flashDuration)
        {
            brightness = warmedUpBrightness * (currentTime - (cycle - (warmupTime + flashDuration))) / warmupTime;
        }
        else if (currentTime >= cycle - flashDuration && currentTime < cycle)
        {
            brightness = FlashBrightness();
        }
        else if (currentTime >= cycle)
        {
            currentTime = 0f;
        }
        light.intensity = brightness;
    }

    float FlashBrightness()
    {
        return warmedUpBrightness + ((flashBrightness - warmedUpBrightness) * (currentTime - (cycle - flashDuration)) / flashDuration);
    }
}
