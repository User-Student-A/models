using System.Collections;

using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject snowMan;

    private void Start() {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn() {
        while (true) {
            yield return new WaitForSeconds(3);
            float x = Random.Range(20, 80);
            float z = Random.Range(0, 40);
            var newSnowMan = Instantiate(snowMan, new Vector3(x, 1f, z), Quaternion.identity);
            var snowManComponent = newSnowMan.GetComponent<SnowMan>();
            if (snowManComponent != null) {
                snowManComponent.SetTarget(player);
            }
        }
    }
}