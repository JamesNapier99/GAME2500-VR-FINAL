﻿using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Arrow : XRGrabInteractable
{
    public float speed = 2000.0f;
    public Transform tip = null;

    private bool inAir = false;
    private Vector3 lastPosition = Vector3.zero;

    private Rigidbody rigidBody = null;

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
            GameObject nearest=null;
                foreach (GameObject person in people)
                {
                Vector3 personPosition = person.transform.position;
                float distance = Vector3.Distance(tip.position, personPosition);
                if (distance < 3)
                    {
                    if (distance < currentmin)
                    {
                        nearest = person;
                    }
                }
            }
            if (nearest!=null)
            {
              //  nearest.transform.position = new Vector3(0, 0, 10);
                nearest.GetComponent<Test_script>().shot();
                nearest.GetComponent<Test_script>().enabled = false;
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
