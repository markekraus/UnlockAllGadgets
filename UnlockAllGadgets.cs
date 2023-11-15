using System.Collections.Generic;
using Il2Cpp;
using MelonLoader;
using UnityEngine;

namespace UnlockAllGadgets
{
    internal class Entry : MelonMod
    {
        private static HashSet<string> processedSaves = new ();
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {

            if (!sceneName.Contains("zone") || sceneName == "zoneCore")
                return;

            var savedGame = Utility.Get<GameContext>("GameContext").AutoSaveDirector.SavedGame.GameState.GameName;
            if (!processedSaves.Add(savedGame))
                return;

            var gadgetDirector = Utility.Get<GadgetDirector>("SceneContext")._model;
            foreach (var item in Resources.FindObjectsOfTypeAll<GadgetDefinition>())
            {
                gadgetDirector.RegisterBlueprint(item);
                gadgetDirector.availBlueprints.Add(item);
                gadgetDirector.registeredBlueprints.Add(item);
                gadgetDirector.blueprints.Add(item);
            }
        }
    }
}
