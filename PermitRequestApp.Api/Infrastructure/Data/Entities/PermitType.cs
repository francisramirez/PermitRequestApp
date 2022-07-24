using PermitRequestApp.Api.Infrastructure.Data.Core;
namespace PermitRequestApp.Api.Infrastructure.Data.Entities
{
    /// <summary>
    /// Entity that represents the types of permissions
    /// </summary>
    public partial class PermitType : BaseEntity
    {
        /// <summary>
        /// Permit Description
        /// </summary>
        public string Description { get; set; }
    }
}
