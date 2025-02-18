using IPTE.ITS.Dominio.ErroresDominio;

namespace IPTE.ITS.API
{
    public class Envelope
    {
        public object? Resultado { get; }
        public string? CodigoError {  get; }
        public string? MensajeError { get; }

        private Envelope(object? resultado, Error? error) 
        {
            Resultado = resultado;
            CodigoError = error?.Codigo;
            MensajeError = error?.Mensaje;
        }

        public static Envelope Ok(object? result = null)
        {
            return new Envelope(result, null);
        }

        public static Envelope Error(Error error)
        {
            return new Envelope(null, error);
        }
    }
}
