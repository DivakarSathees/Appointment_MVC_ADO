using NUnit.Framework;
using dotnetapp.Controllers;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using Moq;
using System.Data;
using System.Data.SqlClient;


namespace AppointmentControllerTests
{
    [TestFixture]
    public class AppointmentControllerTests
    {
        private AppointmentController _controller;
        private Type controllerType;
        private Type carserviceType;
        private PropertyInfo[] properties;

        [SetUp]
        public void Setup()
        {
            // Initialize the controller before each test
            _controller = new AppointmentController();
            carserviceType = typeof(dotnetapp.Models.Appointment);
            properties = carserviceType.GetProperties();
            controllerType = typeof(AppointmentController);
        }

        [Test]
        public void Index_ReturnsViewResultWithAppointments()
        {
            // Arrange

            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsAssignableFrom(typeof(List<Appointment>), result.Model);
        }

        [Test]
        public void Create_ReturnsViewResult()
        {
            // Arrange

            // Act
            var result = _controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
        }
        

[Test]
public void Delete_NonExistingId_ReturnsNotFoundResult()
{
    // Arrange
    int nonExistingId = 100; // Assuming there is no Appointment item with ID 100

    // Act
    var result = _controller.Delete(nonExistingId) as NotFoundResult;

    // Assert
    Assert.IsNotNull(result);
    Assert.IsInstanceOf<NotFoundResult>(result);
}

[Test]
public void Delete_InvalidId_ReturnsBadRequestResult()
{
    // Arrange
    int invalidId = -1; // Assuming -1 is an invalid ID

    // Act
    var result = _controller.Delete(invalidId) as BadRequestResult;

    // Assert
    Assert.IsNotNull(result);
    Assert.IsInstanceOf<BadRequestResult>(result);
}

[Test]
public void TestIndexMethodExists()
{
    // Arrange
    var controllerType = typeof(AppointmentController);
    var methodName = "Index";

    // Act
    var indexMethod = controllerType.GetMethod(methodName);

    // Assert
    Assert.IsNotNull(indexMethod, $"{methodName} method should exist in AppointmentController.");
}

[Test]
        public void TestCreateGetMethodExists()
        {
            // Arrange
            MethodInfo createGetMethod = controllerType.GetMethod("Create", new Type[0]);

            // Assert
            Assert.IsNotNull(createGetMethod, "Create method should exist in AppointmentController.");
        }

        [Test]
        public void TestCreatePostMethodExists()
        {
            // Arrange
            MethodInfo createPostMethod = controllerType.GetMethod("Create", new Type[] { typeof(Appointment) });

            // Assert
            Assert.IsNotNull(createPostMethod, "Create POST method should exist in AppointmentController.");
        }

        [Test]
        public void TestDeleteMethodExists()
        {
            // Arrange
            MethodInfo createPostMethod = controllerType.GetMethod("Delete", new Type[] { typeof(int) });

            // Assert
            Assert.IsNotNull(createPostMethod, "Delete method should exist in AppointmentController.");
        }

        [Test]
        public void TestAppointmentClassExists()
        {
            // Arrange
            Type furnitureType = typeof(dotnetapp.Models.Appointment);

            // Assert
            Assert.IsNotNull(furnitureType, "Appointment class should exist.");            
        }

        [Test]
        public void TestAppointmentPropertiesExist()
        {
            // Assert
            Assert.IsNotNull(properties, "Appointment class should have properties.");
            Assert.IsTrue(properties.Length > 0, "Appointment class should have at least one property.");
        }

        [Test]
        public void TestidProperty()
        {
            // Arrange
            PropertyInfo idProperty = properties.FirstOrDefault(p => p.Name == "Appointmentid");

            // Assert
            Assert.IsNotNull(idProperty, "Appointmentid property should exist.");
            Assert.AreEqual(typeof(int), idProperty.PropertyType, "Appointmentid property should have data type 'int'.");
        }

        [Test]
        public void TestPatientnameProperty()
        {
            // Arrange
            PropertyInfo productProperty = properties.FirstOrDefault(p => p.Name == "Patientname");

            // Assert
            Assert.IsNotNull(productProperty, "Patientname property should exist.");
            Assert.AreEqual(typeof(string), productProperty.PropertyType, "Patientname property should have data type 'string'.");
        }

        [Test]
        public void TestAppointmentDateProperty()
        {
            // Arrange
            PropertyInfo productProperty = properties.FirstOrDefault(p => p.Name == "AppointmentDate");

            // Assert
            Assert.IsNotNull(productProperty, "AppointmentDate property should exist.");
            Assert.AreEqual(typeof(DateTime?), productProperty.PropertyType, "AppointmentDate property should have data type 'string'.");
        }

        [Test]
        public void TestEndTimeProperty()
        {
            // Arrange
            PropertyInfo productProperty = properties.FirstOrDefault(p => p.Name == "EndTime");

            // Assert
            Assert.IsNotNull(productProperty, "EndTime property should exist.");
            Assert.AreEqual(typeof(TimeSpan?), productProperty.PropertyType, "EndTime property should have data type 'string'.");
        }

        [Test]
        public void TestAppointmentDbContext_ClassExists_in_Models()
        {
            // Load the assembly at runtime
            Assembly assembly = Assembly.Load("dotnetapp");
            Type postType = assembly.GetType("dotnetapp.Models.AppointmentDbContext");
            Assert.NotNull(postType, "AppointmentDbContext class does not exist.");
        }

        [Test]
        public void Test_CreateViewFile_Exists()
        {
            string indexPath = Path.Combine(@"/home/coder/project/workspace/Appointment-MVC-ADO/Views/Appointment", "Create.cshtml");
            bool indexViewExists = File.Exists(indexPath);

            Assert.IsTrue(indexViewExists, "Create.cshtml view file does not exist.");
        }

        [Test]
        public void Test_IndexViewFile_Exists()
        {
            string indexPath = Path.Combine(@"/home/coder/project/workspace/Appointment-MVC-ADO/Views/Appointment", "Index.cshtml");
            bool indexViewExists = File.Exists(indexPath);

            Assert.IsTrue(indexViewExists, "Index.cshtml view file does not exist.");
        }

    }
}
