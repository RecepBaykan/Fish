using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class shark : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    [SerializeField] private GameObject bubble;
    int hit = 5;
    // Start is called before the first frame update
    void Start()
    {
        if(transform.position.x>3)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            //gameObject.GetComponent<SpriteRenderer>().flipX = true;s
            
            
        }
    
       eventClass.DragAndDrop = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        
        if(hit == 5)
        {
            scoreText = GameObject.Find("scoreText").GetComponent<TextMeshProUGUI>();
        }

        if(hit<=0 || eventClass.fishing == 5)
        {
            eventClass.DragAndDrop = false;
            eventClass.fishing = 0;
            Destroy(gameObject);
        }else
        {
            hit --;
            if(int.Parse(scoreText.text) >= 0)
            {
                scoreText.text = (int.Parse(scoreText.text) - 50).ToString();
            }
            {
                scoreText.text = "0";
            }
            
        }
       

    }
}
