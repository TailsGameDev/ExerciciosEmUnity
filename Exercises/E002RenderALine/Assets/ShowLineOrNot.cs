using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLineOrNot : MonoBehaviour {

    float time;
    LineRenderer lr;
    bool state;
    public float tempoDePisca;
    Ray r;
    RaycastHit rch;

	void Start () {
        time = 0;
        lr = GetComponent<LineRenderer>();
        state = true;
        r = new Ray(transform.position, Vector3.right);
	}
	

	void Update () {
        time += Time.deltaTime;
        if (time >= tempoDePisca)
        {
            time = 0;
            state = !state;
            lr.enabled = state;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //print(r.GetPoint(0));
            if (Physics.Raycast(r, out rch))
            {
                //print(rch.collider.gameObject.name);
                Destroy(rch.collider.gameObject);
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

    }
}
