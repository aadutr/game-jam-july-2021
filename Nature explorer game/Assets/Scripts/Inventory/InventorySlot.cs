using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public KeyCode key;
    private Button button;
    private DialogueTrigger dialogTrig;
    
    Item item;

    void Start()
    {
        button = GetComponent<Button>();
        dialogTrig = GetComponent<DialogueTrigger>();
    }

    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            // Click the button
            FadeToColor(button.colors.pressedColor);
            button.onClick.Invoke();
        }
        else if (Input.GetKeyUp(key))
        {
            FadeToColor(button.colors.normalColor);
        }
    }

    void FadeToColor(Color color)
    {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, button.colors.fadeDuration, true, true);
    }

    public void AddItem ( Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot ()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
            dialogTrig.TriggerDialogue();
        }
    }
}
