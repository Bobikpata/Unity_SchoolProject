using UnityEngine;
using UnityEngine.UI;

public class SelectionArrow : MonoBehaviour
{
    [SerializeField] private RectTransform[] options;
    private RectTransform rect;
    private int currentPosition;
    [SerializeField] private int size;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangePosition(-1); //up means go backwards in options list
        }

        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangePosition(1); //down means go forward in options list
        }

        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.E)) //selected option, Keycode.Return is Enter
        {
            Interact();
        }
    }

    private void ChangePosition(int _change)
    {
        currentPosition += _change;

        if(currentPosition < 0) //if move up, but no more arrow is up there, sends to the lowest option
        {
            currentPosition = options.Length - 1;
        }
        else if (currentPosition > options.Length - 1) //if move down, but no more arrow is dwon there, sends to the highest option
        {
            currentPosition = 0;
        }

        rect.position = new Vector2(rect.position.x, options[currentPosition].position.y+size); // changes position of arrow
    }

    private void Interact()
    {
        options[currentPosition].GetComponent<Button>().onClick.Invoke();
    }
}
