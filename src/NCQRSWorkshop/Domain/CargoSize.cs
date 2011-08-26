using System;

namespace Domain
{
    public class CargoSize
    {
        /// <summary>
        /// Holds the actual value that represents the size.
        /// </summary>
        private float _actual;

        public CargoSize(float actual)
        {
            if(actual < 0f) throw new ArgumentOutOfRangeException("actual", actual, "A cargo size cannot be negative.");

            _actual = actual;
        }
    }
}
