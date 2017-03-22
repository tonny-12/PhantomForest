using UnityEngine;
using UnityEngine.UI;

public class MyFloatingNumbers : MonoBehaviour {

    public float floatSpeed;
    public int damageNumber;
    public Text displayNumber;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        displayNumber.text = "" + damageNumber;
        transform.position = new Vector3(transform.position.x, transform.position.y + (floatSpeed * Time.deltaTime), transform.position.z);
	}
}
