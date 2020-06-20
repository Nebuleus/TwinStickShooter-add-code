using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector2 direction;
    private Rigidbody2D myRigidbody;
    private Inputs inputs;

    // Start is called before the first frame update
    void Start()
    {
        inputs = new Inputs();
        inputs.Enable();
        // Lorsqu’on appuie sur les touches de Move
        inputs.Player.Move.performed += OnMovePerformed;
        // Lorsqu’on arrête de se déplacer
        inputs.Player.Move.canceled += OnMoveCanceled;
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext obj)
    {
        direction = Vector2.zero;
    }

    private void OnMovePerformed(InputAction.CallbackContext obj)
    {
        direction = obj.ReadValue<Vector2>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // Movement
        myRigidbody.velocity = direction * (speed * Time.fixedDeltaTime);
    }
}