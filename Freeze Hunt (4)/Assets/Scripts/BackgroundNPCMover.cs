using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundNPCMover : MonoBehaviour
{
    public static float hayvan=0.1f;
    public float speed = 5f;
    private float frequency;
    public float frequencymin;
    public float frequencymax;
    public int density;
    public GameObject prefab;
    public Transform point1, point2;
    public int degme_sayaci=0;
public int sayac=0;
    private float timer = 0f;
 public bool vurma = false;
    public List<GameObject> pool = new List<GameObject>();
    private void Start()
    {
        
    }
     private void OnMouseDown()
    {
        vurma = true;
        
        gameObject.SetActive(false);
    }
    private void Awake()
    {
        for (int i = 0; i < density; i++)
        {
            GameObject spawned = Instantiate(prefab, transform, true);
            spawned.AddComponent<NPCSimpleMove>().speed = speed;
            Animator anim = spawned.GetComponent<Animator>();
            //anim.SetBool("walk", true);
            spawned.SetActive(false);
            pool.Add(spawned);
        }
    }
    private void Update()
    {  

        frequency = Random.Range(frequencymin, frequencymax);
        if (timer > frequency)
        {
            if (PoolHasAvailableGO())
            {
                switch (Random.Range(0, 1))
                {
                    case 0:
                        GameObject npc = ReturnFirstAvailableGO();
                        npc.SetActive(true);

                          Debug.Log("sayac arttı");
                        npc.GetComponent<NPCSimpleMove>().target = point2;
                        npc.transform.position = point1.position;
                        npc.transform.rotation = Quaternion.LookRotation(point2.position - npc.transform.position);
                        npc.tag = "NPC";
                        break;
                    case 1:
                        GameObject npc1 = ReturnFirstAvailableGO();
                        npc1.SetActive(true);
                        Debug.Log("sayac arttı");
                        npc1.GetComponent<NPCSimpleMove>().target = point1;
                        npc1.transform.position = point2.position;
                        npc1.transform.rotation = Quaternion.LookRotation(point1.position - npc1.transform.position);
                        npc1.tag = "NPC";
                        break;
                }
                timer = 0;
            }
        }
        if (timer < frequency + 1)
        {
            timer += (float)Time.deltaTime*hayvan;
        }
    }

    private bool PoolHasAvailableGO()
    {
        bool temp = false;
        foreach (GameObject obj in pool) if (!obj.activeSelf) temp = true;
        return temp;
        
    }

    private GameObject ReturnFirstAvailableGO()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeSelf)
            {
                foreach(Transform child in obj.transform.GetChild(0))
                {
                    child.gameObject.SetActive(false);
                }
                int randIndex = Random.Range(0, obj.transform.GetChild(0).childCount);
                obj.transform.GetChild(0).GetChild(randIndex).gameObject.SetActive(true);
                return obj;
            }
        }
        return null;
    }
    void OnCollisionEnter(Collision deneme){
        if(degme_sayaci>=2&& deneme.gameObject.tag=="degme")
        
        {
          degme_sayaci++;
    Time.timeScale=0.0f;
       }

    }
}
