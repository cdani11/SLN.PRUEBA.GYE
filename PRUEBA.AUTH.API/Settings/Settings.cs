namespace PRUEBA.AUTH.API.Settings
{
    public class Settings
    {
        public Settings()
        {
            GSEDOC_BR = new DBSettings();
            GSEDOC_BW = new DBSettings();
        }
        public DBSettings GSEDOC_BR { get; set; }
        public DBSettings GSEDOC_BW { get; set; }
        public Jwt Jwt { get; set; }
        public string UrlWebSitePortalConsulta { get; set; }
    }

    public class Jwt
    {
        public string? Key { get; set; }
        public string? Issuer { get; set; }
        public double? expires { get; set; }
    }

    public class DBSettings
    {
        public string? DataSource { get; set; }
        public string? InitialCatalog { get; set; }
        public string? UserId { get; set; }
        public string? Password { get; set; }
        public long Timeout { get; set; }
        public byte TipoORM { get; set; }
    }
}
