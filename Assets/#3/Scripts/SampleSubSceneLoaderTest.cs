using System.Collections;
using UnityEngine;
using Unity.Entities;
using Unity.Scenes;

namespace Lesson3
{
    public class SampleSubSceneLoaderTest : MonoBehaviour
    {
        public SubScene subSceneToLoad;

        private SceneSystem sceneSystem;

        private Entity subScene;

        private void Start()
        {
            sceneSystem = World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<SceneSystem>();

            LoadSubScene();
        }

        private void LoadSubScene()
        {
            Debug.Log("Start loading SubScene...");

            var loadParameters = new SceneSystem.LoadParameters
            {
                Flags = SceneLoadFlags.NewInstance
            };

            subScene = sceneSystem.LoadSceneAsync(subSceneToLoad.SceneGUID, loadParameters);

            StartCoroutine(CheckScene());
        }


        IEnumerator CheckScene()
        {
            while(!sceneSystem.IsSceneLoaded(subScene))
            {
                yield return null;
            }

            Debug.Log("SubScene loaded.");
        }
    }
}