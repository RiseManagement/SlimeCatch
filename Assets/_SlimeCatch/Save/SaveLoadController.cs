using System.Collections.Generic;

namespace _SlimeCatch.Save
{
    public class SaveLoadController : ISaveController,ILoadController
    {
        private readonly List<bool> _stageClearDataList = new List<bool>();
        private const int StageMaxCount = 6;

        public List<bool> GetStageClearList()
        {
            for (var stageIndex = 1; stageIndex <= StageMaxCount; stageIndex++)
            {
                _stageClearDataList.Add(SaveHandler.Load(stageIndex));
            }

            return _stageClearDataList;
        }

        public void Save(int stageNo,bool isClear)
        {
            SaveHandler.Save(stageNo,isClear);
        }
    }
}