using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ai : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform Player;
    public GameObject players;
    public Transform car;
    Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (players.activeInHierarchy)
        {
            agent.destination = Player.position;

          
            if (agent.velocity.magnitude < 0.1f)
            {
                transform.LookAt(Player.position);
            }
        }
        else
        {
            agent.destination = car.position - new Vector3(2f, 0f, 2f);

           
            if (agent.velocity.magnitude < 0.1f)
            {
                transform.LookAt(car.position);
            }
        }

        animator.SetFloat("Speed", agent.velocity.magnitude);
    }
}
