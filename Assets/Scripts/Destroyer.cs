using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class Destroyer : MonoBehaviour
{
    public float timeToKill = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = SceneManager.GetActiveScene().name;
        Destroy(this.gameObject, timeToKill);
    }
}
