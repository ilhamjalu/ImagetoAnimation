using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using PathCreation;

public class ObjectScript : MonoBehaviour
{
    PathCreator pathCreator;
    public EndOfPathInstruction end;
    float speed, dis;
    public Quaternion quaternion;

    // Start is called before the first frame update
    void Start()
    {
        pathCreator = GameObject.Find("PathCreator " + gameObject.name).GetComponent<PathCreator>();
        speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += Vector3.forward * Time.deltaTime;

        MoveAuto();
        transform.localRotation = Quaternion.Euler(quaternion.x, quaternion.y, quaternion.z);
    }

    void MoveAuto()
    {
        dis += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(dis);
        //transform.localRotation = pathCreator.path.GetRotationAtDistance(dis);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.tag == "destroy")
    //    {
    //        Debug.Log("DEstroy");
    //        Destroy(gameObject);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "destroy")
        {
            Debug.Log("DEstroy");
            Destroy(gameObject);
        }
    }
}
