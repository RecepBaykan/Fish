using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baloon : MonoBehaviour
{

    

    [SerializeField] private GameObject bubble;
    
    bool igneHareketi;
    bool patladi;
    string name;
    
    GameObject parentDiken;
    GameObject parentKonum;
    // Start is called before the first frame update
    void Start()
    {
        //Balığın başlangıç yönünü ayarla
        if(transform.position.x >3)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            for(int i = 0; i<transform.GetChild(0).transform.childCount; i++)
            {
                transform.GetChild(0).transform.GetChild(i).GetComponent<SpriteRenderer>().flipX = true;
            }
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        if(igneHareketi)
        {
            //Debug.Log(parentDiken.transform.childCount);
            if(parentDiken.transform.childCount >0)
            {
                dikenFirlat(parentDiken.transform.childCount);
            }
            
        }
       
        
    }

    private void OnMouseDown() {
       
        if(fishCreate.play && !patladi)
        {
            patladi = true;
            set();
            
            
        }
        
    }

    GameObject childDiken;
    GameObject childKonum;
    RaycastHit2D hit;
    int indis = 0;
    void dikenFirlat(int tiken)
    {
        
        

        for(int i = 0; i<tiken; i++)
        {
            
            
            childDiken = parentDiken.transform.GetChild(i).gameObject;
            childKonum = parentKonum.transform.GetChild(i).gameObject;
            
            


            if(childDiken != null && childDiken.transform.position != childKonum.transform.position)
            {
                childDiken.transform.position = Vector2.Lerp(childDiken.transform.position, childKonum.transform.position, 4f*Time.deltaTime);
                hitting();
                

                if(Vector2.Distance(childDiken.transform.position, childKonum.transform.position)<0.2f)
                {
                   childDiken.SetActive(false);
                
                    
                }
            }
           
        }
    }

    void hitting()
    {
        hit = Physics2D.Raycast(childDiken.transform.position, Vector2.zero);
            {
                if(hit.collider != null)
                {

                    if(hit.collider.gameObject.name != name)
                    {
                        
                        if(childDiken.active)
                        {
                            Instantiate(bubble).transform.position = hit.transform.position;
                            Destroy(hit.collider.gameObject);
                            childDiken.SetActive(false);
                        }
                        
                       

                    }               
                        
                        
                }
                    
            }
        
    }



    void set()
        {
            parentDiken = transform.GetChild(0).gameObject;
            parentKonum = transform.GetChild(1).gameObject;
            parentDiken.transform.SetParent(null);
            parentKonum.transform.SetParent(null);
            //parentDiken.transform.position = transform.GetChild(0).gameObject.transform.position;
            //parentKonum.transform.position = transform.GetChild(1).gameObject.transform.position;
            igneHareketi = true;
            name = gameObject.name;
            this.Wait(3f, () => 
            {
                foreach(Transform i in  parentDiken.transform)
                {
                    
                    Destroy(i.gameObject);
                    
                }
                
                igneHareketi = false;
                Destroy(parentKonum);
                Destroy(parentDiken);
            });
            Instantiate(bubble).transform.position = transform.position;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0f,0f,0f,0f);
            this.Wait(3f, ()=>
            {
                Destroy(gameObject);
            
            });
        }   


    



}

    
