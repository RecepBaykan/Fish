using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreAnimStop : MonoBehaviour
{
    [SerializeField] private Animator animator;

    void Start()
    {
       
        // Animator Controller'da bulunan animasyonu başlatın.
        animator.Play("score");
    }

    void Update()
    {
        
        if (!animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
        {
            Destroy(gameObject);
        }
    }
}


