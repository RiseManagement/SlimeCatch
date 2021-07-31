using UnityEngine;

namespace _SlimeCatch.Player
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class SlimeExtend : MonoBehaviour
    {
        private Vector3 _mMouseDownPosition = Vector3.zero;
        public bool gaugeEmpty;
        private bool _isExtend;
        private float _activeValue = 5f;
        private BoxCollider2D _mCollider;
        private const float MScaleX = 2.677196f;
        private CollisionChange _collisionChange;
        [SerializeField] private ParentActiveBar parentActiveBar;

        private void Awake()
        {
            _collisionChange = GetComponent<CollisionChange>();
            _mCollider = GetComponent<BoxCollider2D>();
        }

        private void Update()
        {
            if (_isExtend)
            {
                _activeValue -= Time.deltaTime;
            }
            else
            {
                if (_activeValue <= 5f)
                {
                    _activeValue += Time.deltaTime;
                }
                
            }
            parentActiveBar.SetActiveValue(_activeValue);
        }

        private void OnMouseDown()
        {
            // マウスクリックした際の初期位置を保存。
            _mMouseDownPosition = transform.position;
        }

        private void OnMouseDrag()
        {
            _isExtend = true;
            _collisionChange.ChangeLayer(true);
            if (gaugeEmpty)
            {
                transform.position = _mMouseDownPosition;
                transform.rotation = Quaternion.identity;
                transform.localScale = Vector3.one;
                return;
            }
            //マウスをドラッグしてる際の位置を取得
            var inputPosition   = new Vector3( Input.mousePosition.x, Input.mousePosition.y, 9.5f );
            //スクリーン座標をワールド座標に変換する
            var mousePos = Camera.main.ScreenToWorldPoint( inputPosition );
            var dist = Vector3.Distance( mousePos, _mMouseDownPosition );

            var distX = Mathf.Clamp(dist, 0.05f, 4.0f);
            var distDs = Mathf.Clamp(dist, 1.478829f, 1.641793f);

            transform.localScale    = new Vector3( 0.5f,distX ,0.5f  );
            _mCollider.size = new Vector3(MScaleX, distDs);
        }


        private void OnMouseUp()
        {
            _isExtend = false;
            _collisionChange.ChangeLayer(false);
            // 位置、回転、スケールを元に戻す。
            transform.position      = _mMouseDownPosition;
            transform.rotation      = Quaternion.identity;
            transform.localScale    = Vector3.one;
            gaugeEmpty = false;
        }
    }
}
