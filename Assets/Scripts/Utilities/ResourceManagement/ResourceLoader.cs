using Scriptables;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities.ResourceManagement
{
    public static class ResourceLoader
    {
        public static Sprite LoadSprite(ResourcePath path) =>
            LoadObject<Sprite>(path);

        public static GameObject LoadPrefab(ResourcePath path) =>
            LoadObject<GameObject>(path);

        public static GameObject[] LoadAllConfig<Pla>(ResourcePath path) =>
            LoadAllObject<GameObject>(path);

        public static TObject LoadObject<TObject>(ResourcePath path) where TObject : Object =>
            Resources.Load<TObject>(path.PathToResource);

        public static TConfig[] LoadAllObject<TConfig>(ResourcePath path) where TConfig : Object =>
            Resources.LoadAll<TConfig>(path.PathToResource);
    }
}