using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Nav : MonoBehaviour {

    NavMeshAgent nva;
    public GameObject target;
    Vector3 TP;
    float z;

	void Start () {
        nva = GetComponent<NavMeshAgent>();
        TP = target.transform.position;
        nva.SetDestination(TP);
        z = TP.z;
    }
	
	void Update () {

        if (Mathf.Abs(transform.position.z - z) <= 0.1)
        {
            z = -z;
            TP.z = z;
            nva.SetDestination(TP);
        }
	}
}
