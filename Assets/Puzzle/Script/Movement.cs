using UnityEngine;

public class Movement : MonoBehaviour
{
    public Quaternion rotacao;
    public Vector3 rot;

    GameControle _gameControle;

    void Start()
    {
        _gameControle = FindObjectOfType(typeof(GameControle)) as GameControle;
    }

    void Update()
    {
        if (!_gameControle.gameStarted) return;

        rotacao = transform.rotation;

        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Moved)
            {
                float valueTy = t.deltaPosition.y;
                float valueTz = t.deltaPosition.x;
                float valueMenor = -4f;
                float valueMax = 4f;

                if (valueTz >= valueMax)
                {
                    valueTz = valueMax;
                }
                if (valueTz <= valueMenor)
                {
                    valueTz = valueMenor;
                }
                if (valueTy <= valueMenor)
                {
                    valueTy = valueMenor;
                }
                if (valueTy >= valueMax)
                {
                    valueTy = valueMax;
                }
                rot = new Vector3(valueTy, 0.0f, valueTz * -1);

                transform.Rotate(rot * 5 * Time.deltaTime, Space.World);
            }
        }
    }

    void OnMouseDown()
    {
        transform.Rotate(rot * 5 * Time.deltaTime, Space.World);
    }
}
