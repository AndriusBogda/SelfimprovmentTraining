using SeleniumTrainingCenter.InfoObjects;

namespace SeleniumTrainingCenter.PageObjects.Interfaces
{
    public interface IRegisterPage : IPage
    {
        public IRegisterPage Register(Person person, UserAddress userAddress);
    }
}
