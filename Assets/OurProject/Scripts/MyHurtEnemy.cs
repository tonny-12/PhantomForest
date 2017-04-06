using UnityEngine;

public class MyHurtEnemy : MonoBehaviour {

    public int damageToGive;
    public GameObject damageBurst;

    public GameObject damageNumber;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<MyEnemyHealth>().HurtEnemy(damageToGive);
            Instantiate(damageBurst, transform.position, transform.rotation);
            var clone = (GameObject) Instantiate(damageNumber, transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<MyFloatingNumbers>().damageNumber = damageToGive;
        }
    }
}
