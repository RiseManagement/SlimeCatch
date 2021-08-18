using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _SlimeCatch.Player
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class SlimeExtend : MonoBehaviour
    {
        private const float MScaleX = 2.677196f;
        [SerializeField] private ParentActiveBar parentActiveBar;
        private float _activeValue = 2f;
        private AngleRotation _angleRotation;
        private CollisionChange _collisionChange;
        private bool _isExtend;
        private bool _isRestore;
        private Camera _mainCamera;

        private BoxCollider2D _mCollider;
        private Vector3 _mMouseDownPosition = Vector3.zero;
        private Transform _transform;
        private float Max = 2f;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _collisionChange = GetComponent<CollisionChange>();
            _angleRotation = GetComponent<AngleRotation>();
            _mCollider = GetComponent<BoxCollider2D>();
        }

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            _activeValue = Mathf.Clamp(_activeValue, 0f, 2f);
            if (_isExtend && 0f < _activeValue)
            {
                _activeValue -= Time.deltaTime;
                SetScale();
            }
            else if (_activeValue <= 5f && _isRestore)
            {
                _activeValue += Time.deltaTime;
            }

            parentActiveBar.SetActiveValue(_activeValue);

            if (_activeValue <= 0f)
            {
                WaitRestoreEnergy();
            }
        }

        private void OnMouseDown()
        {
            // マウスクリックした際の初期位置を保存。
            _mMouseDownPosition = transform.position;
            _isExtend = true;
            _collisionChange.ChangeLayer(true);
            _isRestore = false;
        }

        private void OnMouseUp()
        {
            WaitRestoreEnergy();
        }

        private void SetScale()
        {
            var inputPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 9.5f);
            //スクリーン座標をワールド座標に変換する
            var mousePos = _mainCamera.ScreenToWorldPoint(inputPosition);
            _angleRotation.UpdateSlimeRotation(mousePos, _transform);
            var dist = Vector3.Distance(mousePos, _mMouseDownPosition);

            var distX = Mathf.Clamp(dist, 0.05f, 4.0f);
            var distDs = Mathf.Clamp(dist, 1.478829f, 1.641793f);

            transform.localScale = new Vector3(0.5f, distX, 0.5f);
            _mCollider.size = new Vector3(MScaleX, distDs);
        }

        private async void WaitRestoreEnergy()
        {
            _transform.position = _mMouseDownPosition;
            _transform.rotation = Quaternion.identity;
            _transform.localScale = Vector3.one;
            _collisionChange.ChangeLayer(false);
            _isExtend = false;
            await UniTask.Delay(TimeSpan.FromSeconds(2f));
            _isRestore = true;
        }
    }
}