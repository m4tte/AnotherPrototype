using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    PlayerUI s_PlayerUI;

    public int p_Health;
    public int p_MaxHealth;


    private void Start()
    {
        s_PlayerUI = FindObjectOfType<PlayerUI>();
        p_Health = p_MaxHealth;
        s_PlayerUI.UpdateHealthUI();
    }
    public void TakeDamage(int dmg)
    {
        FindObjectOfType<CameraShake>().Shake(.2f, .1f, .1f);
        {
            if (p_Health >0)
                p_Health -= dmg;
        }
        s_PlayerUI.UpdateHealthUI();
    }
}
