using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class balik : MonoBehaviour
{
   
    [SerializeField] private GameObject bubble;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject scoreAnim;

    string name;
    
    // Start is called before the first frame update
    void Start()
    {
        
        if(transform.position.x>3)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        name = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        if(roketSkill.roketGeliyor)
        {
            if(gameObject.active)
            {
                set();
            }
            
           
        }
    }

    private void OnMouseDown() 
    
    {

        if(gameObject.transform.GetChild(0).name == "key" /*eventClass.DragAndDrop*/)
        {
            fark = (Vector2)((Camera.main.ScreenToWorldPoint(Input.mousePosition)));
        }
        

        
        
        

    }

    void set()
    {

        scoreText = GameObject.Find("scoreText").GetComponent<TextMeshProUGUI>();
        GameObject bubbleClone = Instantiate(bubble);
        bubbleClone.transform.position = transform.position;
        GameObject scoreAnimeClone = Instantiate(scoreAnim);
        scoreAnimeClone.transform.position = new Vector2(transform.position.x, transform.position.y-0.9f);
        scoreAnimeClone.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = transform.GetChild(1).gameObject.name;
        gameObject.SetActive(false);
        
        
        if(!eventClass.GameOver)
        {
            if(fishCreate.pointBoost)
        {
            scoreAnimeClone.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = (2 * int.Parse(transform.GetChild(1).gameObject.name)).ToString();
            scoreText.text = (int.Parse(scoreText.text) + (2)*(int.Parse(transform.GetChild(1).gameObject.name))).ToString();
        }else
        {
            scoreText.text = (int.Parse(scoreText.text) + int.Parse(transform.GetChild(1).gameObject.name)).ToString();
            scoreAnimeClone.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = transform.GetChild(1).gameObject.name;
        }
        }
        
       

        Destroy(gameObject);
        
        
        
        
    }

    Vector2 fark;
    RaycastHit2D hit;
    
    void OnMouseDrag() {

      if(gameObject.transform.GetChild(0).name == "key" /* || eventClass.DragAndDrop*/)
      {
        transform.position = (Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition));
       
      }
      
        
    }

    private void OnMouseUp() {

        if(eventClass.DragAndDrop)
        {
            
        }
        
        if(gameObject.transform.GetChild(0).name == "key")
        {

            // Hit.collider kullanılacak.
            try
                {
                    hit = Physics2D.Raycast(transform.position, Vector2.zero);
                    if(hit.collider != null)
                    {
                        if(hit.collider.gameObject.name != name && hit.collider.gameObject.name == "chest")
                        {
                            Destroy(hit.collider.gameObject);
                        }
               
                    }
                }
                catch (System.NullReferenceException e)
                {
                    
                    
                }
                
                
        }

        if(fishCreate.play)
        {
            set();
        }
    }

   
}


