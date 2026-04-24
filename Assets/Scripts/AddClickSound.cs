using UnityEngine;
using UnityEngine.UI;

public class AddClickSound : MonoBehaviour
{
    private AudioSource clickSound;

    private void Awake()
    {
        clickSound = GameObject.Find("UIClick").GetComponent<AudioSource>();

        Button[] buttons = FindObjectsOfType<Button>(true);

        foreach (Button btn in buttons)
        {
            btn.onClick.AddListener(() => clickSound.Play());
        }
    }
}