using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Domain.Tests
{
    public class CargoSizeTests
    {
        [Test]
        public void It_can_never_be_negative()
        {
            TestDelegate creatingANegativeCargoSize = () => new CargoSize(-1);

            Assert.Throws<ArgumentOutOfRangeException>(creatingANegativeCargoSize);
        }
    }
}
