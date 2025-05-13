using Xunit;
using Moq;
using AutoMapper;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Proyecto1.Application.DTOs;
using Proyecto1.Application.Features.Libros.Commands;
using Proyecto1.Application.Features.Libros.Handlers;
using Proyecto1.Domain.Entities;
using Proyecto1.Domain.Interfaces;

namespace Proyecto1.Tests.Application.Features.Libros
{
    public class CreateLibroCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldCreateLibroSuccessfully()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();

            var libroDto = new LibroDto
            {
                Titulo = "Clean Architecture",
                Anio = 2023,
                AutorId = 1
            };

            var command = new CreateLibroCommand(libroDto);

            var libro = new Libro
            {
                Titulo = libroDto.Titulo,
                Anio = libroDto.Anio,
                AutorId = libroDto.AutorId
            };

            unitOfWorkMock.Setup(u => u.Libros.AddAsync(It.IsAny<Libro>())).Returns(Task.CompletedTask);
            unitOfWorkMock.Setup(u => u.SaveChangesAsync()).ReturnsAsync(1);
            mapperMock.Setup(m => m.Map<Libro>(libroDto)).Returns(libro);
            mapperMock.Setup(m => m.Map<LibroDto>(libro)).Returns(libroDto);

            var handler = new CreateLibroCommandHandler(unitOfWorkMock.Object, mapperMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Titulo.Should().Be("Clean Architecture");
            result.Anio.Should().Be(2023);
            unitOfWorkMock.Verify(u => u.Libros.AddAsync(It.IsAny<Libro>()), Times.Once);
            unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once);
        }
    }
}
