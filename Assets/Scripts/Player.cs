using UnityEngine;
using UnityEngine.SceneManagement;

namespace ColorSwitch
{
    public class Player : MonoBehaviour
    {
        public Rigidbody2D rigid2D;
        public SpriteRenderer spriteRend;

        public string currentColor;
        public float jumpForce = 10f;

        public Color colorCyan;
        public Color colorYellow;
        public Color colorMagenta;
        public Color colorPink;

        // Use this for initialization
        void Start ()
        {
            SetRandomColor();
        }

        // Update is called once per frame
        void Update ()
        {
            if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
            {
                rigid2D.velocity = Vector2.up * jumpForce;
            }
        }

        void OnTriggerEnter2D (Collider2D col)
        {
            if (col.tag == "ColorChanger")
            {
                SetRandomColor();

                Destroy(col.gameObject);

                return;
            }

            if (col.tag != currentColor)
            {
                Debug.Log("GAME OVER!");

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        void SetRandomColor ()
        {
            int index = Random.Range(0, 4);

            switch (index)
            {
                case 0:
                    currentColor = "Cyan";
                    spriteRend.color = colorCyan;
                    break;

                case 1:
                    currentColor = "Yellow";
                    spriteRend.color = colorYellow;
                    break;

                case 2:
                    currentColor = "Magenta";
                    spriteRend.color = colorMagenta;
                    break;

                case 3:
                    currentColor = "Pink";
                    spriteRend.color = colorPink;
                    break;
            }
        }
    }
}