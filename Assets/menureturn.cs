using UnityEngine;
using UnityEngine.SceneManagement;

public class menureturn : MonoBehaviour
{
    private float back;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        back = 5;
    }

    // Update is called once per frame
    void Update()
    {
        back -= Time.deltaTime;
        if(back <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
