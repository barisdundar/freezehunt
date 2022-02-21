
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NPCDespawner : MonoBehaviour
{   public GameObject yeniden_oyna_pnl;
    int sayac=0;




    private void Update(){

                if(sayac == 2){
                   Time.timeScale = 0.0f;
                   yeniden_oyna_pnl.SetActive(true);
                   sayac = 0;}

    }
   private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC") && sayac != 2)
        {
                   
         //           if(other.GetComponent<NPCSimpleMove>().target == transform)
        //    { 
           
                other.gameObject.SetActive(false);
                sayac++;
                Debug.Log("hayvan  = "+sayac);
                
        //    }
            }
            
        }
      
     public void yeniden_oyna_btn()
    {
        
        SceneManager.LoadScene(0);

        Time.timeScale = 1.0f;
    }
}