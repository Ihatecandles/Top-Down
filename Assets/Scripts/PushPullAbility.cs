using UnityEngine;

[RequireComponent(typeof(CombinedCharacterController))]
public class PushPullAbility : MonoBehaviour
{
    [Tooltip("Key to use to grab and release an object.")]
    public KeyCode grabReleaseKey = KeyCode.E;

    [Range(1f, 5f)] [Tooltip("Max distance between the player and object before release.")]
    public float releaseDistance = 3f;

    private bool display;

    private PushPullObject holding;

    private HoldingState holdingState = HoldingState.Released;
    private bool keyDown;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        keyDown = Input.GetKeyDown(grabReleaseKey);

        switch (holdingState)
        {
            case HoldingState.Released:
                if (holding != null && keyDown)
                {
                    // print("Grabbed the object: " + holding.gameObject.name);
                    holdingState = HoldingState.Holding;
                    holding.Grab();
                    display = false;
                }
                else if(holding != null)
                {
                    holding.Release();
                }

                break;
            case HoldingState.Holding:
                if (keyDown || distance() > releaseDistance)
                {
                    // print("Released the object: " + holding.gameObject.name);
                    holdingState = HoldingState.Released;
                    holding.Release();
                    holding = null;
                }

                break;
        }

        if (holdingState == HoldingState.Holding && holding != null)
        {
            var mine = GetComponent<Rigidbody>();
            var theirs = holding.GetComponent<Rigidbody>();
            theirs.velocity = mine.velocity;
            mine.velocity = theirs.velocity;
        }
    }


    /// <summary>
    ///     A simple HUD readout to display pickup messages
    /// </summary>
    private void OnGUI()
    {
        if (display && holding)
            GUI.Box(new Rect(0, 0, 300, 30), $"Press {grabReleaseKey} to pick up {holding.gameObject.name}.");
    }

    private void OnTriggerEnter(Collider other)
    {
        display = true;
    }

    private void OnTriggerExit(Collider other)
    {
        display = false;
    }

    private void OnTriggerStay(Collider other)
    {
        var pushPullObject = other.gameObject.GetComponent<PushPullObject>();
        if (pushPullObject != null) holding = pushPullObject;
    }

    /// <summary>
    ///     Gets the distance between player and object.
    /// </summary>
    /// <returns></returns>
    private float distance()
    {
        if (holding != null) return Vector3.Distance(transform.position, holding.gameObject.transform.position);

        return 0f;
    }

    private enum HoldingState
    {
        Released,
        Holding
    }
}