using SeleniumTrainingCenter.InfoObjects;

namespace SeleniumTrainingCenter.PageObjects.Interfaces
{
    public interface ILoginPage : IPage
    {
        public ILoginPage Login(Person person);
        public IRegisterPage Register(Person person);
    }
}
