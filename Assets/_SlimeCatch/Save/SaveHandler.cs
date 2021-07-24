using BayatGames.SaveGameFree;

namespace _SlimeCatch.Save
{
    public class SaveHandler
    {
        public static void Save(int stageNo,bool isClear)
        {
            SaveGame.Save($"stage{stageNo}",isClear);
        }

        public static bool Load(int stageNo)
        {
            return true;
            // if (SaveGame.Exists($"stage{stageNo}"))
            // {
            //     return SaveGame.Load<bool>($"stage{stageNo}");
            // }
            // else
            // {
            //     return false;
            // }
        }
    }
}