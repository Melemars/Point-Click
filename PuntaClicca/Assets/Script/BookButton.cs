using UnityEngine;

public class BookButton : MonoBehaviour
{
    public void BookCanvasAppear(GameObject BookCanvas)
    {
        GameHandler.OnCanvasAppear?.Invoke();
        BookCanvas.SetActive(true);
    }
}
