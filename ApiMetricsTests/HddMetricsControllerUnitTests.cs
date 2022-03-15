using ApiMetrics.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace ApiMetricsTests
{
    /// <summary>
    /// Тестироание получения метрик hdd
    /// </summary>
    public class HddMetricsControllerUnitTests
    {
        private HddMetricsController controller;

        public HddMetricsControllerUnitTests()
        {
            controller = new HddMetricsController();
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
