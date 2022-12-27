using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform gun;
    [SerializeField] private Transform point;
    [SerializeField] private GameObject snowBall;
    [SerializeField] private float speed = 50f;

    [SerializeField] private int health = 100;

    private float _x;
    private float _y;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            var newSnowBall = Instantiate(snowBall, point.position, Quaternion.identity);
            var rb = newSnowBall.GetComponent<Rigidbody>();
            if (rb != null) {
                rb.AddForce(point.forward * speed, ForceMode.VelocityChange);
            }
        }

        _x += Input.GetAxis("Mouse X");
        _y += Input.GetAxis("Mouse Y") * -1;

        transform.localRotation = Quaternion.Euler(0, _x, 0);

        if (_y < 0 && _y < -85 && _y > -130) {
            gun.localRotation = Quaternion.Euler(_y, 0, 0);
        }
    }

    public void Damage(int damage) {
        health -= damage;
        if (health <= 0) {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void KilledEnemy()
    {
        health += 10;
    }
}