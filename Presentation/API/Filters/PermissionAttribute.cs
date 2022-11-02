namespace API.Filters
{
    public class PermissionAttribute: Attribute
    {
        public string _permissions { get; set; }

        public PermissionAttribute(string permissions)
        {
            _permissions = permissions; 
        }

        
    }
}
