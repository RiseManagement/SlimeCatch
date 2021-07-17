using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace _SlimeCatch.SelectStage
{
    public class StageIconView : MonoBehaviour
    {
        [SerializeField] private List<Button> stageIconList;

        public void SetInteractable(IEnumerable<bool> loadDataList)
        {
            foreach (var (data,index) in loadDataList.Select((data,index) => (data,index)))
            {
                stageIconList[index].interactable = data;
            }
        }
    }
}