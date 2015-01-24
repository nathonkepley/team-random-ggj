using UnityEngine;
using System.Collections;

public class CS_RandomNumber : MonoBehaviour 
{
	public int [] numbers = new int[25];
	string usedNumbers = "-";

	public bool isTouched = false;

	public GameObject text;



	void Awake () 
	{
	for (int i = 0 ; i < 25; i++)
		{
			int randomNumber = Random.Range(0,25);

	while(usedNumbers.Contains("-" + randomNumber.ToString()+"-"))
				{
					randomNumber = Random.Range(0,25 );
				}
				usedNumbers += randomNumber.ToString()+"-";
				numbers[i] = randomNumber;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag =="Player")
		{
			isTouched = true;
			//text.SetActive (true);
		}
	}


}
