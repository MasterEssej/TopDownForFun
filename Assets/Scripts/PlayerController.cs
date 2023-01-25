using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 10.0f;

    public int Score;

    private Alteruna.Avatar _avatar;
    private SpriteRenderer _renderer;

    void Start()
    {
        _avatar = GetComponent<Alteruna.Avatar>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_avatar.IsMe)
        {
            _renderer.color = Color.green;

            float xTranslation = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
            float yTranslation = Input.GetAxis("Vertical") * Speed * Time.deltaTime;

            Vector3 _translation = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0).normalized * Speed * Time.deltaTime;

            transform.Translate(xTranslation, yTranslation, 0, Space.Self);
        }
    }

}
