using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] string animationParameter;
    [SerializeField] Color positive;
    [SerializeField] Color negative;
    [SerializeField] bool right;
    bool ReadyToChange;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && ReadyToChange)
        {
            if (right)
            {
                StatManager.Instance.AddNewValuesPositive();
            }
            else
            {
                StatManager.Instance.AddNewValuesNegative();
            }
            animator.SetBool(animationParameter, true);
            SetStatColor(StatManager.Instance.currentStats.a, StatManager.Instance.a);
            SetStatColor(StatManager.Instance.currentStats.b, StatManager.Instance.b);
            SetStatColor(StatManager.Instance.currentStats.c, StatManager.Instance.c);
            SetStatColor(StatManager.Instance.currentStats.d, StatManager.Instance.d);
            ReadyToChange = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mouse"))
        {
            animator.SetBool(animationParameter, true);
            SetStatColor(StatManager.Instance.currentStats.a, StatManager.Instance.a);
            SetStatColor(StatManager.Instance.currentStats.b, StatManager.Instance.b);
            SetStatColor(StatManager.Instance.currentStats.c, StatManager.Instance.c);
            SetStatColor(StatManager.Instance.currentStats.d, StatManager.Instance.d);
            ReadyToChange = true;
        }
    }

    private void OnTriggerStay2D (Collider2D collision)
    {
        if (collision.CompareTag("Mouse"))
        {
            animator.SetBool(animationParameter, true);
            SetStatColor(StatManager.Instance.currentStats.a, StatManager.Instance.a);
            SetStatColor(StatManager.Instance.currentStats.b, StatManager.Instance.b);
            SetStatColor(StatManager.Instance.currentStats.c, StatManager.Instance.c);
            SetStatColor(StatManager.Instance.currentStats.d, StatManager.Instance.d);
            ReadyToChange = true;
        }
    }

    private void SetStatColor(int value, TMP_Text text)
    {
        text.color = value > 0
            ? positive
            : value < 0
                ? negative
                : Color.white;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Mouse"))
        {
            animator.SetBool(animationParameter, false);
                StatManager.Instance.a.color = Color.white;
                StatManager.Instance.b.color = Color.white;
                StatManager.Instance.c.color = Color.white;
                StatManager.Instance.d.color = Color.white;
            ReadyToChange = false;
        }
    }
}
