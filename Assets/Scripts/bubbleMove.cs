using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleMove : MonoBehaviour
{

   
   GameObject[] paths;
   [SerializeField] private bool[] pathLock;

   [SerializeField] private float[] moveSpeed;
   [SerializeField] private int[] pathCount; 

   [SerializeField] private GameObject bubble;
   [SerializeField] private GameObject[] bubbles;
   [SerializeField] private GameObject[] lastPath;

    // Start is called before the first frame update
    void Start()
    {
        pathLock = new bool[20];
        bubbles = new GameObject[pathLock.Length];
        moveSpeed = new float[pathLock.Length];
        pathCount = new int[pathLock.Length];
        lastPath = new GameObject[pathLock.Length];
        paths = GameObject.FindGameObjectsWithTag("bubblePath");
    }

    // Update is called once per frame
    void Update()
    {
        bubbleSpawn();
        move();
    }



    void bubbleSpawn()
    {

        for(int i = 0; i<pathLock.Length; i++)
        {
            if(!pathLock[i])
            {
                bubbles[i] = Instantiate(bubble);

                
                    
                bubbles[i].transform.position = paths[Random.Range(0,paths.Length)].transform.GetChild(0).transform.position;  
                lastPath[i] = paths[Random.Range(0,paths.Length)].transform.GetChild(1).gameObject;
                moveSpeed[i] = Random.Range(0.5f, 6f);
                pathCount[i] = 1;
                
                pathLock[i] = true;
               
                
            }
        }


    }

    
    
    
    void move()
    {

        for(int i = 0; i<pathLock.Length; i++)
        {
           if(pathLock[i])
           {
                bubbles[i].transform.position = Vector2.Lerp(bubbles[i].transform.position, lastPath[i].transform.position,
                Time.deltaTime*moveSpeed[i]);

                distance(bubbles[i].transform.position, lastPath[i].transform.position, i);
                
                
           }
        }

    }


    void distance(Vector2 bubble, Vector2 path, int i)
    {

      
        
            if(Vector2.Distance(bubble, path)<0.2f)
            {

                if(pathCount[i] == 4)
                {
        
                    
                        Destroy(bubbles[i]);
                        pathLock[i] = false;
                    

                }else
                {
                    moveSpeed[i] = Random.Range(0.6f, 6f);
                    pathCount[i]++;
                    lastPath[i] = paths[Random.Range(0,paths.Length)].transform.GetChild(pathCount[i]).gameObject;
                }
                
           
            }
    }
        
        
    
}

