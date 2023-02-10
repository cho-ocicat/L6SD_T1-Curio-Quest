using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Fall : MonoBehaviour
{
    private float fallDelay = 0.7f;
    private float destroyDelay = 2f;

    [SerializeField] private Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")){
            //StartCoroutine method returns upon the first yield return, however you can yield the result, which waits until the coroutine has finished execution
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall(){
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyDelay);
    }
}
