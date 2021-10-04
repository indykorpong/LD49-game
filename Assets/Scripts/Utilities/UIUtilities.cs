using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUtilities : MonoBehaviour
{
    public static void SetPreferredSize(RectTransform _rect, float _preferredSize = 1024f)
    {
        var _scale = CalculateSpriteScale(_rect.sizeDelta, _preferredSize);
        _rect.sizeDelta *= _scale;
        _rect.anchoredPosition *= _scale;
    }
    
    
    private static float CalculateSpriteScale(Vector2 _originalSize, float _preferSize)
    {
        var _biggestAxis = _originalSize.x > _originalSize.y ? _originalSize.x : _originalSize.y;
        var _scale = _preferSize / _biggestAxis;
        return _scale;
    }
}
