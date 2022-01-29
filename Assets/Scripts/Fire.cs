using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 0.5f;

    private float elapsedTime = 1.0f;
    
    // Update is called once per frame
    void Update()
    {
        elapsedTime = elapsedTime + Time.deltaTime;

        // Fire with mouse click
        if (Input.GetButton("FireMouse") && elapsedTime > fireRate)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos += Camera.main.transform.forward * 10f; // Make sure to add some "depth" to the screen point
            var bulletDirection = Camera.main.ScreenToWorldPoint(mousePos) - transform.position;

            GameObject newProjectile = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
            newProjectile.GetComponent<BulletBehavior>().direction = bulletDirection;
            elapsedTime = 0.0f;
        }

        // Fire with right stick
        else if ((Mathf.Abs(Input.GetAxis("RightStickFireY")) + Mathf.Abs(Input.GetAxis("RightStickFireX")) > 0.4f)  && elapsedTime > fireRate)
        {
            Vector3 bulletDirection = new Vector3(Input.GetAxis("RightStickFireX"), Input.GetAxis("RightStickFireY"));

            GameObject newProjectile = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
            newProjectile.GetComponent<BulletBehavior>().direction = bulletDirection;
            elapsedTime = 0.0f;
        }
    }
}
