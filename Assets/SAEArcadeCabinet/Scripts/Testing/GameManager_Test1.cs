using UnityEngine;

/*
    Script: GameManager_Test1
    Author: Gareth Lockett
    Version: 1.0
    Description:    Super simple example moving player cubes around using input from SAE arcade machine.
                    Make sure the SAE.ArcadeMachine component/prefab is in the scene and calls ConfigurePlayer() (Eg use WITHOUT events for this example)
*/

namespace SAE
{
    public class GameManager_Test1 : MonoBehaviour
    {
        // Properties
        public Rigidbody yellowPlayer;          // Reference to yellow players' Rigidbody component.
        public Rigidbody bluePlayer;            // Reference to blue players' Rigidbody component.
        public Rigidbody redPlayer;             // Reference to red players' Rigidbody component.
        public Rigidbody greenPlayer;           // Reference to green players' Rigidbody component.

        public float moveSpeed = 5f;            // Velocity speed of moving players.
        public float rotateSpeed = 3.0f;

        // Methods
        private void Update()
        {
            // Poll SAE.ArcadeMachine for players' joystick axis and use to set Rigidbody velocity.
            Vector2 axisValues = SAE.ArcadeMachine.PlayerJoystickAxisStatic( ArcadeMachine.PlayerColorId.YELLOW_PLAYER );
            this.yellowPlayer.velocity = new Vector3( axisValues.x, 0f, -axisValues.y ) * this.moveSpeed;
            //Prototype code for rotation, it works but flicks back to normal.
            Quaternion rot = this.yellowPlayer.transform.rotation;
            this.yellowPlayer.transform.forward = new Vector3(axisValues.x, 0f, -axisValues.y);
            this.yellowPlayer.transform.rotation = Quaternion.Slerp(rot, this.yellowPlayer.transform.rotation, Time.deltaTime * rotateSpeed);
            
            //My code testing
            /*if (Vector3.Distance(yellowPlayer.position, transform.position) > 1)
                {
                Quaternion lookDirection = Quaternion.LookRotation(yellowPlayer.transform.position - transform.position);
                transform.position = Quaternion.Slerp(transform.rotation, lookDirection, moveSpeed * Time.deltaTime);
                }*/

            //Gareth Code testig, explained everything to me as we went.
            /*this.yellowPlayer.transform.forward = new Vector3(axisValues.x, 0f, axisValues.y );
            Vector3 newForward = new Vector3(axisValues.x, 0f, axisValues.y);
            this.yellowPlayer.transform.forward = Vector3.Lerp( this.yellowPlayer.transform.forward, newForward, Time.deltaTime *rotateSpeed );*/

            axisValues = SAE.ArcadeMachine.PlayerJoystickAxisStatic( ArcadeMachine.PlayerColorId.BLUE_PLAYER );
            this.bluePlayer.velocity = new Vector3( axisValues.x, 0f, -axisValues.y ) * this.moveSpeed;

            axisValues = SAE.ArcadeMachine.PlayerJoystickAxisStatic( ArcadeMachine.PlayerColorId.RED_PLAYER );
            this.redPlayer.velocity = new Vector3( axisValues.x, 0f, -axisValues.y ) * this.moveSpeed;

            axisValues = SAE.ArcadeMachine.PlayerJoystickAxisStatic( ArcadeMachine.PlayerColorId.GREEN_PLAYER );
            this.greenPlayer.velocity = new Vector3( axisValues.x, 0f, -axisValues.y ) * this.moveSpeed;

            // Poll SAE.ArcadeMachine for YELLOW players' button 0 (True if held down)
            if( SAE.ArcadeMachine.PlayerPressingButtonStatic( ArcadeMachine.PlayerColorId.YELLOW_PLAYER, 0 ) == true )
            { Debug.Log( "YELLOW player pressed button 0 (Held down)" ); }

            // Poll SAE.ArcadeMachine for YELLOW players' button 1 (True if pressed once .. eg. not held down)
            if( SAE.ArcadeMachine.PlayerPressingButtonStatic( ArcadeMachine.PlayerColorId.YELLOW_PLAYER, 1, true ) == true )
            { Debug.Log( "YELLOW player pressed button 1 (Not held down)" ); }

            // **OLD ROTATION** transform.RotateAround(0, Input.GetAxis("Horizontal"), 0);

        }


    }
}
