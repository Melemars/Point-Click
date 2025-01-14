using UnityEngine;

public class HintButton : MonoBehaviour
{

    [SerializeField] Sprite[] bookPagesHint;
    [SerializeField] private Book book;

    public void ChangePageHint() {
        book.bookPages[book.currentPage] = bookPagesHint[book.currentPage/2-1];
    }
}
