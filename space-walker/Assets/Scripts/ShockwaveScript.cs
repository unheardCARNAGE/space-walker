using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Light))]

public class ShockwaveScript : MonoBehaviour {
    [SerializeField]
    float totalCycleTime = 8f;
    [SerializeField]
    float warmupTime = 5f;
    [SerializeField]
    float flashDuration = 0.5f;
    [SerializeField]
    float cooldown = 0.5f;

    [SerializeField]
    Color normalColor = Color.white;
    [SerializeField]
    float normalBrightness = 1f;
    [SerializeField]
    Color warmedUpColor = Color.red;
    [SerializeField]
    float warmedUpBrightness = 2f;
    [SerializeField]
    Color flashColor = Color.red;
    [SerializeField]
    float flashBrightness = 4f;

    [SerializeField]
    UnityEvent onFlashEvent;

    PlayerScript player;
    PebbleScript pebble;
    Light light;
    float currentTime = 0f;
    bool flashpointDoneThisCycle = false;

    void Start()
    {
        player = FindObjectOfType<PlayerScript>();
        pebble = FindObjectOfType<PebbleScript>();
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        ChangeBrightness();
    }

    void ChangeBrightness()
    {
        if (currentTime < warmupTime)
        {
            //warmup mode
            WarmupBrightness();
        }
        else if (currentTime < warmupTime + flashDuration)
        {
            //flash mode
            FlashBrightness();
        }
        else if (currentTime < warmupTime + flashDuration + cooldown)
        {
            //cooldown mode
            CooldownBrightness();
            //this sends an event as soon as the flash ends; IE, when it reaches full brightness.
            if (!flashpointDoneThisCycle)
            {
                FlashResponse();
                flashpointDoneThisCycle = true;
            }
        }
        else if (currentTime < totalCycleTime)
        {
            //waiting mode
        }
        else
        {
            //restart cycle
            currentTime = 0f;
            flashpointDoneThisCycle = false;
        }
    }

    void WarmupBrightness()
    {
        float percentTime = currentTime / warmupTime;
        LerpColorAndBrightness(normalColor, warmedUpColor, normalBrightness, warmedUpBrightness, percentTime);
    }

    void FlashBrightness()
    {
        float percentTime = (currentTime - warmupTime) / flashDuration;
        LerpColorAndBrightness(warmedUpColor, flashColor, warmedUpBrightness, flashBrightness, percentTime);
    }

    void CooldownBrightness()
    {
        float percentTime = (currentTime - (warmupTime + flashDuration)) / cooldown;
        LerpColorAndBrightness(flashColor, normalColor, flashBrightness, normalBrightness, percentTime);
    }

    void LerpColorAndBrightness(Color startC, Color endC, float startB, float endB, float percentTime)
    {
        light.color = Color.Lerp(startC, endC, percentTime);
        light.intensity = Mathf.Lerp(startB, endB, percentTime);
    }

    void FlashResponse()
    {
        if (onFlashEvent != null)
            onFlashEvent.Invoke();
        player.CreateRay();
        pebble.CreateRay();
    }
}
