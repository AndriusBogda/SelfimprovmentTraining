using SeleniumTrainingCenter.InfoObjects;

namespace SeleniumTrainingCenter.PageObjects.Interfaces
{
    public interface ILoginPage : IPage
    {
        public ILoginPage Login(object emailBy, object passwordBy);
        public IRegisterPage Register(Person person);
    }
}
