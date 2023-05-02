using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

[RequireComponent(typeof(SpriteRenderer))]
public class AgentRenderer : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 30;

    [SerializeField]
    private Transform _parent;

    //[SerializeField]
    //private Transform _light = null;

    public void FaceDirection(Vector2 pointerInput)
    {
        var direction = (Vector3)pointerInput - transform.position;
        var result = Vector3.Cross(Vector2.up, direction);

        var rot = _parent.rotation;
        rot.y = result.z > 0 ? 180 : 0;
        _parent.rotation = rot;

        // Light rotation
        //if (_light is null)
        //    return;

        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
        //_light.transform.rotation = Quaternion.Lerp(_light.transform.rotation, rot, _rotationSpeed * Time.deltaTime);
    }
    
    //public void FaceDirection(Vector2 pointerInput)
    //{
    //    var direction = (Vector3)pointerInput - transform.position;
    //    var result = Vector3.Cross(Vector2.up, direction);

    //    _spriteRenderer.flipX = result.z > 0;

    //    //// Light rotation
    //    //if (_light == null)
    //    //    return;

    //    //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //    //Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
    //    //_light.transform.rotation = Quaternion.Lerp(_light.transform.rotation, rot, _rotationSpeed * Time.deltaTime);
    //}
}
