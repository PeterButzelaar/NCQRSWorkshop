using System;

namespace Domain.Exceptions
{
    public class NotEnoughtCapacityLeftForCargoException : Exception
    {
        public NotEnoughtCapacityLeftForCargoException(Guid voyageId, float capacityLeftIncludingOverbook, Guid cargoId, float cargoSize) : base("There is not enough capacity left for this cargo")
        {
        }
    }
}