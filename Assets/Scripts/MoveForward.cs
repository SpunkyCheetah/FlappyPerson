using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    // Variables
    public float moveSpeed;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);

        if(transform.position.z >= 20)
        {
            Destroy(gameObject);
        }
    }
}
