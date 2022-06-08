using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTrainingCenter.PageObjects.Interfaces
{
    public interface ILoginPage : IPage
    {
        public ILoginPage Login(object emailBy, object passwordBy);
        public ILoginPage Register(object loginInfo);
    }
}
