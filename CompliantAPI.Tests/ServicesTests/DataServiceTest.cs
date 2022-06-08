using CompliantAPI.Abstractions.IServices;
using CompliantAPI.Utilities.Clients;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompliantAPI.Tests.ServicesTests
{
    public class DataServiceTest
    {
        private readonly Mock<Swapi> _swapiMock;
        private readonly Mock<ChuckNorris> _chuckNorrisMock;
        public DataServiceTest()
        {
            _swapiMock = new Mock<Swapi>(MockBehavior.Default);
            _chuckNorrisMock = new Mock<ChuckNorris>(MockBehavior.Default);
        }

    }
}
