/*
 * Date: 25/02/2023
 * Author: Johan Steven Jimenez Avendaño
 * Script for button animations
 *
 * Description:
 *
 * This script uses the DOTween plugin to animate buttons using the following functions:
 *
 * Scaling of the button when the mouse enters, and returning it to its original size when the mouse exits
 *
 * Animation when the button is clicked
 *
 */
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class TextAnimations : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Button button;                      // The button component attached to this object
    [SerializeField] private float scaleFactor = 1.2f;  // The amount the button scales up when hovered over
    [SerializeField] private float duration = 0.2f;     // The duration of the animation
    private Vector3 defaultScale;                // The default scale of the button

    private void Start()
    {
        button = this.GetComponent<Button>();
        defaultScale = button.transform.localScale;
    }

    // When the pointer enters the button, scale it up
    public void OnPointerEnter(PointerEventData eventData)
    {
        button.transform.DOScale(defaultScale * scaleFactor, duration);
    }

    // When the pointer exits the button, return it to its default scale
    public void OnPointerExit(PointerEventData eventData)
    {
        button.transform.DOScale(defaultScale, duration);
    }

    // When the button is clicked, punch the scale of the button inward
    public void OnPointerClick(PointerEventData eventData)
    {
        button.transform.DOPunchScale(defaultScale * 0.5f, duration, vibrato: 1, elasticity: 1f);
    }
}

