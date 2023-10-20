using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class ChestOpen : MonoBehaviour
{

    public Animator animator; 
    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("open chest");
            animator.SetFloat("openChest", 1f);
        }
    }
     
}
