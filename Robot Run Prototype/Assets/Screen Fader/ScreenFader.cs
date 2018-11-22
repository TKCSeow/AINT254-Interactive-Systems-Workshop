using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFader : MonoBehaviour {

    Animator anim;
    bool isFading = false;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
    }
	
    public IEnumerator FadeToBlack()
    {
        
        isFading = true;
        anim.SetTrigger("FadeIn");

        while (isFading == true)
        {
            yield return null;
        }

        
    }

    public IEnumerator FadeToClear()
    {
        isFading = true;
        anim.SetTrigger("FadeOut");

        while (isFading == true)
        {
            yield return null;
        }
    }

	void AnimationComplete()
    {
        isFading = false;
    }
}
