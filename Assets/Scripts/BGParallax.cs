using UnityEngine;

public class BGParallax : MonoBehaviour
{
    Vector2 startPos;
    [SerializeField] int moveModifier;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        float posX = Mathf.Lerp(transform.position.x, startPos.x + (pos.x * moveModifier), 2f * Time.deltaTime);
        float posY = Mathf.Lerp(transform.position.y, startPos.y + (pos.y * moveModifier), 2f * Time.deltaTime);

        transform.position = new Vector3(posX, posY, 0f);
    }
}
