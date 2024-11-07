using Unity.VisualScripting;
using UnityEngine;

public class GunshipController : MonoBehaviour
{
    [SerializeField] private Transform leftCannon;
    [SerializeField] private Transform rightCannon;

    public GameObject cannonballPrefab;
    public float cannonballForce = 150f;

    [Header("shooting")]
    [SerializeField] private GameObject RightCanonBarrel;
    [SerializeField] private GameObject LeftCanonBarrel;

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        Vector3 leftDirection = AimCannon(mousePosition, leftCannon);
        Vector3 rightDirection = AimCannon(mousePosition, rightCannon);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireCannonball(leftDirection,leftCannon);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            FireCannonball(rightDirection, rightCannon);
        }
    }

    private Vector3 AimCannon(Vector3 target, Transform cannon)
    {
        Vector3 direction = target - cannon.position;
        direction.z = 0;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        cannon.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        return direction;
    }

    private void FireCannonball(Vector3 direction, Transform cannon)
    {
        GameObject cannoballObject = Instantiate(cannonballPrefab, cannon.position, Quaternion.identity);
        Rigidbody2D canonball = cannoballObject.GetComponent<Rigidbody2D>();
        canonball.AddForce(direction.normalized * cannonballForce, ForceMode2D.Force);

    }

}
