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
    
    // Start is called before the first frame update
    void Start()
    {
        
        if(transform.position.x>3)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
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

        if(gameObject.transform.GetChild(0).name == "key")
        {
            fark = (Vector2)((Camera.main.ScreenToWorldPoint(Input.mousePosition))- transform.position);
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
        scoreText.text = (int.Parse(scoreText.text) + int.Parse(transform.GetChild(1).gameObject.name)).ToString();

        Destroy(gameObject);
        
        
        
        
    }

    Vector2 fark;
    void OnMouseDrag() {

      if(gameObject.transform.GetChild(0).name == "key")
      {
        transform.position = (Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition)) - fark;
      }
      
        
    }

    private void OnMouseUp() {
        
        if(gameObject.transform.GetChild(0).name == "key")
        {
            try
                {
                    if(Vector2.Distance(GameObject.Find("chest").transform.position, 
                    gameObject.transform.GetChild(0).transform.position)<0.9f)
                    {
                        Destroy(GameObject.Find("chest"));
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


