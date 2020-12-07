using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Arrow : XRGrabInteractable
{
    public float speed = 2000.0f;
    public Transform tip = null;

    private bool inAir = false;
    private Vector3 lastPosition = Vector3.zero;

    private Rigidbody rigidBody = null;
    GameObject nearest=null;
    public bool first=false;


    protected override void Awake()
    {
        base.Awake();
        rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (inAir)
        {

            CheckForCollision();
            lastPosition = tip.position;

        }
    }

    private void CheckForCollision()
    {
        if (Physics.Linecast(lastPosition, tip.position))
        {
            Stop();
            GameObject[] people = GameObject.FindGameObjectsWithTag("person");
            //change to while no one has been hit, should only hit one person even if in same spot
            int currentmin = 1000;
            foreach (GameObject person in people)
            {
                Vector3 personPosition = person.transform.position+ new Vector3(0,1,0);
                float distance = Vector3.Distance(tip.position, personPosition);
                if (distance < 1 && person.GetComponent<ishit>().isPersonhit() == false)
                {
                    if (distance < currentmin)
                    {
                        nearest = person;
                    }
                }
            }
            if (nearest != null)
            {
                nearest.GetComponent<Test_script>().shot();
                if (gameObject.name.Contains("Arrow_R"))
                {
                    string name = nearest.name;
                    GameObject.Find("arrowtracker").GetComponent<countofHitstuff>().aNewHit(name, 1);
                    nearest.GetComponent<ishit>().personishit();
                }
                else if (gameObject.name.Contains("Arrow_Y"))
                {
           
                    GameObject.Find("arrowtracker").GetComponent<countofHitstuff>().aNewHit(name, 2);
                    nearest.GetComponent<ishit>().personishit();
                }
                else if (gameObject.name.Contains("Arrow_G"))
                {
                    nearest.SetActive(false);
                    GameObject.Find("arrowtracker").GetComponent<countofHitstuff>().aNewHit(name, 3);
                    nearest.GetComponent<ishit>().personishit();
                }
                else if (gameObject.name.Contains("Arrow_B"))
                {
                    GameObject.Find("arrowtracker").GetComponent<countofHitstuff>().aNewHit(name, 4);
                    nearest.GetComponent<ishit>().personishit();
                }
            }

        }
    }

    private void Stop()
    {
        inAir = false;
        SetPhysics(false);
    }

    public void Release(float pullValue)
    {
        inAir = true;
        SetPhysics(true);

        MaskAndFire(pullValue);
        StartCoroutine(RotateWithVelocity());

        lastPosition = tip.position;
    }

    private void SetPhysics(bool usePhysics)
    {
        rigidBody.isKinematic = !usePhysics;
        rigidBody.useGravity = usePhysics;
    }

    private void MaskAndFire(float power)
    {
        colliders[0].enabled = false;
        interactionLayerMask = 1 << LayerMask.NameToLayer("Ignore");

        Vector3 force = transform.forward * (power * speed);
        rigidBody.AddForce(force);
    }

    private IEnumerator RotateWithVelocity()
    {
        yield return new WaitForFixedUpdate();

        while (inAir)
        {
            Quaternion newRotation = Quaternion.LookRotation(rigidBody.velocity, transform.up);
            transform.rotation = newRotation;
            yield return null;
        }
    }

    public new void OnSelectEnter(XRBaseInteractor interactor)
    {
        base.OnSelectEnter(interactor);
    }

    public new void OnSelectExit(XRBaseInteractor interactor)
    {
        base.OnSelectExit(interactor);
    }
}
