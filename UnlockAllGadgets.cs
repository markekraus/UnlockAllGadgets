using Il2Cpp;
using MelonLoader;
using UnityEngine;

namespace UnlockAllGadgets
{
    internal class Entry : MelonMod
    {
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {

            if (!sceneName.Contains("zone") || sceneName == "zoneCore")
                return;
            var gadgetDirector = Utility.Get<GadgetDirector>("SceneContext").model;
            foreach (var item in Resources.FindObjectsOfTypeAll<GadgetDefinition>())
            {
                gadgetDirector.RegisterBlueprint(item);
                gadgetDirector.availBlueprints.Add(item);
                gadgetDirector.registeredBlueprints.Add(item);
                gadgetDirector.blueprints.Add(item);
                MelonLogger.Msg($"Registered '{item.name}'.");
            }
        }
    }
}
