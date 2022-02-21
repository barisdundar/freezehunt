using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ates_etme : MonoBehaviour
{
    RaycastHit nesne;
    bool hasar_vur;
    float playerMovementSpeed = -10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            hasar_vur = true;
        }
        transform.Translate(
            new Vector3(
                Input.GetAxis("Horizontal") * playerMovementSpeed * Time.deltaTime,
                Input.GetAxis("Vertical") * playerMovementSpeed * Time.deltaTime,
                0
            )
        );
    }
    void FixedUpdate()
    {
        if (hasar_vur)
        {
            if(Physics.Raycast(Camera.main.gameObject.transform.position,Camera.main.gameObject.transform.forward,out nesne, 100f))
            {
                if (nesne.transform.tag == "NPC")
                {
                    Destroy(nesne.transform.gameObject);
                }
            }
            hasar_vur = false;
        }
    }
}
