using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{

    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Invoke("Des", 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Des()
    {
        Destroy(ball);

    }
}
