using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon", order = 0)]
public class WeaponType : ScriptableObject
{

    public AudioClip GunShotAudio;
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

    public bool isAuto;
}
