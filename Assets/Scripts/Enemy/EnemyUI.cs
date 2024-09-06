using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyUI : MonoBehaviour
{
    public Image e_HealthUI;
    EnemyHealth e_Health;

    private void Start()
    {
        e_Health = transform.parent.GetComponent<EnemyHealth>();
        e_Health.e_EnemyUI = this;
    }
    public void UpdateEnemyUI()
    {
        e_HealthUI.fillAmount = (float)((float)e_Health.health / (float)e_Health.maxHealth);
    }
}
