using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{

    PlayerHealth s_PlayerHealth;
    PlayerWeaponManager s_PlayerWeaponManager;
    PlayerSkills s_PlayerSkills;

    [Header("HealthUI")]
    public GameObject[] health = new GameObject[3];

    [Header("WeaponUI")]
    public TextMeshProUGUI t_CurrAmmoLeft;
    public TextMeshProUGUI t_WeaponName;
    public TextMeshProUGUI t_CurrGrenadeRemaining;
    [Header("EXPUI")]
    public Image i_EXP;
    public TextMeshProUGUI t_EXP;
    public TextMeshProUGUI t_CurrentLevel;

    public TextMeshProUGUI t_PickUpWeapon;

    private void Awake()
    {
        s_PlayerHealth = FindObjectOfType<PlayerHealth>();
        s_PlayerWeaponManager = FindObjectOfType<PlayerWeaponManager>();
        s_PlayerSkills = FindObjectOfType<PlayerSkills>();
    }
    private void Start()
    {
    }
    public void UpdateHealthUI()
    {
        switch (s_PlayerHealth.p_Health)
        {
            case 0:
                {
                    health[0].SetActive(false);
                    health[1].SetActive(false);
                    health[2].SetActive(false);
                    break;
                }
            case 1:
                {
                    health[0].SetActive(true);
                    health[1].SetActive(false);
                    health[2].SetActive(false);
                    break;
                }
            case 2:
                {
                    health[0].SetActive(true);
                    health[1].SetActive(true);
                    health[2].SetActive(false);
                    break;
                }
            case 3:
                {
                    health[0].SetActive(true);
                    health[1].SetActive(true);
                    health[2].SetActive(true);
                    break;
                }
        }


    }
    public void PickUpWeaponUI(string name)
    {
        if (name != null)
        t_PickUpWeapon.text = "Press 'E' to pick up " + name + '?';
        else
        t_PickUpWeapon.text = null;

    }
    public void UpdateWeaponUI()
    {
        t_WeaponName.text = s_PlayerWeaponManager.p_WeaponName;
        t_CurrAmmoLeft.text = "Ammo:" + s_PlayerWeaponManager.p_TotalAmmo; 
    }
    public void UpdateGrenadeUI()
    {
/*        t_CurrGrenadeRemaining.text = "x" + s_PlayerWeaponManager.p_GrenadeRemaining;
*/    }
    public void UpdateEXP()
    {
        t_EXP.text = s_PlayerSkills.totalExpPoint.ToString() + '/' + s_PlayerSkills.nextPointToLevelUp.ToString();
        i_EXP.fillAmount = (float)s_PlayerSkills.totalExpPoint / (float)s_PlayerSkills.nextPointToLevelUp;
        print((float)s_PlayerSkills.totalExpPoint / (float)s_PlayerSkills.nextPointToLevelUp);
        t_CurrentLevel.text = "Level: " + s_PlayerSkills.currentLevel.ToString();
    }
}
