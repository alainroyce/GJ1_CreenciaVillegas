using UnityEngine;

public class InventoryUI : MonoBehaviour
  
{
    [SerializeField] private Animator animator;
    bool isActive = false;

    public Transform itemsParent;
    public GameObject inventoryUI;
    Inventory inventory;
    InventorySlot[] slots;

    // Start is called before the first frame update
    private void Awake()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.GJ1_Events.TOGGLE_INVENTORY, this.CheckInventory);
        animator.SetBool("isActive", isActive);
    }

    void Start()
    {
        inventory = Inventory.Instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInv();
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveAllObservers();
    }

    public void CheckInv()
    {
        Parameters updateLineParams = new Parameters();
        EventBroadcaster.Instance.PostEvent(EventNames.GJ1_Events.TOGGLE_INVENTORY);
    }

    private void CheckInventory()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            isActive = !isActive;
            animator.SetBool("isActive", isActive);
        }
    }

    void UpdateUI()
    {
        Debug.Log("Updating UI");
        for (int i = 0; i < slots.Length; i++)
        {
            if(i <inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
