using AutoMapper;
using MediatR;
using Proyecto1.Application.DTOs;
using Proyecto1.Application.Features.Libros.Commands;
using Proyecto1.Domain.Entities;
using Proyecto1.Domain.Interfaces;

namespace Proyecto1.Application.Features.Libros.Handlers
{
    public class CreateLibroCommandHandler : IRequestHandler<CreateLibroCommand, LibroDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateLibroCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<LibroDto> Handle(CreateLibroCommand request, CancellationToken cancellationToken)
        {
            // Verificar si el autor existe
            var autor = await _unitOfWork.Autores.GetByIdAsync(request.Libro.AutorId);
            if (autor == null)
                throw new KeyNotFoundException($"Autor con Id {request.Libro.AutorId} no encontrado.");

            // Verificar cuántos libros ya tiene ese autor
            var cantidadLibros = await _unitOfWork.Libros.CountAsync(l => l.AutorId == request.Libro.AutorId);
            if (cantidadLibros >= 10)
                throw new InvalidOperationException("Este autor ya tiene el número máximo de libros permitidos (10).");

            // Mapear y guardar el libro
            var libroEntity = _mapper.Map<Libro>(request.Libro);
            await _unitOfWork.Libros.AddAsync(libroEntity);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<LibroDto>(libroEntity);
        }
    }
}
