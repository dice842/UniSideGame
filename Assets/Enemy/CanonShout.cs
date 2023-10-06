using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonShout : MonoBehaviour
{
    GameObject shell;
    float shootDelay = 5f;
    float countTime = 0;
    private void Start()
    {
        shell = transform.GetChild(0).gameObject;
        shell.SetActive(false);
    }
    private void Update()
    {
        if (shootDelay <= countTime)
            ShootShell();
        countTime += Time.deltaTime;
    }
    void ShootShell()
    {
        shell.SetActive(true);
        GameObject shellGO = Instantiate(shell);
        shellGO.transform.position = transform.position + new Vector3(1, 0.1f, 0);
        countTime = 0;
        shell.SetActive(false);
    }
}
