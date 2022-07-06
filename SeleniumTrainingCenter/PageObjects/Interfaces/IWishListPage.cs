namespace SeleniumTrainingCenter.PageObjects.Interfaces
{
    public interface IWishListPage : IPage
    {
        public bool AreThereAnyWishlists();
        public void AddNewWishlist(string wishlistName);
    }
}
