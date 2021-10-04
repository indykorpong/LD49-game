using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextItemDisplayer : MonoBehaviour
{
    [SerializeField] private Image _image;
    
    public void ShowNextItem(Sprite _item)
    {
        var _rect = _image.GetComponent<RectTransform>();
        
        _image.sprite = _item;
        _rect.sizeDelta = _item.rect.size;
        UIUtilities.SetPreferredSize(_rect, 160f);
    }
}
