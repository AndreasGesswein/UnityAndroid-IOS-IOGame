using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] public float speed;
    private Vector3 input;
    [SerializeField] private Slider yellowSlider;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (yellowSlider.value > 0)
        {
            // float horizontalMove = joystick.Horizontal;
            // float verticalMove = joystick.Vertical;
            input = new Vector3(joystick.Horizontal, joystick.Vertical).normalized;
            Vector3 velocity = input.normalized * speed;
            // transform.Translate(direction * 0.2f, Space.World);
            transform.position += velocity * Time.deltaTime;
            yellowSlider.value -= 0.005f;
        }
    }
}
