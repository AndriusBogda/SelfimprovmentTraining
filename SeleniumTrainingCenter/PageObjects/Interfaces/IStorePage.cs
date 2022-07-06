namespace SeleniumTrainingCenter.PageObjects.Interfaces
{
    public interface IStorePage : IPage
    {
        public IStorePage AddItemToWishlist();
        public IStorePage AddThreeItemsToCart();
    }
}
