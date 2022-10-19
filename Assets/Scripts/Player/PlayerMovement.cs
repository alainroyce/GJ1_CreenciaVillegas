using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    public Camera cam;

    private float ticks_interval = 0.0f;
    public float threshhold = 2f;

    private void Awake()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.GJ1_Events.ON_INTERACT, this.InteractObject);
        EventBroadcaster.Instance.AddObserver(EventNames.GJ1_Events.ON_MOVE, this.Walking);
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        Interact();
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveAllObservers();
    }

    public void Walk()
    {
        Parameters updateLineParams = new Parameters();
        EventBroadcaster.Instance.PostEvent(EventNames.GJ1_Events.ON_MOVE);
    }

    private void Walking()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        ticks_interval++;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (ticks_interval >= threshhold)
            {
                Debug.Log("CHECKING");
                AudioManager.instance.Play("Walk");
                ticks_interval = 0;
            }
        }
    }

    public void Interact()
    {
        Parameters updateLineParams = new Parameters();
        EventBroadcaster.Instance.PostEvent(EventNames.GJ1_Events.ON_INTERACT);
    }

    private void InteractObject()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (interactable != null)
                {
                    Debug.Log("OBJECT FOUND");
                    float distance = Vector3.Distance(interactable.player.position, interactable.interactionTransform.position);

                    if (distance <= interactable.radius)
                    {
                        interactable.Interact();
                    }
                }
            }
        }
    }
}