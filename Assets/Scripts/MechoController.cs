using UnityEngine;
using System.Collections;
using UnityEditor.Animations;

public class MechoController : MonoBehaviour
{
    public float speed = 1f;

    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Moving forward
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
            anim.SetBool("MoveFwd", true);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("MoveFwd", false);
        }

        //Moving backwards
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
            anim.SetBool("MoveBack", true);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("MoveBack", false);
        }
    }
}
