using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    RaycastHit nesne;
    public GameObject deneme;
    public bool HasarVur;
public Text skor;
public  Text hedef_skor;
int sayac=0;
public GameObject yeniden_oyna_pnl;
public BackgroundNPCMover erisim;
public static int vurma_syc=10;

public int degme_sayaci=0;
 public GameObject next_lvl;
 void Start(){
    erisim = gameObject.AddComponent<BackgroundNPCMover>();
  hedef_skor.text=vurma_syc.ToString();
 }
 
    
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            HasarVur = true;
        }
   // if(degme_sayaci<=2){
        if(sayac==vurma_syc){
              next_lvl.SetActive(true);
                    
            Time.timeScale = 0.0f;
            sayac=0;
       
        }

        


       
 //   }
   // if(degme_sayaci>2){
     //   Debug.Log("Game Lost");
    //}
       
    }
    void FixedUpdate()
    {
       if (HasarVur)
        {
            if (Physics.Raycast(GameObject.Find("Main Camera").GetComponent<Camera>().ScreenPointToRay((Input.mousePosition)), out nesne, 5.0f)){

                if (nesne.collider.gameObject.tag == "NPC")   // transform.tag ?
                {

                    Debug.Log("isik temas etti");
                    sayac++;
                   skor.text= sayac.ToString();
                nesne.collider.gameObject.SetActive(false);  // colieder yerine transform
            
                }
            
            }
            HasarVur = false;
        }
        
//void OnCollisionEnter(Collider deneme){
    
        //if(deneme.gameObject.tag == "degme")
        //{
        //  degme_sayaci++;
      //  }
    //}

    }
      public void _btn()
    {       next_lvl.SetActive(false);
    //  erisim.hayvan+=500.0f;
     
        Time.timeScale = 1.0f;
        BackgroundNPCMover.hayvan+=0.1f;
      SceneManager.LoadScene(0);
      vurma_syc+=10;
       
  
    }
    }
