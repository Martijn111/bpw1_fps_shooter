using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
public class Enemy : MonoBehaviour {

    NavMeshAgent pathfinder;
    Transform target;

	void Start () {
        pathfinder = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag ("Player").transform;

        StartCoroutine(UpdatePath());
	}

	
	
	void Update () {

        
	}

    IEnumerator UpdatePath()
    {
        float refreshRate = 1f;
        while (target != null)
        {
            Vector3 targetPostition = new Vector3(target.position.x, 0, target.position.z);
            pathfinder.SetDestination(target.position);
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
