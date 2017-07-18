using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
    public int count;

    public void Start()
    {
        count = 5;
    }

    public void LookAt(Vector3 point)
    {
        Vector3 heightCorrectedPoint = new Vector3(point.x, transform.position.y, point.z);
        transform.LookAt(heightCorrectedPoint);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Sphere(Clone)")
        {
            Destroy(other.gameObject);
            count -=  1;
        }
    }

}
