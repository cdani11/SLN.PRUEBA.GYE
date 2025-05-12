namespace COM.PRUEBA.QUERY.SERVICE.Model
{
    public partial class PruebaQueryContext
    {
        readonly PruebaQueryContextDP pruebaQueryContextDP;
        readonly PruebaQueryContextEF pruebaQueryContextEF;
        public PruebaQueryContext(PruebaQueryContextDP pruebaQueryContextDP, PruebaQueryContextEF pruebaQueryContextEF)
        {
            this.pruebaQueryContextDP = pruebaQueryContextDP;
            this.pruebaQueryContextEF = pruebaQueryContextEF;
        }
    }
}
