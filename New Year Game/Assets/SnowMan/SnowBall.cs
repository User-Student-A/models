using UnityEngine;

public class SnowBall : MonoBehaviour
{
    private int _damage;
    void Start() {
        _damage = Random.Range(10, 20);
    }
    private void OnCollisionEnter(Collision collision) {
        var snowMan = collision.gameObject.GetComponent<SnowMan>();
        if (snowMan != null) {
            Debug.Log("damage snowMan");
            snowMan.Damage(_damage);
        } else {
            var player = collision.gameObject.GetComponent<Player>();
            if (player != null) {
                Debug.Log("damage player");
                player.Damage(_damage);
            }
        }

        Destroy(gameObject);
    }
	
}