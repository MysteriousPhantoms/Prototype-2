using UnityEngine;

public class WinScreenFade : MonoBehaviour
{
    private CanvasGroup cg;
    [SerializeField] private float fadeSpeed = 1.5f;

    void Awake()
    {
        cg = GetComponent<CanvasGroup>();
        cg.alpha = 0f;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }

    void Update()
    {
        if (cg.alpha < 1f)
        {
            cg.alpha += Time.deltaTime * fadeSpeed;

            if (cg.alpha >= 1f)
            {
                cg.interactable = true;
                cg.blocksRaycasts = true;
            }
        }
    }
}
