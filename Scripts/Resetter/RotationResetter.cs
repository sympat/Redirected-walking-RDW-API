﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RotationResetter : Resetter
{
    protected float rotationSpeed = 60.0f;
    protected float targetAngle;
    protected float ratio;
    private Vector2 realTargetRotation, virtualTargetRotation;

    public RotationResetter() : base() {}

    public override bool ApplyReset(Object2D realUser, Object2D virtualUser, Space2D realSpace)
    {
        if (isFirst)
        {
            realTargetRotation = Matrix3x3.CreateRotation(targetAngle) * realUser.transform.forward;
            virtualTargetRotation = Matrix3x3.CreateRotation(ratio * targetAngle) * virtualUser.transform.forward;
            isFirst = false;
        }

        float realAngle = Vector2.SignedAngle(realUser.transform.forward, realTargetRotation);

        if (Mathf.Abs(realAngle) >= epsilonRotation)
        {
            realUser.Rotate(rotationSpeed * Time.deltaTime);
            virtualUser.Rotate(ratio * rotationSpeed * Time.deltaTime);
        }
        else
        {

            Utility.SyncDirection(virtualUser, realUser, virtualTargetRotation, realTargetRotation);

            realUser.transform.position = realUser.transform.position + realUser.transform.forward * 1;
            if(realUser.gameObject != null) realUser.gameObject.transform.position = Utility.Cast2Dto3D(realUser.transform.position);

            //Utility.SyncPosition(virtualUser, realUser, virtualUser.transform.localPosition, newRealPosition);
            bool isNeedReset = NeedWallReset(realUser, realSpace);

            //Debug.Log(virtualUser.transform);
            //Debug.Log(realUser.transform);
            ////Debug.Log(virtualUser.gameObject.transform.localPosition);
            ////Debug.Log(realUser.gameObject.transform.localPosition);
            //Debug.Log(isNeedReset);

            //realUser.transform.position = realUser.transform.position + realUser.transform.forward * 0.1f; // 다시 리셋 상태에 빠지는 것을 방지
            isFirst = true;
            return true;
            //episode.DeleteTarget();
            //isFirst = true;
            //isFirst2 = true;
        }

        return false;
        //realUser.Rotate(rotationSpeed * Time.deltaTime);
        //virtualUser.Rotate(ratio * rotationSpeed * Time.deltaTime);

        //float realAngle = Vector2.SignedAngle(realUser.transform.forward, realTargetRotation);

        //if (realAngle < 0.1f)
        //{
        //    Utility.SyncDirection(virtualUser, realUser, virtualTargetRotation, realTargetRotation);
        //    realUser.transform.position = realUser.transform.position + realUser.transform.forward * 0.1f; // 다시 리셋 상태에 빠지는 것을 방지
        //    isFirst = true;
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}
    }
}
