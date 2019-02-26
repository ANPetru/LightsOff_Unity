using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

    public Animator animator;
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayFadeAnim()
    {
        animator.SetTrigger("FadeOut");
    }

    public void LoadNewLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}
