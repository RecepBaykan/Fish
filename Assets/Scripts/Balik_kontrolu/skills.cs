using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class skills : MonoBehaviour
{

    GameObject slot;
    [SerializeField] private GameObject viewTray;
    [SerializeField] private GameObject straySkill;
    [SerializeField] private GameObject straySkillSlot;
    
    
   

    private void Update() {
        
       

    }



   
    public void OnButtonClick()
    {
        
        slot = EventSystem.current.currentSelectedGameObject;
        straySkill = GameObject.Find("stray");
        

        switch (slot.transform.GetChild(0).gameObject.name)
        {
            
            case "roket":
            roketSkill();
            break;

            case "frozeTime":
            frozeTimeSkill();
            break;

            case "slowBoost":
            slowBoost();
            break;

            case "pointBoost":
            pointBoost();
            break;


            default:
            break;
        }
    }


    [SerializeField] private GameObject roket;
    void roketSkill()
    {
        GameObject skill = Instantiate(roket);
        Destroy(slot);
    }



  
    [SerializeField] private GameObject frozeTime;
    [SerializeField] private GameObject speedsBoost;
    [SerializeField] private GameObject pointsBoost;
    int a = 4;
    void frozeTimeSkill()
    {
        
        if(!touchTime.frozenTime)
        {
            GameObject go = Instantiate(frozeTime);
            go.name = "frozeTime";
            /*go.GetComponent<Image>().sprite = frozeTime.GetComponent<SpriteRenderer>().sprite;*/
            go.GetComponent<RectTransform>().sizeDelta = new Vector2
            (
                go.GetComponent<RectTransform>().sizeDelta.x/a,
                go.GetComponent<RectTransform>().sizeDelta.y/a

            );
            go.transform.SetParent(straySkill.transform);
            touchTime.frozenTime = true;
            touchTime.sure = 10;
        
            Destroy(slot);
             
        }
            
        
        
       
    }

    void slowBoost()
    {
        if(!fishCreate.speedSlow)
        {

            GameObject go = Instantiate(speedsBoost);
            go.name = "speedBoost";
            /*go.GetComponent<Image>().sprite = speedsBoost.GetComponent<SpriteRenderer>().sprite;*/
            go.GetComponent<RectTransform>().sizeDelta = new Vector2
            (
                go.GetComponent<RectTransform>().sizeDelta.x/a,
                go.GetComponent<RectTransform>().sizeDelta.y/a

            );
            go.transform.SetParent(straySkill.transform);   
            
            fishCreate.speedSlow = true;
           
            Destroy(slot);
        }
       
    }

    void pointBoost()
    {
        if(!fishCreate.pointBoost)
        {
            GameObject go = Instantiate(pointsBoost);
            go.name = "pointBoost";
            /*go.GetComponent<Image>().sprite = pointsBoost.GetComponent<SpriteRenderer>().sprite;*/
            go.GetComponent<RectTransform>().sizeDelta = new Vector2
            (
                go.GetComponent<RectTransform>().sizeDelta.x/a,
                go.GetComponent<RectTransform>().sizeDelta.y/a

            );
            go.transform.SetParent(straySkill.transform);
            
           
            fishCreate.pointBoost = true;
            Destroy(slot);
        }
       
    }


    
    



}
