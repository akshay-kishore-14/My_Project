public static class Connection
{
    private static string Name = "data source=AKSHAY\\SQLEXPRESS; Initial Catalog=MyProjectDB; persist security info=True; Integrated Security=SSPI; TrustServerCertificate=true";
    public static string CName
    {
        get => Name;
    }
} 
