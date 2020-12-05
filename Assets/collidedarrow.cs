using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(CapsuleCollider))]
public class collidedarrow : MonoBehaviour
{
   public GameObject Lovechart;
    // Start is called before the first frame update
    void Start()
    {
        Lovechart.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

//this oncollision is not being triggered
    public void OnCollisionEnter(Collision collision)
    {
        Lovechart.SetActive(true);
        if (collision.gameObject.name.Contains("arrow"))
        {
            gameObject.GetComponent<Test_script>().enabled = false;
            
            gameObject.transform.position = new Vector3(0, 0,10);
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        Lovechart.SetActive(true);
    }



}
