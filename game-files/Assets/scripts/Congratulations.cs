using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Congratulations : MonoBehaviour
{
    // Start is called before the first frame update
    public void setup()
    {
        gameObject.SetActive(true);
    }


    public void ExitButton()
    {
        SceneManager.LoadScene("Minting");

    }
}
