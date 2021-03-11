using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Photon.MonoBehaviour
{
    public PhotonView photonView;
    public GameObject playerCamera;
    public Text playerName;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;

    private void Awake()
    {
        if(photonView.isMine)
        {
            playerCamera.SetActive(true);
        }

    }
  
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();        //animation for player
        myRigidbody = GetComponent<Rigidbody2D>();  //rigidbody for player
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.isMine)
        {
            checkInput();
        }

    }
    
    public void checkInput()
    {
        change = Vector3.zero;      //resets placement to zero every update
        //get x y axis movement
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();
    }

    void UpdateAnimationAndMove()   //player animation for movement
    {
        if (change != Vector3.zero) //if player is moving
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }
    void MoveCharacter()
    {
        //player movement
        myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime
            );
    }
}
