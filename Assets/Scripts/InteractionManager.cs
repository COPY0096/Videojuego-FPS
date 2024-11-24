using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager Instance { get; set; }

    public Weapon hoveredWeapon = null;
    private Weapon lastHoveredWeapon = null;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject objectHitByRaycast = hit.transform.gameObject;

            // Verifica si el objeto tiene un componente Weapon y si no es el arma activa
            if (objectHitByRaycast.GetComponent<Weapon>() && objectHitByRaycast.GetComponent<Weapon>().isActiveWeapon == false)
            {
                hoveredWeapon = objectHitByRaycast.GetComponent<Weapon>();
                
                // Gestiona el efecto de Outline cuando el objeto se selecciona
                if (hoveredWeapon != lastHoveredWeapon)
                {
                    if (lastHoveredWeapon != null)
                    {
                        lastHoveredWeapon.GetComponent<Outline>().enabled = false;
                    }

                    hoveredWeapon.GetComponent<Outline>().enabled = true;
                    lastHoveredWeapon = hoveredWeapon;
                }

                // Verifica que la instancia de WeaponManager no sea null antes de intentar recoger el arma
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (WeaponManager.Instance != null)
                    {
                        WeaponManager.Instance.PickupWeapon(objectHitByRaycast.gameObject);
                    }
                    else
                    {
                        Debug.LogError("WeaponManager instance is null!");
                    }
                }
            }
            else
            {
                // Si el arma no está en el cursor, desactiva el Outline
                if (hoveredWeapon)
                {
                    hoveredWeapon.GetComponent<Outline>().enabled = false;
                    lastHoveredWeapon = null;
                }
            }
        }
        else
        {
            // Si no hay colisión con el raycast, desactiva el Outline
            if (hoveredWeapon)
            {
                hoveredWeapon.GetComponent<Outline>().enabled = false;
                hoveredWeapon = null;
                lastHoveredWeapon = null;
            }
        }
    }
}
