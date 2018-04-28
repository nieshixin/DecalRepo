using UnityEngine;
using System.Collections;

using UnityEngine.Events;


    public class FirstPersonCharacterController : MonoBehaviour
    {	

		[Header("Camera")]
		public GameObject cam;
		public bool CamLock = false;
		private bool excuting = false;
		Space space = Space.Self;
        [Header("Look")]
        public float lookSensitivity = 3f;

        [Header("Move")]
        public float moveAcceleration = 0.2f;
        public float moveSpeed = 8;

        [Header("Jump")]
        public float jumpAcceleration = 1;

        [Header("Camera")]
        public Camera cameraControlled;
        public float cameraSmooth = 0.2f;
        public Vector3 cameraOffset = new Vector3(0, 0.6f, 0);

		[Header("Look Angle")]
	public float lookAngle = 1; //1 is default angle when player start the level! when anle =5 set it back to 1;
		
		public LookAngleChangeEvent m_lookAngleChangeEvent;
		public bool Srotenabled = false;
        //Properties
        public bool Grounded
        {
            get { return grounded; }
        }

        //Backing fields
        private Rigidbody attachedRigidbody;
        private CapsuleCollider capsuleCollider;
	[SerializeField]
	public Vector3 cameraRotation;

        private Vector2 lookDelta;

        private float recoil;
        private float recoilDuration;
        private float recoilVelocity;

        private Vector3 moveDelta;

        private bool grounded;
        private int collisions;

        private bool jumpInput;
        private Vector3 cameraVelocity;

		[HideInInspector]
		public UnityEvent PlayerDied;
        //Generic methods

	void Start(){
		if (PlayerDied == null) {
			PlayerDied = new UnityEvent ();
		}
	}

        private void Awake()
        {
            //Grab our components
            attachedRigidbody = GetComponent<Rigidbody>();
            capsuleCollider = GetComponent<CapsuleCollider>();

            if (Application.isPlaying)
            {
                //Lock Cursor
                Cursor.lockState = CursorLockMode.Confined;

                //Hide Cursor
                Cursor.visible = false;
            }

			if (m_lookAngleChangeEvent == null) {
			m_lookAngleChangeEvent = new LookAngleChangeEvent ();

			}
        }
        private void OnEnable()
        {
			
            if (cameraControlled == null) cameraControlled = Camera.main;
            cameraRotation = cameraControlled.transform.rotation.eulerAngles;
	
        }
        private void Update()
        {	
			
            //Look Input
            lookDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));


	

		/*
				if (Input.GetButtonDown ("RotateCamera") && !excuting) {
					excuting = true;
		//	Debug.Log ("rotated camera");
					float d = Input.GetAxis ("RotateCamera");
			if (d > 0) {
				d = 1;
			} if (d < 0) {
				d = -1;
			}
					//rotate the camera
					//rotate the player
					transform.Rotate (new Vector3 (0f, 90f * d, 0));
			iTween.RotateAdd (cam, iTween.Hash ("x", 0f, "y", 90 * d, "z", 0f, "time", 0.5f, "oncomplete", "CanExecute", "oncompletetarget", this.gameObject, "space", Space.World));
					//Debug.Log(player.transform.rotation.eulerAngles.y);

			//"oncompleteparams",(int)d,
			//update the look angle state
			UpdateLookAngleState90(d);
				}

			else if( Input.GetButtonDown ("SlightRotateCamera")&& !excuting && Srotenabled){
					excuting = true;
					float d = Input.GetAxis ("SlightRotateCamera");
			if (d > 0) {
				d = 1f;
			} if (d < 0) {
				d = -1f;
			}

					transform.Rotate (new Vector3 (0f, 45f * d, 0));
					//rotate the camera
					iTween.RotateAdd (cam, iTween.Hash ("x", 0f, "y", 45 * d, "z", 0f, "time", 0.5f, "oncomplete", "CanExecute", "oncompletetarget", this.gameObject, "space", Space.World));
					//rotate the player
			UpdateLookAngleState45(d);
			}
				
			*/
            //Move Input
            moveDelta = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

            //Jump Input
            if (Input.GetKey(KeyCode.Space)) jumpInput = true;
            else jumpInput = false;



			///////////////////////////////////////////////previously belongs to fixed update
		//Update character rotation
		if (!CamLock) {
			
			Vector3 characterRotation = transform.localRotation.eulerAngles;
			//Debug.Log (characterRotation.y);
	
			characterRotation.y += lookDelta.x * lookSensitivity;
		

			//Debug.Log (characterRotation.y);

			transform.localRotation = Quaternion.Euler(characterRotation);

		}
		//Update weapon - Called here instead of within its own FixedUpdate because we need to guarentee it's not updated until after the camera position has been

		///             //Get velocity
		Vector3 velocity = attachedRigidbody.velocity;

		//Update horizontal velocity
		Vector3 goalAcceleration = transform.rotation * moveDelta.normalized * moveAcceleration;
		velocity.x += goalAcceleration.x;
		velocity.z += goalAcceleration.z;

		//Clamp to max speed
		Vector2 horizontalVelocity = new Vector2(velocity.x, velocity.z);
		if (horizontalVelocity.magnitude > moveSpeed)
		{
			velocity.x *= moveSpeed / horizontalVelocity.magnitude;
			velocity.z *= moveSpeed / horizontalVelocity.magnitude;
		}

		//Grounded
		//grounded = CheckGrounded();

		//Jumping
		/*
			if (jumpInput && grounded)
			{
				velocity.y += jumpAcceleration;
			}
			*/

		if(Input.GetMouseButtonDown(0)){
			lookSensitivity = 0.2f;
		}
		if(Input.GetMouseButtonUp(0)){
			lookSensitivity = 1f;
		}



		//Set velocity
		attachedRigidbody.velocity = velocity;

		//Update camera rotation
		// cameraRotation.x -= lookDelta.y * lookSensitivity;
		if (!CamLock) {
			cameraRotation.y += lookDelta.x * lookSensitivity;
			cameraRotation.z = 0;
		}

		//Clamp looking too high/low
		if (cameraRotation.x < 200) cameraRotation.x = Mathf.Clamp(cameraRotation.x, -90, 90);

		//Update recoil
		/*
		recoil = Mathf.SmoothDamp(recoil, 0, ref recoilVelocity, recoilDuration);
		Vector3 RecoiledRotation = cameraRotation;
		RecoiledRotation.x -= recoil;
*/
		cameraControlled.transform.rotation = Quaternion.Euler(cameraRotation);

		//Update camera position

		cameraControlled.transform.position = Vector3.SmoothDamp(cameraControlled.transform.position, transform.TransformPoint(cameraOffset), ref cameraVelocity, cameraSmooth);

		//broadcast camera rotation to all registered events
		float n= Mathf.Floor(cameraRotation.y/360);
		UpdateLookAngleValue(cameraRotation.y-n*360f);
		//Debug.Log (cameraRotation.y);
       	 }

        //Physics methods
        private void FixedUpdate()
        {
           
        }
        private void OnCollisionEnter(Collision collision)
        {
            collisions++;
        }
		/*
        private void OnCollisionExit(Collision collision)
        {
            collisions--;
        }
*/
        private bool CheckGrounded()
        {
            return (collisions > 0 && Physics.Raycast(transform.position, -Vector3.up, capsuleCollider.bounds.extents.y * 1.4f));
        }


        //Recoil
        public void ApplyRecoil(float RecoilStrength, float RecoilDuration)
        {
            recoilDuration = RecoilDuration;
            recoilVelocity += RecoilStrength;
        }
		public void CanExecute(){
		excuting = false;
		//	Debug.Log ("can execute");
		//	Debug.Log( transform.eulerAngles.y);
		}

	public void UpdateLookAngleValue(float angle){

		m_lookAngleChangeEvent.Invoke (angle);
	}

	public void UpdateLookAngleState90(float direction){//1 is clockwise
		


		lookAngle += direction;
		if (lookAngle == 5f)
			lookAngle = 1f;
		if (lookAngle == 5.5f)
			lookAngle = 1.5f;
		if (lookAngle == 0.5f)
			lookAngle = 4.5f;
		if (lookAngle == 0f)
			lookAngle = 4f;

		//after updating the look angle, broadcast to all event listeners
		m_lookAngleChangeEvent.Invoke (lookAngle);
		}

	public void UpdateLookAngleState45(float direction){//1 is clockwise



		lookAngle += 0.5f*direction;
		if (lookAngle > 4.5f) {
			lookAngle = 1;
		}
		if (lookAngle < 1f) {
			lookAngle = 4.5f;
		}
		//after updating the look angle, broadcast to all event listeners
		m_lookAngleChangeEvent.Invoke (lookAngle);
	}

    }

