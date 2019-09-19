using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveEnemy : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject player;
    public LevelManager manager;
    public float searchPosition = 5f;
    int index;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 3;
        index = Random.Range(0, manager.destination.Length - 1);
        agent.SetDestination(manager.destination[index].transform.position);

    }

    // Update is called once per frame
    void Update()
    {

        DestinationChoose();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == manager.player)
        {
            manager.GameOver();
        }
    }

    private bool atDestination()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            return true;
        }
        return false;
    }

    private bool seePlayer()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, player.transform.position - transform.position, out hit, searchPosition))
        {
            if (hit.collider.tag == "Player" && Vector3.Angle(transform.forward, player.transform.position - transform.position) <= 45)
            {
                return true;
            }
        }
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Color color = Color.blue;
        color.a = 0.5f;
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, searchPosition);
    }

    private void DestinationChoose()
    {
        if (atDestination() && !seePlayer())
        {
            index = Random.Range(0, manager.destination.Length);
            agent.SetDestination(manager.destination[index].transform.position);
            agent.speed = 5;

        }
        else if (!atDestination() && seePlayer())
        {
            agent.SetDestination(player.transform.position);
            agent.speed = 3;
        }
    }

}
