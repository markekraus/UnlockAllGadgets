using System.Collections.Generic;
using System.Linq;
using Il2Cpp;
using MelonLoader;
using UnityEngine;

namespace UnlockAllGadgets
{
    public class Entry : MelonMod
    {
        private static HashSet<string> processedSaves = new ();
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {

            if (!sceneName.Contains("zone") || sceneName == "zoneCore")
                return;

            var savedGame = Utility.Get<GameContext>("GameContext").AutoSaveDirector.SavedGame.GameState.GameName;
            if (!processedSaves.Add(savedGame))
                return;

            var gadgetDirector = Utility.Get<GadgetDirector>("SceneContext");
            var gadgetGroup = Utility.Get<IdentifiableTypeGroup>("GadgetGroup");
            foreach (var group in gadgetGroup.memberGroups)
            {
                foreach (var gadget in group.memberTypes)
                {
                    gadgetDirector.AddBlueprint(gadget.Cast<GadgetDefinition>(), false);
                }
            }
        }
    }
}
