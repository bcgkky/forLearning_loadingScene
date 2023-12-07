using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sahneYonetim : MonoBehaviour
{
    public GameObject Loading;
    public Slider yuklemeSlider;
 
    public void SahneYukle (int LevelId)
    {
        StartCoroutine(SahneYuklemeAsamasi(LevelId));
    }

    IEnumerator SahneYuklemeAsamasi(int SceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);
        Loading.SetActive(true);
        

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            yuklemeSlider.value = progress;
            Debug.Log("progress : " +progress);
            Debug.Log("operation progress : " +operation.progress);
            yield return null;
        }
        
    }
}
