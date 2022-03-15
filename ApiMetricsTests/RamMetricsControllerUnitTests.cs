using ApiMetrics.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace ApiMetricsTests
{
    /// <summary>
    /// Тестироание получения метрик ram
    /// </summary>
    public class RamMetricsControllerUnitTests
    {
        private RamMetricsController controller;

        public RamMetricsControllerUnitTests()
        {
            controller = new RamMetricsController();
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            //Act
            var result = controller.GetMetricsFromAgent();

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
