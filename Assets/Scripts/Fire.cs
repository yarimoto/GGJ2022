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

        if (Input.GetButton("Fire1") && elapsedTime > fireRate)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos += Camera.main.transform.forward * 10f; // Make sure to add some "depth" to the screen point
            var aim = Camera.main.ScreenToWorldPoint(mousePos);

            Debug.Log("fire");
            GameObject newProjectile = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
            newProjectile.GetComponent<BulletBehavior>().direction = aim;
            elapsedTime = 0.0f;
        }
    }
}
