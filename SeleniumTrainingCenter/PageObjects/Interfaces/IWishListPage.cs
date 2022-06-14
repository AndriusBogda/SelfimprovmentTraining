namespace SeleniumTrainingCenter.PageObjects.Interfaces
{
    public interface IWishListPage
    {
        public bool AreThereAnyWishlists();
        public void AddNewWishlist(string wishlistName);
    }
}
