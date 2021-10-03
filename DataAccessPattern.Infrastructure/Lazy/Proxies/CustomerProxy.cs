using DataAccessPattern.Domain.Models;


namespace DataAccessPattern.Infrastructure.Lazy.Proxies
{
    public class CustomerProxy : Customer
    {

        public override byte[] ProfilePicture
        { 
            get
            {
                if(base.ProfilePicture == null)
                {
                    base.ProfilePicture = ProfilePictureService.GetFor(Name);
                }

                return base.ProfilePicture;
            }
        }
    }
}
