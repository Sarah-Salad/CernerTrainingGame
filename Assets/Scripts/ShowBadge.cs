using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowBadge : MonoBehaviour
{
    // Start is called before the first frame update
    public string sceneToLoad;
    
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        StartCoroutine(ShowCredits());
    }

    private IEnumerator ShowCredits() {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(sceneToLoad);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
