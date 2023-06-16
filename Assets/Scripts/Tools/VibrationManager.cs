using System.Collections;
using System.Collections.Generic;
using MoreMountains.NiceVibrations;
using UnityEngine;
#if UNITY_IOS
using UnityEngine.iOS;
#endif
public class VibrationManager : MonoBehaviour
{

    public static int mediumAmplitudeAtStart;
    public static int lightAmplitudeAtStart;
    public static int heavyAmplitudeAtStart;

    private void Start()
    {
        mediumAmplitudeAtStart = MMVibrationManager.MediumAmplitude;
        lightAmplitudeAtStart = MMVibrationManager.LightAmplitude;
        heavyAmplitudeAtStart = MMVibrationManager.HeavyAmplitude;
    }

    public static void ResetVibrations()
    {
        MMVibrationManager.MediumAmplitude = mediumAmplitudeAtStart;
        MMVibrationManager.LightAmplitude = lightAmplitudeAtStart;
        MMVibrationManager.HeavyAmplitude = heavyAmplitudeAtStart;
    }

    public static bool HapticsSupported()
    {
        bool hapticsSupported = false;
#if UNITY_IOS
        DeviceGeneration generation = Device.generation;
        if ((generation == DeviceGeneration.iPhone3G) ||
            (generation == DeviceGeneration.iPhone3GS) ||
            (generation == DeviceGeneration.iPodTouch1Gen) ||
            (generation == DeviceGeneration.iPodTouch2Gen) ||
            (generation == DeviceGeneration.iPodTouch3Gen) ||
            (generation == DeviceGeneration.iPodTouch4Gen) ||
            (generation == DeviceGeneration.iPhone4) ||
            (generation == DeviceGeneration.iPhone4S) ||
            (generation == DeviceGeneration.iPhone5) ||
            (generation == DeviceGeneration.iPhone5C) ||
            (generation == DeviceGeneration.iPhone5S) ||
            (generation == DeviceGeneration.iPhone6) ||
            (generation == DeviceGeneration.iPhone6Plus) ||
            (generation == DeviceGeneration.iPhone6S) ||
            (generation == DeviceGeneration.iPhoneSE1Gen) ||
            (generation == DeviceGeneration.iPhone6SPlus))
        {
            hapticsSupported = false;
        }
        else
        {
            hapticsSupported = true;
        }
#else
        // pour l'instant sur Android on considère que l'haptique est toujours supporté, on verra si on porte le jeu sur ces tel de pouilleux comment on règle ça
        hapticsSupported = true;
#endif
        return hapticsSupported;
    }

    private static int lastVibration = 0;
    private static bool VibrationEnabled()
    {
        if (HapticsSupported() && lastVibration != Time.frameCount)
        {
            lastVibration = Time.frameCount;
            return true;
        }
        else
        {
            return false;
        }

    }

    public static void VibrateSoft()
    {
        if (VibrationEnabled())
        {
            MMVibrationManager.Haptic(HapticTypes.SoftImpact);
        }
    }

    public static void VibrateLight()
    {
        if (VibrationEnabled())
        {
            MMVibrationManager.Haptic(HapticTypes.LightImpact);
        }
    }

    public static void VibrateMedium()
    {
        if (VibrationEnabled())
        {
            MMVibrationManager.MediumAmplitude += 15;
            MMVibrationManager.Haptic(HapticTypes.MediumImpact);
        }
    }

    public static void VibrateHeavy()
    {
        if (VibrationEnabled())
            MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
    }

    public static void VibrateSuccess()
    {
        if (VibrationEnabled())
            MMVibrationManager.Haptic(HapticTypes.Success);
    }

    public static void VibrateWarning()
    {
        if (VibrationEnabled())
            MMVibrationManager.Haptic(HapticTypes.Warning);
    }

    public static void VibrateFailure()
    {
        if (VibrationEnabled())
            MMVibrationManager.Haptic(HapticTypes.Failure);
    }

    public static void VibrateSelection()
    {
        if (VibrationEnabled())
            MMVibrationManager.Haptic(HapticTypes.Selection);
    }

}