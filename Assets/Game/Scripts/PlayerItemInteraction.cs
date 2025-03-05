using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class PlayerItemInteraction : MonoBehaviour
{
    [SerializeField] Transform slot;

    [SerializeField] GameObject throwButton;

    [SerializeField] float rayLength = 5F;
    [SerializeField] float throwForce = 10f;

    private Camera characterCamera;
    private PickableItem pickedItem;
    
    private void Start()
    {
        if (pickedItem == null)
            HideThrowButton();
    }
    private void Awake()
    {
        characterCamera = Camera.main;
    }
    
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!pickedItem) 
            {
                var ray = characterCamera.ViewportPointToRay(Vector3.one * 0.5f);
                RaycastHit hit;

                Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.green);

                if (Physics.Raycast(ray, out hit, rayLength))
                {
                    var pickable = hit.transform.GetComponent<PickableItem>();
                    if (pickable)
{
                        pickedItem = pickable;
                        PickItem();
                    }
                }
            }
        }
    }
    private void PickItem()
    {
        pickedItem.Rb.isKinematic = true;
        pickedItem.Rb.velocity = Vector3.zero;
        pickedItem.Rb.angularVelocity = Vector3.zero;

        pickedItem.transform.SetParent(slot);
        pickedItem.transform.localPosition = Vector3.zero;
        pickedItem.transform.localEulerAngles = Vector3.zero;
        ShowThrowButton();
    }
    public void ThrowItem()
    {
        pickedItem.transform.SetParent(null);
        pickedItem.Rb.isKinematic = false;
        pickedItem.Rb.AddForce(pickedItem.transform.forward * throwForce, ForceMode.Impulse );
        pickedItem = null;
        HideThrowButton();
    }

    private void ShowThrowButton() => throwButton.SetActive(true);
    private void HideThrowButton() => throwButton.SetActive(false);

}