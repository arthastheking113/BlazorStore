using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorStore.Models;
namespace BlazorStore.Models
{
    public class AllItemStateModel
    {
        private List<Item> AllItem;
        //public event EventHandler StateChanged;
        public event Action<List<Item>> OnChange;

        public List<Item> GetCurrentAllItem()
        {
            return AllItem;
        }

        public void SetAllItemState(List<Item> items)
        {
            OnChange?.Invoke(items);
        }

        // This method will allow us to reset the current count
        public void ResetAllItemState()
        {
            AllItem = new List<Item>();
            OnChange?.Invoke(AllItem);
        }
        //private void StateHasChanged()
        //{
        //    // This will update any subscribers
        //    // that the counter state has changed
        //    // so they can update themselves
        //    // and show the current counter value
        //    //StateChanged?.Invoke(this, EventArgs.Empty);
        //    OnChange?.Invoke();
        //}
    }
}
