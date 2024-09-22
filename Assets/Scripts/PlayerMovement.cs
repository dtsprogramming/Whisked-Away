using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float moveSpeed = 5f;

    [Header("Projectile Weapon")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firepoint;
    [SerializeField] private float projectileSpeed = 5f;

    private float flipDir = 1.2f;

    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            float screenHeight = Screen.height;

            // Calculate if the click is in the upper or lower part of the screen
            if (mousePos.y > screenHeight / 2)
            {
                FireWeapon(); // Fire weapon if click is in the upper half
            }
            else
            {
                FlipPlayer(); // Flip direction if click is in the lower half
            }
        }
    }

    private void FireWeapon()
    {
        GameObject projectile = Instantiate(projectilePrefab, firepoint.transform.position, Quaternion.identity);

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        mousePos.z = transform.position.z;

        Vector2 direction = (mousePos - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public void FlipPlayer()
    {
        flipDir *= -1;
        transform.localScale = new Vector3(flipDir, 1.2f, 1.2f);

        moveSpeed *= -1;
    }
}
