using UnityEngine;
using Assets.Scripts.Timers;
using Assets.Scripts.Tokens;

namespace Assets.Scripts.Data
{
    public class TokenSpawnPoint : MonoBehaviour
    {
        private Token spawnItem;

        public void Init()
        {
            //Debug.Log(TokenSpawner.instance.Tokens.Count > 0);
            if (TokenSpawner.instance.Tokens.Count > 0)
            {
                RepetitionTimer t = gameObject.AddComponent<RepetitionTimer>();
                t.Initialize(5f, "Token Spawn Timer");
                t.TimeOut += new RepetitionTimer.TimerEvent(SpawnTokenHelper);
            }
        }

        private void SpawnTokenHelper(RepetitionTimer t)
        {
            if (!HasToken()) SpawnToken(TokenSpawner.instance.GetToken());
        }

        private bool HasToken()
        {
            return (spawnItem != null && spawnItem.gameObject.activeSelf);
        }

        private  void SpawnToken(GameObject tokenPrefab)
        {
            tokenPrefab.transform.position = transform.position;
            tokenPrefab.SetActive(true);
            spawnItem = tokenPrefab.GetComponent<Token>();
            //Instantiate(tokenPrefab, transform.position, transform.rotation);
        }
    }
}
