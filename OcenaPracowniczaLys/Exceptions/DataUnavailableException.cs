namespace OcenaPracowniczaLys.Exceptions;

public class DataUnavailableException : Exception
{
    public DataUnavailableException(Exception inner) 
        : base("Baza danych niedostępna.", inner) { }
}