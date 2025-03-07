//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class BonusGenerator : MonoBehaviour
//{
//    [SerializeField] private GameState _gameState;
//    private readonly List<BonusAttach> _levelBonuses = new List<BonusAttach>();
//    public GameDataScript gameData;


//    public void Generate()
//    {
//        _levelBonuses.Clear();  
//        foreach(var item in gameLevel.Bonuses)
//        {
//            BonusAttach bonusAttach = Instantiate(item, transform);
//            bonusAttach.transform.position = transform.position;
//            _levelBonuses.Add(bonusAttach);
//        }
//    }

//    private void Activate(Vector2 position)
//    {
//        if (_levelBonuses.Count > 0)
//        {
//            int index = Random.Range(0, _levelBonuses.Count);
//            _levelBonuses[index].transform.SetParent(null);
//            _levelBonuses[index].transform.position = position;
//            _levelBonuses[index].SetEnableAndVisual(true);
//            _levelBonuses.RemoveAt(index);
//        }
//    }


//    private void OnEable()
//    {
//        BlockScript.OnDestroyedPosition += BonusChance;
//    }

//    private void OnDisable()
//    {
//        BlockScript.OnDestroyedPosition -= BonusChance;
//    }

//    private void BonusChance(Vector2 positin)
//    {
//        if (_gameState.State == State.Gameplay)
//        {
//            var chance = Random.Range(0, 100);
//            if (chance > 10)
//            {
//                Activate(positin);
//            }
//        }
//    }
//}
