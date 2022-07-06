namespace SeleniumTrainingCenter.PageObjects.Interfaces
{
    public interface IPage
    {
        bool DoesElementExist(string xPath);

        void TakeScreenshot(string path);

        void Load(string url);
    }
}