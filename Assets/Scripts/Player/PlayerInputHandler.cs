using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 MoveDirection { get; private set;}
    public bool IsAttacking { get; private set;}
    public int  SelectedSlot { get; private set;}
    public bool IsinventoryInteracted {get; private set;}

    private InputAction move;
    private InputAction attack;
    private InputAction selectSlot;
    private InputAction interactInventory;

    public event Action<int> OnSlotSelected;
    public event Action<bool> OnInventoryInteracted;

    void Awake()
    {
        PlayerInput input = GetComponent<PlayerInput>();

        move = input.actions["Move"];
        attack = input.actions["Attack"];
        selectSlot = input.actions["SelectSlot"];
        interactInventory = input.actions["InteractInventory"];
    }

    void OnEnable()
    {
        move.Enable();
        attack.Enable();
        selectSlot.Enable();
        interactInventory.Enable();

        move.performed += OnMove;
        move.canceled += OnMove;

        attack.started += OnAttack;
        attack.canceled += OnAttack;

        selectSlot.performed += OnSelectSlot;
        interactInventory.performed += OnInteractInventory;
    }

    void OnDisable()
    {
        move.performed -= OnMove;
        move.canceled -= OnMove;

        attack.started -= OnAttack;
        attack.canceled -= OnAttack;

        selectSlot.performed -= OnSelectSlot;
        interactInventory.performed -= OnInteractInventory;


        move.Disable();
        attack.Disable();
        selectSlot.Disable();
        interactInventory.Disable();
    }

    void Start()
    {
        IsinventoryInteracted = false;
    }

    // Get movement Vector2
    public void OnMove(InputAction.CallbackContext context)
    {
        MoveDirection = context.ReadValue<Vector2>();
    }

    //Use tool while pressed
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
            IsAttacking = true;

        if (context.canceled)
            IsAttacking = false;
    }

    public void OnInteractInventory(InputAction.CallbackContext context)
    {
        IsinventoryInteracted = !IsinventoryInteracted;
        OnInventoryInteracted?.Invoke(IsinventoryInteracted);
    }

    //Get integer number from 1 to 10 if digit was pressed
    public void OnSelectSlot(InputAction.CallbackContext context)
    {
        string key = context.control.name; 

        int slot = (key == "0")? 10 : int.Parse(key);
        //normilize for array
        slot--;

       SelectedSlot = slot;
       OnSlotSelected?.Invoke(slot);
    }
}
