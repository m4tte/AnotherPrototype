using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    PlayerUI s_PlayerUI;


    [Header("FireRate")]
    public float p_WeaponFireRate;

    [Header("AmmoAndMagazine")]
    public int p_CurrAmmo;
    public int p_MaxAmmo;
    public int p_RoundLeft;

    [Header("GrenadeStats")]
    public GameObject p_Grenade;
    public float p_ThrowForce;
    public int p_GrenadeRemaining;



    public GameObject p_Projectile;
    public Transform p_Spawnpos;


    public bool p_Reloading;
    public float p_ReloadTimeLeft;
    float nexttime_ToFire;


    private void Start()
    {
        s_PlayerUI = FindObjectOfType<PlayerUI>();
        s_PlayerUI.UpdateAmmoUI();
    }

    private void Update()
    {


        if (Input.GetButtonDown("Fire") && Time.time >= nexttime_ToFire && p_CurrAmmo > 0)
        {
            nexttime_ToFire = Time.time + 1f /p_WeaponFireRate;
            Shoot();
            p_CurrAmmo--;
            s_PlayerUI.UpdateAmmoUI();
/*            s_Weapon[weaponEquipped].p_CurrMagCount--;
            s_PlayerUI.UpdateAmmoUI(s_Weapon[weaponEquipped]);*/
        }
        if (Input.GetKeyDown(KeyCode.R) && p_CurrAmmo < p_MaxAmmo && p_RoundLeft > 0)
        {
            p_RoundLeft--;
            p_CurrAmmo++;
            s_PlayerUI.ReloadAmmoUI();
        }
        if (Input.GetKeyDown(KeyCode.G) && p_GrenadeRemaining > 0)
            ThrowGrenade();
    }

    public void Shoot()
    {
        GameObject p = Instantiate(p_Projectile, p_Spawnpos.position, p_Spawnpos.rotation);

    }
    public void AddAmmo(int ammo)
    {
        p_RoundLeft += ammo;
        s_PlayerUI.ReloadAmmoUI();
    }
    void ThrowGrenade()
    {
        // Instantiate the grenade at the player's position
        GameObject grenade = Instantiate(p_Grenade, p_Spawnpos.position, p_Spawnpos.rotation);

        // Add force to the grenade
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(-(transform.forward * p_ThrowForce), ForceMode.VelocityChange);

        p_GrenadeRemaining--;

        s_PlayerUI.UpdateGrenadeUI();
    }
}
