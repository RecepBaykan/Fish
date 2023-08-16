using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class baloon : MonoBehaviour
{

    //[SerializeField] private destroy _destroy;

    [SerializeField] private GameObject bubble;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject scoreAnim;
    
    [SerializeField] private bool igneHareketi;
   [SerializeField] private  bool patladi;
    [SerializeField] private string name;
    
    GameObject parentDiken;
    GameObject parentKonum;

    // Start is called before the first frame update
    void Start()
    {
    
        name = gameObject.name;
        parentDiken = gameObject.transform.GetChild(0).gameObject;
        //Balığın başlangıç yönünü ayarla
        if(transform.position.x >3)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            for(int i = 0; i<transform.GetChild(0).transform.childCount; i++)
            {
                transform.GetChild(0).transform.GetChild(i).GetComponent<SpriteRenderer>().flipX = true;
              
            }
        }
        
      
    }

    // Update is called once per frame
    void Update()
    {
        if(roketSkill.roketGeliyor)
        {
            delete();
        }

        if(igneHareketi)
        {
            //Debug.Log(parentDiken.transform.childCount);
            {
                dikenFirlat(parentDiken.transform.childCount);
            }
            
        }/*else
        {
            foreach(GameObject diken in GameObject.FindGameObjectsWithTag("diken"))
            {
                if(Mathf.Abs(transform.position.x - diken.transform.position.x)<=0.4f &&
                Mathf.Abs(transform.position.y - diken.transform.position.y)<=0.4f)
                {
                    diken.SetActive(false);
                    OnMouseDown();
                }
            }
        }*/

        
        
        
            
        
       
        
    }

    public void OnMouseDown() {
        if(gameObject.activeInHierarchy)
        {
            if(fishCreate.play && !patladi)
        {
            patladi = true;
            if(gameObject !=null)
            {
                set();
            }
           
            
            
        }
        
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
                if(childDiken.active)
                {
                    hitting();
                }
                
                

                if(Vector2.Distance(childDiken.transform.position, childKonum.transform.position)<0.2f)
                {
                   childDiken.SetActive(false);
                   childDiken.transform.position = new Vector2(-10f, -10f);
                
                    
                }
            }
           
        }
    }

    void hitting()
    {
        hit = Physics2D.Raycast(childDiken.transform.position, Vector2.zero);
            {
                if(hit.collider != null && hit.collider.gameObject.active)
                {

                    if(hit.collider.gameObject.name != name)
                    {

                        if(/*hit.collider.gameObject.tag == "baloon" ||*/
                          hit.collider.gameObject.name == "chest" || 
                        hit.collider.gameObject.name == "balina") 
                        {
                            
                        }else
                        {

                            if(hit.collider.gameObject.tag == "baloon")
                            {
                            
                                    
                                baloon balon = hit.collider.gameObject.GetComponent<baloon>();
                                if(balon != null)
                                {
                                    balon.OnMouseDown(); 
                                    childDiken.SetActive(false);
                                    childDiken.transform.position = new Vector2(-10f, -10f);
                                }

                                

                            }else
                            {
                                Instantiate(bubble).transform.position = hit.transform.position;
                                GameObject scoreAnimeClone = Instantiate(scoreAnim);
                                scoreAnimeClone.transform.position = new Vector2(hit.collider.gameObject.transform.position.x,hit.collider.gameObject.transform.position.y-0.9f);
                                scoreAnimeClone.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = transform.GetChild(1).gameObject.name;
                                //gameObject.SetActive(false);
                                scoreText = GameObject.Find("scoreText").GetComponent<TextMeshProUGUI>();
                                scoreText.text = (int.Parse(scoreText.text) + int.Parse(transform.GetChild(1).gameObject.name)).ToString();
                                childDiken.transform.position = new Vector2(-10f, -10f);
                                Destroy(hit.collider.gameObject);
                                childDiken.SetActive(false);
                           
                            }


                           
                            
                        }
                        
                       

                    }               
                        
                        
                }
                    
            }
        
    }


    bool sahip;
    void set()
        {
            parentDiken = transform.GetChild(0).gameObject;
            parentKonum = transform.GetChild(1).gameObject;
            parentDiken.transform.SetParent(null);
            parentKonum.transform.SetParent(null);

            parentDiken.AddComponent<destroy>();
            parentKonum.AddComponent<destroy>();

          
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


            scoreText = GameObject.Find("scoreText").GetComponent<TextMeshProUGUI>();
            GameObject scoreAnimeClone = Instantiate(scoreAnim);
            scoreAnimeClone.transform.position = new Vector2(transform.position.x, transform.position.y-0.9f);
           
            scoreAnimeClone.transform.position = new Vector2(transform.position.x, transform.position.y-0.9f);
           
            
            scoreAnimeClone.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = Mathf.Round(0.006f*1000 + 2.5f*eventClass.level).ToString(); /*transform.GetChild(3).gameObject.name;*/
            
            if(!eventClass.GameOver)
            {
                scoreText.text = (int.Parse(scoreText.text) + Mathf.Round(0.006f*1000 + 2.5f*eventClass.level)).ToString();
            }
            gameObject.transform.position = new Vector2(-10f, -10f);
           
            this.Wait(3f, ()=>
            {
                Destroy(gameObject);
            
            });
        }

       
        void delete()
        {
            Instantiate(bubble).transform.position = transform.position;
            scoreText = GameObject.Find("scoreText").GetComponent<TextMeshProUGUI>();
            GameObject scoreAnimeClone = Instantiate(scoreAnim);
            scoreAnimeClone.transform.position = new Vector2(transform.position.x, transform.position.y-0.9f);
           
            
            scoreAnimeClone.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = Mathf.Round(0.006f*1000 + 2.5f*eventClass.level).ToString(); /*transform.GetChild(3).gameObject.name;*/
            scoreText.text = (int.Parse(scoreText.text) + Mathf.Round(0.006f*1000 + 2.5f*eventClass.level)).ToString();
           
           
            
            Destroy(gameObject);
        }   


    



}

    
