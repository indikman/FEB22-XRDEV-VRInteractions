using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Assertions;

public class FadeTeleportationProvider : TeleportationProvider
{
    public float fadeSpeed = 0.05f;
    public RawImage fader;

    private float timer = 0;

    
    void Start()
    {
        fader.color = Color.clear;
    }

    IEnumerator FadeIn(TeleportRequest teleportRequest)
    {
        timer = 0;

        while(timer < 1)
        {
            fader.color = Color.Lerp(Color.clear, Color.black, timer);
            timer += fadeSpeed;
            yield return new WaitForEndOfFrame();
        }

        currentRequest = teleportRequest;
        validRequest = true;
    }

    IEnumerator FadeOut()
    {
        timer = 0;

        while (timer < 1)
        {
            fader.color = Color.Lerp(Color.black, Color.clear, timer);
            timer += fadeSpeed;
            yield return new WaitForEndOfFrame();
        }

        EndLocomotion();
    }

    public override bool QueueTeleportRequest(TeleportRequest teleportRequest)
    {
        StartCoroutine(FadeIn(teleportRequest));

        return true;
    }

    protected override void Update()
    {
        if (!validRequest || !BeginLocomotion())
            return;

        var xrOrigin = system.xrOrigin;
        if (xrOrigin != null)
        {
            switch (currentRequest.matchOrientation)
            {
                case MatchOrientation.WorldSpaceUp:
                    xrOrigin.MatchOriginUp(Vector3.up);
                    break;
                case MatchOrientation.TargetUp:
                    xrOrigin.MatchOriginUp(currentRequest.destinationRotation * Vector3.up);
                    break;
                case MatchOrientation.TargetUpAndForward:
                    xrOrigin.MatchOriginUpCameraForward(currentRequest.destinationRotation * Vector3.up, currentRequest.destinationRotation * Vector3.forward);
                    break;
                case MatchOrientation.None:
                    // Change nothing. Maintain current origin rotation.
                    break;
                default:
                    Assert.IsTrue(false, $"Unhandled {nameof(MatchOrientation)}={currentRequest.matchOrientation}.");
                    break;
            }

            var heightAdjustment = xrOrigin.Origin.transform.up * xrOrigin.CameraInOriginSpaceHeight;

            var cameraDestination = currentRequest.destinationPosition + heightAdjustment;

            xrOrigin.MoveCameraToWorldLocation(cameraDestination);
        }


        StartCoroutine(FadeOut());

        
        validRequest = false;
    }
}
