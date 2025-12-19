using UnityEngine;
using DG.Tweening;

public class GameBegin : MonoBehaviour
{
    public static GameBegin Instance;

    public GameObject plane;
    public GameObject[] cube;

    public GameObject finshObj;
    public GameObject[] text;

    private Vector3[] cubeGroundPos;

    [Header("Plane")]
    public float planeScaleDuration = 1.2f;
    public Vector3 planeTargetScale = new Vector3(1.5f, 0, 1.5f);
    public Vector3 planeRotate = new Vector3(0, 360, 0);

    [Header("Cube Drop")]
    public float dropHeight = 11f;
    public float dropDuration = 0.2f;

    public bool gameBegin = false;

    void Awake()
    {
        Instance = this;

        // Cache ground position
        cubeGroundPos = new Vector3[cube.Length];

        for (int i = 0; i < cube.Length; i++)
        {
            cubeGroundPos[i] = cube[i].transform.position;

            // 👉 ĐẶT CUBE LÊN TRỜI NGAY TỪ FRAME 0
            cube[i].transform.position =
                cubeGroundPos[i] + Vector3.up * dropHeight;
        }
    }

    void Start()
    {
        BeginAnimation();
    }

    public void BeginAnimation()
    {
        // Reset plane
        plane.transform.localScale = Vector3.one * 0.1f;
        plane.transform.rotation = Quaternion.identity;

        Sequence seq = DOTween.Sequence();

        seq.Append(
            plane.transform.DOScale(planeTargetScale, planeScaleDuration)
                .SetEase(Ease.OutBack)
        );

        seq.Join(
            plane.transform.DORotate(planeRotate, planeScaleDuration, RotateMode.FastBeyond360)
                .SetEase(Ease.OutCubic)
        );

        seq.AppendCallback(DropCubes);
        
    }

    void DropCubes()
    {
        for (int i = 0; i < cube.Length; i++)
        {
            float delay = Random.Range(0f, 0.3f);

            cube[i].transform.DOMoveY(cubeGroundPos[i].y, dropDuration)
                .SetDelay(delay)
                .SetEase(Ease.OutBounce);
        }

        Sequence seq = DOTween.Sequence();
        seq.SetDelay(1f);
        finshObj.SetActive(true);
        for (int i = 0; i < text.Length; i++)
        {
            text[i].SetActive(true);
        }
        gameBegin = true;
    }
}
