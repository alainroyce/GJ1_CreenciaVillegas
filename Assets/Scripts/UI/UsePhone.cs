using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsePhone : MonoBehaviour
{
    [SerializeField] private Animator animator;

    bool isActive = false;

    private void Awake()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.GJ1_Events.TOGGLE_PHONE, this.CheckPhone);
    }

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("isActive", isActive);
    }

    // Update is called once per frame
    void Update()
    {
        CheckPh();
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveAllObservers();
    }

    public void CheckPh()
    {
        Parameters updateLineParams = new Parameters();
        EventBroadcaster.Instance.PostEvent(EventNames.GJ1_Events.TOGGLE_PHONE);
    }

    private void CheckPhone()
    {
        if (Input.GetButtonDown("Phone"))
        {
            isActive = !isActive;
            animator.SetBool("isActive", isActive);
        }
    }
}
