namespace Catan.Model.Context
{
    public interface ICubeDice
    {
        /// <summary>
        /// Retur with the rolled number
        /// </summary>
        int RolledValue { get; }
        /// <summary>
        /// Rolling the cube
        /// </summary>
        void roll();
    }
}