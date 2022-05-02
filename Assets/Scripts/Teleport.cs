using System;
using System.Collections;
using Cinemachine;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform endPoint;
    public Animator loadingScreen;

    private GameObject player;
    private CinemachineBrain cameraBrain;

    private void Start()
    {
        cameraBrain = Camera.main.GetComponent<CinemachineBrain>();
        player = GameObject.FindWithTag("Player");
        if (player == null)
            Debug.LogError("Player object not found! Did you tagged it correctly?");
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(TeleportCoroutine());
    }

    private IEnumerator TeleportCoroutine()
    {
        var activeCamera = cameraBrain.ActiveVirtualCamera;
        var loadingAnimator = Instantiate(loadingScreen);
        var animTime = loadingAnimator.GetCurrentAnimatorStateInfo(0).length;
        var startTime = Time.time;
        yield return new WaitUntil(() => Time.time > startTime + animTime);
        activeCamera.OnTargetObjectWarped(player.transform, endPoint.position - player.transform.position);
        player.transform.position = endPoint.position;
        player.transform.rotation = endPoint.rotation;
        loadingAnimator.SetTrigger("Disappear");
    }
}
