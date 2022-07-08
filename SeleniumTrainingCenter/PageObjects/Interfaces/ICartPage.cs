using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTrainingCenter.PageObjects.Interfaces
{
    public interface ICartPage : IPage
    {
        public bool AreThreeItemsAdded();
    }
}
