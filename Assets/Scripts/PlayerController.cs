using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Variables
    public float speed;
    public float minX, maxX, minY, maxY;
    public GameObject laser_1;
    public Transform laserSpawn;
    public float fireRateDelay = 0.25f;

    private Rigidbody2D rBody;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        
		rBody.velocity = new Vector2(horiz, vert) * speed;

        rBody.position = new Vector2(
             Mathf.Clamp(rBody.position.x, minX, maxX),
             Mathf.Clamp(rBody.position.y, minY, maxY));

        // horiz = x
        // 0 = y axis
        // 0.0f = z axis
    }
    void Update()
    {
        // Step.1 for user input
        if (Input.GetAxis("Fire1") > 0 && timer > fireRateDelay)
        {
            // Step 2. Create the object (instantiate)
            GameObject gObj = Instantiate(laser_1, laserSpawn.transform.position, laserSpawn.transform.rotation);
            gObj.transform.Rotate(0, 0, -90);

            // Reset timer 
            timer = 0f;
        }
        timer += Time.deltaTime;
    }
}
