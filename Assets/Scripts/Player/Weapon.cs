using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponType p_WeaponType;

    public string p_WeaponName;

    [Header("FireRate")]
    public float p_WeaponFireRate;

    [Header("Ammo")]
    public int p_TotalAmmo;

    [Header("ProjectileStats")]
    public float p_BulletSpeed;
    public float p_BulletMaxDamage;
    public float p_BulletMinDamage;
    public float p_TimeBeforeSelfDestruct;
    public AudioClip p_WeaponSoundClip;

    public bool isAuto;

    void Start()
    {
        if (p_WeaponType != null)
        {
            p_WeaponName = p_WeaponType.p_WeaponName;
            p_WeaponFireRate = p_WeaponType.p_WeaponFireRate;
            p_TotalAmmo = p_WeaponType.p_TotalAmmo;
            p_BulletSpeed = p_WeaponType.p_BulletSpeed;
            p_BulletMaxDamage = p_WeaponType.p_BulletMaxDamage;
            p_BulletMinDamage = p_WeaponType.p_BulletMinDamage;
            p_TimeBeforeSelfDestruct = p_WeaponType.p_TimeBeforeSelfDestruct;
            p_WeaponSoundClip = p_WeaponType.GunShotAudio;
            isAuto = p_WeaponType.isAuto;
        }
    }
    public void SetWeapon()
    {
        p_WeaponName = p_WeaponType.p_WeaponName;
        p_WeaponFireRate = p_WeaponType.p_WeaponFireRate;
        p_TotalAmmo = p_WeaponType.p_TotalAmmo;
        p_BulletSpeed = p_WeaponType.p_BulletSpeed;
        p_BulletMaxDamage = p_WeaponType.p_BulletMaxDamage;
        p_BulletMinDamage = p_WeaponType.p_BulletMinDamage;
        p_TimeBeforeSelfDestruct = p_WeaponType.p_TimeBeforeSelfDestruct;
        p_WeaponSoundClip = p_WeaponType.GunShotAudio;
        isAuto = p_WeaponType.isAuto;
    }
    public void SetWeapon(WeaponType wt)
    {
        p_WeaponName = wt.p_WeaponName;
        p_WeaponFireRate = wt.p_WeaponFireRate;
        p_TotalAmmo = wt.p_TotalAmmo;
        p_BulletSpeed = wt.p_BulletSpeed;
        p_BulletMaxDamage = wt.p_BulletMaxDamage;
        p_BulletMinDamage = wt.p_BulletMinDamage;
        p_TimeBeforeSelfDestruct = wt.p_TimeBeforeSelfDestruct;
        p_WeaponSoundClip = wt.GunShotAudio;
        isAuto = wt.isAuto;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerHealth>() != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                FindObjectOfType<PlayerMovement>().PlayerWeapon.SetActive(true);
                FindObjectOfType<PlayerWeaponManager>().ChangeWeapon(this);
                Destroy(this.gameObject);
            }

        }
    }

}
