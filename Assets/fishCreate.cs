using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishCreate : MonoBehaviour
{
    [SerializeField] private GameObject fishParent;
    [SerializeField] GameObject[] pathA;
    [SerializeField] GameObject[] pathB;
    string[] fishName = {"red", "blue", "yellow", "green", "purple"};

    string path1;
    string path2;
    
    [SerializeField] private float[] moveSpeed;

    [SerializeField] private float negatifX;
    [SerializeField] private float positifX;


    [SerializeField] private bool[] pathLock;
    [SerializeField] private GameObject[] fishes;
    [SerializeField] private GameObject[] lastPath;


    
    
    void Start()
    {
        pathLock = new bool[4];
        fishes = new GameObject[pathLock.Length];
        lastPath = new GameObject[pathLock.Length];
        moveSpeed = new float[pathLock.Length];
           
       path1 = "path1";
       path2 = "path2";

    }

    // Update is called once per frame
    void Update()
    {
        fishSpam();
        move();


        touch();
       



    }

    void fishSpam(){
        
        for (int i = 0; i < pathLock.Length; i++)
        {
            if(!pathLock[i]){
                path();
                int a = Random.Range(0, fishName.Length);

                string UniqueID = System.Guid.NewGuid().ToString();
                
                fishes[i] = Instantiate(fishParent.transform.GetChild(a).gameObject);
                a = Random.Range(0,4);
                fishes[i].name = System.Guid.NewGuid().ToString();
                
                fishes[i].transform.position = new Vector2(pathA[a].transform.position.x,pathA[a].transform.position.y );
                a = Random.Range(0,4); 
                lastPath[i] = pathB[a];

                moveSpeed[i] = Random.Range(0.3f, 0.8f);
                
                pathLock[i] = true;

                

                


            }
        }
        
        
        



    }

    void path(){
        
        

        if(Random.Range(2, 11) % 2 == 0){
            pathA = GameObject.FindGameObjectsWithTag(path1);
            pathB = GameObject.FindGameObjectsWithTag(path2);
        }else{
            pathA = GameObject.FindGameObjectsWithTag(path2);
            pathB = GameObject.FindGameObjectsWithTag(path1);
        }
    }


    void move(){

        if(pathLock[0]){
            
            if(distance( fishes[0].transform.position, lastPath[0].transform.position) || fishes[0] == null)
            {
               pathLock[0] = delete(fishes[0]);
            }else{
                fishes[0].transform.position = Vector2.Lerp(fishes[0].transform.position, lastPath[0].transform.position, Time.deltaTime * moveSpeed[0]);
            
            }


        }
        if(pathLock[1] ||  fishes[1] == null){
            
        
            if(distance( fishes[1].transform.position, lastPath[1].transform.position))
            {
               pathLock[1] = delete(fishes[1]);
            }else{
                fishes[1].transform.position  = Vector2.Lerp(fishes[1].transform.position,lastPath[1].transform.position, Time.deltaTime * moveSpeed[1]);
            }

        }
        if(pathLock[2] ||  fishes[2] == null){
            fishes[2].transform.position  = Vector2.Lerp(fishes[2].transform.position,lastPath[2].transform.position, Time.deltaTime *moveSpeed[2]);
              if(distance( fishes[2].transform.position, lastPath[2].transform.position))
            {
             pathLock[2] =  pathLock[2] = delete(fishes[2]);
            }else{
                  fishes[2].transform.position  = Vector2.Lerp(fishes[2].transform.position,lastPath[2].transform.position, Time.deltaTime *moveSpeed[2]);
            }
        }
        if(pathLock[3] ||  fishes[3] == null){
            
            if(distance( fishes[3].transform.position, lastPath[3].transform.position))
            {
              pathLock[3] =  delete(fishes[3]);
            } else{
                fishes[3].transform.position  = Vector2.Lerp(fishes[3].transform.position, lastPath[3].transform.position, Time.deltaTime * moveSpeed[3]);
            }
        }

    }

    bool distance(Vector2 a, Vector2 b){

        if(Vector2.Distance(a, b)<2f){
            b = a;
            return true;
        }else{
            return false;
        }
    
    }

    bool delete(GameObject a){
        
        Destroy(a);

        return false;

    }




    RaycastHit2D hit;
    Vector2 mouseP;

    void touch()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mouseP = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(mouseP, Vector2.zero);

            if(hit.collider !=null){
                
                for(int i = 0; i<pathLock.Length;i++)
                {
                    if(hit.collider.gameObject.name == fishes[i].name)
                    {
                        pathLock[i] = false;
                        break;
                    }
                }

                Destroy(hit.collider.gameObject);
              
                
               
                
            }

        
        }
        

    }


    
}
