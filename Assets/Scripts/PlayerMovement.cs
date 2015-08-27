using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    /*
     * TO DO:
     * Movement
//     *      Should use the CharacterController which is already attached to this GameObject
//     *      Be able to move left and right
//     *      Collide with/be stopped by walls
     *      Not move too quickly or slowly
     *          Remember that movement happens every frame
     * Jumping/Falling
//     *      Fall to the ground, and not through it
//     *      Able to jump
     *      Can reach platforms to the right, but not the one on the left
//     *      Only able to jump while standing on the ground
     * Input
//     *      Ideally, use the KeyboardInput script which is already attached to this GameObject
//     *      A & D for left and right movement
//     *      Space for jumping
     * Moving Platform
     *      When standing on the platform, the character should stay on it/move relative to the moving platform
     *      When not standing on the platform, revert to normal behavior
     * Enemy
     *      If the character touches the enemy, he should "die"
     *      
     * 
     * 
     * 
     * Variables you might want:
     *      References to the CharacterController and Keyboard input classes
     *      Speed values for moving, falling, and jumping
     *      A value to keep track of the player's movement speed and direction
     *      You will probably need to use the Update function as well as create functions for moving platforms and enemies
     */


	public float gravity = 10.0f;					//force of gravity
	public float jumpForce = 2.0f;					//force of player jump
	public float playerSpeed = 0.1f;				//speed of player movement
	public bool isDead;								//player dead flag

	private Vector3 moveDirection = Vector3.zero;	//player direction of travel


	void Start()
	{
		isDead = false;
	}


	void Update()
	{

		//if player dies
		if(isDead == true)
		{
			//reload the scene
			

			//reset isDead flag
			isDead = false;

		}//END if(isDead == true)

		//get components
		CharacterController controller = GetComponent<CharacterController>();
		KeyboardInput keyboard = GetComponent<KeyboardInput>();

		if (controller.isGrounded)
		{
			//check for player jump
			if (keyboard.JumpButtonPressedThisFrame == true) {
				//make player jump
				moveDirection.y += jumpForce;

			}//END if(keyboard.JumpButtonPressed == true)
		}
		//check for horizontal movement
		if (keyboard.XAxis > 0f) {
			//move player to the right
			moveDirection.x = playerSpeed;

		}//END if(keyboard.XAxis > 0f)
		else if (keyboard.XAxis < 0f) {
			//move player to the left
			moveDirection.x = -playerSpeed;

		}//END else if(keyboard.XAxis < 0f)
		else
		{
			//this causes it to not stay on moving platform------------------------
			moveDirection.x = 0f;
		}

		//apply gravity to player
		moveDirection.y -= gravity * Time.deltaTime;

		//apply total movement to player
		controller.Move(moveDirection * Time.deltaTime);









	}//END void Update()




}//END public class PlayerMovement : MonoBehaviour {