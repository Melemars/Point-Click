using System;
using UnityEngine;
using UnityEngine.UI;

public class BookButton : MonoBehaviour
{
    public static Action OnBookClose;

    [SerializeField] private Sprite BookOpen;
    [SerializeField] private Sprite BookClose;
    private Image buttonImg;

    private void OnEnable() {
        OnBookClose += BookClosing;
    }

    private void OnDisable() {
        OnBookClose -= BookClosing;
    }

    private void Start() {
        buttonImg = this.GetComponent<Image>();
    }

    public void BookCanvasAppear(GameObject BookCanvas)
    {
        GameHandler.OnCanvasAppear?.Invoke();
        BookCanvas.SetActive(true);
        buttonImg.sprite = BookOpen;
    }

    public void BookClosing(){
        buttonImg.sprite = BookClose;
    }
}
