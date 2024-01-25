using UnityEngine;
using UnityEngine.UI;
using System.Text;
using DTT.MinigameMemory;

namespace DTT.MinigameMemory.Demo
{
    /// <summary>
    /// Manages the UI for the memory game.
    /// </summary>
    public class MemoryUIManager : MonoBehaviour
    {
        /// <summary>
        /// Used to get the state of the game.
        /// </summary>
        [SerializeField]
        private MemoryGameManager _gameManager;
        
        /// <summary>
        /// <see cref="FinishedMenu"/> used to display the game results.
        /// </summary>
        [SerializeField]
        private FinishedMenu _finishedMenu;

        /// <summary>
        /// Subscrive to game events.
        /// </summary>
        private void OnEnable()
        {
            _gameManager.Started += SetFinisedMenuInactive;
            _gameManager.Finish += SetFinisedMenuActive;
            
            _finishedMenu._homeButton.onClick.AddListener(Home);
        
        }

        /// <summary>
        /// Unsubscrive from game events.
        /// </summary>
        private void OnDisable()
        {
            _gameManager.Started -= SetFinisedMenuInactive;
            _gameManager.Finish -= SetFinisedMenuActive;
        }
        

        /// <summary>
        /// Sets the active state of the <see cref="FinishedMenu"/> gameobject to active.
        /// </summary>
        /// <param name="results">Results to be shown on the _finishedMenu.</param>
        private void SetFinisedMenuActive(MemoryGameResults results)
        {
            _finishedMenu.SetResultText(results);
            _finishedMenu.gameObject.SetActive(true);
        }

        /// <summary>
        /// Sets the active state of the <see cref="FinishedMenu"/> gameobject to inactive.
        /// </summary>
        private void SetFinisedMenuInactive() => _finishedMenu.gameObject.SetActive(false);

        /// <summary>
        /// Show home menu.
        /// </summary>
        private void Home()
        {
            Hide();
            _gameManager.Stop();
        }
        
        /// <summary>
        /// Hide menu UI.
        /// </summary>
        private void Hide()
        {
            SetFinisedMenuInactive();
        }
        
    }
}