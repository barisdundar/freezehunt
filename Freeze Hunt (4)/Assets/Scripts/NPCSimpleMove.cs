using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSimpleMove : MonoBehaviour
{
    public float speed = 5f;
    public Transform target;
    private Rigidbody rb;
public int degme_sayaci=0;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * speed * Time.deltaTime;
    }
    
}
