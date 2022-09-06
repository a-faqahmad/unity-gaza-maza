using UnityEngine;

public class collision : MonoBehaviour
{
    [SerializeField] private Material mazeMat;

    void OnCollisionEnter (Collision collisionInfo) {
        
        if (collisionInfo.collider.tag == "mazeWall") {
            
            mazeMat = collisionInfo.collider.GetComponent<Renderer>().material;
            if (mazeMat.color == Color.red)
                mazeMat.SetColor("_Color", Color.white);
            else
                mazeMat.SetColor("_Color", Color.red);
        }
        if (collisionInfo.collider.name == "Floor") {
            FindObjectOfType<GameManager>().BeginLevel();
        }
    }
}
