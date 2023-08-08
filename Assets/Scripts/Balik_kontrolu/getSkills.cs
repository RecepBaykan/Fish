using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class getSkills : MonoBehaviour
{
    [SerializeField] private GameObject view;
    [SerializeField] private GameObject skillParent;
    [SerializeField] private GameObject slot;

    bool add;


    // Start is called before the first frame update
    void Start()
    {
       view = GameObject.Find("Content");
    }

    // Update is called once per frame
    void Update()
    {
         if(gameObject.transform.childCount <= 2  && !add)
        {
            GameObject slotClone = Instantiate(slot);
            
            slotClone.GetComponent<RectTransform>().sizeDelta = new Vector2
            (
                slot.GetComponent<RectTransform>().sizeDelta.x/2, 
                slot.GetComponent<RectTransform>().sizeDelta.y/2
            );
            int index = Random.Range(0, skillParent.transform.childCount);
            GameObject skill = skillParent.transform.GetChild(index).gameObject;
            slotClone.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = skill.GetComponent<SpriteRenderer>().sprite;
            slotClone.transform.GetChild(0).gameObject.name = skill.name;
            slotClone.transform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2
            (slotClone.transform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta.x/2,
            slotClone.transform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta.y/2
            );
            slotClone.transform.parent = view.transform;




            add = true;
        }
    }

    
}
