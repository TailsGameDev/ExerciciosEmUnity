using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public static float H, V;
    Vector3 vel;
    public float vParameter;
    bool PositionFreezed;

    Vector3 incremento;

	void Start () {
        vParameter = 5;
        PositionFreezed = false;
	}
	
	void Update () {
        H = Input.GetAxis("Horizontal");
        V = Input.GetAxis("Vertical");
        vel = new Vector3(H, 0, V);
    }

    private void FixedUpdate()
    {
        incremento = vel * vParameter * Time.deltaTime;
        transform.Translate(incremento);
    }

    private void OnCollisionEnter(Collision collision)
    {
        PositionFreezed = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        PositionFreezed = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        PositionFreezed = false;
    }

    private void LateUpdate()
    {
        if (PositionFreezed)
        {
            transform.position = (transform.position - incremento*1.1f);
        }
    }
}
