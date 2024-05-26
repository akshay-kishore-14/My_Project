public static class Connection
{
    private static string cName = "data source=AKSHAY\\SQLEXPRESS; Initial Catalog=MyProjectDB; persist security info=True; Integrated Security=SSPI; TrustServerCertificate=true";
    public static string CName
    {
        get => cName;
    }
}
