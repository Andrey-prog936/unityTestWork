using UnityEngine;

public class ControlPuzzle : MonoBehaviour
{
    public GameObject parentBoard;
    public GameObject form;
    public bool firstMove;
    private bool finish;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private Vector3 inputPositionOffset;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void OnMouseDown()
    {
        if (!firstMove)
        {
            firstMove = true;
            this.transform.localScale = new Vector2(1f, 1f);
            this.transform.SetParent(parentBoard.transform);
        }
        inputPositionOffset = gameObject.transform.position - GetMouseWorldPosition();
    }
    private void OnMouseDrag()
    {
        if (finish == false)
        {
            this.transform.position = GetMouseWorldPosition() + inputPositionOffset;
        }
    }
    private void OnMouseUp()
    {
        if (Mathf.Abs(this.transform.position.x - form.transform.position.x) <= 0.15f && Mathf.Abs(this.transform.position.y - form.transform.position.y) <= 0.15f)
        {
            this.transform.position = new Vector2(form.transform.position.x, form.transform.position.y);
            finish = true;
            YouWinS.AddElement();
            anim.Play("transparent");
            spriteRenderer.sortingOrder = spriteRenderer.sortingOrder - 1 ;
            this.gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }

}
