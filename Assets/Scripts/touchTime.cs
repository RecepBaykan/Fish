using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class touchTime : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI time;
   [SerializeField] private TextMeshProUGUI score;
   [SerializeField] private TextMeshProUGUI hedefScore;
    float timeElapsed = 25f;
    public static bool sureOlc = true;
    public static bool durdur = false;
    public static bool timeBoost = false;
    public static bool timeDown = false;
    float sure;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(skills.frozenTime)
        {
            if(!sureOlc)
            {
                sure = 10f;
                sureOlc = true;
                 
            }else
            {
                if(sure <=0)
                {
                    sureOlc = false;
                    skills.frozenTime = false;
                }else
                {
                    sure -= Time.deltaTime;
                }
            }
        }

        if(timeBoost)
        {
            timeElapsed +=2;
            timeBoost = false;
        }

        if(timeDown)
        {
            timeElapsed -=2;
            if(timeElapsed<=0)
            {
                timeElapsed = 0;
            }
            timeBoost = false;
        }

        if(timeElapsed <=0)
        {
           
            if(int.Parse(score.text) >= int.Parse(hedefScore.text))
            {
                
                
                eventClass.seviyeAtla = true;
                timeElapsed = 20f;
                
                
                
                
               
            }else
            {
                eventClass.GameOver = true;
                timeElapsed = 20f;
             
            }

        }else
        {
            
            sureDusur();
            
            
        }
        
       
        
    }


    void sureDusur(){
         if(!sureOlc && !durdur)
        {
            
            time.text = ((int)(timeElapsed)).ToString();
            timeElapsed -= Time.deltaTime; 

            
        }
    }
}
