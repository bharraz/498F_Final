using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score=0;
    int numCollected=0;
    int uniqueCollected=0;
    bool collectedGold = false;
    bool collectedSilver = false;
    bool collectedBronze = false;
    public TextMesh outputText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.H)){
            RaycastHit result;
            if (Physics.Raycast(this.gameObject.transform.position,this.gameObject.transform.forward,out result, Mathf.Infinity)){
                print("My ray hit: "+result.collider.gameObject.name);
                addScore(result.collider.GetComponent<Renderer>().material.name);
                Destroy(result.collider.gameObject);
            }
        }



        if (uniqueCollected == 3) {
           outputText.text = "YOU WIN! Bahaa";
        } else {
            outputText.text = $"total score: {score}\ntotal objects collected: {numCollected}\ntotal unique objects collected: {uniqueCollected}";
        }
    }
    void GetScore() {
        print("asd");
    }

    void OnTriggerEnter(Collider other){
        print("I, "+this.gameObject.name+" overlapped another collectible called "+other.gameObject.name);
        addScore(other.GetComponent<Renderer>().material.name);
    }

    void addScore(string materialName) {
        if (materialName == "Gold (Instance)") {
            score += 3;;
            numCollected += 1;
            if (!collectedGold) {
                uniqueCollected += 1;
                collectedGold = true;
            }
        } else if (materialName == "Silver (Instance)") {
            score += 2;
            numCollected += 1;
            if (!collectedSilver) {
                uniqueCollected += 1;
                collectedSilver = true;
            }
        } else {
            score += 1;
            numCollected += 1;
            if (!collectedBronze) {
                uniqueCollected += 1;
                collectedBronze = true;
            }
        }
 
    }


}
