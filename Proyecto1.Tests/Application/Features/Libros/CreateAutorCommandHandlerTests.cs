using Xunit;
using Moq;
using AutoMapper;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Proyecto1.Application.DTOs;
using Proyecto1.Application.Features.Autores.Commands;
using Proyecto1.Application.Features.Autores.Handlers;
using Proyecto1.Domain.Entities;
using Proyecto1.Domain.Interfaces;

namespace Proyecto1.Tests.Application.Features.Autores
{
    public class CreateAutorCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldCreateAutorSuccessfully()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();

            var autorDto = new AutorDto
            {
                NombreCompleto = "Gabriel García Márquez"
            };

            var command = new CreateAutorCommand(autorDto);

            var autor = new Autor
            {
                NombreCompleto = autorDto.NombreCompleto
            };

            unitOfWorkMock.Setup(u => u.Autores.AddAsync(It.IsAny<Autor>())).Returns(Task.CompletedTask);
            unitOfWorkMock.Setup(u => u.SaveChangesAsync()).ReturnsAsync(1);
            mapperMock.Setup(m => m.Map<Autor>(autorDto)).Returns(autor);
            mapperMock.Setup(m => m.Map<AutorDto>(autor)).Returns(autorDto);

            var handler = new CreateAutorCommandHandler(unitOfWorkMock.Object, mapperMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.NombreCompleto.Should().Be("Gabriel García Márquez");
            unitOfWorkMock.Verify(u => u.Autores.AddAsync(It.IsAny<Autor>()), Times.Once);
            unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once);
        }
    }
}
