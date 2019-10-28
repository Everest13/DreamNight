using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour
{
    private float distToGround;

    public float forwardForce = 400f;
    public float upForce = 10f;
    public float sidewaysForce = 10f;

    public Collider playerCollider;
    public Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        distToGround = playerCollider.bounds.extents.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //доб. силу тв.телу
        //rigitBode.useGravity = false - чтобы не крутился
        playerRb.AddForce(0, 0, forwardForce * Time.deltaTime);

        //прыжок
        if (Input.GetKeyDown(KeyCode.W) && isUpForce())
        {
            playerRb.AddForce(0, upForce, forwardForce * Time.deltaTime);
        }

        //движение вправо, влево
        if (Input.GetKey(KeyCode.D)) //If the player is pressing "d" key
        {
            playerRb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.A)) //If the player is pressing "a" key
        {
            playerRb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }

    //проверяет расстояние до платформы
    //для допуска прыжка, чтобы не было doube jumps
    private bool isUpForce()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}
