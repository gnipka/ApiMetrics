using ApiMetrics.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace ApiMetricsTests
{
    /// <summary>
    /// Тестирование получения метрик CPU
    /// </summary>
    public class CpuMetricsControllerUnitTests
    {
        private CpuMetricsController controller;

        public CpuMetricsControllerUnitTests()
        {
            controller = new CpuMetricsController();
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            //Arrange
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);

            //Act
            var result = controller.GetMetricsFromAgent(fromTime, toTime);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsFromAgentWithPercentile_ReturnsOk()
        {
            //Arrange
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);

            //Act
            var result = controller.GetMetricsFromAgent(fromTime, toTime, 30);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }

}