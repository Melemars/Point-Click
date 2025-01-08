using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewItem", menuName = "ScriptableObjects/Items")]
public class ItemScriptableObject : ScriptableObject
{
    public int Id;
    public List<int> RequiredItemsId; //items Id required to pick up an item, if -1 is the only number in the list, is a simple pick up item 
    public List<string> InteractionPhrases; //list of phrases when player interact with an item or when player cannot pick an item up
    public string yesInteractionPhrase; //phrase when player can pick up or use an object 
    public string errorMinigamePhrase;
    public string InventoryImgTag;
    public Sprite characterSprite; //put null for main character portrait to appear
}
