using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    [SerializeField] private int HP = 100;
    private Animator animator;

    private NavMeshAgent navAgent;

    public bool isDead; // Ahora es accesible desde otros scripts.

    private void Start()
    {
        animator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
    }

    public void Die()
    {
        if (!isDead) // Evitar que se muera varias veces
        {
            isDead = true;
            animator.SetTrigger("DIE"); // Asegúrate de que "DIE" esté en el Animator
            // Puedes agregar más comportamientos al morir, como desactivar el navAgent o destruir el zombie
            navAgent.isStopped = true; // Detiene el movimiento del zombie
            Destroy(gameObject, 3f); // Destruir el zombie después de un tiempo
        }
    }

    public void TakeDamage(int damageAmount)
    {
        if (isDead) return; // Si ya está muerto, no tomar más daño

        HP -= damageAmount;

        if (HP <= 0)
        {
            int randomValue = Random.Range(0, 2);

            if (randomValue == 0)
            {
                animator.SetTrigger("DIE1");
            }
            else
            {
                animator.SetTrigger("DIE2");
            }

            Die(); // Llamamos a Die cuando los HP llegan a 0
        }
        else
        {
            animator.SetTrigger("DAMAGE");
        }
    }
}
