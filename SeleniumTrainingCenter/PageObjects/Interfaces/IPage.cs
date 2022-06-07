namespace SeleniumTrainingCenter.PageObjects.PageInterfaces
{
    public interface IPage
    {
        bool DoesElementExist(string xPath);

        void TakeScreenshot(string path);
    }
}