﻿using UnityEngine;

public class Gun : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    public Camera fpsCam;
    public ParticleSystem Flash01;
    public GameObject impactEffect;

    private float nextTimeToFire = 0f;

    private AudioSource mAudioSrc;

    private void Start()
    {
        mAudioSrc = GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    void Update () {
	
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            mAudioSrc.Play();
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
	}
    
    void Shoot ()
    {
        Flash01.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
