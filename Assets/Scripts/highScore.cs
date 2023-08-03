using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class highScore : MonoBehaviour
{

   [SerializeField] private TextMeshProUGUI high;
   
    // Start is called before the first frame update
    void Start()
    {

        
        high.text = PlayerPrefs.GetString("high");
            if(high.text == "")
            {
                high.text = "0";
            }   
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   
        
            
        
    
}
