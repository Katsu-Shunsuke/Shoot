using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowballScript : MonoBehaviour
{
    public GameObject ThrowingObject;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            ThrowingBall();
        }
    }


    private void ThrowingBall()
    {
        GameObject ball = Instantiate(ThrowingObject, this.transform.position, Quaternion.identity);

        Rigidbody rid = ball.GetComponent<Rigidbody>();

        rid.AddForce(this.transform.forward * rid.mass * 10.0f, ForceMode.Impulse);
    }
}
