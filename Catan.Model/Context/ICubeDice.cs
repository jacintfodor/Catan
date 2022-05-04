namespace Catan.Model.Context
{
    public interface ICubeDice
    {
        int RolledValue { get; }

        void roll();
    }
}