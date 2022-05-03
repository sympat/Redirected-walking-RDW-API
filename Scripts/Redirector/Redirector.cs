﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public enum GainType { Translation = 0, Rotation = 1, Curvature = 2, Undefined = -1 };

[Serializable]
public class Redirector
{
    public virtual (GainType, float) ApplyRedirection(RedirectedUnit unit, Vector2 deltaPosition, float deltaRotation) // virtualUser르 그대로 따라가는 Redirector
    {
        float degree = 0;
        GainType type = GainType.Undefined;

        if (deltaPosition.magnitude > 0.01f)
        {
            degree = deltaPosition.magnitude;
            type = GainType.Translation;
        }
        else if (Mathf.Abs(deltaRotation) > 0.01f)
        {
            degree = deltaRotation;
            type = GainType.Rotation;
        }
        else
        {
            type = GainType.Undefined;
        }

        return (type, degree);
    }

    public virtual Dictionary<string, float> GetResult() // Redirector로 인해 일어난 여러 결과들을 반환하는 함수
    {
        return new Dictionary<string, float>();
    }
}
