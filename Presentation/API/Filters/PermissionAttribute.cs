namespace API.Filters
{
    public class PermissionAttribute: Attribute
    {
        public string[] _permissions { get; set; }

        public PermissionAttribute(params string[] permissions)
        {
            _permissions = permissions; 
        }

        
    }
}
