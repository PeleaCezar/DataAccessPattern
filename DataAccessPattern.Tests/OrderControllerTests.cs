using DataAccessPatern.Controllers;
using DataAccessPatern.Models;
using DataAccessPattern.Domain.Models;
using DataAccessPattern.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace DataAccessPattern.Tests
{
    [TestClass]
    public class OrderControllerTests
    {
        [TestMethod]
        public void CanCreateOrderWithCorrectModel()
        {
            var unitOfWork = new Mock<IUnitOfWork>();

            var orderController = new OrderController(
                unitOfWork.Object
                );

            var createOrderModel = new CreateOrderModel
            {
                Customer = new CustomerModel
                {
                    Name = "Cezar Pelea",
                    ShippingAddress = "Test address",
                    City = "Craiova",
                    PostalCode = "200667",
                    Country = "Romania"
                },
                LineItems = new[]
                {
                 new LineItemModel {ProductId = Guid.NewGuid(), Quantity = 2 },
                 new LineItemModel {ProductId = Guid.NewGuid(), Quantity = 12 }
                }    
            };

            orderController.Create(createOrderModel);

            unitOfWork.Verify(repository => repository.OrderRepository.Add(It.IsAny<Order>()), Times.AtMostOnce());
        }
    }
}
