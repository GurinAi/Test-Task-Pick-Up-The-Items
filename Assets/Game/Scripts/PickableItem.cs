using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PickableItem : MonoBehaviour
{
    [SerializeField] ItemScriptableObject itemData;

    public Rigidbody Rb => rb;
    public Collider ItemCollider => itemCollider;

    private Rigidbody rb;
    private Collider itemCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        itemCollider = GetComponent<Collider>();
    }
}