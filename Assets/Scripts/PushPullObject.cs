using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PushPullObject : MonoBehaviour
{
    [Tooltip("Lock the direction an object can be moved.")]
    public bool lockPositionX;

    [Tooltip("Lock the direction an object can be moved.")]
    public bool lockPositionY;

    [Tooltip("Lock the direction an object can be moved.")]
    public bool lockPositionZ;


    private Rigidbody rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Release();
    }

    // Update is called once per frame
    private void Update()
    {
    }


    /// <summary>
    ///     Apply rigidbody constraints based on settings for
    ///     this PullPushObject. Rigidbody constraints are bitwise
    ///     flags, so multiple can be applied as below.
    ///     https://docs.unity3d.com/ScriptReference/Rigidbody-constraints.html
    /// </summary>
    public void Grab()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        if (lockPositionX) rb.constraints |= RigidbodyConstraints.FreezePositionX;
        if (lockPositionY) rb.constraints |= RigidbodyConstraints.FreezePositionY;
        if (lockPositionZ) rb.constraints |= RigidbodyConstraints.FreezePositionZ;
    }

    /// <summary>
    ///     Freeze rigidbody position and rotation.
    /// </summary>
    public void Release()
    {
        // Don't freeze Y-position so blocks can drop off edges.
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.constraints |= RigidbodyConstraints.FreezePositionX;
        rb.constraints |= RigidbodyConstraints.FreezePositionZ;
    }
}