using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject dialogBox;
    public GameObject option1;
    public GameObject option2;
    public GameObject option3;
    //public Text dialogText;
    //public string dialog;
    public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)&&playerInRange) //if player near sign and press spacebar
        {
            if(dialogBox.activeInHierarchy) //if dialog box already active, disable dialog
            {
                dialogBox.SetActive(false);
                option1.SetActive(false);
                option2.SetActive(false);
                option3.SetActive(false);
            }
            else                            //if dialog box is not active, enable dialog box
            {
                dialogBox.SetActive(true);
                option1.SetActive(true);
                option2.SetActive(true);
                option3.SetActive(true);
                //dialogText.text = dialog;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))  //if sign's box collider collides with player's box collider (entering)
        {
            playerInRange = true;
            Debug.Log("Player in range");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //if sign's box collider collides with player's box collider (exiting)
        {
            playerInRange = false;
            Debug.Log("Player left range");
            dialogBox.SetActive(false);
            option1.SetActive(false);
            option2.SetActive(false);
            option3.SetActive(false);
        }
    }
}
