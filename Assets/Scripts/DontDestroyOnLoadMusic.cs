using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadMusic : MonoBehaviour {

	void Start()
	{
		DontDestroyOnLoad (gameObject);
	}
}
