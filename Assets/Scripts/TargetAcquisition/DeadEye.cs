using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using Utils;

public static class DeadEye {

    private const int TAG_AMOUNT_MAX = 5;

    private static PostProcessVolume blackWhitePostProcessVolume;
    private static bool deadEyeActive;
    private static List<DeadEyeTag> deadEyeTagList;
    private static Action<List<Vector3>> onDeadEyeEnd;

    public static void Init(PostProcessVolume blackWhitePostProcessVolume) {
        DeadEye.blackWhitePostProcessVolume = blackWhitePostProcessVolume;
        deadEyeActive = false;
        deadEyeTagList = new List<DeadEyeTag>();
    }

    public static void Start(Action<List<Vector3>> onDeadEyeEnd) {
        DeadEye.onDeadEyeEnd = onDeadEyeEnd;
        deadEyeTagList.Clear();
        AnimateBlackWhiteEffect(0f, 1f, 1f);
        AnimateTimeScaleEffect(1f, .15f, .6f);
        deadEyeActive = true;
    }

    public static void End() {
        AnimateBlackWhiteEffect(1f, 0f, 1f);
        AnimateTimeScaleEffect(.15f, 1f, .8f);
        deadEyeActive = false;
        DeadEyeUI.DestroyAllTags();
        List<Vector3> tagPositionList = new List<Vector3>();
        foreach (DeadEyeTag deadEyeTag in deadEyeTagList) {
            tagPositionList.Add(deadEyeTag.GetPosition());
        }
        onDeadEyeEnd(tagPositionList);
    }

    public static bool IsActive() {
        return deadEyeActive;
    }

    public static void TryAddTag(Func<Vector3> tagPositionFunc) {
        if (deadEyeTagList.Count < TAG_AMOUNT_MAX) {
            DeadEyeTag deadEyeTag = new DeadEyeTag(tagPositionFunc);
            deadEyeTagList.Add(deadEyeTag);
            DeadEyeUI.AddTag_Static(deadEyeTag);
        }
    }

    private static void AnimateBlackWhiteEffect(float start, float end, float animateTime) {
        float time = 0f;
        FunctionUpdater.Create(() => {
            time += Time.unscaledDeltaTime / animateTime;
            blackWhitePostProcessVolume.weight = Mathf.Lerp(start, end, time);
            return time >= 1f;
        });
    }
    
    private static void AnimateTimeScaleEffect(float start, float end, float animateTime) {
        float time = 0f;
        FunctionUpdater.Create(() => {
            time += Time.unscaledDeltaTime / animateTime;
            Time.timeScale = Mathf.Lerp(start, end, time);
            return time >= 1f;
        });
    }


    public class DeadEyeTag {

        private Func<Vector3> tagPositionFunc;

        public DeadEyeTag(Func<Vector3> tagPositionFunc) {
            this.tagPositionFunc = tagPositionFunc;
        }

        public Vector3 GetPosition() {
            return tagPositionFunc();
        }
    }
}
