using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{   public FixedJoystick kumanda;
public bool hareket;
float hiz=5.0f;
Touch parmak;
float x_acisi=0.0f;
//public float minX, maxX , minY, maxY,minZ, maxZ;
Rigidbody rigi;
int i;
Transform kamera;
void Start(){
    //kamera=Camera.main.transform;
    rigi=GameObject.Find("silah").GetComponent<Rigidbody>();
}
    // Start is called before the first frame update
  
    // Update is called once per frame
    //Bizim x=z
    void Update()
    {
  float x=kumanda.Horizontal*Time.deltaTime*hiz;
  transform.Translate(0,0,x);   
  if(x==0.0f){
      hareket=false;}
      else
      {
          hareket=true;
      }
     /* rigi.position = new Vector3(
                Mathf.Clamp(rigi.position.x, minX, maxX),
               Mathf.Clamp(rigi.position.y, minY, maxY), 0);*/
   /* rigi.position = new Vector3(
                Mathf.Clamp(rigi.position.x, minX, maxX),
               Mathf.Clamp(rigi.position.y, minY, maxY), Mathf.Clamp(rigi.position.z, minZ, maxZ));*/
    
    bak();


    }
 private void bak(){
    for(i=0; i<Input.touchCount;i++){
        parmak=Input.GetTouch(i);
        if(parmak.phase==TouchPhase.Moved){

            if(hareket==true && parmak.fingerId==1){
                dondur();
            }
            else if(hareket==false && parmak.fingerId==0 ){
                dondur();
            }
        }
    }
}
private void dondur(){
float sag_sol=parmak.deltaPosition.x*hiz*Time.deltaTime;
transform.Rotate(0,sag_sol,0);
}

}
