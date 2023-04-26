//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Experimental.Rendering.Universal;

//[RequireComponent(typeof(SpriteRenderer))]
//public class AgentRenderer : MonoBehaviour
//{
//    [SerializeField]
//    private float _rotationSpeed = 30;

//    [SerializeField]
//    private Transform _light = null;
//    private SpriteRenderer _spriteRenderer;

//    private void Awake()
//    {
//        _spriteRenderer = GetComponent<SpriteRenderer>();
//    }

//    public void FaceDirection(Vector2 pointerInput)
//    {
//        var direction = (Vector3)pointerInput - transform.position;
//        var result = Vector3.Cross(Vector2.up, direction);

//        bool flip = result.z > 0 ? true : false;
//        _spriteRenderer.flipX = flip;

//        // Light rotation
//        if (_light == null)
//            return;

//        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
//        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
//        _light.transform.rotation = Quaternion.Lerp(_light.transform.rotation, rot, _rotationSpeed * Time.deltaTime);
//    }
//}
