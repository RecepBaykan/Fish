using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class skills : MonoBehaviour
{

    GameObject slot;
    public static bool frozenTime;
   


    private void Update() {
        
       

    }



   
    public void OnButtonClick()
    {
        
        slot = EventSystem.current.currentSelectedGameObject;
        

        switch (slot.transform.GetChild(0).gameObject.name)
        {
            
            case "roket":
            roketSkill();
            break;

            case "frozeTime":
            frozeTimeSkill();
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



    
    void frozeTimeSkill()
    {
        
        Destroy(slot);
       
    }
    



}
