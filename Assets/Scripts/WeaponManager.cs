using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance { get; set; }

    public List<GameObject> weaponSlots;
    
    private void Awake()
{
    if (Instance != null && Instance != this)
    {
        Destroy(gameObject);
    }
    else
    {
        Instance = this;
        DontDestroyOnLoad(gameObject); // Para persistir entre escenas
    }
}


    public void PickupWeapon(GameObject pickedupWeapon)
    {
        Destroy(pickedupWeapon);
    }
}
