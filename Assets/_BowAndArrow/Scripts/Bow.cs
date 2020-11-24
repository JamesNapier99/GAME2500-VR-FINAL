using System.Collections;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [Header("Assets ")]
    public GameObject ArrowPrefab = null;

    [Header("Bow")]
    public float GrabThreshold = 0.15f;
    public Transform m_Start = null;
    public Transform End = null;
    public Transform Socket = null;

    private Transform PullingHand = null;
    private Arrow CurrentArrow = null;
    private Animator Animator = null;

    private float PullValue = 0.0f;

    private void Awake()
    {

    }
    
    private void Start() 
    {
        StartCoroutine(CreateArrow(0.0f));
    }

    private void Update() 
    {
        if (!PullingHand || !CurrentArrow)
            return;

        PullValue = CalculatePull(PullingHand);
        PullValue = Mathf.Clamp(PullValue, 0.0f, 1.0f);

        Animator.SetFloat("Blend", PullValue);
    }

    private float CalculatePull(Transform pullHand) 
    {
        Vector3 direction = End.position - m_Start.position;
        float magnitude = direction.magnitude;

        direction.Normalize();
        Vector3 difference = pullHand.position - m_Start.position;

        return Vector3.Dot(difference, direction) / magnitude;
    }

    private IEnumerator CreateArrow(float waitTime) 
    {
        // wait 
        yield return new WaitForSeconds(waitTime);

        // create child
        GameObject arrowObject = Instantiate(ArrowPrefab, Socket);

        // Orient
        arrowObject.transform.localPosition = new Vector3(0, 0, 0.425f);
        arrowObject.transform.localEulerAngles = Vector3.zero;

        // Set
        CurrentArrow = arrowObject.GetComponent<Arrow>();

    }

    public void Pull(Transform hand) //uses vector3 as an interaction instead of a collider
    {
        float distance = Vector3.Distance(hand.position, m_Start.position);

        if (distance > GrabThreshold)
            return;
        PullingHand = hand;

    }

    public void Release() 
    {
        if (PullValue > 0.25f) // can change/tinker
            FireArrow();

        PullingHand = null;

        PullValue = 0.0f;
        Animator.SetFloat("Blend", 0);

        if (!CurrentArrow)
            StartCoroutine(CreateArrow(0.25f)); //play around with this for perfection
    }

    private void FireArrow() 
    {
        CurrentArrow.Fire(PullValue);
        CurrentArrow = null;
    }

}
