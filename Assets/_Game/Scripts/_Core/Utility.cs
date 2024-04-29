using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
using System.Linq;

public static class Utility
{
    public static Vector3 ToRound(this Vector3 v3, float mul) => new Vector3(RoundTo(v3.x, mul), RoundTo(v3.y, mul), RoundTo(v3.z, mul));
    public static float RoundTo(this float value, float mul = 1) => Mathf.Round(value / mul) * mul;
    public static Vector3 RotateXYPlane(this Vector3 vector) => new Vector3(vector.y, -vector.x, 0);
    public static Vector3 RotateXZPlane(this Vector3 vector) => new Vector3(vector.z, 0, -vector.x);
    public static Vector3 RotateYZPlane(this Vector3 vector) => new Vector3(0, vector.z, -vector.y);
    public static Vector2 ToXZ(this Vector3 vector) => new Vector2(vector.x, vector.z);

    public static Vector3 V2ToX0Z(this Vector2 vector) => new Vector3(vector.x, 0, vector.y);
    public static Vector3 _X0Z(this Vector3 v) => new Vector3(v.x, 0, v.z);

    public static void _SetMaterialColorAlpha(this Material mat, float alpha) => mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, alpha);
    public static Color _SetColorAlpha(this Color c, float alpha) => new Color(c.r, c.g, c.b, alpha);

    public static Vector3 Abs(this Vector3 v) => new Vector3(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z));

    public static void SetLocalPosX(this Transform tra, float x) => tra.localPosition = new Vector3(x, tra.localPosition.y, tra.localPosition.z);
    public static void SetLocalPosY(this Transform tra, float y) => tra.localPosition = new Vector3(tra.localPosition.x, y, tra.localPosition.z);
    public static void SetLocalPosZ(this Transform tra, float z) => tra.localPosition = new Vector3(tra.localPosition.x, tra.localPosition.y, z);

    public static void SetPosX(this Transform tra, float x) => tra.position = new Vector3(x, tra.position.y, tra.position.z);
    public static void SetPosY(this Transform tra, float y) => tra.position = new Vector3(tra.position.x, y, tra.position.z);
    public static void SetPosZ(this Transform tra, float z) => tra.position = new Vector3(tra.position.x, tra.position.y, z);

    public static Vector3 SetPosX(this Vector3 v, float x) => new Vector3(x, v.y, v.z);
    public static Vector3 SetPosY(this Vector3 v, float y) => new Vector3(v.x, y, v.z);
    public static Vector3 SetPosZ(this Vector3 v, float z) => new Vector3(v.x, v.y, z);

    public static float Remap(this float value, float from1, float to1, float from2, float to2) => (value - from1) / (to1 - from1) * (to2 - from2) + from2;

    public static int GetActiveChildCount(this Transform transform)
    {
        int c = 0;
        for (int i = 0; i < transform.childCount; i++) if (transform.GetChild(i).gameObject.activeSelf) c++;
        return c;
    }

    public static float Sign(this float value)
    {
        if (value < 0) return -1;
        else if (value > 0) return 1;
        return 0;
    }

    public static int Sign(this int value)
    {
        if (value < 0) return -1;
        else if (value > 0) return 1;
        return 0;
    }

    public enum DegreeSpace { xy, xz }
    public static float FindDegree(Vector3 v, DegreeSpace space = DegreeSpace.xy)
    {
        float angle = space == DegreeSpace.xy ? Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg : Mathf.Atan2(v.x, v.z) * Mathf.Rad2Deg;
        if (angle < 0) angle += 360;
        return angle;
    }

    public static void Foreach<T>(this IEnumerable<T> aaa, Action<int, T> action)
    {
        int i = 0;
        foreach (var item in aaa) action(++i, item);
    }

    public static void Foreach<T>(this IEnumerable<T> aaa, Action<T> action)
    {
        foreach (var item in aaa) action(item);
    }

    public static RaycastHit RaycastWithCam(Camera cam, out RaycastHit hit, float maxDistance, LayerMask layerMask)
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit, maxDistance, layerMask);
        return hit;
    }

    public static RaycastHit RaycastWithCam(Camera cam, out RaycastHit hit, float maxDistance)
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit, maxDistance);
        return hit;
    }

    public static RaycastHit RaycastWithRay(Ray ray, out RaycastHit hit, float maxDistance, LayerMask layerMask)
    {
        Physics.Raycast(ray, out hit, maxDistance, layerMask);
        return hit;
    }

    public static RaycastHit RaycastWithRay(Ray ray, out RaycastHit hit, float maxDistance)
    {
        Physics.Raycast(ray, out hit, maxDistance);
        return hit;
    }

    public static Vector3 PlaneRaycast(Vector3 inNormal, Vector3 inPoint, Camera cam)
    {
        Plane plane = new Plane(inNormal, inPoint);
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        float rayDistance;
        if (plane.Raycast(ray, out rayDistance)) return ray.GetPoint(rayDistance);
        return Vector3.zero;
    }

    public static Vector3 PlaneRaycast(Vector3 inNormal, Vector3 inPoint, Ray ray)
    {
        Plane plane = new Plane(inNormal, inPoint);
        float rayDistance;
        if (plane.Raycast(ray, out rayDistance)) return ray.GetPoint(rayDistance);
        return Vector3.zero;
    }

    public static Tween RotateAroundTween(this Transform t, Vector3 pivot, Vector3 axis, int loops = 1, float targetAngle = 100, float duration = 1)
    {
        Vector3 rotVector = t.localPosition - pivot;
        float angle = 0;
        return DOTween.To(() => angle, x => angle = x, targetAngle, duration).SetLoops(loops).OnUpdate(() =>
        {
            t.localPosition = pivot + Quaternion.Euler(axis * angle) * rotVector;
        });
    }

    public static Tween DOTimeScale(float from, float to, float duration, Ease ease = Ease.InOutSine)
    {
        return DOTween.To(() => Time.timeScale, x => Time.timeScale = x, to, duration).From(from).SetEase(Ease.InOutSine).SetUpdate(true);
    }

    public static Tween GetEmptyTween(float duration)
    {
        float percent = 0;
        return DOTween.To(() => percent, x => percent = x, 1, duration);
    }

    public static Color RandomColor => new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value, 1);

    public static Color SetAlpha(this Color color, float alpha)
    {
        color.a = alpha;
        return color;
    }

    public static Rigidbody ResetRb(this Rigidbody rb)
    {
        rb.velocity = new Vector3(0f, 0f, 0f);
        rb.angularVelocity = new Vector3(0f, 0f, 0f);
        rb.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        return rb;
    }

    public static void KillMine(this Tween tween)
    {
        tween.Kill();
        tween = null;
    }

    public static bool IsPlayingMine(this Tween tween)
    {
        return tween != null && tween.IsActive() && tween.IsPlaying();
    }

    public static void DeleteJsonWithKey(string key)
    {
        string file = System.IO.Directory.GetFiles(Application.persistentDataPath).FirstOrDefault(x => x.EndsWith(key));
        if (file != null) System.IO.File.Delete(file);
    }

    public static T GetOrAddComponent<T>(this GameObject go) where T : Component
    {
        T component = go.GetComponent<T>();
        if (component == null) component = go.AddComponent<T>();
        return component;
    }
}