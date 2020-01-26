using System.Collections.Generic;
using UnityEngine;

public class DeadEyeUI : MonoBehaviour {

    private static DeadEyeUI instance;

    [SerializeField] private Camera uiCamera;
    private Transform tagTemplateTransform;
    private List<DeadEyeTagUIObject> deadEyeTagUIObjectList;

    private void Awake() {
        instance = this;
        tagTemplateTransform = transform.Find("tagTemplateTransform");
        tagTemplateTransform.gameObject.SetActive(false);
        deadEyeTagUIObjectList = new List<DeadEyeTagUIObject>();
    }

    public static void DestroyAllTags() {
        foreach (DeadEyeTagUIObject deadEyeTagUIObject in instance.deadEyeTagUIObjectList) {
            deadEyeTagUIObject.DestroySelf();
        }
        instance.deadEyeTagUIObjectList.Clear();
    }

    public static void AddTag_Static(DeadEye.DeadEyeTag deadEyeTag) {
        instance.AddTag(deadEyeTag);
    }

    private void AddTag(DeadEye.DeadEyeTag deadEyeTag) {
        Transform tagTransform = Instantiate(tagTemplateTransform, transform);
        tagTransform.gameObject.SetActive(true);
        DeadEyeTagUIObject deadEyeTagUIObject = new DeadEyeTagUIObject(deadEyeTag, tagTransform, uiCamera);
        deadEyeTagUIObjectList.Add(deadEyeTagUIObject);
    }

    private void Update() {
        foreach (DeadEyeTagUIObject deadEyeTagUIObject in deadEyeTagUIObjectList) {
            deadEyeTagUIObject.Update();
        }
    }

    private class DeadEyeTagUIObject {

        private DeadEye.DeadEyeTag deadEyeTag;
        private Transform transform;
        private Camera uiCamera;

        public DeadEyeTagUIObject(DeadEye.DeadEyeTag deadEyeTag, Transform transform, Camera uiCamera) {
            this.deadEyeTag = deadEyeTag;
            this.transform = transform;
            this.uiCamera = uiCamera;
            Update();
        }

        public void Update() {
            Vector3 tagWorldPosition = deadEyeTag.GetPosition();
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(tagWorldPosition);
            Vector3 uiWorldPoint = uiCamera.ScreenToWorldPoint(screenPoint);
            Vector3 uiPoint = transform.parent.InverseTransformPoint(uiWorldPoint);
            uiPoint.z = 0f;
            transform.localPosition = uiPoint;
        }

        public void DestroySelf() {
            Destroy(transform.gameObject);
        }
    }

}
