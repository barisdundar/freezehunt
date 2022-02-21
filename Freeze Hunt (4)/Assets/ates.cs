using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ates : MonoBehaviour
{
    public Camera Kamera;
public GameObject Nesne;
public float FareHassasiyeti = 5f;
public float KameraninXSiniri = 30f;
public float KameraninYSiniri = 30f;
public float FareninXEkseni;
public float FareninYEkseni;
RaycastHit hit;
Ray isinGonder;
    // Start is called before the first frame update
    void Start()
    {
        Kamera = Camera.main;
Nesne = GameObject.FindWithTag ("kamera");
Kamera.transform.parent = GameObject.FindWithTag ("kamera").transform;
Kamera.transform.position = GameObject.FindWithTag ("kamera").transform.position;
Kamera.transform.rotation = GameObject.FindWithTag ("kamera").transform.rotation;
Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        FareninXEkseni -= Input.GetAxis("Mouse Y") * FareHassasiyeti * Time.deltaTime;
FareninYEkseni += Input.GetAxis("Mouse X") * FareHassasiyeti * Time.deltaTime;
FareninXEkseni = Mathf.Clamp(FareninXEkseni, -KameraninXSiniri, KameraninYSiniri);
FareninYEkseni = Mathf.Clamp(FareninYEkseni, -KameraninXSiniri, KameraninYSiniri);
Kamera.transform.localRotation = Quaternion.Euler(FareninXEkseni, FareninYEkseni, 0);
Nesne.transform.rotation = Quaternion.Euler(FareninXEkseni, FareninYEkseni, 0);
    }
}
