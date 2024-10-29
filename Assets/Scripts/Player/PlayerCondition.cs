using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;

    public PlayerController controller;

    Condition health { get { return uiCondition.health; } }
    Condition stamina { get { return uiCondition.stamina; } }

    public float noStaminaHealthDecay;
    public float staminaDecay;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
    }

    void Update()
    {
        stamina.Add(stamina.passiveValue * Time.deltaTime);

        if (controller.IsRunning) 
        {
            stamina.Subtract(staminaDecay * Time.deltaTime);
        }

        if (stamina.curValue <= 0f)
        {
            health.Subtract(noStaminaHealthDecay * Time.deltaTime);
        }

        if (health.curValue <= 0f)
        {
            Die();
        }
    }

    public void Die() 
    {
        Debug.Log("ав╬З╢ы");
    }
}
