using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    //Pantalla en negro 
    public Image blackBackground;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    // Start is called before the first frame update
    public void Exit()
    {
        Application.Quit();
    }
    public void LoadScene(int _scene)
    {
        Time.timeScale = 1;
        StartCoroutine(FadeOut(_scene));
    }

    IEnumerator FadeIn()
    {
        Color c = blackBackground.color;
        for (float alpha = 1f; alpha>=0; alpha-=2f*Time.deltaTime)
        {
            c.a = alpha;
            blackBackground.color = c;
            yield return null;
        }

    }

    IEnumerator FadeOut(int _scene)
    {
        Color c = blackBackground.color;
        for (float alpha = 0f; alpha < 1; alpha += 1f * Time.deltaTime)
        {
            c.a = alpha;
            blackBackground.color = c;
            yield return null;
        }

        SceneManager.LoadScene(_scene);
        
    }
}
