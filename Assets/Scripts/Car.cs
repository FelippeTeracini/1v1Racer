using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20f;
    public string horizontalControl;
    public string accelarationControl;
    public string brakeControl;
    public int id;

    public int current_lap = 1;
    float torqueForce = -200f;
    float driftFactorSticky = 0.9f;
    float driftFactorSlippy = 1.05f;
    float maxStickyVelocity = 2.5f;
    float minSlippyVelocity = 1.5f;
    float driftFactor;

    public bool started = false;

    public AudioManager audioManager;
    public string accelerationAudio;

    ParticleSystem smoke_ps;

    void Start()
    {
        smoke_ps = transform.GetChild(0).transform.GetChild(0).GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (started)
        {
            if (Input.GetButton(accelarationControl))
            {
                if (!audioManager.IsPlaying(accelerationAudio))
                {
                    audioManager.Play(accelerationAudio);
                }
                if (!smoke_ps.isPlaying)
                {
                    smoke_ps.Play();
                }
            }
            if (Input.GetButtonUp(accelarationControl))
            {
                audioManager.Stop(accelerationAudio);
                smoke_ps.Stop();
            }
            if (Input.GetButton(brakeControl))
            {
                audioManager.Stop(accelerationAudio);
                smoke_ps.Stop();
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (started)
        {
            if (RightVelocity().magnitude > maxStickyVelocity && driftFactor == driftFactorSticky)
            {
                driftFactor = driftFactorSlippy;
            }
            else if (RightVelocity().magnitude < minSlippyVelocity && driftFactor == driftFactorSlippy)
            {
                driftFactor = driftFactorSticky;
            }
            else
            {
                driftFactor = driftFactorSticky;
            }

            rb.velocity = ForwardVelocity() + RightVelocity() * driftFactor;

            if (Input.GetButton(accelarationControl))
            {
                rb.AddForce(transform.up * speed);
            }

            if (Input.GetButton(brakeControl) && driftFactor == driftFactorSticky)
            {
                rb.AddForce(transform.up * -speed / 2);
            }

            float tf = Mathf.Lerp(0, torqueForce, rb.velocity.magnitude / 8);

            rb.angularVelocity = Input.GetAxis(horizontalControl) * tf;

            //Debug.Log(rb.velocity);
        }

    }

    Vector2 ForwardVelocity()
    {
        return transform.up * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.up);
    }

    Vector2 RightVelocity()
    {
        return transform.right * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.right);
    }


}
