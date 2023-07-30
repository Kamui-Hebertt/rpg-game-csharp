using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class human_controller : MonoBehaviour
{
    public Animator playerAnimator;
    float input_x = 0;
    float input_y = 0;
    public float speed = 2.5f;
    bool isWalking = false;

    // Start is called before the first frame update
    void Start()
    {
        // No need for this code in Start(), as it will only run once.
    }

    // Update is called once per frame
    void Update()
    {
        // Update input in Update() instead of Start()
        input_x = Input.GetAxisRaw("Horizontal");
        input_y = Input.GetAxisRaw("Vertical");
        isWalking = (input_x != 0 || input_y != 0);

        if (isWalking)
        {
            var move = new Vector3(input_x, input_y, 0).normalized;
            transform.position += move * speed * Time.deltaTime;

            // Set animator parameters for animations
            if (playerAnimator != null)
            {
                playerAnimator.SetFloat("input_x", input_x);
                playerAnimator.SetFloat("input_y", input_y);
            }
        }

        // Set the isWalking parameter in the Animator
        if (playerAnimator != null)
        {
            playerAnimator.SetBool("isWalking", isWalking);
        }

        if(Input.GetButtonDown("Fire1")){
            playerAnimator.SetTrigger("attack");

        }
    }
}
